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
using Impendulo.ContactDetails.Development;
using Impendulo.Common.Enum;
using Impendulo.Email.Development;

namespace Impendulo.Enquiry.ViewContactInformation.Development
{
    public partial class frmEnquiryViewContactInformation : Form
    {
        public Data.Models.Enquiry CurrentEnquiry { get; set; }
        private int _EnquiryID = 0;
        public int EnquiryID
        {
            get
            {
                return _EnquiryID;
            }
            set
            {
                _EnquiryID = value;
            }
        }
        public frmEnquiryViewContactInformation()
        {
            InitializeComponent();
        }



        private void frmEnquiryViewContactInformation_Load(object sender, EventArgs e)
        {
            this.refreshCompanyName();
            this.refreshContact();
            this.refreshContactDetails();
        }

        private void refreshCompanyName()
        {
            populateCompanyName();
        }
        private void refreshContact()
        {
            if (CurrentEnquiry.Individuals.Count() > 0)
            {
                this.populateContact();
            }
            else
            {
                txtContactName.Clear();

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


        private void populateCompanyName()
        {
            if (CurrentEnquiry.Companies.Count > 0)
            {
                txtContactInformationCompanyName.Text = CurrentEnquiry.Companies.FirstOrDefault<Data.Models.Company>().CompanyName;
            }
            else
            {
                txtContactInformationCompanyName.Text = "Private Individual";
            }
        }
        private void populateContact()
        {
            Individual CurrentContact = (from a in CurrentEnquiry.Individuals
                                         select a).FirstOrDefault<Individual>();
            txtContactName.Text = CurrentContact.IndividualFirstName + " " + CurrentContact.IndividualSecondName + " " + CurrentContact.IndividualLastname;

        }


        private void populateContactDetails()
        {

            List<ContactDetail> x = (from a in CurrentEnquiry.Individuals
                                     from b in a.ContactDetails
                                     select b).ToList<ContactDetail>();
            contactDetailBindingSource.DataSource = x;
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
                    if (ContactDetailObj.LookupContactType.ContactTypeID == Convert.ToInt32(EnumContactTypes.Email_Address))
                    {
                        row.Cells[colSendEmail.Index].Value = "Send Mail";
                    }
                    else
                    {
                        row.Cells[colSendEmail.Index].Value = "";
                        row.Cells[colSendEmail.Index].ReadOnly = true;
                    }


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewContactDetails_Click(object sender, EventArgs e)
        {

            if (CurrentEnquiry.Individuals.Count > 0)
            {
                frmAddUpdateContactDetails frm = new frmAddUpdateContactDetails();
                Individual CurrentContact = CurrentEnquiry.Individuals.FirstOrDefault<Individual>();
                frm.ContactDetailID = 0;
                frm.ShowDialog();
                if (frm.CurrentDetail != null)
                {
                    using (var Dbconnection = new MCDEntities())
                    {
                        Dbconnection.Individuals.Attach(CurrentContact);

                        Dbconnection.ContactDetails.Attach(frm.CurrentDetail);

                        CurrentContact.ContactDetails.Add(frm.CurrentDetail);

                        Dbconnection.SaveChanges();

                        Dbconnection.Entry(frm.CurrentDetail).Reference("LookupContactType").Load();
                    };
                    this.refreshContactDetails();
                }
            }

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateContactDetails_Click(object sender, EventArgs e)
        {
            frmAddUpdateContactDetails frm = new frmAddUpdateContactDetails();
            frm.ContactDetailID = ((ContactDetail)contactDetailBindingSource.Current).ContactDetailID;
            frm.CurrentDetail = (ContactDetail)contactDetailBindingSource.Current;
            frm.ShowDialog();
            if (frm.CurrentDetail != null)
            {
                using (var Dbconnection = new MCDEntities())
                {
                    Dbconnection.ContactDetails.Attach(frm.CurrentDetail);
                    Dbconnection.Entry(frm.CurrentDetail).State = System.Data.Entity.EntityState.Modified;
                    Dbconnection.SaveChanges();
                };

                this.refreshContactDetails();
            }
        }

        private void dgvIndividualContactDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvIndividualContactDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                frmSendEmail frm = new frmSendEmail();
                frm.ShowDialog();
                if (dgvIndividualContactDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Send Mail")
                {
                    
                }
            }
        }
    }
}
