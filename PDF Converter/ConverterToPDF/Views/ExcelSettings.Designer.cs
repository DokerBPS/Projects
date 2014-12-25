namespace ConverterToPDF.Views
{
    partial class ExcelSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelSettings));
            this.grbx_FitToPageType = new System.Windows.Forms.GroupBox();
            this.rdbtn_ScaleWithSameFactor = new System.Windows.Forms.RadioButton();
            this.rdbtn_NoScale = new System.Windows.Forms.RadioButton();
            this.rdbtn_None = new System.Windows.Forms.RadioButton();
            this.rdbtn_ScaleWidthDifferentFactor = new System.Windows.Forms.RadioButton();
            this.btn_SetSettings = new System.Windows.Forms.Button();
            this.grbx_DisplayGridLines = new System.Windows.Forms.GroupBox();
            this.rdbtn_Invisible = new System.Windows.Forms.RadioButton();
            this.rdbtn_Visible = new System.Windows.Forms.RadioButton();
            this.rdbtn_Auto = new System.Windows.Forms.RadioButton();
            this.chbx_EmbedFonts = new System.Windows.Forms.CheckBox();
            this.chbx_PageBreak = new System.Windows.Forms.CheckBox();
            this.chbx_Bookmarks = new System.Windows.Forms.CheckBox();
            this.chbx_DocProperties = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txbx_DefaultFocus = new System.Windows.Forms.TextBox();
            this.grbx_FitToPageType.SuspendLayout();
            this.grbx_DisplayGridLines.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbx_FitToPageType
            // 
            this.grbx_FitToPageType.Controls.Add(this.rdbtn_ScaleWithSameFactor);
            this.grbx_FitToPageType.Controls.Add(this.rdbtn_NoScale);
            this.grbx_FitToPageType.Controls.Add(this.rdbtn_None);
            this.grbx_FitToPageType.Controls.Add(this.rdbtn_ScaleWidthDifferentFactor);
            this.grbx_FitToPageType.Location = new System.Drawing.Point(13, 13);
            this.grbx_FitToPageType.Name = "grbx_FitToPageType";
            this.grbx_FitToPageType.Size = new System.Drawing.Size(435, 57);
            this.grbx_FitToPageType.TabIndex = 0;
            this.grbx_FitToPageType.TabStop = false;
            this.grbx_FitToPageType.Text = "Fit sheet to one page";
            // 
            // rdbtn_ScaleWithSameFactor
            // 
            this.rdbtn_ScaleWithSameFactor.AutoSize = true;
            this.rdbtn_ScaleWithSameFactor.Location = new System.Drawing.Point(138, 20);
            this.rdbtn_ScaleWithSameFactor.Name = "rdbtn_ScaleWithSameFactor";
            this.rdbtn_ScaleWithSameFactor.Size = new System.Drawing.Size(132, 17);
            this.rdbtn_ScaleWithSameFactor.TabIndex = 3;
            this.rdbtn_ScaleWithSameFactor.TabStop = true;
            this.rdbtn_ScaleWithSameFactor.Tag = "2";
            this.rdbtn_ScaleWithSameFactor.Text = "Scale with same factor";
            this.rdbtn_ScaleWithSameFactor.UseVisualStyleBackColor = true;
            // 
            // rdbtn_NoScale
            // 
            this.rdbtn_NoScale.AutoSize = true;
            this.rdbtn_NoScale.Location = new System.Drawing.Point(63, 20);
            this.rdbtn_NoScale.Name = "rdbtn_NoScale";
            this.rdbtn_NoScale.Size = new System.Drawing.Size(69, 17);
            this.rdbtn_NoScale.TabIndex = 2;
            this.rdbtn_NoScale.TabStop = true;
            this.rdbtn_NoScale.Tag = "1";
            this.rdbtn_NoScale.Text = "No Scale";
            this.rdbtn_NoScale.UseVisualStyleBackColor = true;
            // 
            // rdbtn_None
            // 
            this.rdbtn_None.AutoSize = true;
            this.rdbtn_None.Location = new System.Drawing.Point(6, 20);
            this.rdbtn_None.Name = "rdbtn_None";
            this.rdbtn_None.Size = new System.Drawing.Size(51, 17);
            this.rdbtn_None.TabIndex = 1;
            this.rdbtn_None.TabStop = true;
            this.rdbtn_None.Tag = "0";
            this.rdbtn_None.Text = "None";
            this.rdbtn_None.UseVisualStyleBackColor = true;
            // 
            // rdbtn_ScaleWidthDifferentFactor
            // 
            this.rdbtn_ScaleWidthDifferentFactor.AutoSize = true;
            this.rdbtn_ScaleWidthDifferentFactor.Location = new System.Drawing.Point(276, 20);
            this.rdbtn_ScaleWidthDifferentFactor.Name = "rdbtn_ScaleWidthDifferentFactor";
            this.rdbtn_ScaleWidthDifferentFactor.Size = new System.Drawing.Size(151, 17);
            this.rdbtn_ScaleWidthDifferentFactor.TabIndex = 0;
            this.rdbtn_ScaleWidthDifferentFactor.TabStop = true;
            this.rdbtn_ScaleWidthDifferentFactor.Tag = "3";
            this.rdbtn_ScaleWidthDifferentFactor.Text = "Scale width different factor";
            this.rdbtn_ScaleWidthDifferentFactor.UseVisualStyleBackColor = true;
            // 
            // btn_SetSettings
            // 
            this.btn_SetSettings.Location = new System.Drawing.Point(105, 216);
            this.btn_SetSettings.Name = "btn_SetSettings";
            this.btn_SetSettings.Size = new System.Drawing.Size(239, 30);
            this.btn_SetSettings.TabIndex = 1;
            this.btn_SetSettings.Text = "OK";
            this.btn_SetSettings.UseVisualStyleBackColor = true;
            this.btn_SetSettings.Click += new System.EventHandler(this.btn_SetSettings_Click);
            // 
            // grbx_DisplayGridLines
            // 
            this.grbx_DisplayGridLines.Controls.Add(this.rdbtn_Invisible);
            this.grbx_DisplayGridLines.Controls.Add(this.rdbtn_Visible);
            this.grbx_DisplayGridLines.Controls.Add(this.rdbtn_Auto);
            this.grbx_DisplayGridLines.Location = new System.Drawing.Point(13, 77);
            this.grbx_DisplayGridLines.Name = "grbx_DisplayGridLines";
            this.grbx_DisplayGridLines.Size = new System.Drawing.Size(435, 63);
            this.grbx_DisplayGridLines.TabIndex = 2;
            this.grbx_DisplayGridLines.TabStop = false;
            this.grbx_DisplayGridLines.Text = "Display grid lines";
            // 
            // rdbtn_Invisible
            // 
            this.rdbtn_Invisible.AutoSize = true;
            this.rdbtn_Invisible.Location = new System.Drawing.Point(138, 20);
            this.rdbtn_Invisible.Name = "rdbtn_Invisible";
            this.rdbtn_Invisible.Size = new System.Drawing.Size(63, 17);
            this.rdbtn_Invisible.TabIndex = 2;
            this.rdbtn_Invisible.TabStop = true;
            this.rdbtn_Invisible.Tag = "2";
            this.rdbtn_Invisible.Text = "Invisible";
            this.rdbtn_Invisible.UseVisualStyleBackColor = true;
            // 
            // rdbtn_Visible
            // 
            this.rdbtn_Visible.AutoSize = true;
            this.rdbtn_Visible.Location = new System.Drawing.Point(63, 20);
            this.rdbtn_Visible.Name = "rdbtn_Visible";
            this.rdbtn_Visible.Size = new System.Drawing.Size(55, 17);
            this.rdbtn_Visible.TabIndex = 1;
            this.rdbtn_Visible.TabStop = true;
            this.rdbtn_Visible.Tag = "1";
            this.rdbtn_Visible.Text = "Visible";
            this.rdbtn_Visible.UseVisualStyleBackColor = true;
            // 
            // rdbtn_Auto
            // 
            this.rdbtn_Auto.AutoSize = true;
            this.rdbtn_Auto.Location = new System.Drawing.Point(7, 20);
            this.rdbtn_Auto.Name = "rdbtn_Auto";
            this.rdbtn_Auto.Size = new System.Drawing.Size(47, 17);
            this.rdbtn_Auto.TabIndex = 0;
            this.rdbtn_Auto.TabStop = true;
            this.rdbtn_Auto.Tag = "0";
            this.rdbtn_Auto.Text = "Auto";
            this.rdbtn_Auto.UseVisualStyleBackColor = true;
            // 
            // chbx_EmbedFonts
            // 
            this.chbx_EmbedFonts.AutoSize = true;
            this.chbx_EmbedFonts.Location = new System.Drawing.Point(3, 3);
            this.chbx_EmbedFonts.Name = "chbx_EmbedFonts";
            this.chbx_EmbedFonts.Size = new System.Drawing.Size(85, 17);
            this.chbx_EmbedFonts.TabIndex = 3;
            this.chbx_EmbedFonts.Text = "Embed fonts";
            this.chbx_EmbedFonts.UseVisualStyleBackColor = true;
            // 
            // chbx_PageBreak
            // 
            this.chbx_PageBreak.AutoSize = true;
            this.chbx_PageBreak.Location = new System.Drawing.Point(3, 28);
            this.chbx_PageBreak.Name = "chbx_PageBreak";
            this.chbx_PageBreak.Size = new System.Drawing.Size(144, 17);
            this.chbx_PageBreak.TabIndex = 4;
            this.chbx_PageBreak.Text = "Enable excel page break";
            this.chbx_PageBreak.UseVisualStyleBackColor = true;
            // 
            // chbx_Bookmarks
            // 
            this.chbx_Bookmarks.AutoSize = true;
            this.chbx_Bookmarks.Location = new System.Drawing.Point(220, 3);
            this.chbx_Bookmarks.Name = "chbx_Bookmarks";
            this.chbx_Bookmarks.Size = new System.Drawing.Size(111, 17);
            this.chbx_Bookmarks.TabIndex = 5;
            this.chbx_Bookmarks.Text = "Export bookmarks";
            this.chbx_Bookmarks.UseVisualStyleBackColor = true;
            // 
            // chbx_DocProperties
            // 
            this.chbx_DocProperties.AutoSize = true;
            this.chbx_DocProperties.Location = new System.Drawing.Point(220, 28);
            this.chbx_DocProperties.Name = "chbx_DocProperties";
            this.chbx_DocProperties.Size = new System.Drawing.Size(155, 17);
            this.chbx_DocProperties.TabIndex = 6;
            this.chbx_DocProperties.Text = "Export document properties";
            this.chbx_DocProperties.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chbx_EmbedFonts, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbx_DocProperties, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chbx_PageBreak, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chbx_Bookmarks, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 146);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(435, 51);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // txbx_DefaultFocus
            // 
            this.txbx_DefaultFocus.Location = new System.Drawing.Point(-20, 0);
            this.txbx_DefaultFocus.Name = "txbx_DefaultFocus";
            this.txbx_DefaultFocus.Size = new System.Drawing.Size(16, 20);
            this.txbx_DefaultFocus.TabIndex = 8;
            // 
            // ExcelSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 263);
            this.ControlBox = false;
            this.Controls.Add(this.txbx_DefaultFocus);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.grbx_DisplayGridLines);
            this.Controls.Add(this.btn_SetSettings);
            this.Controls.Add(this.grbx_FitToPageType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExcelSettings";
            this.grbx_FitToPageType.ResumeLayout(false);
            this.grbx_FitToPageType.PerformLayout();
            this.grbx_DisplayGridLines.ResumeLayout(false);
            this.grbx_DisplayGridLines.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbx_FitToPageType;
        private System.Windows.Forms.RadioButton rdbtn_ScaleWidthDifferentFactor;
        private System.Windows.Forms.RadioButton rdbtn_ScaleWithSameFactor;
        private System.Windows.Forms.RadioButton rdbtn_NoScale;
        private System.Windows.Forms.RadioButton rdbtn_None;
        private System.Windows.Forms.Button btn_SetSettings;
        private System.Windows.Forms.GroupBox grbx_DisplayGridLines;
        private System.Windows.Forms.RadioButton rdbtn_Auto;
        private System.Windows.Forms.RadioButton rdbtn_Invisible;
        private System.Windows.Forms.RadioButton rdbtn_Visible;
        private System.Windows.Forms.CheckBox chbx_EmbedFonts;
        private System.Windows.Forms.CheckBox chbx_PageBreak;
        private System.Windows.Forms.CheckBox chbx_Bookmarks;
        private System.Windows.Forms.CheckBox chbx_DocProperties;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txbx_DefaultFocus;
    }
}