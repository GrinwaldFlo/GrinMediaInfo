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
			this.data = new System.Windows.Forms.DataGridView();
			this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colBitrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cMenuData = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToWithStructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.encodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.butStart = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.butFindFolder = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.txtExtension = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.backWorkFindFiles = new System.ComponentModel.BackgroundWorker();
			this.timAff = new System.Windows.Forms.Timer(this.components);
			this.folderBrowserSelectPath = new System.Windows.Forms.FolderBrowserDialog();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.rtbLog = new System.Windows.Forms.RichTextBox();
			this.backWorkEncode = new System.ComponentModel.BackgroundWorker();
			this.txtBackFolder = new System.Windows.Forms.TextBox();
			this.lblExpfold = new System.Windows.Forms.Label();
			this.lblScanStatus = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
			this.cMenuData.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// backWorkGetData
			// 
			this.backWorkGetData.WorkerReportsProgress = true;
			this.backWorkGetData.WorkerSupportsCancellation = true;
			this.backWorkGetData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkGetData_DoWork);
			this.backWorkGetData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backWorkGetData_ProgressChanged);
			// 
			// data
			// 
			this.data.AllowUserToAddRows = false;
			this.data.AllowUserToDeleteRows = false;
			this.data.AllowUserToResizeRows = false;
			this.data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPath,
            this.colBitrate,
            this.colDuration,
            this.colFileSize,
            this.colInfo,
            this.colEncode});
			this.data.ContextMenuStrip = this.cMenuData;
			this.data.Dock = System.Windows.Forms.DockStyle.Fill;
			this.data.Location = new System.Drawing.Point(0, 0);
			this.data.Name = "data";
			this.data.ReadOnly = true;
			this.data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.data.ShowEditingIcon = false;
			this.data.Size = new System.Drawing.Size(1147, 417);
			this.data.TabIndex = 0;
			// 
			// colPath
			// 
			this.colPath.HeaderText = "Path";
			this.colPath.Name = "colPath";
			this.colPath.ReadOnly = true;
			this.colPath.Width = 54;
			// 
			// colBitrate
			// 
			this.colBitrate.HeaderText = "Bitrate";
			this.colBitrate.Name = "colBitrate";
			this.colBitrate.ReadOnly = true;
			this.colBitrate.Width = 62;
			// 
			// colDuration
			// 
			this.colDuration.HeaderText = "Duration";
			this.colDuration.Name = "colDuration";
			this.colDuration.ReadOnly = true;
			this.colDuration.Width = 72;
			// 
			// colFileSize
			// 
			this.colFileSize.HeaderText = "File size";
			this.colFileSize.Name = "colFileSize";
			this.colFileSize.ReadOnly = true;
			this.colFileSize.Width = 69;
			// 
			// colInfo
			// 
			this.colInfo.HeaderText = "Info";
			this.colInfo.Name = "colInfo";
			this.colInfo.ReadOnly = true;
			this.colInfo.Width = 50;
			// 
			// colEncode
			// 
			this.colEncode.HeaderText = "Encoding";
			this.colEncode.Name = "colEncode";
			this.colEncode.ReadOnly = true;
			this.colEncode.Width = 77;
			// 
			// cMenuData
			// 
			this.cMenuData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.moveToToolStripMenuItem,
            this.moveToWithStructureToolStripMenuItem,
            this.encodeToolStripMenuItem});
			this.cMenuData.Name = "cMenuData";
			this.cMenuData.Size = new System.Drawing.Size(204, 92);
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
            this.lblScanStatus,
            this.lblInfo,
            this.progressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 625);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1171, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = false;
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(150, 17);
			this.lblInfo.Text = "00000/00000";
			// 
			// progressBar
			// 
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(300, 16);
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
			// backWorkFindFiles
			// 
			this.backWorkFindFiles.WorkerReportsProgress = true;
			this.backWorkFindFiles.WorkerSupportsCancellation = true;
			this.backWorkFindFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkFindFiles_DoWork);
			this.backWorkFindFiles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backWorkFindFiles_ProgressChanged);
			// 
			// timAff
			// 
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
			this.splitContainer1.Panel2.Controls.Add(this.rtbLog);
			this.splitContainer1.Size = new System.Drawing.Size(1147, 528);
			this.splitContainer1.SplitterDistance = 417;
			this.splitContainer1.TabIndex = 8;
			// 
			// rtbLog
			// 
			this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbLog.Location = new System.Drawing.Point(0, 0);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.Size = new System.Drawing.Size(1147, 107);
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
			// txtBackFolder
			// 
			this.txtBackFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBackFolder.Location = new System.Drawing.Point(73, 68);
			this.txtBackFolder.Name = "txtBackFolder";
			this.txtBackFolder.Size = new System.Drawing.Size(927, 20);
			this.txtBackFolder.TabIndex = 10;
			this.toolTip1.SetToolTip(this.txtBackFolder, "All extiension to check, separated by a space");
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
			// lblScanStatus
			// 
			this.lblScanStatus.Name = "lblScanStatus";
			this.lblScanStatus.Size = new System.Drawing.Size(75, 17);
			this.lblScanStatus.Text = "Scan status...";
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
			((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
			this.cMenuData.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backWorkGetData;
		private System.Windows.Forms.DataGridView data;
		private System.Windows.Forms.Button butStart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button butFindFolder;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblInfo;
		private System.Windows.Forms.ToolStripProgressBar progressBar;
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
		private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
		private System.Windows.Forms.DataGridViewTextBoxColumn colBitrate;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFileSize;
		private System.Windows.Forms.DataGridViewTextBoxColumn colInfo;
		private System.Windows.Forms.ToolStripMenuItem encodeToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn colEncode;
		private System.ComponentModel.BackgroundWorker backWorkEncode;
		private System.Windows.Forms.TextBox txtBackFolder;
		private System.Windows.Forms.Label lblExpfold;
		private System.Windows.Forms.ToolStripStatusLabel lblScanStatus;
	}
}

