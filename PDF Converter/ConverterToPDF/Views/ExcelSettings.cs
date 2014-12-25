using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Spire.Xls;
using Spire.Xls.Converter;

namespace ConverterToPDF.Views
{
    public partial class ExcelSettings : Form
    {
        PdfConverterSettings settings;
        static PdfConverterSettings ExcelSetting { get; set; }

        public ExcelSettings()
        {
            InitializeComponent();
            SetDefaultFocus();
            settings = new PdfConverterSettings();
        }

        /// <summary>
        /// Set focus to default element
        /// </summary>
        private void SetDefaultFocus()
        {
            txbx_DefaultFocus.Select();
        }

        private void btn_SetSettings_Click(object sender, EventArgs e)
        {
            SetExcelSettings();
            this.DialogResult = DialogResult.OK;
        }

        private void SetExcelSettings()
        {
            foreach (var item in this.Controls)
            {
                if (item is GroupBox)
                {
                    GroupBox temp = ((GroupBox)item);
                    GetControlsFromGroupBox(temp.Controls, temp.Name.Remove(0, 5)); 
                }
            }

            settings.EmbedFonts = chbx_EmbedFonts.Checked;
            settings.EnableExcelPageBreak = chbx_PageBreak.Checked;
            settings.ExportBookmarks = chbx_Bookmarks.Checked;
            settings.ExportDocumentProperties = chbx_DocProperties.Checked;

            ExcelSettings.ExcelSetting = settings;
        }

        private void GetControlsFromGroupBox(Control.ControlCollection controls, string groupBoxName)
        {
            foreach (Control item in controls)
            {
                if (groupBoxName == "FitToPageType" && (item as System.Windows.Forms.RadioButton).Checked)
                {
                    settings.FitSheetToOnePage = (FitToPageType)Convert.ToInt32(item.Tag.ToString());
                }

                if (groupBoxName == "DisplayGridLines" && (item as System.Windows.Forms.RadioButton).Checked)
                {
                    settings.DisplayGridLines = (PdfConverterSettings.GridLinesDisplayStyle)Convert.ToInt32(item.Tag.ToString());
                }
            }
        }

        public static PdfConverterSettings GetExcelSettings()
        {
            return ExcelSetting;
        }

        public static void SetDefaultSettings()
        {
            ExcelSetting = null;
        }
    }
}
