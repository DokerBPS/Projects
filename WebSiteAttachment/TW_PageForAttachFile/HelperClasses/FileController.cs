using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TW_PageForAttachFile.HelperClasses
{
    /// <summary>
    /// Class for binding DragDropHandler with AttachFile
    /// </summary>
    public class FileController
    {
        /// <summary>
        /// File for upload
        /// </summary>
        public static HttpPostedFile PostedFile { get; set; }
    }
}