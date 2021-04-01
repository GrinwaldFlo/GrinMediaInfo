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
using System.Data.Common;

namespace GrinMediaInfo
{
	public partial class frmMain : Form
	{
		BindingData bindingData = new BindingData();
		List<clData> LstGetInfo = new List<clData>();
		BindingSource bindingSource = new BindingSource();

		bool isClosing = false;
		public static bool isDirty = false;
		long VideoTotalSize = 0;

		public frmMain()
		{
			InitializeComponent();

			txtPath.Text = Settings.Default.path;
			txtExtension.Text = Settings.Default.extension;
			txtBackFolder.Text = Settings.Default.pathBackup;

			bindingSource.DataSource = bindingData;
			data.DataSource = bindingSource;

			backWorkEncode.RunWorkerAsync();
			backWorkGetData.RunWorkerAsync();

			foreach (DataGridViewColumn item in data.Columns)
			{
				item.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				item.SortMode = DataGridViewColumnSortMode.Automatic;
			}
		}

		private void butStart_Click(object sender, EventArgs e)
		{
			try
			{
				if (!txtPath.Text.EndsWith("\\"))
				{
					txtPath.Text += "\\";
				}
				if (!txtBackFolder.Text.EndsWith("\\"))
				{
					txtBackFolder.Text += "\\";
				}

				if (butStart.Text == "Start")
				{
					bindingData.Clear();
					VideoTotalSize = 0;

					clParam p = new clParam();
					p.path = txtPath.Text;
					p.extension = txtExtension.Text;
					p.BackupPath = txtBackFolder.Text;
					clData.param = p;

					backWorkFindFiles.RunWorkerAsync(p);
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
					if (LstGetInfo.Count > 0)
					{
						clData cur = LstGetInfo[0];
						LstGetInfo.RemoveAt(0);
						cur.updateInfo();
						isDirty = true;
						hadData = true;
						VideoTotalSize += cur.SizeMb;
						backWorkGetData.ReportProgress(0);
					}
					else
					{
						if (hadData)
						{
							hadData = false;
							backWorkGetData.ReportProgress(0);
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
				clParam p = (clParam)e.Argument;
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
		private void getFilesInDir(clParam p, DirectoryInfo curDir)
		{
			try
			{
				if (backWorkFindFiles.CancellationPending)
					return;

				FileInfo[] files = curDir.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					if (isGoodExtension(p, files[i]))
					{
						backWorkFindFiles.ReportProgress(2, new clData(files[i]));
					}
				}

				if (cntDirectory++ > 50)
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

		private bool isGoodExtension(clParam p, FileInfo fileInfo)
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
						break;
					case 1:
						lblScanStatus.Text = "Scanning: " + e.UserState.ToString();
						break;
					case 2:
						clData item = (clData)e.UserState;
						bindingData.Add(item);
						LstGetInfo.Add(item);
						lblVideoFound.Text = bindingData.Count.ToString();
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
			if (isDirty)
			{
				isDirty = false;
				data.Invalidate();
				data.AutoResizeColumns();
			}
		}


		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			isClosing = true;
			Settings.Default.path = txtPath.Text;
			Settings.Default.extension = txtExtension.Text;
			Settings.Default.pathBackup = txtBackFolder.Text;

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
				for (int i = 0; i < data.SelectedCells.Count; i++)
				{
					clData cur = (clData)data.SelectedCells[i].OwningRow.DataBoundItem;

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
				if (data.SelectedRows.Count == 0)
				{
					if (data.SelectedCells.Count == 1)
					{
						clData cur = (clData)data.SelectedCells[0].OwningRow.DataBoundItem;
						cur.AskEncoding();
					}
				}
				else
				{
					for (int i = 0; i < data.SelectedRows.Count; i++)
					{
						clData cur = (clData)data.SelectedRows[i].DataBoundItem;
						cur.AskEncoding();
					}
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
					for (int i = 0; i < bindingData.Count; i++)
					{
						clData cur = (clData)bindingData[i];
						if (cur.Status == EnEncoding.Pending)
						{
							cur.EncodeVideo();
						}
					}
				}
				catch (Exception)
				{
				}
				System.Threading.Thread.Sleep(5000);
			}
		}

		private void backWorkEncode_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			//clData cur = (clData)e.UserState;
			//cur.refreshRow();
		}

		private void backWorkGetData_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			lblGettingInfo.Text = LstGetInfo.Count.ToString();
			if (VideoTotalSize > 1000)
			{
				lblTotalVideoSize.Text = Math.Round(VideoTotalSize / 1024.0, 2) + " GB";
			}
			else
			{
				lblTotalVideoSize.Text = VideoTotalSize + " MB";
			}
		}

		private void cancelEncodeToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void cMenuData_Opening(object sender, CancelEventArgs e)
		{
			bool SingleSelection = data.SelectedRows.Count == 0 && data.SelectedCells.Count == 1;

			playToolStripMenuItem.Enabled = SingleSelection;
			playBackupToolStripMenuItem.Enabled = SingleSelection && File.Exists(((clData)data.SelectedCells[0].OwningRow.DataBoundItem).pathBackup);
		}

		private void backWorkFindFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			butStart.Text = "Start";
			lblScanStatus.Text = "";
		}

		private void data_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
				return;
			clData cur = (clData)data.Rows[e.RowIndex].DataBoundItem;

			if (cur.EncodingLog != null && cur.EncodingLog.Length > 0)
				rtbLog.Text = cur.EncodingLog.ToString();
		}

		private void playBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < data.SelectedCells.Count; i++)
				{
					clData cur = (clData)data.SelectedCells[i].OwningRow.DataBoundItem;

					Process.Start(cur.pathBackup);
				}
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}
		}

		private void restoreBackupToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private clData GetSelectedItem()
		{
			if(data.SelectedRows == 0 && data.SelectedCells.Count == 1)
		}
	}
}
