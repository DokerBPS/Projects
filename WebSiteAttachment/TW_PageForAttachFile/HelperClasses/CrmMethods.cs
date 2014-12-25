using Microsoft.Xrm.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Web;

using TW_PageForAttachFile.HelperClasses.Connection;

using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Xrm;

namespace TW_PageForAttachFile.HelperClasses
{
    public class CrmMethods
    {
        private static CrmConnection _connection;

        public CrmMethods()
        {
            CreateConnectionToCRM();
        }

        public static CrmConnection Connection
        {
            get
            {
                if (_connection != null) return _connection;

                CreateConnectionToCRM();
                return _connection;

            }
        }

        private static void CreateConnectionToCRM()
        {
            var cf = new ConfigSettings();
            cf.InitSettings();

            _connection = CrmConnection.Parse("Url=" + ConfigSettings.Url);
            _connection.ClientCredentials = new ClientCredentials();
            _connection.ClientCredentials.UserName.UserName = ConfigSettings.Login;
            _connection.ClientCredentials.UserName.Password = ConfigSettings.Password;
        }

        /// <summary>
        /// Delete record WebSiteAttachment if error ocurred when uploaded file
        /// </summary>
        /// <param name="attachID">Record ID for deleting</param>
        public static void DeleteCreatedRecord(Guid attachID)
        {
            using (var xrm = new XrmServiceContext(Connection))
            {
                xrm.Delete("dnl_customattachment", attachID);
            }
        }

        /// <summary>
        /// Create record WebSiteAttachment 
        /// </summary>
        /// <param name="attachName"></param>
        /// <param name="attachType"></param>
        /// <returns>Return true if websiteattachment created successfull</returns>
        public static bool SaveValueInCrm(string attachName, int attachType, ref Guid propertyID, ref Guid attachmentID)
        {
            using (var xrm = new XrmServiceContext(Connection))
            {
                bool saveValue = false;
                Microsoft.Xrm.Sdk.Entity attachment = new Microsoft.Xrm.Sdk.Entity("dnl_customattachment");
                attachment.Attributes.Add("dnl_name", attachName);
                attachment.Attributes.Add("dnl_attachmenttype", new Microsoft.Xrm.Sdk.OptionSetValue(attachType));
                attachment.Attributes.Add("dnl_property", new Microsoft.Xrm.Sdk.EntityReference("awx_property", propertyID));

                attachmentID = xrm.Create(attachment);

                if (attachmentID != Guid.Empty)
                    saveValue = true;

                return saveValue;
            }
        }

        /// <summary>
        /// Attach selected file to WebsiteAttachment
        /// </summary>
        /// <param name="uploadFile">Selected file</param>
        /// <param name="attachName">Name for websiteattachment</param>
        /// <param name="attachmentID">WebsiteAttachment ID</param>
        /// <returns>Return true if file attached successfull</returns>
        public static bool AttachFileToWebSiteAttachment(HttpPostedFile uploadFile, string attachName, ref Guid attachmentID)
        {
            using (var xrm = new XrmServiceContext(Connection))
            {
                bool attachComplete = false;
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
                note.ObjectId = new Microsoft.Xrm.Sdk.EntityReference("dnl_customattachment", attachmentID);
                note.Subject = string.Format("File attach for {0}", attachName);

                // Set EncodedData to Document Body
                note.DocumentBody = encodedData;

                // Set the type of attachment
                note.MimeType = myFile.ContentType;

                // Set the File Name
                note.FileName = myFile.FileName;

                if (xrm.Create(note) != Guid.Empty)
                    attachComplete = true;

                return attachComplete;
            }
        }
    }
}