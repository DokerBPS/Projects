using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System.ServiceModel.Description;
using System.Net;
using Microsoft.Office.Interop.Outlook;
using System.ServiceModel.Security;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Drawing;
using Microsoft.Xrm.Sdk.Messages;

namespace OutlookImportUtility.Helpers
{
    public static class CrmMethods
    {
        #region Private Properties

        private static IOrganizationService orgService;
        private static List<Guid> crmIds = new List<Guid>();
        private static EntityCollection contactsInCrm = null;
        private static Guid currentUserId;

        #endregion

        #region Public Methods

        /// <summary>
        /// Set crm connection and create IOrganizationService
        /// </summary>
        /// <param name="crmUrl">Url to CRM</param>
        /// <param name="login">CRM Login</param>
        /// <param name="pass">CRM Password</param>
        /// <param name="_domain">Organization domain</param>
        public static void ConnectToCrm(string crmUrl, string login, string pass, string _domain)
        {
            #region Work with http
            //Uri organizationUri = new Uri(url);
            //Uri homeRealmUri = null;
            //ClientCredentials credentials = new ClientCredentials();
            //credentials.Windows.ClientCredential = new System.Net.NetworkCredential(userName, password, domain);

            //OrganizationServiceProxy orgProxy = new OrganizationServiceProxy(organizationUri, homeRealmUri, credentials, null);

            //// Get the IOrganizationService
            //IOrganizationService orgService = (IOrganizationService)orgProxy;

            ////Get OrganizationServiceContext -the organization service context class implements the IQueryable interface and
            ////a .NET Language-Integrated Query (LINQ) query provider so we can write LINQ queries against Microsoft Dynamics CRM data.
            //OrganizationServiceContext orgServiceContext = new OrganizationServiceContext(orgService);

            //return orgService;
            #endregion

            #region Work with https
            OrganizationServiceProxy serviceProxy;
            string uri = crmUrl;
            //string userName = EncDec.Decrypt(login, "abc");
            //string password = EncDec.Decrypt(pass, "abc");
            string userName = login;
            string password = pass;
            string domain = _domain;

            IServiceConfiguration<IOrganizationService> config = ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(new Uri(uri));

            if (config.AuthenticationType == AuthenticationProviderType.Federation)
            {
                // ADFS (IFD) Authentication
                ClientCredentials clientCred = new ClientCredentials();
                clientCred.UserName.UserName = userName;
                clientCred.UserName.Password = password;
                serviceProxy = new OrganizationServiceProxy(config, clientCred);
            }
            else
            {
                // On-Premise, non-IFD authentication
                ClientCredentials credentials = new ClientCredentials();
                credentials.Windows.ClientCredential = new NetworkCredential(userName, password, domain);
                serviceProxy = new OrganizationServiceProxy(new Uri(uri), null, credentials, null);
            }

            orgService = serviceProxy;

            GetCurrentUserId(login, _domain);
            #endregion
        }

        /// <summary>
        /// Get all contacts from outlook folder
        /// </summary>
        /// <returns>List of outlook contacts</returns>
        public static List<OutlookContact> GetOutlookContacts()
        {
            List<OutlookContact> outlookContacts = new List<OutlookContact>();

            var outlook = new Microsoft.Office.Interop.Outlook.Application();
            MAPIFolder folder = outlook.GetNamespace("MAPI").GetDefaultFolder(OlDefaultFolders.olFolderContacts);
            List<ContactItem> contacts = folder.Items.OfType<ContactItem>().ToList();

            foreach (dynamic cont in contacts)
            {
                foreach (var contProp in cont.UserProperties)
                {
                    if (contProp.Name == "crmid" && contProp.Value != "" && cont.Categories != "")
                    {
                        #region *Commented* Mapping all fields
                        //outlookContacts.Add(new OutlookContact(cont.FirstName, cont.LastName, cont.Email1Address,
                        //    cont.BusinessTelephoneNumber, cont.JobTitle, cont.CompanyName, cont.BusinessAddressCity,
                        //    cont.BusinessAddressCountry, cont.BusinessAddressPostalCode, cont.BusinessAddressState,
                        //    cont.BusinessAddressStreet, cont.Categories, contProp.Value));
                        #endregion

                        string pathToPic = GetContactPicturePath(cont);

                        // for testing
                        //for (int i = 0; i < 175; i++)
                        //{
                        //    outlookContacts.Add(new OutlookContact(cont.Categories, contProp.Value, cont.Body, pathToPic));
                        //    crmIds.Add(new Guid(contProp.Value));

                        //}
                        outlookContacts.Add(new OutlookContact(cont.Categories, contProp.Value, cont.Body, pathToPic));
                        crmIds.Add(new Guid(contProp.Value));
                        break;
                    }
                }
            }

            return outlookContacts;
        }

        /// <summary>
        /// Update contact in CRM 
        /// </summary>
        /// <param name="outlookConacts">Contacts from Outlook</param>
        public static bool UpdateContacts(OutlookContact outlookConact)
        {
            GetCrmContacts();
            if (contactsInCrm == null)
                return false;

            //var contact = contactsInCrm.Entities.Select(cont => Guid.Parse(cont.Attributes["ownerid"].ToString()) == currentUserId);
            var contact = (from cont in contactsInCrm.Entities
                           where Guid.Parse(cont.Attributes["contactid"].ToString()) == outlookConact.CrmId
                           select cont).ToList();

            if (contact == null || contact.Count == 0)
                return false;

            var ownerId = ((EntityReference)contact[0].Attributes["ownerid"]).Id;

            string contactDesc = string.Empty;
            Guid awx_imageId = Guid.Empty;

            if (contact[0].Attributes.Contains("description"))
                contactDesc = contact[0].Attributes["description"].ToString();

            if (contact[0].Attributes.Contains("dnl_contactphoto"))
                CreateAnnotationForImage(((EntityReference)contact[0].Attributes["dnl_contactphoto"]).Id, outlookConact.PathToPicture);
            else
                awx_imageId = CreateImageForContact(outlookConact.PathToPicture);

            if (ownerId == currentUserId)
            {
                return PrepareContact(outlookConact, contactDesc, awx_imageId);
            }
            else
            {
                AddCurrentUserToContactContributor(contact[0]);
                return PrepareContact(outlookConact, contactDesc, awx_imageId);
            }
        }

        /// <summary>
        /// Clean temp directory. Delete saved photo for outlook contact 
        /// </summary>
        public static void CleanupContactPictures()
        {
            foreach (string picturePath in Directory.GetFiles(Path.GetTempPath(), "ContactPic_*.jpg"))
            {
                try
                {
                    File.Delete(picturePath);
                }
                catch
                {
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get outlook contact photo
        /// </summary>
        /// <param name="contact">Outlook contact for retrieve photo</param>
        /// <returns>Return path to photo for outlook contact which saved in temp folder</returns>
        private static string GetContactPicturePath(ContactItem contact)
        {
            string picturePath = "";
            string path = Path.GetTempPath();//get system temp path
            if (contact.HasPicture)
            {
                foreach (Attachment att in contact.Attachments)
                {
                    if (att.DisplayName == "ContactPicture.jpg")
                    {
                        try
                        {
                            picturePath = Path.GetDirectoryName(path) + "\\ContactPic_" + contact.FileAs + ".jpg";
                            if (!File.Exists(picturePath))
                                att.SaveAsFile(picturePath);
                        }
                        catch
                        {
                            picturePath = "";
                        }
                    }
                }
            }

            return picturePath;
        }

        /// <summary>
        /// Create image entity for contact in crm. 
        /// </summary>
        /// <param name="path">Path to contact photo</param>
        /// <returns>Return ID created image</returns>
        private static Guid CreateImageForContact(string path)
        {
            FileInfo image = null;
            Guid awx_imageId = Guid.Empty;

            if ((path != "") && (File.Exists(path)))
            {
                image = new FileInfo(path);

                Entity awx_image = new Entity("awx_image");
                awx_image.Attributes["awx_title"] = image.Name;
                awx_image.Attributes["awx_filename"] = image.Name;
                awx_image.Attributes["awx_size"] = (int)image.Length;
                awx_image.Attributes["awx_mimetype"] = image.Extension;

                awx_imageId = CreateRecord(awx_image);

                if (awx_imageId != Guid.Empty)
                    CreateAnnotationForImage(awx_imageId, path);
            }

            return awx_imageId;
        }

        /// <summary>
        /// Create note for image in crm.
        /// </summary>
        /// <param name="awx_imageId">Image ID</param>
        /// <param name="imagePath">Path to contact photo</param>
        private static void CreateAnnotationForImage(Guid awx_imageId, string imagePath)
        {
            if (imagePath == "")
                return;

            QueryExpression query = new QueryExpression { EntityName = "annotation", ColumnSet = new ColumnSet(true) };
            query.Criteria.AddCondition("objectid", ConditionOperator.Equal, awx_imageId);
            EntityCollection notesRetrieved = RetrieveMultipleRecords(query);

            if (notesRetrieved != null)
            {
                foreach (var note in notesRetrieved.Entities)
                {
                    DeleteRecord(note.LogicalName, note.Id);
                }
            }

            // Open a file and read the contents into a byte array
            FileStream stream = File.OpenRead(imagePath);
            byte[] byteData = new byte[stream.Length];
            stream.Read(byteData, 0, byteData.Length);
            stream.Close();

            // Encode the data using base64.
            string encodedData = System.Convert.ToBase64String(byteData);

            Entity annotation = new Entity("annotation");
            FileInfo fileInfo = new FileInfo(imagePath);
            annotation.Attributes["subject"] = "original";
            annotation.Attributes["filename"] = fileInfo.Name;
            annotation.Attributes["documentbody"] = encodedData;
            annotation.Attributes["filesize"] = (int)fileInfo.Length;

            // rather pass the actual type
            annotation.Attributes["mimetype"] = GetMimeType(imagePath);
            annotation.Attributes["objectid"] = new EntityReference("awx_image", awx_imageId);

            CreateRecord(annotation);
        }

        /// <summary>
        /// Prepare record before updating in CRM
        /// </summary>
        /// <param name="outlookContact">Contact from Outlook</param>
        private static bool PrepareContact(OutlookContact outlookContact, string contactDesc, Guid awx_imageId)
        {
            if (outlookContact.CrmId != Guid.Empty)
            {

                #region *Commented* Mapping all fields
                //Entity crmContact = GetContactById(contact.CrmId);
                //if (crmContact == null)
                //    return false;

                //crmContact.Attributes["firstname"] = contact.FirstName;
                //crmContact.Attributes["lastname"] = contact.LastName;
                //crmContact.Attributes["emailaddress1"] = contact.Email;
                //crmContact.Attributes["telephone1"] = contact.Phone;
                //crmContact.Attributes["jobtitle"] = contact.JobTitle;
                //crmContact.Attributes["address1_line1"] = contact.Street;
                //crmContact.Attributes["address1_city"] = contact.City;
                //crmContact.Attributes["address1_stateorprovince"] = contact.State;
                //crmContact.Attributes["address1_postalcode"] = contact.PostalCode;
                //crmContact.Attributes["address1_country"] = contact.Country;
                #endregion

                Entity crmContact = new Entity("contact");
                crmContact.Id = outlookContact.CrmId;
                crmContact.Attributes["awx_contactstatus"] = new OptionSetValue((int)outlookContact.Category);

                if (awx_imageId != Guid.Empty)
                    crmContact.Attributes["dnl_contactphoto"] = new EntityReference("awx_image", awx_imageId);

                try
                {
                    if (outlookContact.Notes != string.Empty)
                    {
                        if (contactDesc != string.Empty && IsEqualString(contactDesc, outlookContact.Notes))
                            crmContact.Attributes["description"] = string.Empty;

                        CreateNotesForContact(crmContact, outlookContact.Notes);
                    }

                    UpdateRecord(crmContact);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Checks whether the strings are equal
        /// </summary>
        /// <param name="contactDesc">First string</param>
        /// <param name="outlookNotes">Second string</param>
        /// <returns>Return "true" if strings equals else return "false"</returns>
        private static bool IsEqualString(string contactDesc, string outlookNotes)
        {
            contactDesc = contactDesc.Replace("\n", "").Replace("\t", "").Replace("\r", "");
            outlookNotes = outlookNotes.Replace("\n", "").Replace("\t", "").Replace("\r", "");

            return contactDesc.Equals(outlookNotes);
        }

        /// <summary>
        /// Create conenction for cotnact
        /// </summary>
        /// <param name="contact"></param>
        private static void AddCurrentUserToContactContributor(Entity contact)
        {
            if (GetConnectionForContact(currentUserId, contact.Id))
                return;

            Entity connection = new Entity("connection");
            connection.Attributes["record1id"] = new EntityReference("contact", contact.Id);
            /*As this role - Contributed by - record1roleid - 2BB209D2-6D14-E111-A170-000C290B0E27*/
            connection.Attributes["record1roleid"] = new EntityReference("connectionrole", Guid.Parse("2BB209D2-6D14-E111-A170-000C290B0E27"));

            /*Name - record2id - currentUserId*/
            connection.Attributes["record2id"] = new EntityReference("systemuser", currentUserId);

            /*As this role - Contributor - record2roleid - 3357CAF5-6D14-E111-A170-000C290B0E27*/
            connection.Attributes["record2roleid"] = new EntityReference("connectionrole", Guid.Parse("3357CAF5-6D14-E111-A170-000C290B0E27"));
            connection.Attributes["ownerid"] = new EntityReference("team", Guid.Parse("016F88F2-7914-E211-B575-00155D01ED23"));
            connection.Attributes["awx_primary"] = true;

            orgService.Create(connection);
        }

        /// <summary>
        /// Get connection for contact 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <returns>If connection exist in CRM return true, else return false</returns>
        private static bool GetConnectionForContact(Guid userId, Guid contactId)
        {
            var query = new QueryExpression
            {
                ColumnSet = new ColumnSet(true),
                EntityName = "connection",
                Criteria = new FilterExpression
                {
                    FilterOperator = LogicalOperator.And,
                    Conditions =
                                        {
                                            new ConditionExpression("record2id", ConditionOperator.Equal, userId),
                                            new ConditionExpression("record1id", ConditionOperator.Equal, contactId)
                                        }

                }
            };
            var response = orgService.RetrieveMultiple(query).Entities.FirstOrDefault();

            if (response != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get contact from CRM by Id from outlook
        /// </summary>
        /// <param name="contactId">Contact ID</param>
        /// <returns>Found contact</returns>
        private static Entity GetContactById(Guid contactId)
        {
            var query = new QueryExpression
            {
                ColumnSet = new ColumnSet(true),
                EntityName = "contact",
                Criteria = new FilterExpression
                {
                    FilterOperator = LogicalOperator.And,
                    Conditions =
                                        {
                                            new ConditionExpression("contactid", ConditionOperator.Equal, contactId)
                                        }

                }
            };
            return orgService.RetrieveMultiple(query).Entities.FirstOrDefault();
        }

        /// <summary>
        /// Get current user id by login and domain
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="_domain">Domain</param>
        private static void GetCurrentUserId(string login, string _domain)
        {
            var query = new QueryExpression
            {
                ColumnSet = new ColumnSet(true),
                EntityName = "systemuser",
                Criteria = new FilterExpression
                {
                    FilterOperator = LogicalOperator.And,
                    Conditions =
                                        {
                                            new ConditionExpression("domainname", ConditionOperator.Equal, _domain + @"\" + login)
                                        }

                }
            };
            var user = orgService.RetrieveMultiple(query).Entities.FirstOrDefault();
            currentUserId = Guid.Parse(user.Attributes["systemuserid"].ToString());
        }

        /// <summary>
        /// Get all contacts from CRM by crmId from Outlook
        /// </summary>
        /// <returns>Collections retrived records</returns>
        private static void GetCrmContacts()
        {
            if (contactsInCrm != null)
                return;

            contactsInCrm = new EntityCollection();

            //  Query using the paging cookie.
            // Define the paging attributes.
            // The number of records per page to retrieve.
            int fetchCount = 1;
            // Initialize the page number.
            int pageNumber = 1;
            // Initialize the number of records.
            int recordCount = 0;

            #region Conditions
            // Define the condition expression for retrieving records.
            ConditionExpression pagecondition = new ConditionExpression();
            pagecondition.AttributeName = "contactid";
            pagecondition.Operator = ConditionOperator.Equal;
            #endregion

            // Create the query expression and add condition.
            QueryExpression pagequery = new QueryExpression();
            pagequery.EntityName = "contact";
            pagequery.ColumnSet = new ColumnSet(true);

            // Assign the pageinfo properties to the query expression.
            pagequery.PageInfo = new PagingInfo();
            pagequery.PageInfo.Count = fetchCount;
            pagequery.PageInfo.PageNumber = pageNumber;

            // The current paging cookie. When retrieving the first page, 
            // pagingCookie should be null.
            pagequery.PageInfo.PagingCookie = null;

            foreach (var contactId in crmIds)
            {
                pagecondition.Values.Add(contactId);
                pagequery.Criteria.AddCondition(pagecondition);

                var response = orgService.RetrieveMultiple(pagequery);
                contactsInCrm.Entities.AddRange(response.Entities);
                pagecondition.Values.Clear();
            }
        }

        /// <summary>
        /// Get all contacts from CRM by crmId from Outlook
        /// </summary>
        /// <returns>Collections retrived records</returns>
        private static void GetCrmContacts2()
        {
            if (contactsInCrm != null)
                return;

            EntityCollection requestCollection = new EntityCollection();
            contactsInCrm = new EntityCollection();


            try
            {
                QueryExpression quey = new QueryExpression
                {
                    EntityName = "contact",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression()
                };

                quey.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);

                int pageNumber = 1;
                RetrieveMultipleRequest multiRequest;
                RetrieveMultipleResponse multiResponse = new RetrieveMultipleResponse();

                do
                {
                    quey.PageInfo.Count = 4000;
                    quey.PageInfo.PagingCookie = (pageNumber == 1) ? null : multiResponse.EntityCollection.PagingCookie;
                    quey.PageInfo.PageNumber = pageNumber++;

                    multiRequest = new RetrieveMultipleRequest();
                    multiRequest.Query = quey;
                    multiResponse = (RetrieveMultipleResponse)orgService.Execute(multiRequest);

                    requestCollection.Entities.AddRange(multiResponse.EntityCollection.Entities);
                }
                while (multiResponse.EntityCollection.MoreRecords);

                foreach (var crmId in crmIds)
                {
                    contactsInCrm.Entities.AddRange(
                        (from cont in requestCollection.Entities
                         where Guid.Parse(cont.Attributes["contactid"].ToString()) == crmId
                         select cont).ToList()
                        );
                }
            }
            catch (System.Exception ex)
            {
                contactsInCrm = null;
            }
        }

        /// <summary>
        /// Create Notes for crm contact from outlook contact
        /// </summary>
        /// <param name="crmContact">Contact in CRM</param>
        /// <param name="outlookContact">Notes from Outlook contact</param>
        private static void CreateNotesForContact(Entity crmContact, string notes)
        {
            //retrieve annotation for crmContact
            QueryExpression query = new QueryExpression { EntityName = "annotation", ColumnSet = new ColumnSet(true) };
            query.Criteria.AddCondition("notetext", ConditionOperator.Equal, notes);
            EntityCollection notesRetrieved = RetrieveMultipleRecords(query);

            if (notesRetrieved.Entities.Count == 0)
            {
                //Create Note 
                Entity annotation = new Entity("annotation");
                annotation.Attributes["objectid"] = new EntityReference(crmContact.LogicalName, crmContact.Id);
                annotation.Attributes["objecttypecode"] = "contact";
                annotation.Attributes["subject"] = "Imported from Outlook";
                annotation.Attributes["notetext"] = notes;
                //annotation.Attributes["overriddencreatedon"] = DateTime.Parse(DateTime.Now.ToString(), new CultureInfo("en-US", false));

                CreateRecord(annotation);
            }
        }

        #region CRUD CRM operation

        /// <summary>
        /// Update record in CRM
        /// </summary>
        /// <param name="crmContact">Record for update</param>
        private static void UpdateRecord(Entity record)
        {
            orgService.Update(record);
        }

        /// <summary>
        /// Create record in CRM
        /// </summary>
        /// <param name="crmContact">Record for create</param>
        private static Guid CreateRecord(Entity record)
        {
            return orgService.Create(record);
        }

        /// <summary>
        /// Delete record from CRM
        /// </summary>
        /// <param name="recordName">Logical name of entity</param>
        /// <param name="recordId">Record ID for delete</param>
        private static void DeleteRecord(string recordName, Guid recordId)
        {
            orgService.Delete(recordName, recordId);
        }

        /// <summary>
        /// Retrieve multiple records from CRM
        /// </summary>
        /// <param name="crmContact">Query for retrieve</param>
        private static EntityCollection RetrieveMultipleRecords(QueryExpression query)
        {
            return orgService.RetrieveMultiple(query);
        }

        #endregion

        /// <summary>
        /// Get MIME type for any files
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Return MIME type</returns>
        private static string GetMimeType(string fileName)
        {
            string mimeType;

            switch (System.IO.Path.GetExtension(fileName).ToLower())
            {
                case ".3dm": mimeType = "x-world/x-3dmf"; break;
                case ".3dmf": mimeType = "x-world/x-3dmf"; break;
                case ".a": mimeType = "application/octet-stream"; break;
                case ".aab": mimeType = "application/x-authorware-bin"; break;
                case ".aam": mimeType = "application/x-authorware-map"; break;
                case ".aas": mimeType = "application/x-authorware-seg"; break;
                case ".abc": mimeType = "text/vnd.abc"; break;
                case ".acgi": mimeType = "text/html"; break;
                case ".afl": mimeType = "video/animaflex"; break;
                case ".ai": mimeType = "application/postscript"; break;
                case ".aif": mimeType = "audio/aiff"; break;
                case ".aifc": mimeType = "audio/aiff"; break;
                case ".aiff": mimeType = "audio/aiff"; break;
                case ".aim": mimeType = "application/x-aim"; break;
                case ".aip": mimeType = "text/x-audiosoft-intra"; break;
                case ".ani": mimeType = "application/x-navi-animation"; break;
                case ".aos": mimeType = "application/x-nokia-9000-communicator-add-on-software"; break;
                case ".aps": mimeType = "application/mime"; break;
                case ".arc": mimeType = "application/octet-stream"; break;
                case ".arj": mimeType = "application/arj"; break;
                case ".art": mimeType = "image/x-jg"; break;
                case ".asf": mimeType = "video/x-ms-asf"; break;
                case ".asm": mimeType = "text/x-asm"; break;
                case ".asp": mimeType = "text/asp"; break;
                case ".asx": mimeType = "video/x-ms-asf"; break;
                case ".au": mimeType = "audio/basic"; break;
                case ".avi": mimeType = "video/avi"; break;
                case ".avs": mimeType = "video/avs-video"; break;
                case ".bcpio": mimeType = "application/x-bcpio"; break;
                case ".bin": mimeType = "application/octet-stream"; break;
                case ".bm": mimeType = "image/bmp"; break;
                case ".bmp": mimeType = "image/bmp"; break;
                case ".boo": mimeType = "application/book"; break;
                case ".book": mimeType = "application/book"; break;
                case ".boz": mimeType = "application/x-bzip2"; break;
                case ".bsh": mimeType = "application/x-bsh"; break;
                case ".bz": mimeType = "application/x-bzip"; break;
                case ".bz2": mimeType = "application/x-bzip2"; break;
                case ".c": mimeType = "text/plain"; break;
                case ".c++": mimeType = "text/plain"; break;
                case ".cat": mimeType = "application/vnd.ms-pki.seccat"; break;
                case ".cc": mimeType = "text/plain"; break;
                case ".ccad": mimeType = "application/clariscad"; break;
                case ".cco": mimeType = "application/x-cocoa"; break;
                case ".cdf": mimeType = "application/cdf"; break;
                case ".cer": mimeType = "application/pkix-cert"; break;
                case ".cha": mimeType = "application/x-chat"; break;
                case ".chat": mimeType = "application/x-chat"; break;
                case ".class": mimeType = "application/java"; break;
                case ".com": mimeType = "application/octet-stream"; break;
                case ".conf": mimeType = "text/plain"; break;
                case ".cpio": mimeType = "application/x-cpio"; break;
                case ".cpp": mimeType = "text/x-c"; break;
                case ".cpt": mimeType = "application/x-cpt"; break;
                case ".crl": mimeType = "application/pkcs-crl"; break;
                case ".crt": mimeType = "application/pkix-cert"; break;
                case ".csh": mimeType = "application/x-csh"; break;
                case ".css": mimeType = "text/css"; break;
                case ".cxx": mimeType = "text/plain"; break;
                case ".dcr": mimeType = "application/x-director"; break;
                case ".deepv": mimeType = "application/x-deepv"; break;
                case ".def": mimeType = "text/plain"; break;
                case ".der": mimeType = "application/x-x509-ca-cert"; break;
                case ".dif": mimeType = "video/x-dv"; break;
                case ".dir": mimeType = "application/x-director"; break;
                case ".dl": mimeType = "video/dl"; break;
                case ".doc": mimeType = "application/msword"; break;
                case ".dot": mimeType = "application/msword"; break;
                case ".dp": mimeType = "application/commonground"; break;
                case ".drw": mimeType = "application/drafting"; break;
                case ".dump": mimeType = "application/octet-stream"; break;
                case ".dv": mimeType = "video/x-dv"; break;
                case ".dvi": mimeType = "application/x-dvi"; break;
                case ".dwf": mimeType = "model/vnd.dwf"; break;
                case ".dwg": mimeType = "image/vnd.dwg"; break;
                case ".dxf": mimeType = "image/vnd.dwg"; break;
                case ".dxr": mimeType = "application/x-director"; break;
                case ".el": mimeType = "text/x-script.elisp"; break;
                case ".elc": mimeType = "application/x-elc"; break;
                case ".env": mimeType = "application/x-envoy"; break;
                case ".eps": mimeType = "application/postscript"; break;
                case ".es": mimeType = "application/x-esrehber"; break;
                case ".etx": mimeType = "text/x-setext"; break;
                case ".evy": mimeType = "application/envoy"; break;
                case ".exe": mimeType = "application/octet-stream"; break;
                case ".f": mimeType = "text/plain"; break;
                case ".f77": mimeType = "text/x-fortran"; break;
                case ".f90": mimeType = "text/plain"; break;
                case ".fdf": mimeType = "application/vnd.fdf"; break;
                case ".fif": mimeType = "image/fif"; break;
                case ".fli": mimeType = "video/fli"; break;
                case ".flo": mimeType = "image/florian"; break;
                case ".flx": mimeType = "text/vnd.fmi.flexstor"; break;
                case ".fmf": mimeType = "video/x-atomic3d-feature"; break;
                case ".for": mimeType = "text/x-fortran"; break;
                case ".fpx": mimeType = "image/vnd.fpx"; break;
                case ".frl": mimeType = "application/freeloader"; break;
                case ".funk": mimeType = "audio/make"; break;
                case ".g": mimeType = "text/plain"; break;
                case ".g3": mimeType = "image/g3fax"; break;
                case ".gif": mimeType = "image/gif"; break;
                case ".gl": mimeType = "video/gl"; break;
                case ".gsd": mimeType = "audio/x-gsm"; break;
                case ".gsm": mimeType = "audio/x-gsm"; break;
                case ".gsp": mimeType = "application/x-gsp"; break;
                case ".gss": mimeType = "application/x-gss"; break;
                case ".gtar": mimeType = "application/x-gtar"; break;
                case ".gz": mimeType = "application/x-gzip"; break;
                case ".gzip": mimeType = "application/x-gzip"; break;
                case ".h": mimeType = "text/plain"; break;
                case ".hdf": mimeType = "application/x-hdf"; break;
                case ".help": mimeType = "application/x-helpfile"; break;
                case ".hgl": mimeType = "application/vnd.hp-hpgl"; break;
                case ".hh": mimeType = "text/plain"; break;
                case ".hlb": mimeType = "text/x-script"; break;
                case ".hlp": mimeType = "application/hlp"; break;
                case ".hpg": mimeType = "application/vnd.hp-hpgl"; break;
                case ".hpgl": mimeType = "application/vnd.hp-hpgl"; break;
                case ".hqx": mimeType = "application/binhex"; break;
                case ".hta": mimeType = "application/hta"; break;
                case ".htc": mimeType = "text/x-component"; break;
                case ".htm": mimeType = "text/html"; break;
                case ".html": mimeType = "text/html"; break;
                case ".htmls": mimeType = "text/html"; break;
                case ".htt": mimeType = "text/webviewhtml"; break;
                case ".htx": mimeType = "text/html"; break;
                case ".ice": mimeType = "x-conference/x-cooltalk"; break;
                case ".ico": mimeType = "image/x-icon"; break;
                case ".idc": mimeType = "text/plain"; break;
                case ".ief": mimeType = "image/ief"; break;
                case ".iefs": mimeType = "image/ief"; break;
                case ".iges": mimeType = "application/iges"; break;
                case ".igs": mimeType = "application/iges"; break;
                case ".ima": mimeType = "application/x-ima"; break;
                case ".imap": mimeType = "application/x-httpd-imap"; break;
                case ".inf": mimeType = "application/inf"; break;
                case ".ins": mimeType = "application/x-internett-signup"; break;
                case ".ip": mimeType = "application/x-ip2"; break;
                case ".isu": mimeType = "video/x-isvideo"; break;
                case ".it": mimeType = "audio/it"; break;
                case ".iv": mimeType = "application/x-inventor"; break;
                case ".ivr": mimeType = "i-world/i-vrml"; break;
                case ".ivy": mimeType = "application/x-livescreen"; break;
                case ".jam": mimeType = "audio/x-jam"; break;
                case ".jav": mimeType = "text/plain"; break;
                case ".java": mimeType = "text/plain"; break;
                case ".jcm": mimeType = "application/x-java-commerce"; break;
                case ".jfif": mimeType = "image/jpeg"; break;
                case ".jfif-tbnl": mimeType = "image/jpeg"; break;
                case ".jpe": mimeType = "image/jpeg"; break;
                case ".jpeg": mimeType = "image/jpeg"; break;
                case ".jpg": mimeType = "image/jpeg"; break;
                case ".jps": mimeType = "image/x-jps"; break;
                case ".js": mimeType = "application/x-javascript"; break;
                case ".jut": mimeType = "image/jutvision"; break;
                case ".kar": mimeType = "audio/midi"; break;
                case ".ksh": mimeType = "application/x-ksh"; break;
                case ".la": mimeType = "audio/nspaudio"; break;
                case ".lam": mimeType = "audio/x-liveaudio"; break;
                case ".latex": mimeType = "application/x-latex"; break;
                case ".lha": mimeType = "application/octet-stream"; break;
                case ".lhx": mimeType = "application/octet-stream"; break;
                case ".list": mimeType = "text/plain"; break;
                case ".lma": mimeType = "audio/nspaudio"; break;
                case ".log": mimeType = "text/plain"; break;
                case ".lsp": mimeType = "application/x-lisp"; break;
                case ".lst": mimeType = "text/plain"; break;
                case ".lsx": mimeType = "text/x-la-asf"; break;
                case ".ltx": mimeType = "application/x-latex"; break;
                case ".lzh": mimeType = "application/octet-stream"; break;
                case ".lzx": mimeType = "application/octet-stream"; break;
                case ".m": mimeType = "text/plain"; break;
                case ".m1v": mimeType = "video/mpeg"; break;
                case ".m2a": mimeType = "audio/mpeg"; break;
                case ".m2v": mimeType = "video/mpeg"; break;
                case ".m3u": mimeType = "audio/x-mpequrl"; break;
                case ".man": mimeType = "application/x-troff-man"; break;
                case ".map": mimeType = "application/x-navimap"; break;
                case ".mar": mimeType = "text/plain"; break;
                case ".mbd": mimeType = "application/mbedlet"; break;
                case ".mc$": mimeType = "application/x-magic-cap-package-1.0"; break;
                case ".mcd": mimeType = "application/mcad"; break;
                case ".mcf": mimeType = "text/mcf"; break;
                case ".mcp": mimeType = "application/netmc"; break;
                case ".me": mimeType = "application/x-troff-me"; break;
                case ".mht": mimeType = "message/rfc822"; break;
                case ".mhtml": mimeType = "message/rfc822"; break;
                case ".mid": mimeType = "audio/midi"; break;
                case ".midi": mimeType = "audio/midi"; break;
                case ".mif": mimeType = "application/x-mif"; break;
                case ".mime": mimeType = "message/rfc822"; break;
                case ".mjf": mimeType = "audio/x-vnd.audioexplosion.mjuicemediafile"; break;
                case ".mjpg": mimeType = "video/x-motion-jpeg"; break;
                case ".mm": mimeType = "application/base64"; break;
                case ".mme": mimeType = "application/base64"; break;
                case ".mod": mimeType = "audio/mod"; break;
                case ".moov": mimeType = "video/quicktime"; break;
                case ".mov": mimeType = "video/quicktime"; break;
                case ".movie": mimeType = "video/x-sgi-movie"; break;
                case ".mp2": mimeType = "audio/mpeg"; break;
                case ".mp3": mimeType = "audio/mpeg"; break;
                case ".mpa": mimeType = "audio/mpeg"; break;
                case ".mpc": mimeType = "application/x-project"; break;
                case ".mpe": mimeType = "video/mpeg"; break;
                case ".mpeg": mimeType = "video/mpeg"; break;
                case ".mpg": mimeType = "video/mpeg"; break;
                case ".mpga": mimeType = "audio/mpeg"; break;
                case ".mpp": mimeType = "application/vnd.ms-project"; break;
                case ".mpt": mimeType = "application/vnd.ms-project"; break;
                case ".mpv": mimeType = "application/vnd.ms-project"; break;
                case ".mpx": mimeType = "application/vnd.ms-project"; break;
                case ".mrc": mimeType = "application/marc"; break;
                case ".ms": mimeType = "application/x-troff-ms"; break;
                case ".mv": mimeType = "video/x-sgi-movie"; break;
                case ".my": mimeType = "audio/make"; break;
                case ".mzz": mimeType = "application/x-vnd.audioexplosion.mzz"; break;
                case ".nap": mimeType = "image/naplps"; break;
                case ".naplps": mimeType = "image/naplps"; break;
                case ".nc": mimeType = "application/x-netcdf"; break;
                case ".ncm": mimeType = "application/vnd.nokia.configuration-message"; break;
                case ".nif": mimeType = "image/x-niff"; break;
                case ".niff": mimeType = "image/x-niff"; break;
                case ".nix": mimeType = "application/x-mix-transfer"; break;
                case ".nsc": mimeType = "application/x-conference"; break;
                case ".nvd": mimeType = "application/x-navidoc"; break;
                case ".o": mimeType = "application/octet-stream"; break;
                case ".oda": mimeType = "application/oda"; break;
                case ".omc": mimeType = "application/x-omc"; break;
                case ".omcd": mimeType = "application/x-omcdatamaker"; break;
                case ".omcr": mimeType = "application/x-omcregerator"; break;
                case ".p": mimeType = "text/x-pascal"; break;
                case ".p10": mimeType = "application/pkcs10"; break;
                case ".p12": mimeType = "application/pkcs-12"; break;
                case ".p7a": mimeType = "application/x-pkcs7-signature"; break;
                case ".p7c": mimeType = "application/pkcs7-mime"; break;
                case ".p7m": mimeType = "application/pkcs7-mime"; break;
                case ".p7r": mimeType = "application/x-pkcs7-certreqresp"; break;
                case ".p7s": mimeType = "application/pkcs7-signature"; break;
                case ".part": mimeType = "application/pro_eng"; break;
                case ".pas": mimeType = "text/pascal"; break;
                case ".pbm": mimeType = "image/x-portable-bitmap"; break;
                case ".pcl": mimeType = "application/vnd.hp-pcl"; break;
                case ".pct": mimeType = "image/x-pict"; break;
                case ".pcx": mimeType = "image/x-pcx"; break;
                case ".pdb": mimeType = "chemical/x-pdb"; break;
                case ".pdf": mimeType = "application/pdf"; break;
                case ".pfunk": mimeType = "audio/make"; break;
                case ".pgm": mimeType = "image/x-portable-greymap"; break;
                case ".pic": mimeType = "image/pict"; break;
                case ".pict": mimeType = "image/pict"; break;
                case ".pkg": mimeType = "application/x-newton-compatible-pkg"; break;
                case ".pko": mimeType = "application/vnd.ms-pki.pko"; break;
                case ".pl": mimeType = "text/plain"; break;
                case ".plx": mimeType = "application/x-pixclscript"; break;
                case ".pm": mimeType = "image/x-xpixmap"; break;
                case ".pm4": mimeType = "application/x-pagemaker"; break;
                case ".pm5": mimeType = "application/x-pagemaker"; break;
                case ".png": mimeType = "image/png"; break;
                case ".pnm": mimeType = "application/x-portable-anymap"; break;
                case ".pot": mimeType = "application/vnd.ms-powerpoint"; break;
                case ".pov": mimeType = "model/x-pov"; break;
                case ".ppa": mimeType = "application/vnd.ms-powerpoint"; break;
                case ".ppm": mimeType = "image/x-portable-pixmap"; break;
                case ".pps": mimeType = "application/vnd.ms-powerpoint"; break;
                case ".ppt": mimeType = "application/vnd.ms-powerpoint"; break;
                case ".ppz": mimeType = "application/vnd.ms-powerpoint"; break;
                case ".pre": mimeType = "application/x-freelance"; break;
                case ".prt": mimeType = "application/pro_eng"; break;
                case ".ps": mimeType = "application/postscript"; break;
                case ".psd": mimeType = "application/octet-stream"; break;
                case ".pvu": mimeType = "paleovu/x-pv"; break;
                case ".pwz": mimeType = "application/vnd.ms-powerpoint"; break;
                case ".py": mimeType = "text/x-script.phyton"; break;
                case ".pyc": mimeType = "applicaiton/x-bytecode.python"; break;
                case ".qcp": mimeType = "audio/vnd.qcelp"; break;
                case ".qd3": mimeType = "x-world/x-3dmf"; break;
                case ".qd3d": mimeType = "x-world/x-3dmf"; break;
                case ".qif": mimeType = "image/x-quicktime"; break;
                case ".qt": mimeType = "video/quicktime"; break;
                case ".qtc": mimeType = "video/x-qtc"; break;
                case ".qti": mimeType = "image/x-quicktime"; break;
                case ".qtif": mimeType = "image/x-quicktime"; break;
                case ".ra": mimeType = "audio/x-pn-realaudio"; break;
                case ".ram": mimeType = "audio/x-pn-realaudio"; break;
                case ".ras": mimeType = "application/x-cmu-raster"; break;
                case ".rast": mimeType = "image/cmu-raster"; break;
                case ".rexx": mimeType = "text/x-script.rexx"; break;
                case ".rf": mimeType = "image/vnd.rn-realflash"; break;
                case ".rgb": mimeType = "image/x-rgb"; break;
                case ".rm": mimeType = "application/vnd.rn-realmedia"; break;
                case ".rmi": mimeType = "audio/mid"; break;
                case ".rmm": mimeType = "audio/x-pn-realaudio"; break;
                case ".rmp": mimeType = "audio/x-pn-realaudio"; break;
                case ".rng": mimeType = "application/ringing-tones"; break;
                case ".rnx": mimeType = "application/vnd.rn-realplayer"; break;
                case ".roff": mimeType = "application/x-troff"; break;
                case ".rp": mimeType = "image/vnd.rn-realpix"; break;
                case ".rpm": mimeType = "audio/x-pn-realaudio-plugin"; break;
                case ".rt": mimeType = "text/richtext"; break;
                case ".rtf": mimeType = "text/richtext"; break;
                case ".rtx": mimeType = "text/richtext"; break;
                case ".rv": mimeType = "video/vnd.rn-realvideo"; break;
                case ".s": mimeType = "text/x-asm"; break;
                case ".s3m": mimeType = "audio/s3m"; break;
                case ".saveme": mimeType = "application/octet-stream"; break;
                case ".sbk": mimeType = "application/x-tbook"; break;
                case ".scm": mimeType = "application/x-lotusscreencam"; break;
                case ".sdml": mimeType = "text/plain"; break;
                case ".sdp": mimeType = "application/sdp"; break;
                case ".sdr": mimeType = "application/sounder"; break;
                case ".sea": mimeType = "application/sea"; break;
                case ".set": mimeType = "application/set"; break;
                case ".sgm": mimeType = "text/sgml"; break;
                case ".sgml": mimeType = "text/sgml"; break;
                case ".sh": mimeType = "application/x-sh"; break;
                case ".shar": mimeType = "application/x-shar"; break;
                case ".shtml": mimeType = "text/html"; break;
                case ".sid": mimeType = "audio/x-psid"; break;
                case ".sit": mimeType = "application/x-sit"; break;
                case ".skd": mimeType = "application/x-koan"; break;
                case ".skm": mimeType = "application/x-koan"; break;
                case ".skp": mimeType = "application/x-koan"; break;
                case ".skt": mimeType = "application/x-koan"; break;
                case ".sl": mimeType = "application/x-seelogo"; break;
                case ".smi": mimeType = "application/smil"; break;
                case ".smil": mimeType = "application/smil"; break;
                case ".snd": mimeType = "audio/basic"; break;
                case ".sol": mimeType = "application/solids"; break;
                case ".spc": mimeType = "text/x-speech"; break;
                case ".spl": mimeType = "application/futuresplash"; break;
                case ".spr": mimeType = "application/x-sprite"; break;
                case ".sprite": mimeType = "application/x-sprite"; break;
                case ".src": mimeType = "application/x-wais-source"; break;
                case ".ssi": mimeType = "text/x-server-parsed-html"; break;
                case ".ssm": mimeType = "application/streamingmedia"; break;
                case ".sst": mimeType = "application/vnd.ms-pki.certstore"; break;
                case ".step": mimeType = "application/step"; break;
                case ".stl": mimeType = "application/sla"; break;
                case ".stp": mimeType = "application/step"; break;
                case ".sv4cpio": mimeType = "application/x-sv4cpio"; break;
                case ".sv4crc": mimeType = "application/x-sv4crc"; break;
                case ".svf": mimeType = "image/vnd.dwg"; break;
                case ".svr": mimeType = "application/x-world"; break;
                case ".swf": mimeType = "application/x-shockwave-flash"; break;
                case ".t": mimeType = "application/x-troff"; break;
                case ".talk": mimeType = "text/x-speech"; break;
                case ".tar": mimeType = "application/x-tar"; break;
                case ".tbk": mimeType = "application/toolbook"; break;
                case ".tcl": mimeType = "application/x-tcl"; break;
                case ".tcsh": mimeType = "text/x-script.tcsh"; break;
                case ".tex": mimeType = "application/x-tex"; break;
                case ".texi": mimeType = "application/x-texinfo"; break;
                case ".texinfo": mimeType = "application/x-texinfo"; break;
                case ".text": mimeType = "text/plain"; break;
                case ".tgz": mimeType = "application/x-compressed"; break;
                case ".tif": mimeType = "image/tiff"; break;
                case ".tiff": mimeType = "image/tiff"; break;
                case ".tr": mimeType = "application/x-troff"; break;
                case ".tsi": mimeType = "audio/tsp-audio"; break;
                case ".tsp": mimeType = "application/dsptype"; break;
                case ".tsv": mimeType = "text/tab-separated-values"; break;
                case ".turbot": mimeType = "image/florian"; break;
                case ".txt": mimeType = "text/plain"; break;
                case ".uil": mimeType = "text/x-uil"; break;
                case ".uni": mimeType = "text/uri-list"; break;
                case ".unis": mimeType = "text/uri-list"; break;
                case ".unv": mimeType = "application/i-deas"; break;
                case ".uri": mimeType = "text/uri-list"; break;
                case ".uris": mimeType = "text/uri-list"; break;
                case ".ustar": mimeType = "application/x-ustar"; break;
                case ".uu": mimeType = "application/octet-stream"; break;
                case ".uue": mimeType = "text/x-uuencode"; break;
                case ".vcd": mimeType = "application/x-cdlink"; break;
                case ".vcs": mimeType = "text/x-vcalendar"; break;
                case ".vda": mimeType = "application/vda"; break;
                case ".vdo": mimeType = "video/vdo"; break;
                case ".vew": mimeType = "application/groupwise"; break;
                case ".viv": mimeType = "video/vivo"; break;
                case ".vivo": mimeType = "video/vivo"; break;
                case ".vmd": mimeType = "application/vocaltec-media-desc"; break;
                case ".vmf": mimeType = "application/vocaltec-media-file"; break;
                case ".voc": mimeType = "audio/voc"; break;
                case ".vos": mimeType = "video/vosaic"; break;
                case ".vox": mimeType = "audio/voxware"; break;
                case ".vqe": mimeType = "audio/x-twinvq-plugin"; break;
                case ".vqf": mimeType = "audio/x-twinvq"; break;
                case ".vql": mimeType = "audio/x-twinvq-plugin"; break;
                case ".vrml": mimeType = "application/x-vrml"; break;
                case ".vrt": mimeType = "x-world/x-vrt"; break;
                case ".vsd": mimeType = "application/x-visio"; break;
                case ".vst": mimeType = "application/x-visio"; break;
                case ".vsw": mimeType = "application/x-visio"; break;
                case ".w60": mimeType = "application/wordperfect6.0"; break;
                case ".w61": mimeType = "application/wordperfect6.1"; break;
                case ".w6w": mimeType = "application/msword"; break;
                case ".wav": mimeType = "audio/wav"; break;
                case ".wb1": mimeType = "application/x-qpro"; break;
                case ".wbmp": mimeType = "image/vnd.wap.wbmp"; break;
                case ".web": mimeType = "application/vnd.xara"; break;
                case ".wiz": mimeType = "application/msword"; break;
                case ".wk1": mimeType = "application/x-123"; break;
                case ".wmf": mimeType = "windows/metafile"; break;
                case ".wml": mimeType = "text/vnd.wap.wml"; break;
                case ".wmlc": mimeType = "application/vnd.wap.wmlc"; break;
                case ".wmls": mimeType = "text/vnd.wap.wmlscript"; break;
                case ".wmlsc": mimeType = "application/vnd.wap.wmlscriptc"; break;
                case ".word": mimeType = "application/msword"; break;
                case ".wp": mimeType = "application/wordperfect"; break;
                case ".wp5": mimeType = "application/wordperfect"; break;
                case ".wp6": mimeType = "application/wordperfect"; break;
                case ".wpd": mimeType = "application/wordperfect"; break;
                case ".wq1": mimeType = "application/x-lotus"; break;
                case ".wri": mimeType = "application/mswrite"; break;
                case ".wrl": mimeType = "application/x-world"; break;
                case ".wrz": mimeType = "x-world/x-vrml"; break;
                case ".wsc": mimeType = "text/scriplet"; break;
                case ".wsrc": mimeType = "application/x-wais-source"; break;
                case ".wtk": mimeType = "application/x-wintalk"; break;
                case ".xbm": mimeType = "image/x-xbitmap"; break;
                case ".xdr": mimeType = "video/x-amt-demorun"; break;
                case ".xgz": mimeType = "xgl/drawing"; break;
                case ".xif": mimeType = "image/vnd.xiff"; break;
                case ".xl": mimeType = "application/excel"; break;
                case ".xla": mimeType = "application/vnd.ms-excel"; break;
                case ".xlb": mimeType = "application/vnd.ms-excel"; break;
                case ".xlc": mimeType = "application/vnd.ms-excel"; break;
                case ".xld": mimeType = "application/vnd.ms-excel"; break;
                case ".xlk": mimeType = "application/vnd.ms-excel"; break;
                case ".xll": mimeType = "application/vnd.ms-excel"; break;
                case ".xlm": mimeType = "application/vnd.ms-excel"; break;
                case ".xls": mimeType = "application/vnd.ms-excel"; break;
                case ".xlt": mimeType = "application/vnd.ms-excel"; break;
                case ".xlv": mimeType = "application/vnd.ms-excel"; break;
                case ".xlw": mimeType = "application/vnd.ms-excel"; break;
                case ".xm": mimeType = "audio/xm"; break;
                case ".xml": mimeType = "application/xml"; break;
                case ".xmz": mimeType = "xgl/movie"; break;
                case ".xpix": mimeType = "application/x-vnd.ls-xpix"; break;
                case ".xpm": mimeType = "image/xpm"; break;
                case ".x-png": mimeType = "image/png"; break;
                case ".xsr": mimeType = "video/x-amt-showrun"; break;
                case ".xwd": mimeType = "image/x-xwd"; break;
                case ".xyz": mimeType = "chemical/x-pdb"; break;
                case ".z": mimeType = "application/x-compressed"; break;
                case ".zip": mimeType = "application/zip"; break;
                case ".zoo": mimeType = "application/octet-stream"; break;
                case ".zsh": mimeType = "text/x-script.zsh"; break;
                default: mimeType = "application/octet-stream"; break;
            }
            return mimeType;
        }

        #endregion
    }
}
