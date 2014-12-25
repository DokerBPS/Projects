using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Drawing.Printing;

using ConverterToPDF.Controllers;
using ConverterToPDF.Controllers.Structs;
using System.IO;

namespace ConverterToPDF
{
    public partial class View : Form
    {
        OpenFileDialog fileDialog;
        private string fileLocation = null, extension = null;

        public View()
        {
            InitializeComponent();
            SetDefaultFocus();

            btn_Convert.Enabled = false;
            fileDialog = new OpenFileDialog();
        }

        private void ChangeDocument_Click(object sender, EventArgs e)
        {
            lbl_SuccessConvert.Text = string.Empty;
            txbx_DocumentPath.Text = string.Empty;
            fileDialog.FileName = string.Empty;
            string buttonName = ((PictureBox)sender).Name.Substring(5);
            string filter = null;
            bool buttonVisible = false;

            ViewController.SetSettingsForFileDialog(buttonName, ref filter, ref buttonVisible);

            fileDialog.Filter = filter;
            btn_PdfSettings.Visible = buttonVisible;

            SelectedFile();
        }

        /// <summary>
        /// Show path to selected file
        /// </summary>
        private void SelectedFile()
        {
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                btn_Convert.Enabled = true;
                txbx_DocumentPath.Text = fileDialog.SafeFileName;
                fileLocation = fileDialog.FileName;
                extension = Path.GetExtension(txbx_DocumentPath.Text);
            }
            else
            {
                btn_PdfSettings.Visible = false;
                btn_Convert.Enabled = false;
                txbx_DocumentPath.Text = "File not selected";
            }
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            try
            {
                SetDefaultFocus();
                bool successConvertion = ConvertController.StartConvertion(extension, fileLocation, chbx_OpenFileAfterConvert.Checked);
                ConvertionComplete(successConvertion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConvertionComplete(bool convertion)
        {
            if (convertion)
            {
                lbl_SuccessConvert.ForeColor = Color.Green;
                lbl_SuccessConvert.Text = "Конвертация прошла успешно";
            }
            else
            {
                lbl_SuccessConvert.ForeColor = Color.Red;
                lbl_SuccessConvert.Text = "Произошла ошибка во время конвертации";
            }
        }

        /// <summary>
        /// Set focus to default element
        /// </summary>
        private void SetDefaultFocus()
        {
            txbx_DefaultFocus.Select();
        }

        private void pcbx_MouseHover(object sender, EventArgs e)
        {
            try
            {
                ((PictureBox)sender).Image = ViewController.SetImageForPictureBox("hover", sender);
            }
            catch
            {
                return;
            }
        }

        private void pcbx_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                ((PictureBox)sender).Image = ViewController.SetImageForPictureBox("original", sender);
            }
            catch
            {
                return;
            }
        }

        private void btn_PdfSettings_Click(object sender, EventArgs e)
        {
            ViewController.ShowModalDialog(extension);
            SetDefaultFocus();
        }
    }
}
