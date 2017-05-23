


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;
using Impendulo.Data.Models;
using Impendulo.Common;
using Impendulo.WizardForm.ClientEnquiry.Development;
using Impendulo.Enquiry.ViewContactInformation.Development;
using Impendulo.Email.Development;
using Impendulo.Common.Enum;

namespace Impendulo.ClientEnquiry.Development
{
    public partial class frmClientEnquiry : Form
    {

        public Employee CurrentEmployeeLoggedIn
        {
            get;
            set;
        }

        #region All Datasets

        #region New Equiry

        #endregion

        #endregion
        public frmClientEnquiry()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region All Sections

        #region Common Methods
        private void openNewEnquiry()
        {
            frmNewEnquiry frm = new frmNewEnquiry();
            frm.CurrentEmployeeLoggedIn = this.CurrentEmployeeLoggedIn;
            frm.ShowDialog();
        }
        #endregion

        #region Enquiry Summary Page 

        #region New Equiry Summary Details

        #region Control Events
        private void btnAddNewEnquiry_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.openNewEnquiry();
        }
        #endregion
        #endregion
        #endregion

        #region New Equiry Workbench
        #region Refresh Methods
        private void refreshNewEnquiryWorkbench_NewEquiry()
        {
            populateNewEquiryWorkBench_NewEquiry();
        }
        private void refreshNewEnquiryWorkbench_OverDueEquiry()
        {
            populateNewEquiryWorkBench_OverDueEquiry();
        }
        #endregion

        #region Populate Methods
        private void populateNewEquiryWorkBench_NewEquiry()
        {

            using (var Dbconnection = new MCDEntities())
            {
                var x = DateTime.Now.AddDays(-2.0);
                NewEnquiryWorkbench_NewEnquiryBindingSource.DataSource = (from a in Dbconnection.Enquiries
                                                                          from b in a.CurriculumEnquiries
                                                                          where
                                                                                b.EnquiryStatusID == (int)Common.Enum.EnumEnquiryStatuses.New &&
                                                                                (a.EnquiryDate > x && a.EnquiryDate < DateTime.Now)
                                                                          select a)
                                                                          .Include("Individuals")
                                                                          .Include("CurriculumEnquiries")
                                                                          .Include("CurriculumEnquiries.Curriculum")
                                                                          .Include("Individuals.ContactDetails")
                                                                          .Include("Individuals.ContactDetails.LookupContactType")
                                                                          .Include("Companies").ToList<Data.Models.Enquiry>();
            };

        }
        private void populateNewEquiryWorkBench_OverDueEquiry()
        {
            using (var Dbconnection = new MCDEntities())
            {
               // var x = DateTime.Now.AddDays(-2.0);
                NewEnquiryWorkbench_OverDueCurriculumEnquiriesBindingSource.DataSource = (from a in Dbconnection.Enquiries
                                                                                          from b in a.CurriculumEnquiries
                                                                                          where b.EnquiryStatusID == (int)Common.Enum.EnumEnquiryStatuses.New 
                                                                                         // && a.EnquiryDate < x
                                                                                          select b).Include("Enquiry").ToList<CurriculumEnquiry>();
            };
        }
        #endregion


        #region New Enquiry Workbench Controls Events
        /// <summary>
        /// opens the new equiy dialog to add new enquiry.
        /// then refresh the New Enquiy datagridview to reflect the new enquiry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewEnquiry_Click(object sender, EventArgs e)
        {
            openNewEnquiry();
            this.refreshNewEnquiryWorkbench_NewEquiry();
        }
        //Just To Prevent Unnessesary Error Messages due to UI Over Flow in the Datagrid
        private void dgvNewEnquiryOverDue_DataError(object sender, DataGridViewDataErrorEventArgs e) { }

        //Just To Prevent Unnessesary Error Messages due to UI Over Flow in the Datagrid
        private void dgvNewEnquiryCurrent_DataError(object sender, DataGridViewDataErrorEventArgs e) { }


        private void dgvNewEnquiryCurrent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //toolStrip1 catch which of the options where selected
            switch (e.ColumnIndex)
            {
                //Accept the Enquiry
                case 1:
                    frmEnquiryViewContactInformation frm = new frmEnquiryViewContactInformation();
                    frm.CurrentEnquiry = (Data.Models.Enquiry)NewEnquiryWorkbench_NewEnquiryBindingSource.Current;
                    frm.ShowDialog();
                    break;
                //Close the Equiry
                case 2:

                    frmSendEmail frm1 = new frmSendEmail();
                    Data.Models.Enquiry CurrentEnquiryObj = (Data.Models.Enquiry)NewEnquiryWorkbench_NewEnquiryBindingSource.Current;
                    List<ContactDetail> you = (from a in CurrentEnquiryObj.Individuals
                                               from b in a.ContactDetails
                                               where b.ContactTypeID == (int)Common.Enum.EnumContactTypes.Email_Address
                                               select b).ToList<ContactDetail>();

                    //Sets the Email Address For the Currently Selected Contact For this Enquiry
                    foreach (ContactDetail ConDetObj in you)
                    {
                        if (frm1.txtTestingToAddress.Text.Length > 0)
                        {
                            frm1.txtTestingToAddress.Text += ";";
                        }
                        frm1.txtTestingToAddress.Text += ConDetObj.ContactDetailValue;
                    }
                   





                    using (var Dbconnection = new MCDEntities())
                    {

                        List<MessageTemplate> MT = (from a in Dbconnection.MessageTemplates
                                                    from b in a.Files
                                                    where a.ProcessStepID == (int)EnumProcessSteps.Enquiry__Apprenticeship__Step_1__Documentation_To_Send
                                                    select a).ToList<MessageTemplate>();

                        MessageTemplate CurrentMessageTemplate = MT.FirstOrDefault<MessageTemplate>();
                        frm1.txtTestMessage.Text = CurrentMessageTemplate.Message;
                        foreach (MessageTemplate MTObj in MT)
                        {
                            foreach (Data.Models.File FileObj in MTObj.Files)
                            {
                                frm1.AttachmentsUsingDbImageFileID.Add(FileObj.ImageID);
                            }
                        }

                    };
                    frm1.ShowDialog();
                    break;
                //SEnd Email Message
                case 3:
                    break;
                //View Enquiry History
                case 4:
                    break;
            }
        }
        private void dgvNewEnquiryCurrent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var EnquiryObj = (Data.Models.Enquiry)(row.DataBoundItem);

                    var CurriculumEnquiriesObj = EnquiryObj.CurriculumEnquiries.FirstOrDefault<CurriculumEnquiry>();

                    var CurriculumObj = CurriculumEnquiriesObj.Curriculum.CurriculumName;

                    string CompanyNameOrPrivate = "";
                    if (EnquiryObj.Companies.Count == 0)
                    {
                        CompanyNameOrPrivate = "Private";
                    }
                    else
                    {
                        CompanyNameOrPrivate = EnquiryObj.Companies.FirstOrDefault<Data.Models.Company>().CompanyName;
                    }
                    string ContactName = "";
                    if (EnquiryObj.Individuals.Count > 0)
                    {
                        ContactName = EnquiryObj.Individuals.FirstOrDefault<Individual>().IndividualFirstName + " " + EnquiryObj.Individuals.FirstOrDefault<Individual>().IndividualLastname;
                    }
                    //var x = EnquiryObj.CurriculumEnquiries
                    //var lookupAddressTypeObj = AddressObj.LookupAddressType.AddressType;

                    row.Cells[colNewEquiryWorkbenchEnrollmentQuanity.Index].Value = CurriculumEnquiriesObj.EnrollmentQuanity.ToString();
                    row.Cells[colNewEquiryWorkbenchCurriculumName.Index].Value = CurriculumEnquiriesObj.Curriculum.CurriculumName.ToString();
                    row.Cells[colNewEquiryWorkbenchCompanyName.Index].Value = CompanyNameOrPrivate;
                    row.Cells[colNewEquiryWorkbenchContactName.Index].Value = ContactName;
                }
            }
        }

        private void dgvNewEnquiryOverDue_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var CurriculumEnquiryObj = (Data.Models.CurriculumEnquiry)(row.DataBoundItem);

                    var EnquiriesObj = CurriculumEnquiryObj.Enquiry;

                    //var CurriculumObj = CurriculumEnquiriesObj.Curriculum.CurriculumName;

                    //string CompanyNameOrPrivate = "";
                    //if (EnquiryObj.Companies.Count == 0)
                    //{
                    //    CompanyNameOrPrivate = "Private";
                    //}
                    //else
                    //{
                    //    CompanyNameOrPrivate = EnquiryObj.Companies.FirstOrDefault<Data.Models.Company>().CompanyName;
                    //}
                    //string ContactName = "";
                    //if (EnquiryObj.Individuals.Count > 0)
                    //{
                    //    ContactName = EnquiryObj.Individuals.FirstOrDefault<Individual>().IndividualFirstName + " " + EnquiryObj.Individuals.FirstOrDefault<Individual>().IndividualLastname;
                    //}

                    //row.Cells[colNewEquiryWorkbenchEnrollmentQuanity.Index].Value = CurriculumEnquiriesObj.EnrollmentQuanity.ToString();
                    //row.Cells[colNewEquiryWorkbenchCurriculumName.Index].Value = CurriculumEnquiriesObj.Curriculum.CurriculumName.ToString();
                    //row.Cells[colNewEquiryWorkbenchCompanyName.Index].Value = CompanyNameOrPrivate;
                    //row.Cells[colNewEquiryWorkbenchContactName.Index].Value = ContactName;
                }
            }
        }
        #endregion

        #region New Equiry Workbench Commom Methods
        /// <summary>
        /// Attachs the Selected Enquiry and updates the status of the 
        /// Equiry's Curriculum Enquiry to "Enrollment In Progress"
        /// and then save the update and referesh the list of NEW Quiries 
        /// in the datagridview.
        /// </summary>
        /// <param name="SelectedEnquiry"></param>
        private void acceptNewEnquiry(Data.Models.Enquiry SelectedEnquiry)

        {
            using (var Dbconnection = new MCDEntities())
            {
                Dbconnection.Enquiries.Attach(SelectedEnquiry);
                //Gets the Curriculum Enquiry details
                CurriculumEnquiry SelectedCurriculumEnquiry = SelectedEnquiry.CurriculumEnquiries.FirstOrDefault<CurriculumEnquiry>();

            };
        }
        #endregion

        #endregion

        #region In Progress Work Bench

        #endregion

        #region Compelted Enquiry Workbench

        #endregion


        #endregion


        private void tabEnquiryWorkbench_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((tabEnquiryWorkbench).SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    this.refreshNewEnquiryWorkbench_NewEquiry();

                    this.refreshNewEnquiryWorkbench_OverDueEquiry();
                    break;
                case 2:

                    break;
                case 3:
                    break;

                case 4:
                    break;

                case 5:

                    break;
                default:

                    break;
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Data.Models.Enquiry x = (Data.Models.Enquiry)NewEnquiryWorkbench_NewEnquiryBindingSource.Current;
        }

        private void dgvNewEnquiryOverDue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
