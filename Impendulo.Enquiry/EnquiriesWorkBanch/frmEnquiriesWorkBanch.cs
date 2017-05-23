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
using Impendulo.Common.Enum;

namespace Impendulo.Enquiry.Development.EnquiriesWorkBanch
{
    public partial class frmEnquiriesWorkBanch : Form
    {
        public frmEnquiriesWorkBanch()
        {
            InitializeComponent();
        }

        private void frmEnquiriesWorkBanch_Load(object sender, EventArgs e)
        {
            /*set date parameters*/
            DateTime Todaydate = DateTime.Now;
            Todaydate.Month.ToString("D");
            lblcurrentdate.Text = Todaydate.ToShortDateString();
            dtpFrom.Value = new DateTime(Todaydate.Year, Todaydate.Month, 1);
            dtpTo.Value = new DateTime(Todaydate.Year, Todaydate.Month, 1).AddMonths(1).AddDays(-1);
            /*load queries*/
            LoadItems(dtpFrom.Value, dtpTo.Value, EnumDepartments.Apprenticeship);
            
        }
        private void LoadItems(DateTime FromDate, DateTime Todate, EnumDepartments aDepartment)
        {
            using (var Dbconnection = new MCDEntities())
            {
                lblEquiyTotalEquiry.Text = (from a in Dbconnection.Enquiries
                                                /*Include Sections */
                                            from b in a.CurriculumEnquiries
                                                /* Where Sections */
                                            where
                                                 /*Filters*/
                                                 (a.EnquiryDate >= FromDate &&
                                                  a.EnquiryDate <= Todate) &&
                                                  //Sections
                                                  b.Curriculum.DepartmentID == (int)aDepartment
                                            select a)
                                         /*Aggregation*/
                                         .Count<Data.Models.Enquiry>().ToString();
                //new enquiries
                lblNewEnquiry.Text = (from a in Dbconnection.Enquiries
                                      from b in a.CurriculumEnquiries
                                      where a.InitialConsultationComplete == true/*b.LookupEnquiryStatus.EnquiryStatusID == (int)EnumEnquiryStatuses.New*/
                                      && a.EnquiryDate >= FromDate && a.EnquiryDate <= Todate &&
                                      b.Curriculum.DepartmentID == (int)aDepartment
                                      select a).Count<Data.Models.Enquiry>().ToString();

                //Over due enquiries
                lblOverDueEnquiries.Text = (from a in Dbconnection.Enquiries
                                            from b in a.CurriculumEnquiries
                                            where a.EnquiryDate <= DateTime.Now &&
                                            b.Curriculum.DepartmentID == (int)aDepartment
                                            select a).Count<Data.Models.Enquiry>().ToString();

                //company enquiries
                lblCompanyEnquiry.Text = (from a in Dbconnection.Enquiries
                                          from b in a.Companies
                                          join c in Dbconnection.Companies on b.CompanyID equals c.CompanyID
                                          where a.EnquiryID == a.EnquiryID && a.EnquiryDate >= FromDate && a.EnquiryDate <= Todate
                                          select a).Count<Data.Models.Enquiry>().ToString();

                //Private enquiries
                lblPrivateEquiries.Text = (from a in Dbconnection.Enquiries
                                          from b in a.Individuals
                                          join c in Dbconnection.Individuals on b.IndividualID equals c.IndividualID
                                          where a.EnquiryID == a.EnquiryID && a.EnquiryDate >= FromDate && a.EnquiryDate <= Todate
                                          select a).Count<Data.Models.Enquiry>().ToString();
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadItems(dtpFrom.Value, dtpTo.Value, EnumDepartments.Apprenticeship);
        }
    }
}
