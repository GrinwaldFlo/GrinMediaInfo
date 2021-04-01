using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrinMediaInfo
{
	class clParam
	{
		private string p_path = "";
		internal string path
		{
			get
			{ return p_path; }
			set
			{
				p_path = value;
				pathLength = value.Length;
			}
		}
		internal int pathLength;

		private string p_extension = "";
		internal string extension
		{
			get
			{ return p_extension; }
			set
			{
				p_extension = value;
				extensionArr = p_extension.Split(new char[] { ' ' });

				for (int i = 0; i < extensionArr.Length; i++)
				{
					extensionArr[i] = "." + extensionArr[i];
				}
			}
		}

		internal string[] extensionArr;

		public string BackupPath { get; set; }
	}
}
