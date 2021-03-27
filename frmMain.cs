using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GrinMediaInfo.Properties;
using System.Diagnostics;
using grinlib.CommonTools;
using NReco.VideoInfo;
using NReco.VideoConverter;

namespace GrinMediaInfo
{
	public partial class frmMain : Form
	{
		//List<clData> lstData = new List<clData>();
		List<clData> lstToGetMediaInfo = new List<clData>();
		List<clData> lstToRefresh = new List<clData>();
		List<clData> lstToDataToAdd = new List<clData>();
		bool isClosing = false;

		public frmMain()
		{
			InitializeComponent();

			txtPath.Text = Settings.Default.path;
			txtExtension.Text = Settings.Default.extension;
			txtBackFolder.Text = Settings.Default.pathBackup;

			backWorkEncode.RunWorkerAsync();
			backWorkGetData.RunWorkerAsync();
		}

		private void butStart_Click(object sender, EventArgs e)
		{
			try
			{
				if (!txtPath.Text.EndsWith("\\"))
				{
					txtPath.Text += "\\";
				}

				if (butStart.Text == "Start")
				{
					data.Rows.Clear();
					
					clparam p = new clparam();
					p.path = txtPath.Text;
					p.extension = txtExtension.Text;
					clData.param = p;

					backWorkFindFiles.RunWorkerAsync(p);

					timAff.Enabled = true;

					butStart.Text = "Cancel";
				}
				else
				{
					backWorkFindFiles.CancelAsync();
				}
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}
		}

		private void backWorkGetData_DoWork(object sender, DoWorkEventArgs e)
		{
			bool hadData = false;
			while (!isClosing)
			{
				try
				{
					if (lstToGetMediaInfo.Count > 0)
					{
						clData cur = lstToGetMediaInfo[0];
						lstToGetMediaInfo.RemoveAt(0);
						cur.updateInfo();

						lstToRefresh.Add(cur);
						hadData = true;
					}
					else
					{
						if (hadData)
						{
							backWorkGetData.ReportProgress(1);
							hadData = false;
						}

						System.Threading.Thread.Sleep(500);
					}
				}
				catch (Exception ex)
				{
					GenFunc.LogAdd(ex);
				}
				
			}
		}

		private void backWorkFindFiles_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				clparam p = (clparam)e.Argument;
				DirectoryInfo curDir = new DirectoryInfo(p.path);
				if (!curDir.Exists)
				{
					backWorkFindFiles.ReportProgress(0, "Folder doen't exists");
					return;
				}

				getFilesInDir(p, curDir);
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}
		}

		int cntDirectory = 0;
		private void getFilesInDir(clparam p, DirectoryInfo curDir)
		{
			try
			{
				FileInfo[] files = curDir.GetFiles();
				List<clData> result = new List<clData>();
				for (int i = 0; i < files.Length; i++)
				{
					if (isGoodExtension(p, files[i]))
					{
						result.Add(new clData(files[i]));
					}
				}

				backWorkFindFiles.ReportProgress(0, result);
				if(cntDirectory++ > 50)
				{
					cntDirectory = 0;
					backWorkFindFiles.ReportProgress(1, curDir.FullName.Substring(p.pathLength));
				}

				DirectoryInfo[] childDirectories = curDir.GetDirectories();
				for (int i = 0; i < childDirectories.Length; i++)
				{
					getFilesInDir(p, childDirectories[i]);
				}
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}

		}

		private bool isGoodExtension(clparam p, FileInfo fileInfo)
		{
			try
			{
				for (int i = 0; i < p.extensionArr.Length; i++)
				{
					if (fileInfo.Extension == p.extensionArr[i])
						return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
				return false;
			}
		}

		private void backWorkFindFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			try
			{
				switch (e.ProgressPercentage)
				{
					case 0:
						if (e.UserState.GetType().Name == "String")
						{
							MessageBox.Show(e.UserState.ToString());
							return;
						}

						lstToDataToAdd.AddRange((List<clData>)e.UserState);
						break;
					case 1:
						lblScanStatus.Text = "Scanning: " + e.UserState.ToString();
						break;
					default:
						break;
				}


			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}

		}

		private void timAff_Tick(object sender, EventArgs e)
		{
			try
			{
				while (lstToDataToAdd.Count > 0)
				{
					clData curItem = lstToDataToAdd[0];
					lstToDataToAdd.RemoveAt(0);


					DataGridViewRow newRow = curItem.getRow();
					data.Rows.Add(newRow);
					lstToGetMediaInfo.Add(curItem);
				}

				while (lstToRefresh.Count > 0)
				{
					lstToRefresh[0].refreshRow();
					lstToRefresh.RemoveAt(0);
				}

				lblInfo.Text = (data.Rows.Count - lstToGetMediaInfo.Count) + " / " + data.Rows.Count;
				progressBar.Maximum = data.Rows.Count;
				progressBar.Value = Math.Max(data.Rows.Count - lstToGetMediaInfo.Count, 0);
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}

			try
			{
				while (GenFunc.log.Count > 0)
				{
					rtbLog.AppendText(GenFunc.log[0]);
					GenFunc.log.RemoveAt(0);
				}
			}
			catch (Exception)
			{
			}
		}


		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			isClosing = true;
			Settings.Default.path = txtPath.Text;
			Settings.Default.extension = txtExtension.Text;

			Settings.Default.Save();
		}



		private void butFindFolder_Click(object sender, EventArgs e)
		{
			folderBrowserSelectPath.SelectedPath = txtPath.Text;
			if (folderBrowserSelectPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtPath.Text = folderBrowserSelectPath.SelectedPath;
			}
		}

		private void txtPath_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (Directory.Exists(txtPath.Text))
				{
					txtPath.BackColor = Color.LightGreen;
					butStart.Enabled = true;
				}
				else
				{
					txtPath.BackColor = Color.Pink;
					butStart.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
				txtPath.BackColor = Color.Pink;
				butStart.Enabled = false;
			}
		}

		private void playToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < data.SelectedRows.Count; i++)
				{
					clData cur = (clData)data.SelectedRows[i].Tag;

					Process.Start(cur.fileInfo.FullName);
				}
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}

		}

		private void moveToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog dlg = new FolderBrowserDialog();
				dlg.SelectedPath = txtPath.Text;
				dlg.ShowNewFolderButton = true;
				if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					for (int i = 0; i < data.SelectedRows.Count; i++)
					{
						clData cur = (clData)data.SelectedRows[i].Tag;
						cur.fileInfo.MoveTo(dlg.SelectedPath + "\\" + cur.fileInfo.Name);
					}
				}
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}

		}

		private void moveToWithStructureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog dlg = new FolderBrowserDialog();
				dlg.SelectedPath = txtPath.Text;
				dlg.ShowNewFolderButton = true;
				if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					for (int i = 0; i < data.SelectedRows.Count; i++)
					{
						try
						{
							clData cur = (clData)data.SelectedRows[i].Tag;
							string movePath = dlg.SelectedPath + "\\" + cur.fileInfo.FullName.Substring(txtPath.Text.Length);
							Directory.CreateDirectory(FileFunc.GetDirOfFullName(movePath));
							cur.fileInfo.MoveTo(movePath);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
				}
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}
		}

		private void encodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < data.SelectedRows.Count; i++)
				{
					clData cur = (clData)data.SelectedRows[i].Tag;
					cur.Encoding = EnEncoding.Pending;
					cur.refreshRow();
				}
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}




		}

		private void backWorkEncode_DoWork(object sender, DoWorkEventArgs e)
		{
			while (!isClosing)
			{
				try
				{
					for (int i = 0; i < data.Rows.Count; i++)
					{
						clData cur = (clData)data.Rows[i].Tag;
						if (cur.Encoding == EnEncoding.Pending)
						{
							cur.Encoding = EnEncoding.Processing;
							backWorkEncode.ReportProgress(0, cur);
							string newName = cur.fileInfo.FullName;
							cur.fileInfo.MoveTo(cur.fileInfo.DirectoryName + "\\_OldFile_" + cur.fileInfo.Name);

							var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
							ConvertSettings c = new ConvertSettings();
							//c.VideoCodec = "libx264";
							//c.CustomOutputArgs = "-crf 23";
							//ffMpeg.ConvertMedia(cur.fileInfo.FullName, null, newName + "23", "MP4", c);

							//c.CustomOutputArgs = "-crf 1";
							//ffMpeg.ConvertMedia(cur.fileInfo.FullName, null, newName + "1", "MP4", c);

							c.VideoCodec = "libx265";
							c.CustomOutputArgs = "-crf 28";
							ffMpeg.ConvertMedia(cur.fileInfo.FullName, null, newName, "MP4", c);
							cur.Encoding = EnEncoding.Done;
							backWorkEncode.ReportProgress(0, cur);
						}
					}
				}
				catch (Exception )
				{
				}
				System.Threading.Thread.Sleep(5000);
			}
		}

		private void backWorkEncode_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			clData cur = (clData)e.UserState;
			cur.refreshRow();
		}

		private void backWorkGetData_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if(!backWorkFindFiles.IsBusy)
				butStart.Text = "Start";
		}
	}
}
