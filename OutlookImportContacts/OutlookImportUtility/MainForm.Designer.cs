namespace OutlookImportUtility
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_StartImport = new System.Windows.Forms.Button();
            this.btn_GetOutlookContacts = new System.Windows.Forms.Button();
            this.txbx_DefaultFocus = new System.Windows.Forms.TextBox();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.lstbx_Log = new System.Windows.Forms.ListBox();
            this.btn_ClearLog = new System.Windows.Forms.Button();
            this.lbl_UpdatedContacts = new System.Windows.Forms.Label();
            this.prgbr_Progress = new System.Windows.Forms.ProgressBar();
            this.lbl_UpdatedContactCount = new System.Windows.Forms.Label();
            this.lbl_NotUpdatedContacts = new System.Windows.Forms.Label();
            this.lbl_NotUpdatedContactCount = new System.Windows.Forms.Label();
            this.pnl_ImportInfo = new System.Windows.Forms.Panel();
            this.notifyIcon_Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_Tray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_Progress = new System.Windows.Forms.Panel();
            this.txbx_CrmDomain = new System.Windows.Forms.TextBox();
            this.lbl_CrmDomain = new System.Windows.Forms.Label();
            this.txbx_CrmPass = new System.Windows.Forms.TextBox();
            this.txbx_CrmLogin = new System.Windows.Forms.TextBox();
            this.txbx_CrmUrl = new System.Windows.Forms.TextBox();
            this.lbl_CrmPass = new System.Windows.Forms.Label();
            this.lbl_CrmLogin = new System.Windows.Forms.Label();
            this.lbl_CrmUrl = new System.Windows.Forms.Label();
            this.pnl_ImportInfo.SuspendLayout();
            this.contextMenuStrip_Tray.SuspendLayout();
            this.pnl_Progress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_StartImport
            // 
            this.btn_StartImport.Location = new System.Drawing.Point(163, 121);
            this.btn_StartImport.Name = "btn_StartImport";
            this.btn_StartImport.Size = new System.Drawing.Size(137, 27);
            this.btn_StartImport.TabIndex = 0;
            this.btn_StartImport.Text = "Start Import";
            this.btn_StartImport.UseVisualStyleBackColor = true;
            this.btn_StartImport.Click += new System.EventHandler(this.btn_StartImport_Click);
            // 
            // btn_GetOutlookContacts
            // 
            this.btn_GetOutlookContacts.Location = new System.Drawing.Point(12, 121);
            this.btn_GetOutlookContacts.Name = "btn_GetOutlookContacts";
            this.btn_GetOutlookContacts.Size = new System.Drawing.Size(137, 27);
            this.btn_GetOutlookContacts.TabIndex = 9;
            this.btn_GetOutlookContacts.Text = "Get Contacts";
            this.btn_GetOutlookContacts.UseVisualStyleBackColor = true;
            this.btn_GetOutlookContacts.Click += new System.EventHandler(this.btn_GetOutlookContacts_Click);
            // 
            // txbx_DefaultFocus
            // 
            this.txbx_DefaultFocus.Location = new System.Drawing.Point(2, -20);
            this.txbx_DefaultFocus.Name = "txbx_DefaultFocus";
            this.txbx_DefaultFocus.Size = new System.Drawing.Size(12, 20);
            this.txbx_DefaultFocus.TabIndex = 10;
            // 
            // lbl_Log
            // 
            this.lbl_Log.AutoSize = true;
            this.lbl_Log.Location = new System.Drawing.Point(9, 265);
            this.lbl_Log.Name = "lbl_Log";
            this.lbl_Log.Size = new System.Drawing.Size(28, 13);
            this.lbl_Log.TabIndex = 11;
            this.lbl_Log.Text = "Log:";
            // 
            // lstbx_Log
            // 
            this.lstbx_Log.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lstbx_Log.FormattingEnabled = true;
            this.lstbx_Log.Location = new System.Drawing.Point(12, 282);
            this.lstbx_Log.Name = "lstbx_Log";
            this.lstbx_Log.Size = new System.Drawing.Size(288, 225);
            this.lstbx_Log.TabIndex = 12;
            // 
            // btn_ClearLog
            // 
            this.btn_ClearLog.Location = new System.Drawing.Point(190, 513);
            this.btn_ClearLog.Name = "btn_ClearLog";
            this.btn_ClearLog.Size = new System.Drawing.Size(110, 23);
            this.btn_ClearLog.TabIndex = 14;
            this.btn_ClearLog.Text = "Clear Log";
            this.btn_ClearLog.UseVisualStyleBackColor = true;
            this.btn_ClearLog.Click += new System.EventHandler(this.btn_ClearLog_Click);
            // 
            // lbl_UpdatedContacts
            // 
            this.lbl_UpdatedContacts.AutoSize = true;
            this.lbl_UpdatedContacts.Location = new System.Drawing.Point(21, 7);
            this.lbl_UpdatedContacts.Name = "lbl_UpdatedContacts";
            this.lbl_UpdatedContacts.Size = new System.Drawing.Size(131, 13);
            this.lbl_UpdatedContacts.TabIndex = 15;
            this.lbl_UpdatedContacts.Text = "Count of updated contact:";
            this.lbl_UpdatedContacts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prgbr_Progress
            // 
            this.prgbr_Progress.Location = new System.Drawing.Point(0, 6);
            this.prgbr_Progress.Name = "prgbr_Progress";
            this.prgbr_Progress.Size = new System.Drawing.Size(288, 24);
            this.prgbr_Progress.Step = 1;
            this.prgbr_Progress.TabIndex = 16;
            // 
            // lbl_UpdatedContactCount
            // 
            this.lbl_UpdatedContactCount.AutoSize = true;
            this.lbl_UpdatedContactCount.Location = new System.Drawing.Point(157, 7);
            this.lbl_UpdatedContactCount.Name = "lbl_UpdatedContactCount";
            this.lbl_UpdatedContactCount.Size = new System.Drawing.Size(13, 13);
            this.lbl_UpdatedContactCount.TabIndex = 17;
            this.lbl_UpdatedContactCount.Text = "0";
            // 
            // lbl_NotUpdatedContacts
            // 
            this.lbl_NotUpdatedContacts.AutoSize = true;
            this.lbl_NotUpdatedContacts.Location = new System.Drawing.Point(3, 29);
            this.lbl_NotUpdatedContacts.Name = "lbl_NotUpdatedContacts";
            this.lbl_NotUpdatedContacts.Size = new System.Drawing.Size(149, 13);
            this.lbl_NotUpdatedContacts.TabIndex = 18;
            this.lbl_NotUpdatedContacts.Text = "Count of not updated contact:";
            // 
            // lbl_NotUpdatedContactCount
            // 
            this.lbl_NotUpdatedContactCount.AutoSize = true;
            this.lbl_NotUpdatedContactCount.Location = new System.Drawing.Point(157, 29);
            this.lbl_NotUpdatedContactCount.Name = "lbl_NotUpdatedContactCount";
            this.lbl_NotUpdatedContactCount.Size = new System.Drawing.Size(13, 13);
            this.lbl_NotUpdatedContactCount.TabIndex = 19;
            this.lbl_NotUpdatedContactCount.Text = "0";
            // 
            // pnl_ImportInfo
            // 
            this.pnl_ImportInfo.Controls.Add(this.lbl_UpdatedContacts);
            this.pnl_ImportInfo.Controls.Add(this.lbl_UpdatedContactCount);
            this.pnl_ImportInfo.Controls.Add(this.lbl_NotUpdatedContactCount);
            this.pnl_ImportInfo.Controls.Add(this.lbl_NotUpdatedContacts);
            this.pnl_ImportInfo.Location = new System.Drawing.Point(12, 154);
            this.pnl_ImportInfo.Name = "pnl_ImportInfo";
            this.pnl_ImportInfo.Size = new System.Drawing.Size(288, 50);
            this.pnl_ImportInfo.TabIndex = 20;
            // 
            // notifyIcon_Tray
            // 
            this.notifyIcon_Tray.ContextMenuStrip = this.contextMenuStrip_Tray;
            this.notifyIcon_Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_Tray.Icon")));
            this.notifyIcon_Tray.Text = "Update contacts in CRM";
            this.notifyIcon_Tray.Visible = true;
            // 
            // contextMenuStrip_Tray
            // 
            this.contextMenuStrip_Tray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Show,
            this.toolStripMenuItem_Quit});
            this.contextMenuStrip_Tray.Name = "contextMenuStrip_Tray";
            this.contextMenuStrip_Tray.Size = new System.Drawing.Size(104, 48);
            // 
            // toolStripMenuItem_Show
            // 
            this.toolStripMenuItem_Show.Name = "toolStripMenuItem_Show";
            this.toolStripMenuItem_Show.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem_Show.Text = "Show";
            this.toolStripMenuItem_Show.Click += new System.EventHandler(this.toolStripMenuItem_Show_Click);
            // 
            // toolStripMenuItem_Quit
            // 
            this.toolStripMenuItem_Quit.Name = "toolStripMenuItem_Quit";
            this.toolStripMenuItem_Quit.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem_Quit.Text = "Quit";
            this.toolStripMenuItem_Quit.Click += new System.EventHandler(this.toolStripMenuItem_Quit_Click);
            // 
            // pnl_Progress
            // 
            this.pnl_Progress.Controls.Add(this.prgbr_Progress);
            this.pnl_Progress.Location = new System.Drawing.Point(12, 210);
            this.pnl_Progress.Name = "pnl_Progress";
            this.pnl_Progress.Size = new System.Drawing.Size(288, 35);
            this.pnl_Progress.TabIndex = 21;
            // 
            // txbx_CrmDomain
            // 
            this.txbx_CrmDomain.BackColor = System.Drawing.SystemColors.Control;
            this.txbx_CrmDomain.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txbx_CrmDomain.Location = new System.Drawing.Point(82, 32);
            this.txbx_CrmDomain.Name = "txbx_CrmDomain";
            this.txbx_CrmDomain.ReadOnly = true;
            this.txbx_CrmDomain.Size = new System.Drawing.Size(214, 20);
            this.txbx_CrmDomain.TabIndex = 37;
            this.txbx_CrmDomain.Text = "DOMAIN";
            // 
            // lbl_CrmDomain
            // 
            this.lbl_CrmDomain.AutoSize = true;
            this.lbl_CrmDomain.Location = new System.Drawing.Point(28, 35);
            this.lbl_CrmDomain.Name = "lbl_CrmDomain";
            this.lbl_CrmDomain.Size = new System.Drawing.Size(46, 13);
            this.lbl_CrmDomain.TabIndex = 36;
            this.lbl_CrmDomain.Text = "Domain:";
            // 
            // txbx_CrmPass
            // 
            this.txbx_CrmPass.Location = new System.Drawing.Point(82, 84);
            this.txbx_CrmPass.Name = "txbx_CrmPass";
            this.txbx_CrmPass.PasswordChar = '*';
            this.txbx_CrmPass.Size = new System.Drawing.Size(214, 20);
            this.txbx_CrmPass.TabIndex = 35;
            // 
            // txbx_CrmLogin
            // 
            this.txbx_CrmLogin.Location = new System.Drawing.Point(82, 58);
            this.txbx_CrmLogin.Name = "txbx_CrmLogin";
            this.txbx_CrmLogin.Size = new System.Drawing.Size(214, 20);
            this.txbx_CrmLogin.TabIndex = 34;
            // 
            // txbx_CrmUrl
            // 
            this.txbx_CrmUrl.BackColor = System.Drawing.SystemColors.Control;
            this.txbx_CrmUrl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txbx_CrmUrl.Location = new System.Drawing.Point(82, 6);
            this.txbx_CrmUrl.Name = "txbx_CrmUrl";
            this.txbx_CrmUrl.ReadOnly = true;
            this.txbx_CrmUrl.Size = new System.Drawing.Size(214, 20);
            this.txbx_CrmUrl.TabIndex = 33;
            this.txbx_CrmUrl.Text = "https://crmurl.com";
            // 
            // lbl_CrmPass
            // 
            this.lbl_CrmPass.AutoSize = true;
            this.lbl_CrmPass.Location = new System.Drawing.Point(18, 87);
            this.lbl_CrmPass.Name = "lbl_CrmPass";
            this.lbl_CrmPass.Size = new System.Drawing.Size(56, 13);
            this.lbl_CrmPass.TabIndex = 32;
            this.lbl_CrmPass.Text = "Password:";
            // 
            // lbl_CrmLogin
            // 
            this.lbl_CrmLogin.AutoSize = true;
            this.lbl_CrmLogin.Location = new System.Drawing.Point(38, 61);
            this.lbl_CrmLogin.Name = "lbl_CrmLogin";
            this.lbl_CrmLogin.Size = new System.Drawing.Size(36, 13);
            this.lbl_CrmLogin.TabIndex = 31;
            this.lbl_CrmLogin.Text = "Login:";
            // 
            // lbl_CrmUrl
            // 
            this.lbl_CrmUrl.AutoSize = true;
            this.lbl_CrmUrl.Location = new System.Drawing.Point(15, 9);
            this.lbl_CrmUrl.Name = "lbl_CrmUrl";
            this.lbl_CrmUrl.Size = new System.Drawing.Size(59, 13);
            this.lbl_CrmUrl.TabIndex = 30;
            this.lbl_CrmUrl.Text = "CRM URL:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 548);
            this.Controls.Add(this.txbx_CrmDomain);
            this.Controls.Add(this.lbl_CrmDomain);
            this.Controls.Add(this.txbx_CrmPass);
            this.Controls.Add(this.txbx_CrmLogin);
            this.Controls.Add(this.txbx_CrmUrl);
            this.Controls.Add(this.lbl_CrmPass);
            this.Controls.Add(this.lbl_CrmLogin);
            this.Controls.Add(this.lbl_CrmUrl);
            this.Controls.Add(this.pnl_Progress);
            this.Controls.Add(this.pnl_ImportInfo);
            this.Controls.Add(this.btn_ClearLog);
            this.Controls.Add(this.lstbx_Log);
            this.Controls.Add(this.lbl_Log);
            this.Controls.Add(this.txbx_DefaultFocus);
            this.Controls.Add(this.btn_GetOutlookContacts);
            this.Controls.Add(this.btn_StartImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update contacts in CRM";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnl_ImportInfo.ResumeLayout(false);
            this.pnl_ImportInfo.PerformLayout();
            this.contextMenuStrip_Tray.ResumeLayout(false);
            this.pnl_Progress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StartImport;
        private System.Windows.Forms.Button btn_GetOutlookContacts;
        private System.Windows.Forms.TextBox txbx_DefaultFocus;
        private System.Windows.Forms.Label lbl_Log;
        private System.Windows.Forms.Button btn_ClearLog;
        private System.Windows.Forms.ListBox lstbx_Log;
        private System.Windows.Forms.Label lbl_UpdatedContacts;
        private System.Windows.Forms.ProgressBar prgbr_Progress;
        private System.Windows.Forms.Label lbl_UpdatedContactCount;
        private System.Windows.Forms.Label lbl_NotUpdatedContacts;
        private System.Windows.Forms.Label lbl_NotUpdatedContactCount;
        private System.Windows.Forms.Panel pnl_ImportInfo;
        private System.Windows.Forms.NotifyIcon notifyIcon_Tray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Tray;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Show;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Quit;
        private System.Windows.Forms.Panel pnl_Progress;
        private System.Windows.Forms.TextBox txbx_CrmDomain;
        private System.Windows.Forms.Label lbl_CrmDomain;
        private System.Windows.Forms.TextBox txbx_CrmPass;
        private System.Windows.Forms.TextBox txbx_CrmLogin;
        private System.Windows.Forms.TextBox txbx_CrmUrl;
        private System.Windows.Forms.Label lbl_CrmPass;
        private System.Windows.Forms.Label lbl_CrmLogin;
        private System.Windows.Forms.Label lbl_CrmUrl;
    }
}

