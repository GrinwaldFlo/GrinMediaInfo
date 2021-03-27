using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using grinlib.CommonTools;

namespace GrinMediaInfo
{
	enum EnEncoding
	{
		None,
		Pending,
		Processing,
		Done
	}
	class clData
	{
		static internal clparam param;

		internal double bitrate;
		internal double duration;
		internal string durationStr;
		internal long fileSize;
		internal string format;
		internal EnEncoding Encoding = EnEncoding.None;

		internal System.IO.FileInfo fileInfo;
		internal DataGridViewRow row;

		public clData(System.IO.FileInfo fileInfo)
		{
			this.fileInfo = fileInfo;
		}

		internal bool updateInfo()
		{
			try
			{
				if (fileInfo == null || fileInfo.Exists == false || fileInfo.DirectoryName.Contains(@":\$RECYCLE.BIN\"))
					return false;

				DateTime start = DateTime.Now;
				var ffProbe = new NReco.VideoInfo.FFProbe();
				var videoInfo = ffProbe.GetMediaInfo(fileInfo.FullName);

				duration = videoInfo.Duration.TotalMilliseconds;
				fileSize = fileInfo.Length;
				bitrate = (fileSize/1024.0) / (duration/1000.0);
				durationStr = string.Format("{0}:{1}:{2}", videoInfo.Duration.Hours, videoInfo.Duration.Minutes, videoInfo.Duration.Seconds) ;

				for (int i = 0; i < videoInfo.Streams.Length; i++)
				{
					format += videoInfo.Streams[i].CodecLongName + " ";
				}

				GenFunc.LogAddInfo(this,"updateInfo", "Time: " + Math.Round((DateTime.Now - start).TotalMilliseconds) + " [ms]");
				return true;
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}
			return false;
		}

		internal DataGridViewRow getRow()
		{
			try
			{
				row = new DataGridViewRow();
				row.Cells.Add(getCell(fileInfo.FullName.Substring(param.pathLength)));
				row.Cells.Add(getCell(Math.Round(bitrate)));
				row.Cells.Add(getCell(durationStr));
				row.Cells.Add(getCell(Math.Round(fileSize / (1024*1024.0))));
				row.Cells.Add(getCell(format));
				row.Cells.Add(getCell(""));

				row.Tag = this;
				return row;
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}
			return null;
		}

		private DataGridViewCell getCell(object val)
		{
			try
			{
				DataGridViewTextBoxCell newCell = new DataGridViewTextBoxCell();
				newCell.Value = val;
				return newCell;
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}
			return null;
		}

		internal void refreshRow()
		{
			try
			{
				int i = 0;
				row.Cells[i++].Value = fileInfo.FullName.Substring(param.pathLength);
				row.Cells[i++].Value = Math.Round(bitrate);
				row.Cells[i++].Value = durationStr;
				row.Cells[i++].Value = Math.Round(fileSize / 1048576.0);
				row.Cells[i++].Value = format;
				row.Cells[i++].Value = Encoding.ToString();
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
			}

		}
	}
}
