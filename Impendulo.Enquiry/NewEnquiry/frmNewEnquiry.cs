using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Impendulo.Data.Models;
using System.Data.Entity;
using Impendulo.Common.Enum;

using Impendulo.Enquiry.SelectCourseCurriculum.Development;
using Impendulo.Enquiry.SelectContacts.Developemnt;
using Impendulo.Enquiry.UpdateSelectedCurriculumEnrollQty.Development;
using Impendulo.Enquiry.SelectContacts.Deployment1;

namespace Impendulo.WizardForm.ClientEnquiry.Development
{
    public partial class frmNewEnquiry : Form
    {
        private Boolean _CompanyContactSelected = true;

        public Boolean CompanyContactSelected
        {
            get
            {
                return _CompanyContactSelected;
            }
            set
            {
                _CompanyContactSelected = value;
            }
        }
        int iCurrentPosition = 0;
        //MCDEntities Dbconnection;
        //Student StudentObj;


        public Data.Models.Enquiry CurrentEnquiry { get; set; }

        private Curriculum CurrentSelectedCurriculum { get; set; }

        public Employee CurrentEmployeeLoggedIn
        {
            get;
            set;
        }

        List<CurriculumEnquiry> _SelectedEnquiryCurriculum = null;
        private List<CurriculumEnquiry> SelectedEnquiryCurriculum
        {
            get
            {
                if (_SelectedEnquiryCurriculum == null)
                {
                    _SelectedEnquiryCurriculum = new List<CurriculumEnquiry>();
                }
                return _SelectedEnquiryCurriculum;
            }
            set
            {
                if (value == null)
                {
                    _SelectedEnquiryCurriculum = new List<CurriculumEnquiry>();
                }
                else { _SelectedEnquiryCurriculum = value; }
            }
        }

        public Boolean CommitEnquiry = false;
        public frmNewEnquiry()
        {
            InitializeComponent();
            CurrentEnquiry = new Data.Models.Enquiry
            {
                EnquiryDate = DateTime.Now
            };
        }



        private void frmAddUpdateStudent_Load(object sender, EventArgs e)
        {


            if (CurrentEmployeeLoggedIn == null)
            {
                /*
             * Thismust be Commmented out or removed in the production version this is just for Develpoement Testing.
             */
                using (var Dbconnection = new MCDEntities())
                {
                    CurrentEmployeeLoggedIn = (from a in Dbconnection.Employees
                                               where a.EmployeeID == 11075
                                               select a).FirstOrDefault<Employee>();
                };

                /***************************************************************************************/
                // MessageBox.Show("It is Required that you be logged in to use the feature.\n Login and try again!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // this.Close();

            }



            this.setCenterDisplayPanels();
            this.setNavigationControls();
            this.loadupStep();
        }

        #region Forms Sections

        #region Page 1 - Contact Type Selection

        #region Controls Events
        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            ////////RadioButton rb = sender as RadioButton;

            ////////// Ensure that the RadioButton.Checked property
            ////////// changed to true.
            ////////if (rb.Checked)
            ////////{
            ////////    if (rb.Tag.ToString().ToLower().Equals("private"))
            ////////    {
            ////////        DialogResult Dialogres = MessageBox.Show("Are you Sure, as this will clear all previous selections!!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            ////////        if (Dialogres == DialogResult.Yes)
            ////////        {
            ////////            this.setControlsForPrivate();
            ////////            this.clearSelectedCompanies();
            ////////            this.clearSelectedIndividuals();
            ////////            this.clearSelectedCurriculumForEnquiry();
            ////////        }
            ////////        else
            ////////        {
            ////////            this.radEnquiryTypeSelectionIsCompany.Checked = true;
            ////////        }

            ////////    }
            ////////    else
            ////////    {
            ////////        DialogResult Dialogres = MessageBox.Show("Are you Sure, as this will clear all previous selections!!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            ////////        if (Dialogres == DialogResult.Yes)
            ////////        {
            ////////            this.setControlsForCompany();
            ////////            this.clearSelectedCompanies();
            ////////            this.clearSelectedIndividuals();
            ////////            this.clearSelectedCurriculumForEnquiry();
            ////////        }else
            ////////        {
            ////////            this.radEnquiryTypeSelectionIsPrivateIndividual.Checked = true;
            ////////        }
            ////////    }
            ////////    //clearAllContactInfo();
            ////////}
        }
        private void btnEnquiryTypeSelectionIsCompany_Click(object sender, EventArgs e)
        {
            if (CurrentEnquiry.Companies.Count > 0 || CurrentEnquiry.Individuals.Count > 0 || SelectedEnquiryCurriculum.Count > 0)
            {
                DialogResult Dialogres = MessageBox.Show("Are you Sure, as this will clear all previous selections!!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Dialogres == DialogResult.Yes)
                {
                    this.setControlsForCompany();
                    this.clearSelectedCompanies();
                    this.clearSelectedIndividuals();
                    this.clearSelectedCurriculumForEnquiry();
                    this.refreshPrivateIndividualDetails();
                }
            }
            else
            {
                this.setControlsForCompany();
                this.clearSelectedCompanies();
                this.clearSelectedIndividuals();
                this.clearSelectedCurriculumForEnquiry();
                this.refreshPrivateIndividualDetails();
            }
            CompanyContactSelected = true;
        }

        private void btnEnquiryTypeSelectionIsPrivateIndividual_Click(object sender, EventArgs e)
        {
            if (CurrentEnquiry.Companies.Count > 0 || CurrentEnquiry.Individuals.Count > 0 || SelectedEnquiryCurriculum.Count > 0)
            {
                DialogResult Dialogres = MessageBox.Show("Are you Sure, as this will clear all previous selections!!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Dialogres == DialogResult.Yes)
                {
                    this.setControlsForPrivate();
                    this.clearSelectedCompanies();
                    this.clearSelectedIndividuals();
                    this.clearSelectedCurriculumForEnquiry();
                    this.refreshPrivateIndividualDetails();
                }
            }
            else
            {
                this.setControlsForPrivate();
                this.clearSelectedCompanies();
                this.clearSelectedIndividuals();
                this.clearSelectedCurriculumForEnquiry();
                this.refreshPrivateIndividualDetails();
            }
            CompanyContactSelected = false;
        }

        #endregion

        #region Logical Control Metods
        private void setControlsForPrivate()
        {
            this.lblEnquiryTypeSelection.Text = "Private Individual";
            this.gbContactInformationPrivate.Visible = true;
            gbContactInformationCompany.Visible = false;
        }
        private void setControlsForCompany()
        {
            this.lblEnquiryTypeSelection.Text = "Company";
            this.gbContactInformationPrivate.Visible = false;
            gbContactInformationCompany.Visible = true;
        }
        //private void clearAllContactInfo()
        //{
        //    CurrentEnquiry.Companies.Clear();
        //}

        #endregion



        #endregion

        #region Page 2 - Contact Selection

        #region Refresh Methods

        private void refreshCompanyName()
        {
            if (CurrentEnquiry.Companies.Count() > 0)
            {
                this.populateCompanyName();
            }
            else
            {
                txtContactInformationCompanyName.Clear();
                txtSummaryCompanyName.Text = "NA - Private Enquiry";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void refreshContact()
        {
            if (CurrentEnquiry.Individuals.Count() > 0)
            {
                this.populateContact();
            }
            else
            {
                txtContactInformationCompanyContact.Clear();
                txtSummaryContactName.Clear();
            }
        }
        private void refreshContactDetails()
        {

            if (CurrentEnquiry.Individuals.Count() > 0)
            {
                this.populateContactDetails();
            }
            else
            {
                contactDetailBindingSource.DataSource = null;
            }

        }

        private void refreshPrivateIndividualDetails()
        {

            if (CurrentEnquiry.Individuals.Count() > 0)
            {
                this.populatePrivateContact();
            }
            else
            {
                this.txtPrivateIndividualFirstName.Clear();
                this.txtPrivateIndividualLastName.Clear();
                this.txtSummaryContactName.Clear();
            }
        }

        #endregion

        #region Populate Methods
        private void populateContact()
        {
            Individual CurrentContact = (from a in CurrentEnquiry.Individuals
                                         select a).FirstOrDefault<Individual>();
            txtContactInformationCompanyContact.Text = CurrentContact.IndividualFirstName + " " + CurrentContact.IndividualSecondName + " " + CurrentContact.IndividualLastname;
            txtSummaryContactName.Text = CurrentContact.IndividualFirstName + " " + CurrentContact.IndividualSecondName + " " + CurrentContact.IndividualLastname;
        }

        private void populatePrivateContact()
        {
            Individual CurrentContact = (from a in CurrentEnquiry.Individuals
                                         select a).FirstOrDefault<Individual>();
            this.txtPrivateIndividualFirstName.Text = CurrentContact.IndividualFirstName;
            this.txtPrivateIndividualLastName.Text = CurrentContact.IndividualLastname;
            txtSummaryContactName.Text = CurrentContact.IndividualFirstName + " " + CurrentContact.IndividualSecondName + " " + CurrentContact.IndividualLastname;

        }
        private void populateContactDetails()
        {

            List<ContactDetail> x = (from a in CurrentEnquiry.Individuals
                                     from b in a.ContactDetails
                                     select b).ToList<ContactDetail>();
            contactDetailBindingSource.DataSource = x;
        }
        private void populateCompanyName()
        {
            Data.Models.Company CompanyObj = (from a in CurrentEnquiry.Companies
                                              select a).FirstOrDefault<Data.Models.Company>();

            txtContactInformationCompanyName.Text = CompanyObj.CompanyName;
            txtSummaryCompanyName.Text = CompanyObj.CompanyName;
        }
        #endregion

        #region Control Events
        private void btnContactInformationSelectCompanyContact_Click(object sender, EventArgs e)
        {
            frmSelectCompanyContact frm = new frmSelectCompanyContact();
            frm.CurrentCompany = CurrentEnquiry.Companies.FirstOrDefault<Data.Models.Company>();
            frm.SelectedIndividual = CurrentEnquiry.Individuals.FirstOrDefault<Individual>();
            frm.ShowDialog();
            this.clearSelectedCompanies();
            this.clearSelectedIndividuals();


            using (var Dbconnection = new MCDEntities())
            {
                Dbconnection.Enquiries.Attach(CurrentEnquiry);
                if (frm.CurrentCompany != null)
                {

                    //Data.Models.Company CompanyToLink = new Data.Models.Company
                    //{
                    //    CompanyID = frm.CurrentCompany.CompanyID
                    //};
                    //Dbconnection.Companies.Attach(CompanyToLink);
                    //CurrentEnquiry.Companies.Add(CompanyToLink);

                    //Dbconnection.Entry(CompanyToLink).Reload();
                    CurrentEnquiry.Companies.Add(frm.CurrentCompany);
                }
                else
                {
                    CurrentEnquiry.Companies.Clear();
                }
                if (frm.SelectedIndividual != null)
                {
                    //Individual ContactPersonToLink = new Individual
                    //{
                    //    IndividualID = frm.SelectedIndividual.IndividualID
                    //};
                    //Dbconnection.Individuals.Attach(ContactPersonToLink);
                    //CurrentEnquiry.Individuals.Add(ContactPersonToLink);


                    //Dbconnection.Entry(ContactPersonToLink).Reload();

                    //Dbconnection.Entry(ContactPersonToLink).Collection(a => a.ContactDetails).Load();
                    //foreach (ContactDetail ConDetail in ContactPersonToLink.ContactDetails)
                    //{
                    //    Dbconnection.Entry(ConDetail).Reference("LookupContactType").Load();
                    //}
                    CurrentEnquiry.Individuals.Add(frm.SelectedIndividual);
                }
                else
                {
                    CurrentEnquiry.Individuals.Clear();
                }
            };
            this.refreshCompanyName();
            this.refreshContact();
            this.refreshContactDetails();

        }


        private void dgvIndividualContactDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var ContactDetailObj = (ContactDetail)(row.DataBoundItem);

                    //var lookupAddressTypeObj = AddressObj.LookupAddressType.AddressType;

                    row.Cells[colContactType.Index].Value = ContactDetailObj.LookupContactType.ContactType.ToString();

                }
            }
        }

        private void btnContactInformationSelectPrivateContact_Click(object sender, EventArgs e)
        {
            frmSelectIndividualContact frm = new frmSelectIndividualContact();
            frm.SelectedIndividual = CurrentEnquiry.Individuals.FirstOrDefault<Individual>();
            frm.ShowDialog();
            this.clearSelectedIndividuals();
            using (var Dbconnection = new MCDEntities())
            {
                if (frm.SelectedIndividual != null)
                {
                    CurrentEnquiry.Individuals.Add(frm.SelectedIndividual);
                }
            };

            this.refreshPrivateIndividualDetails();
            this.refreshContactDetails();
        }
        #endregion

        #region Logic Control Methods




        private void clearSelectedCompanies()
        {
            CurrentEnquiry.Companies.Clear();
            this.refreshCompanyName();
            this.refreshContact();
        }

        private void clearSelectedIndividuals()
        {
            CurrentEnquiry.Individuals.Clear();
            this.refreshContactDetails();
        }

        private void clearSelectedCurriculumForEnquiry()
        {
            this.SelectedEnquiryCurriculum.Clear();
            this.refreshSelectedCurriculum();
        }

        #endregion
        #endregion

        #region Page 3 - Curriculum Selection

        #region Refresh Methods
        private void refreshSelectedCurriculum()
        {
            if (SelectedEnquiryCurriculum != null && SelectedEnquiryCurriculum.Count > 0)
            {
                this.populateSelectedCurriculum();
                this.btnUpdateQty.Enabled = true;
                this.gbCurriculumCourses.Enabled = true;
                this.btnRemoveSelectedCurriculum.Enabled = true;
            }
            else
            {
                this.curriculumEnquiryBindingSource.DataSource = null;
                this.btnRemoveSelectedCurriculum.Enabled = false;
                this.gbCurriculumCourses.Enabled = false;
                this.btnUpdateQty.Enabled = false;
            }

        }
        #endregion

        #region Populate Methods
        private void populateSelectedCurriculum()
        {
            curriculumEnquiryBindingSource.DataSource = (from a in SelectedEnquiryCurriculum
                                                         select a).ToList<CurriculumEnquiry>();
        }
        #endregion

        #region Control Events
        private void dgvSelectedCurrriculum_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var CurriculumEnquiryObj = (CurriculumEnquiry)(row.DataBoundItem);

                    row.Cells[colCurriculum.Index].Value = CurriculumEnquiryObj.Curriculum.CurriculumName.ToString();
                    row.Cells[colDepartment.Index].Value = CurriculumEnquiryObj.Curriculum.LookupDepartment.DepartmentName.ToString();
                }
            }
        }
        private void btnSelectCurricullum_Click(object sender, EventArgs e)
        {
            frmSelectCourseCurriculumForClientEnquiry frm = new frmSelectCourseCurriculumForClientEnquiry();

            frm.SelectedCurriculum = (from a in SelectedEnquiryCurriculum
                                      select a.Curriculum).ToList<Curriculum>();
            frm.ShowDialog();
            if (frm.currentCurriculum != null)
            {
                this.CurrentSelectedCurriculum = frm.currentCurriculum;
                this.txtSelectedCourseCurriculum.Text = CurrentSelectedCurriculum.CurriculumName;
                this.enableAddSelectedCurriculumControls();
            }
            else
            {
                this.resetCurriculumSelectionControls();
                this.disableAddSElectedCurriculumControls();
            }

        }



        private void AddSelectedCurriculum_Click(object sender, EventArgs e)
        {
            if (SelectedEnquiryCurriculum == null) { SelectedEnquiryCurriculum = new List<CurriculumEnquiry>(); }

            CurriculumEnquiry EnquiryCurriculumToBeAdded = new CurriculumEnquiry
            {
                CurriculumEnquiryID = 0,
                EnquiryID = 0,
                Curriculum = CurrentSelectedCurriculum,
                CurriculumID = CurrentSelectedCurriculum.CurriculumID,
                EnquiryStatusID = (int)EnumEnquiryStatuses.New,
                EnrollmentQuanity = (int)nudQtyToEnroll.Value
            };
            // CurrentEnquiry.CurriculumEnquiries.Add(EnquiryCurriculumToBeAdded);
            SelectedEnquiryCurriculum.Add(EnquiryCurriculumToBeAdded);

            this.resetCurriculumSelectionControls();
            this.refreshSelectedCurriculum();
        }

        private void btnResetSelection_Click(object sender, EventArgs e)
        {
            this.resetCurriculumSelectionControls();
        }

        private void btnUpdateQty_Click(object sender, EventArgs e)
        {
            frmUpdateSelectedCurriculumEnrollQty frm = new frmUpdateSelectedCurriculumEnrollQty();
            frm.CurrentCurriculumEnquiry = (CurriculumEnquiry)this.curriculumEnquiryBindingSource.Current;
            frm.ShowDialog();
            this.refreshSelectedCurriculum();
        }

        private void btnRemoveSelectedCurriculum_Click(object sender, EventArgs e)
        {
            SelectedEnquiryCurriculum.RemoveAt(curriculumEnquiryBindingSource.Position);
            // CurriculumEnquiry CurriculumEnquiryToRemove = (CurriculumEnquiry)curriculumEnquiryBindingSource.Current;

            // CurrentEnquiry.CurriculumEnquiries.Remove(CurriculumEnquiryToRemove);
            this.refreshSelectedCurriculum();
        }


        #endregion

        #region logical Control Methods

        private void enableAddSelectedCurriculumControls()
        {
            btnAddSelectedCurriculum.Enabled = true;
            this.btnAddSelectedCurriculum.Enabled = true;
        }
        private void disableAddSElectedCurriculumControls()
        {
            btnAddSelectedCurriculum.Enabled = false;
            this.btnAddSelectedCurriculum.Enabled = false;
        }
        private void resetCurriculumSelectionControls()
        {
            this.txtSelectedCourseCurriculum.Clear();
            nudQtyToEnroll.Value = 1;
            this.CurrentSelectedCurriculum = null;
            this.btnAddSelectedCurriculum.Enabled = false;
        }
        #endregion

        #endregion

        #region Page 4 - Summary Confirmation

        #region Control Methods

        private void dgvSummarySelectedCurriculum_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var CurriculumEnquiryObj = (CurriculumEnquiry)(row.DataBoundItem);

                    row.Cells[colCurriculum.Index].Value = CurriculumEnquiryObj.Curriculum.CurriculumName.ToString();
                    row.Cells[colDepartment.Index].Value = CurriculumEnquiryObj.Curriculum.LookupDepartment.DepartmentName.ToString();
                }
            }
        }

        private void dgvSummaryContactDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var ContactDetailObj = (ContactDetail)(row.DataBoundItem);
                    row.Cells[colContactType.Index].Value = ContactDetailObj.LookupContactType.ContactType.ToString();
                }
            }
        }

        #endregion

        #endregion


        #endregion

        #region Wizard Comopnents
        #region "Navigation Controls"
        private void navigateForward()
        {
            if (ValidateStep())
            {
                if (iCurrentPosition + 1 < MainflowLayoutPanel.Controls.Count)
                {
                    //if step validation is passed the next window is display by incrementing the IcurrentPosition Counter.
                    iCurrentPosition++;
                }
                else
                {
                    //on last step which will close if the finish b=button is selected.
                    DialogResult res = MessageBox.Show("Are Enquiry Details Correct?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (DialogResult.Yes == res)
                    {
                        this.CommitEnquiry = true;
                        this.Close();
                    }
                }
                this.setCenterDisplayPanels();
                this.setNavigationControls();
                this.loadupStep();
            }
        }
        private void navigateBackwards()
        {
            if (iCurrentPosition - 1 >= 0)
            {
                iCurrentPosition--;
            }
            else
            {

                //iCurrentPosition = 5;
            }
            //Hide All Panels inside the MainFlowPanel
            //MainflowLayoutPanel
            this.setCenterDisplayPanels();
            this.setNavigationControls();
            this.loadupStep();
        }


        private void setNavigationControls()
        {
            if (iCurrentPosition == 0)
            {
                btnPreviousSection.Visible = false;
                btnNextSection.Text = "Next";
            }
            else
            {
                if (iCurrentPosition == MainflowLayoutPanel.Controls.Count - 1)
                {
                    btnNextSection.Text = "Save Enquiry";
                    btnNextSection.ImageIndex = 2;
                }
                else
                {
                    btnNextSection.Text = "Next";
                    btnNextSection.ImageIndex = 0;
                }
                btnPreviousSection.Visible = true;
            }
            foreach (var Control in panel5.Controls)
            {
                if (Control is Label)
                {
                    //NavigationPanel
                    var lblObj = (Label)Control;
                    if (Convert.ToInt32(lblObj.Tag.ToString()) == iCurrentPosition)
                    {
                        lblObj.Font = new Font(lblObj.Font, FontStyle.Bold | FontStyle.Underline);
                    }
                    else
                    {
                        lblObj.Font = new Font(lblObj.Font, FontStyle.Regular);
                    }
                }
            }

        }
        private void setCenterDisplayPanels()
        {
            foreach (var gbControl in MainflowLayoutPanel.Controls)
            {
                if (gbControl is GroupBox)
                {
                    var gbObj = (GroupBox)gbControl;
                    gbObj.Hide();
                }
            }
            foreach (var Control in MainflowLayoutPanel.Controls)
            {
                if (Control is GroupBox)
                {
                    var gbObj = (GroupBox)Control;
                    if (Convert.ToInt32(gbObj.Tag.ToString()) == iCurrentPosition)
                    {
                        gbObj.Show();
                        gbObj.Width = MainflowLayoutPanel.Width;
                        gbObj.Height = MainflowLayoutPanel.Height;
                    }
                    else
                    {
                        gbObj.Hide();
                        gbObj.Width = 0;
                        gbObj.Height = 0;

                    }
                }
            }
        }
        #endregion

        #region Wizard Methods
        private void loadupStep()
        {
            switch (iCurrentPosition)
            {
                case 0:
                    this.loadupEnquiryContactSelectionType();
                    break;
                case 1:
                    this.loadupEnquiryContactSelection();
                    break;
                case 2:
                    this.loadupEnquiryCurriculumSelection();
                    break;
                case 3:
                    this.loadupEnquiryConfirmation();
                    break;
                default:

                    break;
            }

        }
        private void btnPreviousSection_Click(object sender, EventArgs e)
        {
            navigateBackwards();
        }

        private void btnNextSection_Click(object sender, EventArgs e)
        {
            navigateForward();
        }
        private Boolean ValidateStep()
        {

            Boolean bRtn = true;
            switch (iCurrentPosition)
            {
                case 0:
                    break;
                case 1:
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
                    bRtn = false;
                    break;
            }

            return bRtn;
        }

        #region "Each Wizard Page Loadup"
        private void loadupEnquiryContactSelectionType()
        {


        }
        private void loadupEnquiryContactSelection()
        {





        }
        private void loadupEnquiryCurriculumSelection()
        {



        }


        private void loadupEnquiryConfirmation()
        {

        }

        #endregion

        #endregion

        #endregion

        private void frmNewEnquiry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CommitEnquiry)
            {
                this.SaveEnquiry();
            }
        }

        private void SaveEnquiry()
        {
            using (var Dbconnection = new MCDEntities())
            {
                Dbconnection.Enquiries.Attach(CurrentEnquiry);

                Dbconnection.Entry(CurrentEnquiry).State = EntityState.Added;
                Dbconnection.SaveChanges();

                /*Adds Each of the Curriculum Selected for this equiry*/
                foreach (CurriculumEnquiry CE in SelectedEnquiryCurriculum)
                {
                    CE.Curriculum = null;
                    CE.LookupEnquiryStatus = null;
                    CE.Enquiry = null;
                    CE.EnquiryID = CurrentEnquiry.EnquiryID;
                   
                    CE.InitialCurriculumEnquiryDocumentationSent = false;
                    CE.LastUpdated = DateTime.Now;
                    CE.EnquiryStatusID = CE.EnquiryStatusID;
                    CurrentEnquiry.CurriculumEnquiries.Add(CE);
                   
                }

                EquiryHistory AddingContactDetailsHistory = new EquiryHistory
                {
                    EnquiryID = CurrentEnquiry.EnquiryID,
                    EmployeeID = CurrentEmployeeLoggedIn.EmployeeID,
                    LookupEquiyHistoryTypeID = (int)EnumEquiryHistoryTypes.Company_Contact_Selection,
                    DateEnquiryUpdated = DateTime.Now,
                    EnquiryNotes = txtSelectedContactNotes.Text.ToString()

                };
                EquiryHistory AddingSelectedCurriculumHistory = new EquiryHistory
                {
                    EnquiryID = CurrentEnquiry.EnquiryID,
                    EmployeeID = CurrentEmployeeLoggedIn.EmployeeID,
                    LookupEquiyHistoryTypeID = (int)EnumEquiryHistoryTypes.Curriculum_Selection,
                    DateEnquiryUpdated = DateTime.Now,
                    EnquiryNotes = txtSelectedCurriculumNotes.Text.ToString()

                };
                CurrentEnquiry.EquiryHistories.Add(AddingContactDetailsHistory);
                CurrentEnquiry.EquiryHistories.Add(AddingSelectedCurriculumHistory);

                Dbconnection.SaveChanges();
            };
        }
    }
}
