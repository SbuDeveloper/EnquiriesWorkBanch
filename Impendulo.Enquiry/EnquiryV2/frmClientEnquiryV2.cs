using Impendulo.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Impendulo.WizardForm.ClientEnquiry.Development;
using Impendulo.Enquiry.ViewContactInformation.Development;
using Impendulo.Email.Development;
using Impendulo.Common.Enum;
using Impendulo.Enquiry.Development.EnquiryProcessing.Aprenticeship.Step2___DocumentationRecieved.Development;
using Impendulo.Enquiry.Development.InitaialConsultation;
using Impendulo.Enquiry.Development.InitialDocumentation.ApprenticeshipDocumentation;
using Impendulo.Enquiry.Development.ViewHistory;
using Impendulo.StudentEngineeringCourseErollment.Devlopment.CurriculumEmrollmentForms.ApprenticeshipEnrollment;
using Impendulo.StudentEngineeringCourseErollment.Devlopment;

namespace Impendulo.Enquiry.Development.EnquiryV2.Development
{
    public partial class frmClientEnquiryV2 : Form
    {

        public Data.Models.Enquiry CurrentNewEquiry { get; set; }

        //private List<LookupDepartment> 

        public Employee CurrentEmployeeLoggedIn { get; set; }
        public frmClientEnquiryV2()
        {
            InitializeComponent();

            using (var Dbconnection = new MCDEntities())
            {
                CurrentEmployeeLoggedIn = (from a in Dbconnection.Employees
                                           where a.EmployeeID == 11075
                                           select a)
                                           .Include("LookupDepartments")
                                           .FirstOrDefault<Employee>();
            };
        }


        private void frmClientEnquiryV2_Load(object sender, EventArgs e)
        {

        }
        #region Common Methods
        private void openNewEnquiry()
        {
            frmNewEnquiry frm = new frmNewEnquiry();
            frm.CurrentEmployeeLoggedIn = this.CurrentEmployeeLoggedIn;
            frm.ShowDialog();
        }
        #endregion
        #region Enquiry DashBoard

        #endregion

        #region New Equiry Tab
        #region New Equiry

        #region Refresh New Equiry
        private void refreshNewEnquiry()
        {
            populateNewEquiry();
        }
        #endregion

        private Boolean DetermineIfPartOfDepartment(int DepartmentIdToCheck)
        {
            Boolean IsPart = false;
            foreach (LookupDepartment EmployDep in CurrentEmployeeLoggedIn.LookupDepartments)
            {
                if (EmployDep.DepartmentID == DepartmentIdToCheck)
                {
                    IsPart = true;
                }
            }

            return IsPart;

        }
        #region Populate New Equiry
        private void clearAllNewEquiryControls()
        {
            NewEnquiryTab_NewEnquiryBindingSource.Clear();

        }
        private void populateNewEquiry()
        {
            clearAllNewEquiryControls();
            dgvNewEnquiryTab_NewEnquiry.Refresh();
            List<Data.Models.Enquiry> AllEnquiry = new List<Data.Models.Enquiry>();
            using (var Dbconnection = new MCDEntities())
            {
                DateTime f = DateTime.Now;
                f.AddDays(-5);//DateTime.Now - DateTime.Now.AddDays(-5);
                AllEnquiry = (from a in Dbconnection.Enquiries
                              where a.EnquiryID.ToString().Contains(txtFilterCriteriaForNewEnquiry.Text)
                              select a)
                                    .Include("Individuals")
                                    .Include("CurriculumEnquiries")
                                    .Include("CurriculumEnquiries.Curriculum")
                                    .Include("Individuals.ContactDetails")
                                    .Include("Individuals.LookupTitle")
                                    .Include("Individuals.ContactDetails.LookupContactType")
                                    .Include("Companies")
                                    .Include("CurriculumEnquiries.Enrollments")
                                    .ToList<Data.Models.Enquiry>();
            };



            //Filters out the Curriculum Enquiries that are not related to the person logged in.
            List<Data.Models.Enquiry> FilteredListWithNoCurriculumEnquiryItemsListed = new List<Data.Models.Enquiry>();
            foreach (Data.Models.Enquiry x in AllEnquiry)
            {
                //checks to see that the Enquiry is for the department for the empoyee is currently logged
                List<CurriculumEnquiry> temp = new List<CurriculumEnquiry>();
                foreach (CurriculumEnquiry y in x.CurriculumEnquiries)
                {
                    if (DetermineIfPartOfDepartment(y.Curriculum.DepartmentID) && y.EnquiryStatusID == (int)EnumEnquiryStatuses.New)
                    {
                        temp.Add(y);
                    }
                }
                x.CurriculumEnquiries.Clear();
                foreach (CurriculumEnquiry z in temp)
                {
                    x.CurriculumEnquiries.Add(z);
                }
                if (x.CurriculumEnquiries.Count > 0)
                {
                    FilteredListWithNoCurriculumEnquiryItemsListed.Add(x);
                }


            }

            FilteredListWithNoCurriculumEnquiryItemsListed = (from a in FilteredListWithNoCurriculumEnquiryItemsListed
                                                              orderby a.EnquiryID descending
                                                              select a).ToList<Data.Models.Enquiry>();
            NewEnquiryTab_NewEnquiryBindingSource.DataSource = FilteredListWithNoCurriculumEnquiryItemsListed;
        }
        #endregion

        #region New Equiry Control Event Methods
        private void btnAddNewEnquiry_Click(object sender, EventArgs e)
        {
            openNewEnquiry();
            this.refreshNewEnquiry();
        }
        #endregion

        #endregion
        #endregion
        #region Closed Equiry
        #region Refresh Closed Equiry
        private void refreshClosedEnquiry()
        {
            populateClosedEquiry();
        }
        #endregion

        private void populateClosedEquiry()
        {
            clearAllNewEquiryControls();
            dgvNewEnquiryTab_NewEnquiry.Refresh();
            List<Data.Models.Enquiry> AllEnquiry = new List<Data.Models.Enquiry>();
            using (var Dbconnection = new MCDEntities())
            {
                DateTime f = DateTime.Now;
                f.AddDays(-5);//DateTime.Now - DateTime.Now.AddDays(-5);
                AllEnquiry = (from a in Dbconnection.Enquiries
                              where a.EnquiryID.ToString().Contains(txtFilterCriteriaForNewEnquiry.Text)
                              select a)
                                    .Include("Individuals")
                                    .Include("CurriculumEnquiries")
                                    .Include("CurriculumEnquiries.Curriculum")
                                    .Include("Individuals.ContactDetails")
                                    .Include("Individuals.LookupTitle")
                                    .Include("Individuals.ContactDetails.LookupContactType")
                                    .Include("Companies")
                                    .Include("CurriculumEnquiries.Enrollments")
                                    .ToList<Data.Models.Enquiry>();
            };



            //Filters out the Curriculum Enquiries that are not related to the person logged in.
            List<Data.Models.Enquiry> FilteredListWithNoCurriculumEnquiryItemsListed = new List<Data.Models.Enquiry>();
            foreach (Data.Models.Enquiry x in AllEnquiry)
            {
                //checks to see that the Enquiry is for the department for the empoyee is currently logged
                List<CurriculumEnquiry> temp = new List<CurriculumEnquiry>();
                foreach (CurriculumEnquiry y in x.CurriculumEnquiries)
                {
                    if (DetermineIfPartOfDepartment(y.Curriculum.DepartmentID) && y.EnquiryStatusID == (int)EnumEnquiryStatuses.Enquiry_Closed)
                    {
                        temp.Add(y);
                    }
                }
                x.CurriculumEnquiries.Clear();
                foreach (CurriculumEnquiry z in temp)
                {
                    x.CurriculumEnquiries.Add(z);
                }
                if (x.CurriculumEnquiries.Count > 0)
                {
                    FilteredListWithNoCurriculumEnquiryItemsListed.Add(x);
                }


            }

            FilteredListWithNoCurriculumEnquiryItemsListed = (from a in FilteredListWithNoCurriculumEnquiryItemsListed
                                                              orderby a.EnquiryID descending
                                                              select a).ToList<Data.Models.Enquiry>();
            NewEnquiryTab_NewEnquiryBindingSource.DataSource = FilteredListWithNoCurriculumEnquiryItemsListed;
        }

        #endregion

        private void tabEnquiryWorkbench_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((tabEnquiryWorkbench).SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    this.refreshNewEnquiry();
                    break;
                case 2:
                    this.refreshClosedEnquiry();
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

        private void dgvNewEnquiryTab_NewEnquiry_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var EnquiryObj = (Data.Models.Enquiry)(row.DataBoundItem);

                    string CompanyNameOrPrivate = "";
                    if (EnquiryObj.Companies.Count == 0)
                    {
                        CompanyNameOrPrivate = "Private";
                        txtNewEnquiryTab_CompanyName.Text = "NA - Private Enquiry";
                    }
                    else
                    {
                        CompanyNameOrPrivate = EnquiryObj.Companies.FirstOrDefault<Data.Models.Company>().CompanyName;
                    }
                }
            }
        }

        private void dgvNewEnquiryTab_NewEnquiry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvNewEnquiryTab_ContactDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var ContactDetailObj = (ContactDetail)(row.DataBoundItem);
                    row.Cells[colNewEquiry_ContactType.Index].Value = ContactDetailObj.LookupContactType.ContactType.ToString();

                }
            }
        }

        private void dgvNewEnquiryTab_ContactDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvNewEnquiryTab_CurriculumEnquiry_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var CurriculumEnquiryObj = (CurriculumEnquiry)(row.DataBoundItem);


                    row.Cells[colNewEnquiry_QtyNotEnrolled.Index].Value = CurriculumEnquiryObj.Enrollments.Count.ToString();
                    row.Cells[colNewEnquiry_Curriculum.Index].Value = CurriculumEnquiryObj.Curriculum.CurriculumName.ToString();
                }
            }
        }

        private void dgvNewEnquiryTab_CurriculumEnquiry_DataError(object sender, DataGridViewDataErrorEventArgs e) { }

        private void txtNewEnquiryTab_CompanyName_BindingContextChanged(object sender, EventArgs e) { }

        private void NewEnquiryTab_NewEnquiryBindingSource_PositionChanged(object sender, EventArgs e)
        {

            Data.Models.Enquiry EnquiryObj = (Data.Models.Enquiry)(NewEnquiryTab_NewEnquiryBindingSource.Current);
            if (EnquiryObj != null)
            {
                if (EnquiryObj != null)
                {
                    if (EnquiryObj.Companies.Count == 0)
                    {
                        txtNewEnquiryTab_CompanyName.Text = "NA - Private Enquiry";
                    }

                }
            }




        }

        private void dgvNewEnquiryTab_CurriculumEnquiry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //colNewEnquiry_Curriculum.Name
            //dgvNewEnquiryTab_CurriculumEnquiry.Rows[e.RowIndex].Cells[e.ColumnIndex].
            //row.Cells[colNewEnquiry_Curriculum.Index].Value
            // MessageBox.Show("Col Index : " + dgvNewEnquiryTab_CurriculumEnquiry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

            CurriculumEnquiry CE = (CurriculumEnquiry)dgvNewEnquiryTab_CurriculumEnquiry.Rows[e.RowIndex].DataBoundItem;
            Data.Models.Enquiry CurrentEnquiryObj = (Data.Models.Enquiry)NewEnquiryTab_NewEnquiryBindingSource.Current;
            switch (e.ColumnIndex)
            {
                case 1:
                    //Close the enquiry
                    DialogResult Rtn = MessageBox.Show("Are you Sure that you wish to Close this Enquiry?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (Rtn == DialogResult.Yes)
                    {
                        using (var Dbconnection = new MCDEntities())
                        {
                            Dbconnection.CurriculumEnquiries.Attach(CE);
                            CE.EnquiryStatusID = (int)EnumEnquiryStatuses.Enquiry_Closed;
                            CE.LastUpdated = DateTime.Now;
                            Dbconnection.Entry<CurriculumEnquiry>(CE).State = System.Data.Entity.EntityState.Modified;
                            Dbconnection.SaveChanges();
                            Dbconnection.CurriculumEnquiries.Remove(CE);
                        };
                    }
                    if (curriculumEnquiriesBindingSource.Count == 0)
                    {
                        refreshNewEnquiry();
                    }

                    break;
                //Accept the Enquiry
                case 2:
                    frmSendEmail frm = new frmSendEmail();

                    List<ContactDetail> CustomEmailPerson = (from a in CurrentEnquiryObj.Individuals
                                                             from b in a.ContactDetails
                                                             where b.ContactTypeID == (int)Common.Enum.EnumContactTypes.Email_Address
                                                             select b).ToList<ContactDetail>();

                    //Sets the Email Address For the Currently Selected Contact For this Enquiry
                    foreach (ContactDetail ConDetObj in CustomEmailPerson)
                    {
                        if (frm.txtTestingToAddress.Text.Length > 0)
                        {
                            frm.txtTestingToAddress.Text += ";";
                        }
                        frm.txtTestingToAddress.Text += ConDetObj.ContactDetailValue;
                    }

                    frm.txtTestSubject.Text = "Enquiry No: ( " + CE.EnquiryID + "-" + CE.CurriculumEnquiryID + " ) Enquiry Feed Back";

                    frm.ShowDialog();
                    using (var Dbconnection = new MCDEntities())
                    {
                        EquiryHistory hist = new EquiryHistory
                        {
                            EnquiryID = CE.EnquiryID,
                            EmployeeID = this.CurrentEmployeeLoggedIn.EmployeeID,
                            LookupEquiyHistoryTypeID = (int)EnumEquiryHistoryTypes.Enquiry_Custom_Email_Message_Sent,
                            DateEnquiryUpdated = DateTime.Now,
                            EnquiryNotes = "Custom Message Sent To Client Via Email\nSubject of the Message was:\n\n{" + frm.txtTestSubject.Text + "}\n\nBody Of the Message read:\n" + frm.txtTestMessage.Text
                        };
                        Dbconnection.EquiryHistories.Add(hist);
                        int IsSaved = Dbconnection.SaveChanges();
                        if (IsSaved > 0)
                        {
                            Dbconnection.CurriculumEnquiries.Attach(CE);
                            CE.LastUpdated = DateTime.Now;
                            Dbconnection.Entry<CurriculumEnquiry>(CE).State = EntityState.Modified;
                            Dbconnection.SaveChanges();

                        }
                        dgvNewEnquiryTab_CurriculumEnquiry.Refresh();
                    };

                    break;
                //Close the Equiry
                case 3:
                    frmEnquiryViewHistory frm5 = new frmEnquiryViewHistory();
                    frm5.CurrentEnquiryID = CurrentEnquiryObj.EnquiryID;
                    frm5.ShowDialog();
                    break;
                case 8:
                    if (CurrentEnquiryObj.InitialConsultationComplete)
                    {

                        if (!CE.InitialCurriculumEnquiryDocumentationSent)
                        {
                            frmInitailDocumentation frm3 = new frmInitailDocumentation();
                            frm3.ShowDialog();
                            if (!frm3.IsCanceled)
                            {

                                if (frm3.UseEmail)
                                {
                                    frmSendEmail frm1 = new frmSendEmail();

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

                                    frm1.txtTestSubject.Text = "Enquiry No: ( " + CurrentEnquiryObj.EnquiryID + "-" + CE.CurriculumEnquiryID + " ) Enquiry Feed Back";

                                    using (var Dbconnection = new MCDEntities())
                                    {

                                        List<MessageTemplate> MT = (from a in Dbconnection.MessageTemplates
                                                                    from b in a.Files
                                                                    where a.ProcessStepID == (int)EnumProcessSteps.Enquiry__Apprenticeship__Step_1__Documentation_To_Send
                                                                    select a).ToList<MessageTemplate>();

                                        MessageTemplate CurrentMessageTemplate = MT.FirstOrDefault<MessageTemplate>();
                                        string Mess = "Good Day " + txtNewEnquiryTab_ContactPersonTitle.Text + " " + txtNewEnquiryTab_ContactPersonFirstName.Text + " " + txtNewEnquiryTab_ContactPersonLastName.Text + "\n \n";
                                        frm1.txtTestMessage.Text = "Please Reference the Following Line Equiry Number when returning any documentation: \n" +
                                                                    "Enquiry No " + CE.EnquiryID + "-" + CE.CurriculumEnquiryID + "\n" + Mess + CurrentMessageTemplate.Message;
                                        foreach (MessageTemplate MTObj in MT)
                                        {
                                            foreach (Data.Models.File FileObj in MTObj.Files)
                                            {
                                                frm1.AttachmentsUsingDbImageFileID.Add(FileObj.ImageID);
                                            }
                                        }

                                    };
                                    frm1.ShowDialog();
                                    using (var Dbconnection = new MCDEntities())
                                    {
                                        EquiryHistory hist = new EquiryHistory
                                        {
                                            EnquiryID = CE.EnquiryID,
                                            EmployeeID = this.CurrentEmployeeLoggedIn.EmployeeID,
                                            LookupEquiyHistoryTypeID = (int)EnumEquiryHistoryTypes.Enquiry_Initial_Documentation_Sent,
                                            DateEnquiryUpdated = DateTime.Now,
                                            EnquiryNotes = "Documentation Sent To Client Via Email"
                                        };
                                        Dbconnection.EquiryHistories.Add(hist);
                                        int IsSaved = Dbconnection.SaveChanges();
                                        if (IsSaved > 0)
                                        {
                                            Dbconnection.CurriculumEnquiries.Attach(CE);
                                            CE.InitialCurriculumEnquiryDocumentationSent = true;
                                            CE.LastUpdated = DateTime.Now;
                                            Dbconnection.Entry<CurriculumEnquiry>(CE).State = EntityState.Modified;
                                            Dbconnection.SaveChanges();

                                        }
                                        dgvNewEnquiryTab_CurriculumEnquiry.Refresh();
                                    };
                                }
                                else
                                {

                                    using (var Dbconnection = new MCDEntities())
                                    {
                                        EquiryHistory hist = new EquiryHistory
                                        {
                                            EnquiryID = CE.EnquiryID,
                                            EmployeeID = this.CurrentEmployeeLoggedIn.EmployeeID,
                                            LookupEquiyHistoryTypeID = (int)EnumEquiryHistoryTypes.Enquiry_Initial_Documentation_Sent,
                                            DateEnquiryUpdated = DateTime.Now,
                                            EnquiryNotes = "Documentation Manually Given To Client"
                                        };
                                        Dbconnection.EquiryHistories.Add(hist);
                                        int IsSaved = Dbconnection.SaveChanges();
                                        if (IsSaved > 0)
                                        {
                                            Dbconnection.CurriculumEnquiries.Attach(CE);
                                            CE.InitialCurriculumEnquiryDocumentationSent = true;
                                            CE.LastUpdated = DateTime.Now;
                                            Dbconnection.Entry<CurriculumEnquiry>(CE).State = EntityState.Modified;
                                            Dbconnection.SaveChanges();
                                            dgvNewEnquiryTab_CurriculumEnquiry.Refresh();
                                        }

                                    };
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Documentation Already Sent,\nUse Send Mail Option to send additional Mail.\nSee History For Details.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Initial Contsultation Not Completed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
                case 10:
                    if (CE.Curriculum.DepartmentID == (int)EnumDepartments.Apprenticeship)
                    {
                        frmApprenticeshipEnrollmentFormV2 frm6 = new frmApprenticeshipEnrollmentFormV2();
                        frm6.CurrentCurriculumEnquiry = CE;
                        frm6.ShowDialog();
                        //Check to see if the amoount required to be enrolled equal the amount that have been enrolled.
                        if (CE.EnrollmentQuanity <= CE.Enrollments.Count)
                        {
                            using (var Dbconnection = new MCDEntities())
                            {
                                Dbconnection.CurriculumEnquiries.Attach(CE);
                                CE.EnquiryStatusID = (int)EnumEnquiryStatuses.Enquiry_Closed;
                                CE.LastUpdated = DateTime.Now;
                                Dbconnection.Entry<CurriculumEnquiry>(CE).State = System.Data.Entity.EntityState.Modified;
                                Dbconnection.SaveChanges();
                                Dbconnection.CurriculumEnquiries.Remove(CE);
                                int currentIndex = NewEnquiryTab_NewEnquiryBindingSource.Position;
                                refreshNewEnquiry();
                                NewEnquiryTab_NewEnquiryBindingSource.Position = currentIndex;
                                dgvNewEnquiryTab_CurriculumEnquiry.Refresh();

                            };
                        }
                        DialogResult Rtn1 = MessageBox.Show("Do you wish to View the Enrollment,\and course selection?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (Rtn1 == DialogResult.Yes)
                        {
                            frmStudentCourseEnrollmentV2 frm7 = new frmStudentCourseEnrollmentV2();
                            frm7.ShowDialog();
                        }
                    }


                    //frm6.CurrentEnrollments.ApprienticeshipEnrollment.(CE);
                    break;
            }
        }

        private void btnFilterTrainingDepartmentCourses_Click(object sender, EventArgs e)
        {
            this.refreshNewEnquiry();
        }

        private void tsbtnRefreshCourseSearch_Click(object sender, EventArgs e)
        {
            txtFilterCriteriaForNewEnquiry.Clear();
            this.refreshNewEnquiry();
        }

        private void dgvNewEnquiryTab_NewEnquiry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Data.Models.Enquiry En = (Data.Models.Enquiry)dgvNewEnquiryTab_NewEnquiry.Rows[e.RowIndex].DataBoundItem;
            switch (e.ColumnIndex)
            {
                case 2:
                    if (!(Boolean)En.InitialConsultationComplete)
                    {
                        DialogResult Rtn1 = MessageBox.Show("Is Intial Consultation Completed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (Rtn1 == DialogResult.Yes)
                        {
                            frmEnquiryInitialConsultation frm3 = new frmEnquiryInitialConsultation();

                            frm3.CurrentEnquiry = En;
                            frm3.EmployeeID = CurrentEmployeeLoggedIn.EmployeeID;
                            frm3.ShowDialog();
                            dgvNewEnquiryTab_NewEnquiry.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Consultation Already Completed,See History.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    break;
                //SEnd Email Message

                case 4:
                    //CurriculumEnquiry CE = En.CurriculumEnquiries;

                    frmSendEmail frm = new frmSendEmail();
                    frm.ShowDialog();
                    if (dgvNewEnquiryTab_CurriculumEnquiry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Send Mail")
                    {

                    }
                    break;

            }
        }

        private void dgvClosedCompletedEnquiry_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dgvClosedCompletedEnquiry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvClosedCompletedEnquiry_CurriculumEnquiry_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var CurriculumEnquiryObj = (CurriculumEnquiry)(row.DataBoundItem);

                    row.Cells[ColClosedEnquiryCurriculum.Index].Value = CurriculumEnquiryObj.Curriculum.CurriculumName.ToString();
                }
            }
        }

        private void dgvClosedCompletedEnquiry_CurriculumEnquiry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvClosedCompletedEnquiryContacts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var ContactDetailObj = (ContactDetail)(row.DataBoundItem);
                    row.Cells[colNewEquiry_ContactType.Index].Value = ContactDetailObj.LookupContactType.ContactType.ToString();

                }
            }
        }

        private void dgvClosedCompletedEnquiryContacts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
