using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using grinlib.CommonTools;
using NReco.VideoConverter;

namespace GrinMediaInfo
{
	public enum EnEncoding
	{
		None,
		NeedInfo,
		HasInfo,
		Pending,
		Processing,
		Encoded,
		Error
	}
	public class clData : IEditableObject
	{
		static internal clParam param;

		public string Path
		{
			get
			{
				if (fileInfo != null)
					return fileInfo.FullName.Substring(param.pathLength);
				return "";
			}
		}
		public double Bitrate { get; private set; }
		public string Duration { get; private set; }

		public int SizeMb { get; private set; }

		public string Format { get; private set; }

		public EnEncoding Status { get; private set; }

		internal string pathBackup 
		{
			get
			{
				if (!string.IsNullOrEmpty(param.BackupPath))
				{
					return param.BackupPath + fileInfo.FullName.Replace(":", "_") ;
				}
				else
				{
					return fileInfo.DirectoryName + "\\_OldFile_" + fileInfo.Name;
				}
			}
		}
		
		internal double durationMs;
		internal long SizeByte;

		internal System.IO.FileInfo fileInfo;
		internal BindingData Parent;

		public clData(System.IO.FileInfo fileInfo)
		{
			this.fileInfo = fileInfo;
			Status = EnEncoding.NeedInfo;
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

				durationMs = videoInfo.Duration.TotalMilliseconds;
				Duration = string.Format("{0}:{1}:{2}", videoInfo.Duration.Hours, videoInfo.Duration.Minutes, videoInfo.Duration.Seconds);
				if (Duration.StartsWith("0:"))
					Duration = Duration.Substring(2);
				SizeByte = fileInfo.Length;
				SizeMb = (int)(fileInfo.Length / (1024 * 1024.0));
				Bitrate = Math.Round((SizeByte / 1024.0) / (durationMs / 1000.0));

				string formatVideo = "";
				string formatAudio = "";
				for (int i = 0; i < videoInfo.Streams.Length; i++)
				{
					if (videoInfo.Streams[i].CodecType == "video")
						formatVideo += videoInfo.Streams[i].CodecName + " ";
					else
						formatAudio += videoInfo.Streams[i].CodecName + " ";
				}
				Format = formatVideo + formatAudio.Trim();

				Status = EnEncoding.HasInfo;

				//GenFunc.LogAddInfo(this,"updateInfo", "Time: " + Math.Round((DateTime.Now - start).TotalMilliseconds) + " [ms]");
				return true;
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
				Status = EnEncoding.Error;
			}
			return false;
		}

		public void BeginEdit()
		{

		}

		public void EndEdit()
		{

		}

		public void CancelEdit()
		{

		}

		internal void EncodeVideo()
		{
			Status = EnEncoding.Processing;
			frmMain.isDirty = true;
			string originalPath = fileInfo.FullName;
			string newName = fileInfo.FullName.Replace(fileInfo.Extension, ".mp4");

			System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(pathBackup));
			fileInfo.MoveTo(pathBackup);
			fileInfo = new System.IO.FileInfo(newName);
			try
			{
				var ffMpeg = new FFMpegConverter();
				ConvertSettings c = new ConvertSettings();
				//c.VideoCodec = "libx264";
				//c.CustomOutputArgs = "-crf 23";
				//ffMpeg.ConvertMedia(cur.fileInfo.FullName, null, newName + "23", "MP4", c);

				//c.CustomOutputArgs = "-crf 1";
				//ffMpeg.ConvertMedia(cur.fileInfo.FullName, null, newName + "1", "MP4", c);

				c.VideoCodec = "libx265";
				c.CustomOutputArgs = "-crf 28";
				EncodingLog = new StringBuilder();
				ffMpeg.FFMpegProcessPriority = System.Diagnostics.ProcessPriorityClass.BelowNormal;
				ffMpeg.LogReceived += FfMpeg_LogReceived;
				ffMpeg.ConvertMedia(fileInfo.FullName, null, newName, "MP4", c);
				string s = EncodingLog.ToString();
				
				updateInfo();
				Status = EnEncoding.Encoded;
			}
			catch (Exception ex)
			{
				GenFunc.LogAdd(ex);
				FileFunc.TryDelete(newName);
				fileInfo = new System.IO.FileInfo(pathBackup);
				fileInfo.MoveTo(originalPath);
				updateInfo();
				Status = EnEncoding.Error;
			}

			frmMain.isDirty = true;
		}

		internal StringBuilder EncodingLog { get; private set; }


		private void FfMpeg_LogReceived(object sender, FFMpegLogEventArgs e)
		{
			EncodingLog.AppendLine(e.Data);
		}

		internal void AskEncoding()
		{
			Status = EnEncoding.Pending;
			frmMain.isDirty = true;
		}


	}
}
