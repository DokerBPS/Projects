using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Xrm;
using System.Web.UI.HtmlControls;
using TW_PageForAttachFile.HelperClasses;

namespace TW_PageForAttachFile
{
    public partial class AttachFile : System.Web.UI.Page
    {
        private Guid _propertyId = Guid.Empty;
        private Guid _attachmentId = Guid.Empty;

        const int MaxTotalBytes = 10485760; // 1 MB
        long totalBytes;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Enctype = "multipart/form-data";
            lbl_ErrorMessage.Text = string.Empty;
            try
            {
                //var xrm = new XrmServiceContext("Xrm");

                txbx_Name.Style.Clear();
                file_upload.Style.Clear();
                DropDownList1.Style.Clear();
                string notAvailableExtensions = "ade;adp;app;asa;ashx;asmx;asp;bas;bat;cdx;cer;chm;class;cmd;com;config;cpl;crt;csh;dll;exe;fxp;hlp;hta;htr;htw;ida;idc;idq;inf;ins;isp;its;js;jse;ksh;lnk;mad;maf;mag;mam;maq;mar;mas;mat;mau;mav;maw;mda;mdb;mde;mdt;mdw;mdz;msc;msh;msh1;msh1xml;msh2;msh2xml;mshxml;msi;msp;mst;ops;pcd;pif;prf;prg;printer;pst;reg;rem;scf;scr;sct;shb;shs;shtm;shtml;soap;stm;tmp;url;vb;vbe;vbs;vsmacros;vss;vst;vsw;ws;wsc;wsf;wsh";

                #region Verify browserType (version, ex. IE8 IE9 IE10 Internet Explorer 11)
                ////string uploadifyScript = "<script type='text/javascript' language='javascript'>setUploadify();</script>";
                //LiteralControl uploadifyScript = new LiteralControl(
                //    "<script type=\"text/javascript\" language=\"javascript\"> "
                //    +   "$(function () {" 
                //    +   "$(\"#file_upload\").uploadify({"
                //    +   "'swf': 'scripts/uploadify.swf',"
                //    +   "'uploader': 'Upload.ashx',"
                //    +   "'multi': false,"
                //    +   "'fileSizeLimit': '500MB',"
                //    +   "'successTimeout': 72000,"
                //    +   "'auto': true,"
                //    +   "'width': 84,"
                //    +   "'height': 18"
                //    +   "});    });"
                //    +   "</script>");

                //bool isIE = false;

                //var browser = Request.Browser;
                //if (browser.Type.Equals("IE10") || browser.Type.Equals("IE9") || browser.Type.Equals("IE8") || browser.Type.Equals("IE7") || browser.Type.Equals("IE6"))
                //{
                //    Page.Header.Controls.Add(uploadifyScript);
                //    //RegisterClientScriptBlock("clientScript", uploadifyScript);
                //    isIE = true;
                //}
                #endregion

                if (!GetParamFromUrl())
                {
                    RegisterClientScriptBlock("clientScript", "<script> alert('Invalid Property ID! Verify Property ID');</script>");
                    DisableControls();
                    return;
                }

                if (Page.IsPostBack)
                {
                    string message = "Fix the following errors: ";
                    bool showError = false;

                    #region Verify fileds values
                    if (txbx_Name.Value == string.Empty)
                    {
                        message += " Name is not valid;";
                        showError = true;
                        txbx_Name.Style.Add("border", "1px solid red");
                    }

                    string extension = string.Empty;

                    /*Verify if user used IE8*/
                    //if (isIE)
                    //{
                    //    #region Work with .ashx
                    //    WorkWithIE8(notAvailableExtensions, ref message, ref showError, ref extension);
                    //    #endregion
                    //}
                    //else
                    //{
                    #region Work with FileUpload
                    WorkWithoutIE(notAvailableExtensions, ref message, ref showError, ref extension);
                    #endregion
                    //}
                    /*end verification*/
                    if (DropDownList1.SelectedValue == string.Empty)
                    {
                        message += " Choose attachment type;";
                        showError = true;
                        DropDownList1.Style.Add("border", "1px solid red");
                    }

                    if (showError)
                    {
                        ClientScript.RegisterStartupScript(
                                                        this.Page.GetType(),
                                                        "",
                                                        "alert('" + message + "');",
                                                        true);
                        return;
                    }
                    #endregion

                    #region Upload file to HDD in folder
                    /*string fn = System.IO.Path.GetFileName(uploadFile.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("~//App_Data//images") + "//" + fn;
                    try
                    {
                        uploadFile.PostedFile.SaveAs(SaveLocation);
                    }
                    catch (Exception ex)
                    {
                        lbl_ErrorMessage.Text = ex.Message;
                        RegisterClientScriptBlock("clientScript", "<script> alert('An error occurred while uploading files on the server!'); </script>");
                        //Note: Exception.Message returns detailed message that describes the current exception. 
                        //For security reasons, we do not recommend you return Exception.Message to end users in 
                        //production environments. It would be better just to put a generic error message. 
                    }*/
                    #endregion

                    //if (SaveValueInCrm(txbx_Name.Value, DropDownList1.SelectedIndex, xrm))
                    //{
                    if (CrmMethods.SaveValueInCrm(txbx_Name.Value, DropDownList1.SelectedIndex, ref _propertyId, ref _attachmentId))
                    {
                        //if (isIE)
                        //{
                        //    if (!AttachFileToWebSiteAttachment(Upload.PostedFile, xrm, txbx_Name.Value))
                        //        DeleteCreatedRecord(xrm, AttachmentID);
                        //}
                        //else
                        //{
                        //if (!AttachFileToWebSiteAttachment(file_upload.PostedFile, xrm, txbx_Name.Value))
                        if (!CrmMethods.AttachFileToWebSiteAttachment(file_upload.PostedFile, txbx_Name.Value, ref _attachmentId))
                        {
                            //DeleteCreatedRecord(xrm, AttachmentID);
                            CrmMethods.DeleteCreatedRecord(_attachmentId);
                        }
                        //}

                        ClientScript.RegisterStartupScript(
                         this.Page.GetType(),
                         "",
                         "window.close();",
                         true);
                    }
                }
                txbx_Name.Value = string.Empty;
                DropDownList1.ClearSelection();
            }
            catch (Exception ex)
            {
                lbl_ErrorMessage.Text = ex.Message;
            }
        }

        private void WorkWithoutIE(string notAvailableExtensions, ref string message, ref bool showError, ref string extension)
        {
            if (file_upload.PostedFile != null)
            {
                if (file_upload.PostedFile.FileName != string.Empty)
                {
                    extension = System.IO.Path.GetExtension(file_upload.PostedFile.FileName).Remove(0, 1);
                }

                if ((file_upload.PostedFile.FileName == string.Empty) && (file_upload.PostedFile.ContentLength == 0) || notAvailableExtensions.Contains(extension))
                {
                    message += " Choose valid file;";
                    showError = true;
                    file_upload.Style.Add("border", "1px solid red");
                }
            }
            else
            {
                message += " Choose file;";
                showError = true;
                file_upload.Style.Add("border", "1px solid red");
            }
        }

        private void WorkWithIE8(string notAvailableExtensions, ref string message, ref bool showError, ref string extension)
        {
            if (Upload.PostedFile != null)
            {
                if (Upload.PostedFile.FileName != string.Empty)
                {
                    extension = System.IO.Path.GetExtension(Upload.PostedFile.FileName).Remove(0, 1);
                }

                if ((Upload.PostedFile.FileName == string.Empty) && (Upload.PostedFile.ContentLength == 0) || notAvailableExtensions.Contains(extension))
                {
                    message += " Choose valid file;";
                    showError = true;
                    file_upload.Style.Add("border", "1px solid red");
                }

            }
            else
            {
                message += " Choose file;";
                showError = true;
                file_upload.Style.Add("border", "1px solid red");
            }
        }

        private void DisableControls()
        {
            txbx_Name.Disabled = true;
            DropDownList1.Enabled = false;
            file_upload.Enabled = false;
        }
        
        private bool GetParamFromUrl()
        {
            bool validID = false;
            try
            {
                int ParamCount = HttpContext.Current.Request.QueryString.Count;

                if (ParamCount <= 0)
                    return validID = false;

                for (int i = 0; i < ParamCount; i++)
                {
                    _propertyId = Guid.Parse(HttpContext.Current.Request.QueryString[i]);
                }
                validID = true;
            }
            catch
            {
                validID = false;
            }

            return validID;

        }

        #region Old Logic with credentials in web.config
        /// <summary>
        /// Delete record WebSiteAttachment if error ocurred when uploaded file
        /// </summary>
        /// <param name="xrm"></param>
        /// <param name="attachID"></param>
        private void DeleteCreatedRecord(XrmServiceContext xrm, Guid attachID)
        {
            xrm.Delete("dnl_customattachment", attachID);
        }

        /// <summary>
        /// Create record WebSiteAttachment 
        /// </summary>
        /// <param name="attachName"></param>
        /// <param name="attachType"></param>
        /// <param name="xrm"></param>
        /// <returns></returns>
        private bool SaveValueInCrm(string attachName, int attachType, XrmServiceContext xrm)
        {
            bool saveValue = false;
            try
            {
                Microsoft.Xrm.Sdk.Entity attachment = new Microsoft.Xrm.Sdk.Entity("dnl_customattachment");
                attachment.Attributes.Add("dnl_name", attachName);
                attachment.Attributes.Add("dnl_attachmenttype", new Microsoft.Xrm.Sdk.OptionSetValue(attachType));
                attachment.Attributes.Add("dnl_property", new Microsoft.Xrm.Sdk.EntityReference("awx_property", _propertyId));

                _attachmentId = xrm.Create(attachment);
                saveValue = true;
            }
            catch (Exception ex)
            {
                saveValue = false;
                lbl_ErrorMessage.Text = ex.Message + "\t" + ex.StackTrace;
            }

            return saveValue;
        }

        private bool AttachFileToWebSiteAttachment(HttpPostedFile uploadFile, XrmServiceContext xrm, string attachName)
        {
            bool attachComplete = true;
            try
            {
                #region Upload file from HDD (comment)
                // Open a file and read the contents into a byte array
                //FileStream stream = File.OpenRead(pathToFile);
                //byte[] byteData = new byte[stream.Length];
                //stream.Read(byteData, 0, byteData.Length);
                //stream.Close();
                #endregion

                // Get a reference to PostedFile object
                HttpPostedFile myFile = uploadFile;

                // Get size of uploaded file
                int nFileLen = myFile.ContentLength;

                // Allocate a buffer for reading of the file
                byte[] myData = new byte[nFileLen];

                // Read uploaded file from the Stream
                myFile.InputStream.Read(myData, 0, nFileLen);


                // Encode the data using base64.
                string encodedData = System.Convert.ToBase64String(myData);

                // Add the Note
                Annotation note = new Annotation();

                // Im going to add Note to Web site attachment entity
                note.ObjectId = new Microsoft.Xrm.Sdk.EntityReference("dnl_customattachment", _attachmentId);
                note.Subject = string.Format("File attach for {0}", attachName);

                // Set EncodedData to Document Body
                note.DocumentBody = encodedData;

                // Set the type of attachment
                note.MimeType = myFile.ContentType;

                // Set the File Name
                note.FileName = myFile.FileName;
                xrm.Create(note);
            }
            catch (Exception ex)
            {
                attachComplete = false;
                lbl_ErrorMessage.Text = ex.Message;
            }

            return attachComplete;
        }
        #endregion

    }
}