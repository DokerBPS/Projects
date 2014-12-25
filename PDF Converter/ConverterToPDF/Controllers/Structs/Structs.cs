using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterToPDF.Controllers.Structs
{
    public struct Document
    {
        public const string Word = "word";
        public const string Html = "html";
        public const string Excel = "excel";
    }

    public struct FileExtension
    {
        /// <summary>
        /// Word extension - .doc
        /// </summary>
        public const string Doc = ".doc";
        /// <summary>
        /// Word extension - .docx
        /// </summary>
        public const string Docx = ".docx";

        /// <summary>
        /// Excel extension - .xls
        /// </summary>
        public const string Xls = ".xls";
        /// <summary>
        /// Excel extension - .xlsx
        /// </summary>
        public const string Xlsx = ".xlsx";

        /// <summary>
        /// Html extension - .htm
        /// </summary>
        public const string Htm = ".htm";
        /// <summary>
        /// Html extension - .html
        /// </summary>
        public const string Html = ".html";
    }
}
