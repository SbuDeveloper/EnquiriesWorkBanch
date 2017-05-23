using Impendulo.Common.Enum;
using Impendulo.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impendulo.Enquiry.Development.TestPage
{
    public partial class frmEnquiryTwest : Form
    {

        private MCDEntities db;
        public frmEnquiryTwest()
        {
            InitializeComponent();
        }

        private void frmEnquiryTwest_Load(object sender, EventArgs e)
        {
            
            
            
            loadEnquiry();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            db = new MCDEntities();
           // db.CurriculumEnquiries.Load();
            db.Enquiries.Load();
            enquiryBindingSource.DataSource = (from a in db.Enquiries.Local.ToBindingList()
                                                    .Where(b => b.CurriculumEnquiries.Where(c => c.EnquiryStatusID == (int)EnumEnquiryStatuses.New).Count() > 0) select a);
                                               // c=> c.
                                               //from b in a.CurriculumEnquiries
                                               //where b.EnquiryStatusID == (int)EnumEnquiryStatuses.New
                                               //select a).ToList<Data.Models.Enquiry>();

        }
        private void loadEnquiry()
        {
            
            //(from a in db.Enquiries
            //                                   select a).ToList<Data.Models.Enquiry>();
        }
    }
}
