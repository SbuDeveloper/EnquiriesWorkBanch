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

namespace Impendulo.Enquiry.Development.ViewHistory
{
    public partial class frmEnquiryViewHistory : Form
    {
        public int CurrentEnquiryID { get; set; }
        public frmEnquiryViewHistory()
        {
            InitializeComponent();
        }

        private void frmEnquiryViewHistory_Load(object sender, EventArgs e)
        {
            LoadupHistroyDetails();
        }

        private void LoadupHistroyDetails()
        {
            List<Data.Models.EquiryHistory> hist;

            using (var Dbconnection = new MCDEntities())
            {
                hist = (from a in Dbconnection.EquiryHistories
                        where a.EnquiryID == this.CurrentEnquiryID
                        orderby a.EnqueryHistoryID descending
                        select a)
                        .Include("LookupEquiryHistoryType")
                        .Include("Employee")
                        .Include("Employee.Individual")
                        .ToList<EquiryHistory>();
            };
            string output = "";
            foreach (EquiryHistory HistItem in hist)
            {
                string name = HistItem.Employee.Individual.IndividualFirstName + " " + HistItem.Employee.Individual.IndividualLastname;
                string LogRef = HistItem.EnqueryHistoryID.ToString();
                output += "Log Ref: " + LogRef + "\b\nCreated By: " + name + "\nDate: " + HistItem.DateEnquiryUpdated + "\nLog Type: " + HistItem.LookupEquiryHistoryType.LookupEquiyHistoryTypeName + "\n-------------------\nNotes: " + HistItem.EnquiryNotes + "\n-------------------\n";
            }
            txtHistoryLog.Text = output;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
