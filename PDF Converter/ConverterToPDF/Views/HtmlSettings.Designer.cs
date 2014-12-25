namespace ConverterToPDF.Views
{
    partial class HtmlSettings
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
            this.grbx_Orientation = new System.Windows.Forms.GroupBox();
            this.rdbtn_OrientationDefault = new System.Windows.Forms.RadioButton();
            this.rdbtn_OrientationLandscape = new System.Windows.Forms.RadioButton();
            this.rdbtn_OrientationPortrait = new System.Windows.Forms.RadioButton();
            this.grbx_PageSize = new System.Windows.Forms.GroupBox();
            this.rdbtn_PageSizeDefault = new System.Windows.Forms.RadioButton();
            this.rdbtn_PageSizeA4 = new System.Windows.Forms.RadioButton();
            this.rdbtn_PageSizeA3 = new System.Windows.Forms.RadioButton();
            this.rdbtn_PageSizeLetter = new System.Windows.Forms.RadioButton();
            this.grbx_PageMargins = new System.Windows.Forms.GroupBox();
            this.lbl_PageMarginsBottom = new System.Windows.Forms.Label();
            this.lbl_PageMarginsLeft = new System.Windows.Forms.Label();
            this.lbl_PageMarginsRight = new System.Windows.Forms.Label();
            this.lbl_PageMarginsTop = new System.Windows.Forms.Label();
            this.nupdw_PageMarginsBottom = new System.Windows.Forms.NumericUpDown();
            this.nupdw_PageMarginsLeft = new System.Windows.Forms.NumericUpDown();
            this.nupdw_PageMarginsRight = new System.Windows.Forms.NumericUpDown();
            this.nupdw_PageMarginsTop = new System.Windows.Forms.NumericUpDown();
            this.btn_SetSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chbx_GenToc = new System.Windows.Forms.CheckBox();
            this.chbx_LowQuality = new System.Windows.Forms.CheckBox();
            this.chbx_Grayscale = new System.Windows.Forms.CheckBox();
            this.txbx_DefaultFocus = new System.Windows.Forms.TextBox();
            this.grbx_Orientation.SuspendLayout();
            this.grbx_PageSize.SuspendLayout();
            this.grbx_PageMargins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdw_PageMarginsBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdw_PageMarginsLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdw_PageMarginsRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdw_PageMarginsTop)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbx_Orientation
            // 
            this.grbx_Orientation.Controls.Add(this.rdbtn_OrientationPortrait);
            this.grbx_Orientation.Controls.Add(this.rdbtn_OrientationLandscape);
            this.grbx_Orientation.Controls.Add(this.rdbtn_OrientationDefault);
            this.grbx_Orientation.Location = new System.Drawing.Point(13, 13);
            this.grbx_Orientation.Name = "grbx_Orientation";
            this.grbx_Orientation.Size = new System.Drawing.Size(308, 56);
            this.grbx_Orientation.TabIndex = 0;
            this.grbx_Orientation.TabStop = false;
            this.grbx_Orientation.Text = "Orientation";
            // 
            // rdbtn_OrientationDefault
            // 
            this.rdbtn_OrientationDefault.AutoSize = true;
            this.rdbtn_OrientationDefault.Location = new System.Drawing.Point(7, 20);
            this.rdbtn_OrientationDefault.Name = "rdbtn_OrientationDefault";
            this.rdbtn_OrientationDefault.Size = new System.Drawing.Size(59, 17);
            this.rdbtn_OrientationDefault.TabIndex = 0;
            this.rdbtn_OrientationDefault.TabStop = true;
            this.rdbtn_OrientationDefault.Tag = "0";
            this.rdbtn_OrientationDefault.Text = "Default";
            this.rdbtn_OrientationDefault.UseVisualStyleBackColor = true;
            // 
            // rdbtn_OrientationLandscape
            // 
            this.rdbtn_OrientationLandscape.AutoSize = true;
            this.rdbtn_OrientationLandscape.Location = new System.Drawing.Point(101, 20);
            this.rdbtn_OrientationLandscape.Name = "rdbtn_OrientationLandscape";
            this.rdbtn_OrientationLandscape.Size = new System.Drawing.Size(78, 17);
            this.rdbtn_OrientationLandscape.TabIndex = 1;
            this.rdbtn_OrientationLandscape.TabStop = true;
            this.rdbtn_OrientationLandscape.Tag = "1";
            this.rdbtn_OrientationLandscape.Text = "Landscape";
            this.rdbtn_OrientationLandscape.UseVisualStyleBackColor = true;
            // 
            // rdbtn_OrientationPortrait
            // 
            this.rdbtn_OrientationPortrait.AutoSize = true;
            this.rdbtn_OrientationPortrait.Location = new System.Drawing.Point(200, 19);
            this.rdbtn_OrientationPortrait.Name = "rdbtn_OrientationPortrait";
            this.rdbtn_OrientationPortrait.Size = new System.Drawing.Size(58, 17);
            this.rdbtn_OrientationPortrait.TabIndex = 2;
            this.rdbtn_OrientationPortrait.TabStop = true;
            this.rdbtn_OrientationPortrait.Tag = "2";
            this.rdbtn_OrientationPortrait.Text = "Portrait";
            this.rdbtn_OrientationPortrait.UseVisualStyleBackColor = true;
            // 
            // grbx_PageSize
            // 
            this.grbx_PageSize.Controls.Add(this.rdbtn_PageSizeLetter);
            this.grbx_PageSize.Controls.Add(this.rdbtn_PageSizeA3);
            this.grbx_PageSize.Controls.Add(this.rdbtn_PageSizeA4);
            this.grbx_PageSize.Controls.Add(this.rdbtn_PageSizeDefault);
            this.grbx_PageSize.Location = new System.Drawing.Point(13, 76);
            this.grbx_PageSize.Name = "grbx_PageSize";
            this.grbx_PageSize.Size = new System.Drawing.Size(308, 56);
            this.grbx_PageSize.TabIndex = 1;
            this.grbx_PageSize.TabStop = false;
            this.grbx_PageSize.Text = "Page size";
            // 
            // rdbtn_PageSizeDefault
            // 
            this.rdbtn_PageSizeDefault.AutoSize = true;
            this.rdbtn_PageSizeDefault.Location = new System.Drawing.Point(7, 20);
            this.rdbtn_PageSizeDefault.Name = "rdbtn_PageSizeDefault";
            this.rdbtn_PageSizeDefault.Size = new System.Drawing.Size(59, 17);
            this.rdbtn_PageSizeDefault.TabIndex = 0;
            this.rdbtn_PageSizeDefault.TabStop = true;
            this.rdbtn_PageSizeDefault.Tag = "0";
            this.rdbtn_PageSizeDefault.Text = "Default";
            this.rdbtn_PageSizeDefault.UseVisualStyleBackColor = true;
            // 
            // rdbtn_PageSizeA4
            // 
            this.rdbtn_PageSizeA4.AutoSize = true;
            this.rdbtn_PageSizeA4.Location = new System.Drawing.Point(82, 20);
            this.rdbtn_PageSizeA4.Name = "rdbtn_PageSizeA4";
            this.rdbtn_PageSizeA4.Size = new System.Drawing.Size(38, 17);
            this.rdbtn_PageSizeA4.TabIndex = 1;
            this.rdbtn_PageSizeA4.TabStop = true;
            this.rdbtn_PageSizeA4.Tag = "1";
            this.rdbtn_PageSizeA4.Text = "A4";
            this.rdbtn_PageSizeA4.UseVisualStyleBackColor = true;
            // 
            // rdbtn_PageSizeA3
            // 
            this.rdbtn_PageSizeA3.AutoSize = true;
            this.rdbtn_PageSizeA3.Location = new System.Drawing.Point(141, 19);
            this.rdbtn_PageSizeA3.Name = "rdbtn_PageSizeA3";
            this.rdbtn_PageSizeA3.Size = new System.Drawing.Size(38, 17);
            this.rdbtn_PageSizeA3.TabIndex = 2;
            this.rdbtn_PageSizeA3.TabStop = true;
            this.rdbtn_PageSizeA3.Tag = "2";
            this.rdbtn_PageSizeA3.Text = "A3";
            this.rdbtn_PageSizeA3.UseVisualStyleBackColor = true;
            // 
            // rdbtn_PageSizeLetter
            // 
            this.rdbtn_PageSizeLetter.AutoSize = true;
            this.rdbtn_PageSizeLetter.Location = new System.Drawing.Point(206, 20);
            this.rdbtn_PageSizeLetter.Name = "rdbtn_PageSizeLetter";
            this.rdbtn_PageSizeLetter.Size = new System.Drawing.Size(52, 17);
            this.rdbtn_PageSizeLetter.TabIndex = 3;
            this.rdbtn_PageSizeLetter.TabStop = true;
            this.rdbtn_PageSizeLetter.Tag = "3";
            this.rdbtn_PageSizeLetter.Text = "Letter";
            this.rdbtn_PageSizeLetter.UseVisualStyleBackColor = true;
            // 
            // grbx_PageMargins
            // 
            this.grbx_PageMargins.Controls.Add(this.nupdw_PageMarginsTop);
            this.grbx_PageMargins.Controls.Add(this.nupdw_PageMarginsRight);
            this.grbx_PageMargins.Controls.Add(this.nupdw_PageMarginsLeft);
            this.grbx_PageMargins.Controls.Add(this.lbl_PageMarginsTop);
            this.grbx_PageMargins.Controls.Add(this.nupdw_PageMarginsBottom);
            this.grbx_PageMargins.Controls.Add(this.lbl_PageMarginsBottom);
            this.grbx_PageMargins.Controls.Add(this.lbl_PageMarginsLeft);
            this.grbx_PageMargins.Controls.Add(this.lbl_PageMarginsRight);
            this.grbx_PageMargins.Location = new System.Drawing.Point(13, 139);
            this.grbx_PageMargins.Name = "grbx_PageMargins";
            this.grbx_PageMargins.Size = new System.Drawing.Size(308, 99);
            this.grbx_PageMargins.TabIndex = 2;
            this.grbx_PageMargins.TabStop = false;
            this.grbx_PageMargins.Text = "Page margins";
            // 
            // lbl_PageMarginsBottom
            // 
            this.lbl_PageMarginsBottom.AutoSize = true;
            this.lbl_PageMarginsBottom.Location = new System.Drawing.Point(33, 31);
            this.lbl_PageMarginsBottom.Name = "lbl_PageMarginsBottom";
            this.lbl_PageMarginsBottom.Size = new System.Drawing.Size(43, 13);
            this.lbl_PageMarginsBottom.TabIndex = 1;
            this.lbl_PageMarginsBottom.Text = "Bottom:";
            // 
            // lbl_PageMarginsLeft
            // 
            this.lbl_PageMarginsLeft.AutoSize = true;
            this.lbl_PageMarginsLeft.Location = new System.Drawing.Point(48, 64);
            this.lbl_PageMarginsLeft.Name = "lbl_PageMarginsLeft";
            this.lbl_PageMarginsLeft.Size = new System.Drawing.Size(28, 13);
            this.lbl_PageMarginsLeft.TabIndex = 3;
            this.lbl_PageMarginsLeft.Text = "Left:";
            // 
            // lbl_PageMarginsRight
            // 
            this.lbl_PageMarginsRight.AutoSize = true;
            this.lbl_PageMarginsRight.Location = new System.Drawing.Point(154, 31);
            this.lbl_PageMarginsRight.Name = "lbl_PageMarginsRight";
            this.lbl_PageMarginsRight.Size = new System.Drawing.Size(35, 13);
            this.lbl_PageMarginsRight.TabIndex = 5;
            this.lbl_PageMarginsRight.Text = "Right:";
            // 
            // lbl_PageMarginsTop
            // 
            this.lbl_PageMarginsTop.AutoSize = true;
            this.lbl_PageMarginsTop.Location = new System.Drawing.Point(160, 64);
            this.lbl_PageMarginsTop.Name = "lbl_PageMarginsTop";
            this.lbl_PageMarginsTop.Size = new System.Drawing.Size(29, 13);
            this.lbl_PageMarginsTop.TabIndex = 7;
            this.lbl_PageMarginsTop.Text = "Top:";
            // 
            // nupdw_PageMarginsBottom
            // 
            this.nupdw_PageMarginsBottom.Location = new System.Drawing.Point(82, 29);
            this.nupdw_PageMarginsBottom.Name = "nupdw_PageMarginsBottom";
            this.nupdw_PageMarginsBottom.Size = new System.Drawing.Size(63, 20);
            this.nupdw_PageMarginsBottom.TabIndex = 3;
            this.nupdw_PageMarginsBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nupdw_PageMarginsLeft
            // 
            this.nupdw_PageMarginsLeft.Location = new System.Drawing.Point(82, 62);
            this.nupdw_PageMarginsLeft.Name = "nupdw_PageMarginsLeft";
            this.nupdw_PageMarginsLeft.Size = new System.Drawing.Size(63, 20);
            this.nupdw_PageMarginsLeft.TabIndex = 8;
            this.nupdw_PageMarginsLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nupdw_PageMarginsRight
            // 
            this.nupdw_PageMarginsRight.Location = new System.Drawing.Point(195, 29);
            this.nupdw_PageMarginsRight.Name = "nupdw_PageMarginsRight";
            this.nupdw_PageMarginsRight.Size = new System.Drawing.Size(63, 20);
            this.nupdw_PageMarginsRight.TabIndex = 9;
            this.nupdw_PageMarginsRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nupdw_PageMarginsTop
            // 
            this.nupdw_PageMarginsTop.Location = new System.Drawing.Point(195, 62);
            this.nupdw_PageMarginsTop.Name = "nupdw_PageMarginsTop";
            this.nupdw_PageMarginsTop.Size = new System.Drawing.Size(63, 20);
            this.nupdw_PageMarginsTop.TabIndex = 10;
            this.nupdw_PageMarginsTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_SetSettings
            // 
            this.btn_SetSettings.Location = new System.Drawing.Point(49, 310);
            this.btn_SetSettings.Name = "btn_SetSettings";
            this.btn_SetSettings.Size = new System.Drawing.Size(239, 30);
            this.btn_SetSettings.TabIndex = 3;
            this.btn_SetSettings.Text = "OK";
            this.btn_SetSettings.UseVisualStyleBackColor = true;
            this.btn_SetSettings.Click += new System.EventHandler(this.btn_SetSettings_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.27273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.72727F));
            this.tableLayoutPanel1.Controls.Add(this.chbx_GenToc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbx_LowQuality, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbx_Grayscale, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 245);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 53);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // chbx_GenToc
            // 
            this.chbx_GenToc.AutoSize = true;
            this.chbx_GenToc.Location = new System.Drawing.Point(3, 3);
            this.chbx_GenToc.Name = "chbx_GenToc";
            this.chbx_GenToc.Size = new System.Drawing.Size(152, 17);
            this.chbx_GenToc.TabIndex = 0;
            this.chbx_GenToc.Text = "Generate table of contents";
            this.chbx_GenToc.UseVisualStyleBackColor = true;
            // 
            // chbx_LowQuality
            // 
            this.chbx_LowQuality.AutoSize = true;
            this.chbx_LowQuality.Location = new System.Drawing.Point(164, 3);
            this.chbx_LowQuality.Name = "chbx_LowQuality";
            this.chbx_LowQuality.Size = new System.Drawing.Size(78, 17);
            this.chbx_LowQuality.TabIndex = 1;
            this.chbx_LowQuality.Text = "LowQuality";
            this.chbx_LowQuality.UseVisualStyleBackColor = true;
            // 
            // chbx_Grayscale
            // 
            this.chbx_Grayscale.AutoSize = true;
            this.chbx_Grayscale.Location = new System.Drawing.Point(3, 29);
            this.chbx_Grayscale.Name = "chbx_Grayscale";
            this.chbx_Grayscale.Size = new System.Drawing.Size(73, 17);
            this.chbx_Grayscale.TabIndex = 2;
            this.chbx_Grayscale.Text = "Grayscale";
            this.chbx_Grayscale.UseVisualStyleBackColor = true;
            // 
            // txbx_DefaultFocus
            // 
            this.txbx_DefaultFocus.Location = new System.Drawing.Point(-20, 0);
            this.txbx_DefaultFocus.Name = "txbx_DefaultFocus";
            this.txbx_DefaultFocus.Size = new System.Drawing.Size(16, 20);
            this.txbx_DefaultFocus.TabIndex = 5;
            // 
            // HtmlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 352);
            this.ControlBox = false;
            this.Controls.Add(this.txbx_DefaultFocus);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_SetSettings);
            this.Controls.Add(this.grbx_PageMargins);
            this.Controls.Add(this.grbx_PageSize);
            this.Controls.Add(this.grbx_Orientation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HtmlSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HtmlSettings";
            this.grbx_Orientation.ResumeLayout(false);
            this.grbx_Orientation.PerformLayout();
            this.grbx_PageSize.ResumeLayout(false);
            this.grbx_PageSize.PerformLayout();
            this.grbx_PageMargins.ResumeLayout(false);
            this.grbx_PageMargins.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdw_PageMarginsBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdw_PageMarginsLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdw_PageMarginsRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdw_PageMarginsTop)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbx_Orientation;
        private System.Windows.Forms.RadioButton rdbtn_OrientationDefault;
        private System.Windows.Forms.RadioButton rdbtn_OrientationLandscape;
        private System.Windows.Forms.RadioButton rdbtn_OrientationPortrait;
        private System.Windows.Forms.GroupBox grbx_PageSize;
        private System.Windows.Forms.RadioButton rdbtn_PageSizeDefault;
        private System.Windows.Forms.RadioButton rdbtn_PageSizeLetter;
        private System.Windows.Forms.RadioButton rdbtn_PageSizeA3;
        private System.Windows.Forms.RadioButton rdbtn_PageSizeA4;
        private System.Windows.Forms.GroupBox grbx_PageMargins;
        private System.Windows.Forms.Label lbl_PageMarginsBottom;
        private System.Windows.Forms.Label lbl_PageMarginsLeft;
        private System.Windows.Forms.Label lbl_PageMarginsRight;
        private System.Windows.Forms.Label lbl_PageMarginsTop;
        private System.Windows.Forms.NumericUpDown nupdw_PageMarginsTop;
        private System.Windows.Forms.NumericUpDown nupdw_PageMarginsRight;
        private System.Windows.Forms.NumericUpDown nupdw_PageMarginsLeft;
        private System.Windows.Forms.NumericUpDown nupdw_PageMarginsBottom;
        private System.Windows.Forms.Button btn_SetSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chbx_GenToc;
        private System.Windows.Forms.CheckBox chbx_LowQuality;
        private System.Windows.Forms.CheckBox chbx_Grayscale;
        private System.Windows.Forms.TextBox txbx_DefaultFocus;
    }
}