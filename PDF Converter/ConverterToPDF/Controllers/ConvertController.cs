using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConverterToPDF.Models;
using ConverterToPDF.Views;
using ConverterToPDF.Controllers.Structs;


namespace ConverterToPDF.Controllers
{
    public static class ConvertController
    {
        static FileConverters_Model model = new FileConverters_Model();
        static string DefaultExtension { get; set; }
        static string PathToSelectedFile { get; set; }
        static bool OpenTheFile { get; set; }
        static bool SuccessfullConvertion { get; set; }

        public static bool StartConvertion(string defaultExt, string path, bool openFile)
        {
            DefaultExtension = defaultExt;
            PathToSelectedFile = path;
            OpenTheFile = openFile;

            ChangeConverter();
            CheckOpenTheFile();

            return SuccessfullConvertion;
        }

        /// <summary>
        /// Verify open the file after converting
        /// </summary>
        private static void CheckOpenTheFile()
        {
            if (OpenTheFile)
                model.OpenFile();
        }

        /// <summary>
        /// Selects the converter according to file extension
        /// </summary>
        private static void ChangeConverter()
        {
            switch (DefaultExtension)
            {
                case FileExtension.Docx:
                case FileExtension.Doc:
                    {
                        SuccessfullConvertion = model.WordConverter(PathToSelectedFile);

                    } break;
                case FileExtension.Xlsx:
                case FileExtension.Xls:
                    {
                        var excelSettings = ExcelSettings.GetExcelSettings();
                        SuccessfullConvertion = model.ExcelConverter(PathToSelectedFile, excelSettings);

                    } break;
                case FileExtension.Htm:
                case FileExtension.Html:
                    {
                        var htmlSettings = HtmlSettings.GetHtmlSettings();
                        SuccessfullConvertion = model.HTMLConverter(PathToSelectedFile, htmlSettings);
                    } break;
                default:  break;
            }
        }
    }
}
