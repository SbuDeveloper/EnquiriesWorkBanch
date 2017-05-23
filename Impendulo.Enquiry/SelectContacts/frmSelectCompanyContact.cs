
using Impendulo.Company.AddCompany.Development;
using Impendulo.Company.SearchForCompany.Development;
using Impendulo.ContactDetails.Development;
using Impendulo.Contacts.Development;
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

namespace Impendulo.Enquiry.SelectContacts.Deployment1

{
    public partial class frmSelectCompanyContact : Form
    {
        public Data.Models.Company CurrentCompany { get; set; }
        public Individual SelectedIndividual { get; set; }

        private string SerachCriteriaCompanyName { get; set; }
        private string SerachCriteriaContactName { get; set; }
        public frmSelectCompanyContact()
        {
            this.CurrentCompany = new Data.Models.Company();
            InitializeComponent();
        }

        private void frmSelectCompanyContact_Load(object sender, EventArgs e)
        {
            setContactNameSearchCriteria();
            if (CurrentCompany != null)
            {
                txtCompanyName.Text = CurrentCompany.CompanyName;

                this.refreshCompanyContacts();
                this.refreshCompanyContactDetails();

                int SelectedIndividualIndex = 0;
                if (SelectedIndividual != null)
                {
                    foreach (Individual x in individualBindingSource.List)
                    {
                        if (x.IndividualID == SelectedIndividual.IndividualID)
                        {
                            individualBindingSource.Position = SelectedIndividualIndex;
                        }
                        SelectedIndividualIndex++;
                    }
                }

                this.setDisplayControlsToEnabled();
            }
            else
            {
                this.setDisplayControlsToDisabled();


            }


        }

        private void setDisplayControlsToEnabled()
        {
            this.txtCompanyName.Text = CurrentCompany.CompanyName;
            this.gbContacts.Enabled = true;
            this.btnSelectContact.Enabled = true;
        }

        private void setDisplayControlsToDisabled()
        {
            this.btnSelectContact.Enabled = false;
            this.gbContacts.Enabled = false;
            this.txtCompanyName.Clear();
        }
        private void refreshCompanyContacts()
        {
            if (CurrentCompany != null)
            {
                this.populateCompanyContacts();
                if (individualBindingSource.Count > 0)
                {
                    this.btnSelectContact.Enabled = true;
                }
                else
                {
                    this.btnSelectContact.Enabled = false;
                }
            }


        }
        private void refreshCompanyContactDetails()
        {
            int _IndividualID = 0;
            if (individualBindingSource.Count > 0 && CurrentCompany != null)
            {
                _IndividualID = ((Individual)individualBindingSource.Current).IndividualID;
                this.populateCompanyContactDetails(_IndividualID);
            }
            else
            {
                this.contactDetailBindingSource.DataSource = null;
            }
        }




        private void populateCompanyContactDetails(int _IndividualID)
        {
            this.contactDetailBindingSource.DataSource = (from a in CurrentCompany.Individuals
                                                          from b in a.ContactDetails
                                                          where a.IndividualID == _IndividualID
                                                          select b).ToList<ContactDetail>();
        }
        private void populateCompanyContacts()
        {
            this.individualBindingSource.DataSource = (from a in CurrentCompany.Individuals
                                                       
                                                       where a.IndividualFirstName.ToLower().Contains(SerachCriteriaContactName)
                                                          || a.IndividualSecondName.ToLower().Contains(SerachCriteriaContactName) ||
                                                          a.IndividualLastname.ToLower().Contains(SerachCriteriaContactName)
                                                       select a).ToList<Individual>();
        }

        private void btnSelectCompany_Click(object sender, EventArgs e)
        {
            frmCompanySearch frm = new frmCompanySearch();

            frm.ShowDialog();
            CurrentCompany = frm.CurrentCompany;
            if (CurrentCompany != null)
            {
                this.setDisplayControlsToEnabled();
            }
            else
            {
                this.setDisplayControlsToDisabled();
                this.individualBindingSource.Clear();
            }
            this.refreshCompanyContacts();
            this.refreshCompanyContactDetails();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            frmContacts frm = new frmContacts();
            frm.ShowDialog();
            //Data.Models.Company CompanyObj = (Data.Models.Company)companyBindingSource.Current;
            if (frm.CurrentContact != null)
            {
                if (frm.CurrentContact.IndividualID != 0)
                {
                    using (var Dbconnection = new MCDEntities())
                    {
                        Dbconnection.Companies.Attach(CurrentCompany);
                        Dbconnection.Individuals.Attach(frm.CurrentContact);
                        CurrentCompany.Individuals.Add(frm.CurrentContact);
                        Dbconnection.SaveChanges();
                        Dbconnection.Entry(frm.CurrentContact).Collection(a => a.ContactDetails).Load();

                    };
                }
            }
            // CompanyObj.Individuals.Add(NewContact);
            this.refreshCompanyContacts();

        }

        private void individualBindingSource_PositionChanged(object sender, EventArgs e)
        {
            this.refreshCompanyContactDetails();
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            frmContacts frm = new frmContacts();

            Individual IndividualObj = (Individual)individualBindingSource.Current;

            //Data.Models.Company CompanyObj = (Data.Models.Company)companyBindingSource.Current;

            Individual IndividualToUpdate = null;
            foreach (Individual CurrentIndividualObj in CurrentCompany.Individuals)
            {
                System.Type type = IndividualObj.GetType();
                //if (CurrentIndividualObj.IndividualID == (int)type.GetProperty("IndividualID").GetValue(IndividualObj, null))
                if (CurrentIndividualObj.IndividualID == IndividualObj.IndividualID)
                {
                    IndividualToUpdate = CurrentIndividualObj;
                }
            }
            if (IndividualToUpdate != null)
            {
                frm.CurrentContact = IndividualToUpdate;
                frm.IndividualID = IndividualToUpdate.IndividualID;
                frm.ShowDialog();
                this.refreshCompanyContacts();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectContact_Click(object sender, EventArgs e)
        {
            SelectedIndividual = (Individual)individualBindingSource.Current;

            this.Close();
        }

        private void btnAddContactInfo_Click(object sender, EventArgs e)
        {
            Individual CurrentContact = (Individual)individualBindingSource.Current;
            frmAddUpdateContactDetails frm = new frmAddUpdateContactDetails();
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
                this.refreshCompanyContactDetails();
            }
        }

        private void btnUpdateContactDetials_Click(object sender, EventArgs e)
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

                this.refreshCompanyContactDetails();
            }
        }

        private void dgvCompanyContacts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var IndividualObj = (Individual)(row.DataBoundItem);
                    //var lookupAddressTypeObj = AddressObj.LookupAddressType.AddressType;

                    row.Cells[colContactTitle.Index].Value = IndividualObj.LookupTitle.Title.ToString();
                    row.Cells[colContactFullName.Index].Value = IndividualObj.IndividualFirstName + " " + IndividualObj.IndividualSecondName + " " + IndividualObj.IndividualLastname.ToString();

                }
            }
        }

        private void dgvStudentContactInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
        private void setContactNameSearchCriteria()
        {
            SerachCriteriaContactName = txtContactsFilterCriteria.Text.ToLower().ToString();
        }

        private void btnFilterContacts_Click(object sender, EventArgs e)
        {
            this.setContactNameSearchCriteria();
            this.refreshCompanyContacts();
            this.refreshCompanyContactDetails();
        }

        private void btnRefreshContactsearch_Click(object sender, EventArgs e)
        {
            this.txtContactsFilterCriteria.Clear();
            this.setContactNameSearchCriteria();
            this.refreshCompanyContacts();
            this.refreshCompanyContactDetails();
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            frmAddCompany frm = new frmAddCompany();
            frm.ShowDialog();

        }

    }
}
