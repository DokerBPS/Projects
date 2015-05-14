using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutlookImportUtility.Helpers;
using System.Configuration;
using System.Threading;
using System.ServiceModel.Security;

namespace OutlookImportUtility
{
    delegate void WriteCount_Delegate(int count, bool updated);
    delegate void IncrementProgress();
    delegate void WriteLogDelegate(string message);

    public partial class MainForm : Form
    {
        private List<OutlookContact> outlookContacts;
        private List<OutlookContact> notUpdatedContacts;

        public MainForm()
        {
            InitializeComponent();

            SetDefaultFocus();

            outlookContacts = new List<OutlookContact>();
            notUpdatedContacts = new List<OutlookContact>();

            GetOrganizationParameters();
            EnableControls(1);
        }

        #region Async operation

        private async void btn_StartImport_Click(object sender, EventArgs e)
        {
            EnableControls(4);
            SetDefaultFocus();
            
            lbl_NotUpdatedContactCount.Text = "0";
            lbl_UpdatedContactCount.Text = "0";
            prgbr_Progress.Value = 0;
            prgbr_Progress.Maximum = outlookContacts.Count;

            try
            {
                WriteLog("Import contacts to CRM -> Started");
                await Task.Run(() =>
                    {
                        if (!ConnectToCrm())
                            return;

                        int updatedCount = 0;
                        int notUdpatedCount = 0;
                        foreach (var outlookContact in outlookContacts)
                        {
                            bool result = CrmMethods.UpdateContacts(outlookContact);
                            if (result)
                            {
                                InvokeMethods(++updatedCount, true);
                            }
                            else
                            {
                                notUpdatedContacts.Add(outlookContact);
                                InvokeMethods(++notUdpatedCount, false);
                            }
                        }
                    });

                WriteLog("Import contacts to CRM -> Success");
            }
            catch (Exception ex)
            {
                WriteLog("Import contacts to CRM -> Error");
                WriteLog(ex.Message);
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            //radWaitingBar.StopWaiting();
            EnableControls(2);

        }

        async private void btn_GetOutlookContacts_Click(object sender, EventArgs e)
        {
            try
            {
                CrmMethods.CleanupContactPictures();
                EnableControls(3);
                //radWaitingBar.StartWaiting();

                SetDefaultFocus();
                WriteLog("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                WriteLog("Get outlook Contacts -> Started");
                outlookContacts = await Task.Run(() => CrmMethods.GetOutlookContacts());
                WriteLog("Outlook tracked contacts count: " + outlookContacts.Count);

                //ShowAllContacts();
            }
            catch (Exception ex)
            {
                WriteLog("Get outlook Contacts -> Error");
                WriteLog(ex.Message);
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            //radWaitingBar.StopWaiting();
            EnableControls(2);
            AutoScrollLog();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Methods for access to elements from another thread
        /// </summary>
        /// <param name="count">Count of contacts</param>
        /// <param name="updated">Updated contact: true - updated, false - not updated</param>
        private void InvokeMethods(int count, bool updated)
        {
            #region Access to elements from another thread

            if (updated)
            {
                if (lbl_UpdatedContactCount.InvokeRequired)
                {
                    var writeCount = new WriteCount_Delegate(Counting);
                    lbl_UpdatedContactCount.Invoke(writeCount, count, updated);
                }
            }
            else
            {
                if (lbl_NotUpdatedContactCount.InvokeRequired)
                {
                    var writeCount = new WriteCount_Delegate(Counting);
                    lbl_NotUpdatedContactCount.Invoke(writeCount, count, updated);
                }
            }

            if (prgbr_Progress.InvokeRequired)
            {
                var incrementProgress = new IncrementProgress(IncrementProgress);
                prgbr_Progress.Invoke(incrementProgress);
            }

            #endregion
        }

        /// <summary>
        /// Method for show count of updated contact
        /// </summary>
        /// <param name="count">Count of updated contact</param>
        private void Counting(int count, bool updated)
        {
            if (updated)
                lbl_UpdatedContactCount.Text = count.ToString();
            else
                lbl_NotUpdatedContactCount.Text = count.ToString();
        }

        /// <summary>
        /// Icrement progress value
        /// </summary>
        private void IncrementProgress()
        {
            prgbr_Progress.Value++;
        }

        /// <summary>
        /// Get params from app.config file. 
        /// </summary>
        private void GetOrganizationParameters()
        {
            //CrmUrl = ConfigurationManager.AppSettings["crmUrl"].ToString();
            //CrmLogin = ConfigurationManager.AppSettings["crmLogin"].ToString();
            //CrmPass = ConfigurationManager.AppSettings["crmPass"].ToString();
            //CrmDomain = ConfigurationManager.AppSettings["crmDomain"].ToString();

            CrmUrl = txbx_CrmUrl.Text + "/XRMServices/2011/Organization.svc";
            CrmDomain = txbx_CrmDomain.Text;
            CrmLogin = txbx_CrmLogin.Text;
            CrmPass = txbx_CrmPass.Text;
        }

        /// <summary>
        /// Create connection to CRM Server
        /// </summary>
        /// <returns>Returns true if connected to crm success, else - return false</returns>
        private bool ConnectToCrm()
        {
            WriteLogDelegate writelog = new WriteLogDelegate(WriteLogInvoke);

            lstbx_Log.Invoke(writelog, "Connecting to CRM -> Started");
            //WriteLog("Connecting to CRM -> Started");
            GetOrganizationParameters();

            if (CrmUrl == string.Empty || CrmDomain == string.Empty || CrmLogin == string.Empty || CrmPass == string.Empty)
            {
                lstbx_Log.Invoke(writelog, "Connecting to CRM -> Please enter your credentials!");
                return false;
            }

            try
            {
                CrmMethods.ConnectToCrm(CrmUrl, CrmLogin, CrmPass, CrmDomain);
                //WriteLog("Connecting to CRM -> Success");
                lstbx_Log.Invoke(writelog, "Connecting to CRM -> Success");
                return true;
            }
            catch (MessageSecurityException)
            {
                lstbx_Log.Invoke(writelog, "Connecting to CRM -> Please enter correct login and password");
                return false;
            }
            catch (Exception ex)
            {
                //WriteLog("Connecting to CRM -> Error");
                //WriteLog(ex.Message);
                lstbx_Log.Invoke(writelog, "Connecting to CRM -> Error");
                lstbx_Log.Invoke(writelog, ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Show all not updated contacts 
        /// </summary>
        /// <param name="notUpdatedContacts">List of not updated contacts</param>
        private void ShowNotUpdatedContacts(List<OutlookContact> notUpdatedContacts)
        {
            foreach (var contact in notUpdatedContacts)
            {
                WriteLog(contact.FirstName + " " + contact.LastName);
            }
        }

        /// <summary>
        /// Set default focus
        /// </summary>
        private void SetDefaultFocus()
        {
            txbx_DefaultFocus.Select();
        }

        /// <summary>
        /// Clear log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearLog_Click(object sender, EventArgs e)
        {
            SetDefaultFocus();
            lstbx_Log.Items.Clear();
        }

        /// <summary>
        /// Enable / Disable controls
        /// </summary>
        /// <param name="state"></param>
        private void EnableControls(int state)
        {
            switch (state)
            {
                // Enabled only one button - < Get outlook contacts >
                case 1:
                    {
                        btn_StartImport.Enabled = false;
                        btn_GetOutlookContacts.Enabled = true;
                        pnl_Progress.Visible = false;
                        pnl_ImportInfo.Visible = false;
                    } break;

                // Enabled two buttons - < Start Import > and < Get outlook contacts >
                case 2:
                    {
                        btn_StartImport.Enabled = true;
                        btn_GetOutlookContacts.Enabled = true;
                        pnl_Progress.Visible = false;
                        pnl_ImportInfo.Visible = false;
                    } break;

                // Enabled only waiting bar
                case 3:
                    {
                        btn_StartImport.Enabled = false;
                        btn_GetOutlookContacts.Enabled = false;
                        pnl_Progress.Visible = true;
                        pnl_ImportInfo.Visible = false;

                        prgbr_Progress.Style = ProgressBarStyle.Marquee;
                        prgbr_Progress.MarqueeAnimationSpeed = 10;
                    } break;

                // Enable import info elements
                case 4:
                    {
                        btn_StartImport.Enabled = false;
                        btn_GetOutlookContacts.Enabled = false;
                        pnl_Progress.Visible = true;
                        prgbr_Progress.Style = ProgressBarStyle.Blocks;
                        pnl_ImportInfo.Visible = true;
                    } break;
            }

        }

        /// <summary>
        /// Auto scrolling log to bottom
        /// </summary>
        private void AutoScrollLog()
        {
            lstbx_Log.SelectedIndex = lstbx_Log.Items.Count - 1;
            lstbx_Log.SelectedIndex = -1;
        }

        /// <summary>
        /// Write log in log control
        /// </summary>
        /// <param name="message">Log Message</param>
        private void WriteLog(string message)
        {
            if (message.Length > 45)
            {
                string temp = message.Substring(45);
                message = message.Replace(temp, "");
                this.lstbx_Log.Items.Add(message);
                //this.lstbx_Log.Items.Add(temp);
                WriteLog(temp);
            }
            else
                this.lstbx_Log.Items.Add(message);

            AutoScrollLog();
        }

        private void WriteLogInvoke(string message)
        {
            this.lstbx_Log.Items.Add(message);
            AutoScrollLog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Do you really want to close the application?";
            if (!btn_GetOutlookContacts.Enabled && !btn_StartImport.Enabled)
            {
                message += string.Format("\nImport contacts had not yet been completed!\nStop import and close the application?");

                DialogResult dr = MessageBox.Show(message, this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        #region For tray

        private void toolStripMenuItem_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon_Tray.Visible = true;
            }
        }

        private void toolStripMenuItem_Show_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon_Tray.Visible = false;
            }
        }

        #endregion

        #endregion

        #region Public properties

        public string CrmUrl { get; set; }
        public string CrmLogin { get; set; }
        public string CrmPass { get; set; }
        public string CrmDomain { get; set; }

        #endregion

    }
}
