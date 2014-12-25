namespace ConverterToPDF
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.lbl_PathToConvertedFile = new System.Windows.Forms.Label();
            this.txbx_DocumentPath = new System.Windows.Forms.TextBox();
            this.btn_Convert = new System.Windows.Forms.Button();
            this.lbl_ChangeDoc = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_OpenedDoc = new System.Windows.Forms.Label();
            this.chbx_OpenFileAfterConvert = new System.Windows.Forms.CheckBox();
            this.lbl_SuccessConvert = new System.Windows.Forms.Label();
            this.txbx_DefaultFocus = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_PdfSettings = new System.Windows.Forms.Button();
            this.pcbx_Word = new System.Windows.Forms.PictureBox();
            this.pcbx_Html = new System.Windows.Forms.PictureBox();
            this.pcbx_Excel = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbx_Word)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbx_Html)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbx_Excel)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_PathToConvertedFile
            // 
            this.lbl_PathToConvertedFile.AutoSize = true;
            this.lbl_PathToConvertedFile.Location = new System.Drawing.Point(12, 330);
            this.lbl_PathToConvertedFile.Name = "lbl_PathToConvertedFile";
            this.lbl_PathToConvertedFile.Size = new System.Drawing.Size(0, 13);
            this.lbl_PathToConvertedFile.TabIndex = 1;
            // 
            // txbx_DocumentPath
            // 
            this.txbx_DocumentPath.AllowDrop = true;
            this.txbx_DocumentPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbx_DocumentPath.Enabled = false;
            this.txbx_DocumentPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txbx_DocumentPath.Location = new System.Drawing.Point(15, 181);
            this.txbx_DocumentPath.Name = "txbx_DocumentPath";
            this.txbx_DocumentPath.ReadOnly = true;
            this.txbx_DocumentPath.Size = new System.Drawing.Size(350, 21);
            this.txbx_DocumentPath.TabIndex = 2;
            // 
            // btn_Convert
            // 
            this.btn_Convert.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Convert.Location = new System.Drawing.Point(12, 246);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(353, 42);
            this.btn_Convert.TabIndex = 3;
            this.btn_Convert.Text = "Convert";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // lbl_ChangeDoc
            // 
            this.lbl_ChangeDoc.AutoSize = true;
            this.lbl_ChangeDoc.Location = new System.Drawing.Point(12, 41);
            this.lbl_ChangeDoc.Name = "lbl_ChangeDoc";
            this.lbl_ChangeDoc.Size = new System.Drawing.Size(171, 13);
            this.lbl_ChangeDoc.TabIndex = 7;
            this.lbl_ChangeDoc.Text = "Select the file you want to convert:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingToolStripMenuItem.Text = "Settings";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.оПрограммеToolStripMenuItem.Text = "Help";
            // 
            // lbl_OpenedDoc
            // 
            this.lbl_OpenedDoc.AutoSize = true;
            this.lbl_OpenedDoc.Location = new System.Drawing.Point(12, 165);
            this.lbl_OpenedDoc.Name = "lbl_OpenedDoc";
            this.lbl_OpenedDoc.Size = new System.Drawing.Size(68, 13);
            this.lbl_OpenedDoc.TabIndex = 9;
            this.lbl_OpenedDoc.Text = "Selected file:";
            // 
            // chbx_OpenFileAfterConvert
            // 
            this.chbx_OpenFileAfterConvert.AutoSize = true;
            this.chbx_OpenFileAfterConvert.Location = new System.Drawing.Point(15, 223);
            this.chbx_OpenFileAfterConvert.Name = "chbx_OpenFileAfterConvert";
            this.chbx_OpenFileAfterConvert.Size = new System.Drawing.Size(151, 17);
            this.chbx_OpenFileAfterConvert.TabIndex = 10;
            this.chbx_OpenFileAfterConvert.Text = "Open file after converting?";
            this.chbx_OpenFileAfterConvert.UseVisualStyleBackColor = true;
            // 
            // lbl_SuccessConvert
            // 
            this.lbl_SuccessConvert.AutoSize = true;
            this.lbl_SuccessConvert.Location = new System.Drawing.Point(12, 304);
            this.lbl_SuccessConvert.Name = "lbl_SuccessConvert";
            this.lbl_SuccessConvert.Size = new System.Drawing.Size(0, 13);
            this.lbl_SuccessConvert.TabIndex = 12;
            // 
            // txbx_DefaultFocus
            // 
            this.txbx_DefaultFocus.Location = new System.Drawing.Point(-30, 18);
            this.txbx_DefaultFocus.Name = "txbx_DefaultFocus";
            this.txbx_DefaultFocus.Size = new System.Drawing.Size(28, 20);
            this.txbx_DefaultFocus.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.pcbx_Word, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pcbx_Html, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pcbx_Excel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 89);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // btn_PdfSettings
            // 
            this.btn_PdfSettings.Location = new System.Drawing.Point(282, 218);
            this.btn_PdfSettings.Name = "btn_PdfSettings";
            this.btn_PdfSettings.Size = new System.Drawing.Size(83, 25);
            this.btn_PdfSettings.TabIndex = 17;
            this.btn_PdfSettings.Text = "Show settings";
            this.btn_PdfSettings.UseVisualStyleBackColor = true;
            this.btn_PdfSettings.Visible = false;
            this.btn_PdfSettings.Click += new System.EventHandler(this.btn_PdfSettings_Click);
            // 
            // pcbx_Word
            // 
            this.pcbx_Word.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbx_Word.Image = global::ConverterToPDF.Properties.Resources.Microsoft_Word_2013;
            this.pcbx_Word.Location = new System.Drawing.Point(3, 3);
            this.pcbx_Word.Name = "pcbx_Word";
            this.pcbx_Word.Size = new System.Drawing.Size(64, 64);
            this.pcbx_Word.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbx_Word.TabIndex = 5;
            this.pcbx_Word.TabStop = false;
            this.pcbx_Word.Tag = "1";
            this.pcbx_Word.Click += new System.EventHandler(this.ChangeDocument_Click);
            this.pcbx_Word.MouseEnter += new System.EventHandler(this.pcbx_MouseHover);
            this.pcbx_Word.MouseLeave += new System.EventHandler(this.pcbx_MouseLeave);
            // 
            // pcbx_Html
            // 
            this.pcbx_Html.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbx_Html.Image = global::ConverterToPDF.Properties.Resources.HTML;
            this.pcbx_Html.Location = new System.Drawing.Point(177, 3);
            this.pcbx_Html.Name = "pcbx_Html";
            this.pcbx_Html.Size = new System.Drawing.Size(64, 64);
            this.pcbx_Html.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbx_Html.TabIndex = 15;
            this.pcbx_Html.TabStop = false;
            this.pcbx_Html.Tag = "2";
            this.pcbx_Html.Click += new System.EventHandler(this.ChangeDocument_Click);
            this.pcbx_Html.MouseEnter += new System.EventHandler(this.pcbx_MouseHover);
            this.pcbx_Html.MouseLeave += new System.EventHandler(this.pcbx_MouseLeave);
            // 
            // pcbx_Excel
            // 
            this.pcbx_Excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbx_Excel.Image = global::ConverterToPDF.Properties.Resources.Microsoft_Excel_2013;
            this.pcbx_Excel.Location = new System.Drawing.Point(90, 3);
            this.pcbx_Excel.Name = "pcbx_Excel";
            this.pcbx_Excel.Size = new System.Drawing.Size(64, 64);
            this.pcbx_Excel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbx_Excel.TabIndex = 6;
            this.pcbx_Excel.TabStop = false;
            this.pcbx_Excel.Tag = "2";
            this.pcbx_Excel.Click += new System.EventHandler(this.ChangeDocument_Click);
            this.pcbx_Excel.MouseEnter += new System.EventHandler(this.pcbx_MouseHover);
            this.pcbx_Excel.MouseLeave += new System.EventHandler(this.pcbx_MouseLeave);
            // 
            // View
            // 
            this.ClientSize = new System.Drawing.Size(936, 379);
            this.Controls.Add(this.btn_PdfSettings);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txbx_DefaultFocus);
            this.Controls.Add(this.lbl_SuccessConvert);
            this.Controls.Add(this.chbx_OpenFileAfterConvert);
            this.Controls.Add(this.lbl_OpenedDoc);
            this.Controls.Add(this.lbl_ChangeDoc);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.txbx_DocumentPath);
            this.Controls.Add(this.lbl_PathToConvertedFile);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convert file to PDF";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbx_Word)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbx_Html)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbx_Excel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_PathToConvertedFile;
        private System.Windows.Forms.TextBox txbx_DocumentPath;
        private System.Windows.Forms.Button btn_Convert;
        private System.Windows.Forms.PictureBox pcbx_Word;
        private System.Windows.Forms.PictureBox pcbx_Excel;
        private System.Windows.Forms.Label lbl_ChangeDoc;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Label lbl_OpenedDoc;
        private System.Windows.Forms.CheckBox chbx_OpenFileAfterConvert;
        private System.Windows.Forms.Label lbl_SuccessConvert;
        private System.Windows.Forms.TextBox txbx_DefaultFocus;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.PictureBox pcbx_Html;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_PdfSettings;
    }
}

