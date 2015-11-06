using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TW_PageForAttachFile.HelperClasses;

namespace TW_PageForAttachFile
{
    /// <summary>
    /// Сводное описание для DragDropHandler
    /// </summary>
    public class DragDropHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpFileCollection files = context.Request.Files;
            foreach (string key in files)
            {
                FileController.PostedFile = files[key];
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}