using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

using Microsoft.Office.Interop.Word;

using Spire.Xls;
using Spire.Xls.Converter;
using NReco.PdfGenerator;

namespace ConverterToPDF.Models
{
    class FileConverters_Model
    {
        protected string PathToConvertedFile { get; set; }
        SaveFileDialog saveDialog;

        public FileConverters_Model()
        {
            saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".pdf";
            saveDialog.Filter = "PDF documents (.pdf)|*.pdf";
        }

        /// <summary>
        /// Convert WORD documents to PDF file 
        /// </summary>
        /// <param name="path">Path to file which would be converted</param>
        /// <param name="openFile">Open file after convertion</param>
        /// <returns>A successful conversion</returns>
        public bool WordConverter(string path)
        {
            Microsoft.Office.Interop.Word.Document wordDocument;
            Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();

            wordDocument = appWord.Documents.Open(path);

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                wordDocument.ExportAsFixedFormat(saveDialog.FileName, WdExportFormat.wdExportFormatPDF);
                PathToConvertedFile = saveDialog.FileName;
            }
            else
                return false;

            appWord.Quit();
            saveDialog.FileName = null;
            return true;
        }

        /// <summary>
        /// Convert EXCEL documents to PDF file
        /// </summary>
        /// <param name="path">Path to file which would be converted</param>
        /// <param name="openFile">Open file after convertion</param>
        /// <returns>A successful conversion</returns>
        public bool ExcelConverter(string path, PdfConverterSettings settings)
        {
            Spire.Xls.Workbook workBook = new Spire.Xls.Workbook();

            workBook.LoadFromFile(path);

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //workBook.SaveToFile(saveDialog.FileName, settings);
                PdfConvertionHelper.SaveToPdf(workBook, saveDialog.FileName, settings);
                PathToConvertedFile = saveDialog.FileName;
            }
            //PdfConvertionHelper.SaveToPdf(workBook, saveDialog.FileName);
            else
                return false;

            workBook.Dispose();
            saveDialog.FileName = null;
            return true;
        }

        /// <summary>
        /// Convert HTML documents to PDF file
        /// </summary>
        /// <param name="path">Path to file which would be converted</param>
        /// <param name="openFile">Open file after convertion</param>
        /// <returns>A successful conversion</returns>
        public bool HTMLConverter(string path, HtmlToPdfConverter htmlToPdf)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                htmlToPdf.GeneratePdfFromFile(path, null, saveDialog.FileName);
                PathToConvertedFile = saveDialog.FileName;
            }
            else
                return false;

            return true;
        }

        /// <summary>
        /// Open file after convertion
        /// </summary>
        public void OpenFile()
        {
            try
            {
                System.Diagnostics.Process.Start(PathToConvertedFile);
            }
            catch { }
        }
    }
}
