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
using Impendulo.Contacts.Development;

namespace Impendulo.Enquiry.SelectContacts.Developemnt
{
    public partial class frmSelectIndividualContact : Form
    {
        public frmSelectIndividualContact()
        {
            InitializeComponent();
        }

        private string _FirstName = "";
        private string _LastName = "";

        private Individual _CurrentSelectedIndividual;
        public Individual SelectedIndividual
        {
            get
            {
                if (_CurrentSelectedIndividual == null)
                {
                    _CurrentSelectedIndividual = new Individual();
                }
                return _CurrentSelectedIndividual;
            }
            set { _CurrentSelectedIndividual = value; }
        }

        private void frmSelectIndividualContact_Load(object sender, EventArgs e)
        {
            if(SelectedIndividual.IndividualID != 0)
            {
                txtFirstName.Text = SelectedIndividual.IndividualFirstName;
                txtLastName.Text = SelectedIndividual.IndividualLastname;
                setSearchControls();
            }else
            {

            }
            this.refreshContacts();
            // this.refreshContactDetails();
        }

        private void setSearchControls()
        {
            _FirstName = this.txtFirstName.Text.ToString();
            _LastName = this.txtLastName.Text.ToString();
            this.refreshContacts();
        }
        private void refreshContacts()
        {
            this.populateContacts();
        }

        private void refreshContactDetails()
        {
            if (individualBindingSource.Count > 0)
            {
                populateContactDetails();
            }
            else
            {
                contactDetailBindingSource.DataSource = null;
            }
        }

        private void populateContactDetails()
        {
            Individual CurrentIndividual = (Individual)individualBindingSource.Current;
            contactDetailBindingSource.DataSource = (CurrentIndividual.ContactDetails).ToList<ContactDetail>();
            if (contactDetailBindingSource.Count > 0)
            {
                this.btnSelectContact.Enabled = true;
            }
            else
            {
                this.btnSelectContact.Enabled = false;
            }
        }

        private void populateContacts()
        {
            using (var Dbconnection = new MCDEntities())
            {
                List<Individual> AllIndividuals = (from a in Dbconnection.Individuals
                                                      .Include("ContactDetails")
                                                      .Include("ContactDetails.LookupContactType")
                                                   where a.IndividualFirstName.Contains(_FirstName) && a.IndividualLastname.Contains(_LastName)
                                                   select a)
                                                       .Except(from a in Dbconnection.Facilitators
                                                               select a.Individual)
                                                               .Except(from a in Dbconnection.Employees
                                                                       select a.Individual)
                                                                       .Except(from a in Dbconnection.Assessors
                                                                               select a.Individual)
                                                                               .Except(from a in Dbconnection.Students
                                                                                       select a.Individual)
                                                               .ToList<Individual>();

                individualBindingSource.DataSource = AllIndividuals;
            };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.setSearchControls();
            this.refreshContactDetails();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            this.setSearchControls();
            this.refreshContactDetails();
        }

        private void individualBindingSource_PositionChanged(object sender, EventArgs e)
        {
            this.refreshContactDetails();
        }

        private void dgvContactInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridView)sender;
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    var ContactDetailObj = (ContactDetail)(row.DataBoundItem);
                    row.Cells[colContactType.Index].Value = ContactDetailObj.LookupContactType.ContactType;
                }
            }
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
                this.refreshContactDetails();
            }
        }

        private void btnSelectContact_Click(object sender, EventArgs e)
        {
            if (individualBindingSource.Count > 0)
            {
                SelectedIndividual = (Individual)individualBindingSource.Current;
            }
            this.Close();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            frmContacts frm = new frmContacts();
            frm.ShowDialog();
            refreshContacts();
        }

        private void btnUpdateContactDetials_Click(object sender, EventArgs e)
        {

        }
    }
}
