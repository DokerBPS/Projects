using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConverterToPDF.Controllers.Structs;
using ConverterToPDF.Views;
using System.Drawing;
using System.Windows.Forms;

namespace ConverterToPDF.Controllers
{
    public class ViewController
    {
        /// <summary>
        /// Set setting for fileDialog. Window which appear when click to the button
        /// </summary>
        /// <param name="buttonName">Name of the clicked button</param>
        /// <param name="filter">Filter for file dialog</param>
        /// <param name="visible">Show setting button or not</param>
        public static void SetSettingsForFileDialog(string buttonName, ref string filter, ref bool visible)
        {
            filter = "{0} documents ({1})|*{2};*{3}";

            switch (buttonName.ToLower())
            {
                case Document.Word:
                    {
                        filter = string.Format(filter, Document.Word, FileExtension.Doc, FileExtension.Doc, FileExtension.Docx);
                        visible = false;
                    } break;
                case Document.Excel:
                    {
                        ExcelSettings.SetDefaultSettings();
                        filter = string.Format(filter, Document.Excel, FileExtension.Xls, FileExtension.Xls, FileExtension.Xlsx);
                        visible = true;
                    } break;
                case Document.Html:
                    {
                        HtmlSettings.SetDefaultSettings();
                        filter = string.Format(filter, Document.Html, FileExtension.Html, FileExtension.Htm, FileExtension.Html);
                        visible = true;
                    } break;
                default: break;
            }

        }

        /// <summary>
        /// Show setting window dependent of file extension
        /// </summary>
        /// <param name="extension">File extension wich selected</param>
        public static void ShowModalDialog(string extension)
        {
            switch (extension)
            {
                case FileExtension.Xls:
                case FileExtension.Xlsx:
                    {
                        ExcelSettings excelSettingsDialog = new ExcelSettings();
                        excelSettingsDialog.ShowDialog();
                    } break;
                case FileExtension.Htm:
                case FileExtension.Html:
                    {
                        HtmlSettings htmlSettingsDialog = new HtmlSettings();
                        htmlSettingsDialog.ShowDialog();
                    } break;
                default:
                    break;
            } 
        }

        /// <summary>
        /// Change picture if mouse hover on pictureBox
        /// </summary>
        /// <param name="buttonName">Name of pictureBox</param>
        /// <param name="buttonEvent">Mouse event</param>
        public static Image SetImageForPictureBox(string buttonEvent, object sender)
        {
            Image image = null;
            string buttonName = ((PictureBox)sender).Name.Substring(5);
            string appSettingKey = buttonName + "_" + buttonEvent;
            switch (buttonName.ToLower())
            {
                case Document.Word:
                    {
                        image = Image.FromFile(System.Configuration.ConfigurationSettings.AppSettings[appSettingKey]);
                    } break;
                case Document.Excel:
                    {
                        image = Image.FromFile(System.Configuration.ConfigurationSettings.AppSettings[appSettingKey]);
                    } break;
                case Document.Html:
                    {
                        image = Image.FromFile(System.Configuration.ConfigurationSettings.AppSettings[appSettingKey]);
                    } break;
                default: break;
            }

            return image;
        }
    }
}
