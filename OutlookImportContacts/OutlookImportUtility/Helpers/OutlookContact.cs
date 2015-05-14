using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace OutlookImportUtility.Helpers
{
    /// <summary>
    /// Represent contact from outlook
    /// </summary>
    public class OutlookContact
    {
        #region Constructors

        public OutlookContact(string firstName, string lastName, string email, string phone, string jobTitle, string companyName, string city,
            string country, string postalCode, string state, string street, string categories, string crmId)
        {
            Category = SetCategory(categories);
            CrmId = new Guid(crmId);
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            JobTitle = jobTitle;
            CompanyName = companyName;
            City = city;
            Country = country;
            PostalCode = postalCode;
            State = state;
            Street = street;
        }

        public OutlookContact(string categories, string crmId, string notes, string pathToPic)
        {
            CrmId = Guid.Parse(crmId);
            Category = SetCategory(categories);
            Notes = notes;
            PathToPicture = pathToPic;
        }

        #endregion

        #region Public properties

        public Guid CrmId { get; set; }
        public Category Category { get; set; }
        public string Notes { get; set; }
        public string PathToPicture { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }

        #endregion

        #region Private methods

        /// <summary>
        /// Set color category for contact. 
        /// Important: Only first color category will be set to contact
        /// </summary>
        /// <param name="category">Category names</param>
        /// <returns>Category by name</returns>
        private Category SetCategory(string category)
        {
            string[] cat = category.Split(',');
            switch (cat[0].ToLower())
            {
                case "in the market": return Category.InTheMarket;
                case "prospect": return Category.Prospect;
                case "preferred prospect": return Category.PreferredProspect;
                case "dead": return Category.Dead;
                case "client": return Category.Client;
                default: return Category.Other;
            }
        }

        #endregion
    }
}