using Microsoft.Xrm.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using StoreCredentialsLibrary;
using System.ServiceModel.Description;

namespace TW_PageForAttachFile.HelperClasses.Connection
{
    public class ConfigSettings
    {
        public static string Login;
        public static string Password;
        public static string Url;

        public void InitSettings()
        {
            var key = EncDec.Encrypt(DateTime.Now.ToString(CultureInfo.InvariantCulture), "Transwestern IXS20");
            var settins = StoreCredentialsLibrary.TranswesternCredentials.GetCredentials(key);

            if (!string.IsNullOrEmpty(settins.ErrorMessage))
                throw new Exception(settins.ErrorMessage);

            Login = settins.Login;
            Password = settins.Password;
            Url = settins.Url;
        }
    }
}