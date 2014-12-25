using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace TW_PageForAttachFile
{
    /// <summary>
    /// Сводное описание для Upload
    /// </summary>
    public class Upload : IHttpHandler
    {
        public static HttpPostedFile PostedFile { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile oFile = context.Request.Files["Filedata"];

            if (oFile != null)
            {
                PostedFile = oFile;
                /*
                const string sDirectory = "c:\\";
                if (!Directory.Exists(sDirectory))
                    Directory.CreateDirectory(sDirectory);

                oFile.SaveAs(Path.Combine(sDirectory, oFile.FileName));
                */
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
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