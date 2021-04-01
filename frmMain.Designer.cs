namespace GrinMediaInfo
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.backWorkGetData = new System.ComponentModel.BackgroundWorker();
			this.cMenuData = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToWithStructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.encodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelEncodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.butStart = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.butFindFolder = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblVideoFound = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblGettingInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblTotalVideoSize = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			this.txtExtension = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.txtBackFolder = new System.Windows.Forms.TextBox();
			this.backWorkFindFiles = new System.ComponentModel.BackgroundWorker();
			this.timAff = new System.Windows.Forms.Timer(this.components);
			this.folderBrowserSelectPath = new System.Windows.Forms.FolderBrowserDialog();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.data = new System.Windows.Forms.DataGridView();
			this.lblScanStatus = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rtbLog = new System.Windows.Forms.RichTextBox();
			this.backWorkEncode = new System.ComponentModel.BackgroundWorker();
			this.lblExpfold = new System.Windows.Forms.Label();
			this.playBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restoreBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cMenuData.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
			this.SuspendLayout();
			// 
			// backWorkGetData
			// 
			this.backWorkGetData.WorkerReportsProgress = true;
			this.backWorkGetData.WorkerSupportsCancellation = true;
			this.backWorkGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkGetData_DoWork);
			this.backWorkGetData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backWorkGetData_ProgressChanged);
			// 
			// cMenuData
			// 
			this.cMenuData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.playBackupToolStripMenuItem,
            this.restoreBackupToolStripMenuItem,
            this.moveToToolStripMenuItem,
            this.moveToWithStructureToolStripMenuItem,
            this.encodeToolStripMenuItem,
            this.cancelEncodeToolStripMenuItem,
            this.openFolderToolStripMenuItem});
			this.cMenuData.Name = "cMenuData";
			this.cMenuData.Size = new System.Drawing.Size(204, 202);
			this.cMenuData.Opening += new System.ComponentModel.CancelEventHandler(this.cMenuData_Opening);
			// 
			// playToolStripMenuItem
			// 
			this.playToolStripMenuItem.Name = "playToolStripMenuItem";
			this.playToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.playToolStripMenuItem.Text = "Play";
			this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
			// 
			// moveToToolStripMenuItem
			// 
			this.moveToToolStripMenuItem.Name = "moveToToolStripMenuItem";
			this.moveToToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.moveToToolStripMenuItem.Text = "Move to...";
			this.moveToToolStripMenuItem.Click += new System.EventHandler(this.moveToToolStripMenuItem_Click);
			// 
			// moveToWithStructureToolStripMenuItem
			// 
			this.moveToWithStructureToolStripMenuItem.Name = "moveToWithStructureToolStripMenuItem";
			this.moveToWithStructureToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.moveToWithStructureToolStripMenuItem.Text = "Move to with structure...";
			this.moveToWithStructureToolStripMenuItem.Click += new System.EventHandler(this.moveToWithStructureToolStripMenuItem_Click);
			// 
			// encodeToolStripMenuItem
			// 
			this.encodeToolStripMenuItem.Name = "encodeToolStripMenuItem";
			this.encodeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.encodeToolStripMenuItem.Text = "Encode";
			this.encodeToolStripMenuItem.Click += new System.EventHandler(this.encodeToolStripMenuItem_Click);
			// 
			// cancelEncodeToolStripMenuItem
			// 
			this.cancelEncodeToolStripMenuItem.Name = "cancelEncodeToolStripMenuItem";
			this.cancelEncodeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.cancelEncodeToolStripMenuItem.Text = "Cancel Encode";
			this.cancelEncodeToolStripMenuItem.Click += new System.EventHandler(this.cancelEncodeToolStripMenuItem_Click);
			// 
			// butStart
			// 
			this.butStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butStart.Location = new System.Drawing.Point(1048, 14);
			this.butStart.Name = "butStart";
			this.butStart.Size = new System.Drawing.Size(111, 23);
			this.butStart.TabIndex = 1;
			this.butStart.Text = "Start";
			this.butStart.UseVisualStyleBackColor = true;
			this.butStart.Click += new System.EventHandler(this.butStart_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Folder";
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.Location = new System.Drawing.Point(73, 16);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(927, 20);
			this.txtPath.TabIndex = 3;
			this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
			// 
			// butFindFolder
			// 
			this.butFindFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.butFindFolder.Location = new System.Drawing.Point(1006, 14);
			this.butFindFolder.Name = "butFindFolder";
			this.butFindFolder.Size = new System.Drawing.Size(36, 23);
			this.butFindFolder.TabIndex = 4;
			this.butFindFolder.Text = "...";
			this.butFindFolder.UseVisualStyleBackColor = true;
			this.butFindFolder.Click += new System.EventHandler(this.butFindFolder_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblVideoFound,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel2,
            this.lblGettingInfo,
            this.toolStripStatusLabel3,
            this.lblTotalVideoSize,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5});
			this.statusStrip1.Location = new System.Drawing.Point(0, 625);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1171, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 17);
			this.toolStripStatusLabel1.Text = "Videos found:";
			// 
			// lblVideoFound
			// 
			this.lblVideoFound.AutoSize = false;
			this.lblVideoFound.Name = "lblVideoFound";
			this.lblVideoFound.Size = new System.Drawing.Size(100, 17);
			this.lblVideoFound.Text = "0000000";
			// 
			// toolStripStatusLabel6
			// 
			this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
			this.toolStripStatusLabel6.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel6.Text = "|";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(73, 17);
			this.toolStripStatusLabel2.Text = "Getting info:";
			// 
			// lblGettingInfo
			// 
			this.lblGettingInfo.AutoSize = false;
			this.lblGettingInfo.Name = "lblGettingInfo";
			this.lblGettingInfo.Size = new System.Drawing.Size(100, 17);
			this.lblGettingInfo.Text = "00000/00000";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(57, 17);
			this.toolStripStatusLabel3.Text = "Total size:";
			// 
			// lblTotalVideoSize
			// 
			this.lblTotalVideoSize.Name = "lblTotalVideoSize";
			this.lblTotalVideoSize.Size = new System.Drawing.Size(34, 17);
			this.lblTotalVideoSize.Text = "0 Mb";
			// 
			// toolStripStatusLabel7
			// 
			this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
			this.toolStripStatusLabel7.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel7.Text = "|";
			// 
			// toolStripStatusLabel4
			// 
			this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			this.toolStripStatusLabel4.Size = new System.Drawing.Size(60, 17);
			this.toolStripStatusLabel4.Text = "Encoding:";
			// 
			// toolStripStatusLabel5
			// 
			this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
			this.toolStripStatusLabel5.Size = new System.Drawing.Size(72, 17);
			this.toolStripStatusLabel5.Text = "00000/00000";
			// 
			// txtExtension
			// 
			this.txtExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtExtension.Location = new System.Drawing.Point(73, 42);
			this.txtExtension.Name = "txtExtension";
			this.txtExtension.Size = new System.Drawing.Size(927, 20);
			this.txtExtension.TabIndex = 7;
			this.toolTip1.SetToolTip(this.txtExtension, "All extiension to check, separated by a space");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Ext.";
			// 
			// txtBackFolder
			// 
			this.txtBackFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBackFolder.Location = new System.Drawing.Point(73, 68);
			this.txtBackFolder.Name = "txtBackFolder";
			this.txtBackFolder.Size = new System.Drawing.Size(927, 20);
			this.txtBackFolder.TabIndex = 10;
			this.toolTip1.SetToolTip(this.txtBackFolder, "Backup folder for encoded videos, if empty, keep same directly");
			// 
			// backWorkFindFiles
			// 
			this.backWorkFindFiles.WorkerReportsProgress = true;
			this.backWorkFindFiles.WorkerSupportsCancellation = true;
			this.backWorkFindFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkFindFiles_DoWork);
			this.backWorkFindFiles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backWorkFindFiles_ProgressChanged);
			this.backWorkFindFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkFindFiles_RunWorkerCompleted);
			// 
			// timAff
			// 
			this.timAff.Enabled = true;
			this.timAff.Interval = 1000;
			this.timAff.Tick += new System.EventHandler(this.timAff_Tick);
			// 
			// folderBrowserSelectPath
			// 
			this.folderBrowserSelectPath.ShowNewFolderButton = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 94);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.data);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lblScanStatus);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.rtbLog);
			this.splitContainer1.Size = new System.Drawing.Size(1147, 528);
			this.splitContainer1.SplitterDistance = 417;
			this.splitContainer1.TabIndex = 8;
			// 
			// data
			// 
			this.data.AllowUserToAddRows = false;
			this.data.AllowUserToDeleteRows = false;
			this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.data.ContextMenuStrip = this.cMenuData;
			this.data.Dock = System.Windows.Forms.DockStyle.Fill;
			this.data.Location = new System.Drawing.Point(0, 0);
			this.data.Name = "data";
			this.data.ReadOnly = true;
			this.data.Size = new System.Drawing.Size(1147, 417);
			this.data.TabIndex = 0;
			this.data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_CellClick);
			// 
			// lblScanStatus
			// 
			this.lblScanStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblScanStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblScanStatus.Location = new System.Drawing.Point(96, 80);
			this.lblScanStatus.Name = "lblScanStatus";
			this.lblScanStatus.Size = new System.Drawing.Size(1048, 22);
			this.lblScanStatus.TabIndex = 2;
			this.lblScanStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Searching folder:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rtbLog
			// 
			this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbLog.Location = new System.Drawing.Point(0, 0);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.Size = new System.Drawing.Size(1147, 77);
			this.rtbLog.TabIndex = 0;
			this.rtbLog.Text = "";
			// 
			// backWorkEncode
			// 
			this.backWorkEncode.WorkerReportsProgress = true;
			this.backWorkEncode.WorkerSupportsCancellation = true;
			this.backWorkEncode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkEncode_DoWork);
			this.backWorkEncode.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backWorkEncode_ProgressChanged);
			// 
			// lblExpfold
			// 
			this.lblExpfold.AutoSize = true;
			this.lblExpfold.Location = new System.Drawing.Point(9, 71);
			this.lblExpfold.Name = "lblExpfold";
			this.lblExpfold.Size = new System.Drawing.Size(58, 13);
			this.lblExpfold.TabIndex = 9;
			this.lblExpfold.Text = "Bak. folder";
			// 
			// playBackupToolStripMenuItem
			// 
			this.playBackupToolStripMenuItem.Name = "playBackupToolStripMenuItem";
			this.playBackupToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.playBackupToolStripMenuItem.Text = "Play backup";
			this.playBackupToolStripMenuItem.Click += new System.EventHandler(this.playBackupToolStripMenuItem_Click);
			// 
			// restoreBackupToolStripMenuItem
			// 
			this.restoreBackupToolStripMenuItem.Name = "restoreBackupToolStripMenuItem";
			this.restoreBackupToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.restoreBackupToolStripMenuItem.Text = "Restore backup";
			this.restoreBackupToolStripMenuItem.Click += new System.EventHandler(this.restoreBackupToolStripMenuItem_Click);
			// 
			// openFolderToolStripMenuItem
			// 
			this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
			this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.openFolderToolStripMenuItem.Text = "Open folder";
			this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1171, 647);
			this.Controls.Add(this.txtBackFolder);
			this.Controls.Add(this.lblExpfold);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.txtExtension);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.butFindFolder);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.butStart);
			this.Name = "frmMain";
			this.Text = "GrinMediaInfo";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.cMenuData.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backWorkGetData;
		private System.Windows.Forms.Button butStart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button butFindFolder;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblVideoFound;
		private System.Windows.Forms.TextBox txtExtension;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.BackgroundWorker backWorkFindFiles;
		private System.Windows.Forms.Timer timAff;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserSelectPath;
		private System.Windows.Forms.ContextMenuStrip cMenuData;
		private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveToToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveToWithStructureToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.RichTextBox rtbLog;
		private System.Windows.Forms.ToolStripMenuItem encodeToolStripMenuItem;
		private System.ComponentModel.BackgroundWorker backWorkEncode;
		private System.Windows.Forms.TextBox txtBackFolder;
		private System.Windows.Forms.Label lblExpfold;
		private System.Windows.Forms.DataGridView data;
		private System.Windows.Forms.ToolStripMenuItem cancelEncodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel lblGettingInfo;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
		private System.Windows.Forms.Label lblScanStatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel lblTotalVideoSize;
		private System.Windows.Forms.ToolStripMenuItem playBackupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem restoreBackupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
	}
}

