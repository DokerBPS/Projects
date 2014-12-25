using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConverterToPDF.Views
{
    public partial class HtmlSettings : Form
    {
        HtmlToPdfConverter settings;
        static HtmlToPdfConverter HtmlToPdfSettings { get; set; }
        public HtmlSettings()
        {
            InitializeComponent();
            SetDefaultFocus();
            settings = new HtmlToPdfConverter();
        }

        private void btn_SetSettings_Click(object sender, EventArgs e)
        {
            SetHtmlSettings();
            this.DialogResult = DialogResult.OK;
        }

        void SetDefaultFocus()
        {
            txbx_DefaultFocus.Select();
        }

        /// <summary>
        /// Set settings for pdf file
        /// </summary>
        private void SetHtmlSettings()
        {
            foreach (var item in this.Controls)
            {
                if (item is GroupBox)
                {
                    GroupBox temp = ((GroupBox)item);
                    GetControlsFromGroupBox(temp.Controls, temp.Name.Remove(0, 5));
                }
            }

            settings.GenerateToc = chbx_GenToc.Checked;
            settings.Grayscale = chbx_Grayscale.Checked;
            settings.LowQuality = chbx_LowQuality.Checked;

            HtmlSettings.HtmlToPdfSettings = settings;
        }

        /// <summary>
        /// Get control collection from groupbox by groupbox name
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="groupBoxName"></param>
        private void GetControlsFromGroupBox(Control.ControlCollection controls, string groupBoxName)
        {
            foreach (Control item in controls)
            {
                if (groupBoxName == "Orientation" && (item as System.Windows.Forms.RadioButton).Checked)
                {
                    settings.Orientation = (PageOrientation)Convert.ToInt32(item.Tag.ToString());
                }

                if (groupBoxName == "PageSize" && (item as System.Windows.Forms.RadioButton).Checked)
                {
                    settings.Size = (PageSize)Convert.ToInt32(item.Tag.ToString());
                }

                if (groupBoxName == "PageMargins" && (item is System.Windows.Forms.NumericUpDown))
                {
                    PageMargins pm = new PageMargins();
                    pm.Bottom = (float?)nupdw_PageMarginsBottom.Value;
                    pm.Left = (float?)nupdw_PageMarginsLeft.Value;
                    pm.Right = (float?)nupdw_PageMarginsRight.Value;
                    pm.Top = (float?)nupdw_PageMarginsTop.Value;

                    settings.Margins = pm;
                }
            }
        }

        public static HtmlToPdfConverter GetHtmlSettings()
        {
            return HtmlToPdfSettings;
        }

        public static void SetDefaultSettings()
        {
            HtmlToPdfSettings = null;
        }
    }
}
