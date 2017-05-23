using Impendulo.Enquiry.Development.EnquiryV2.Development;
using Impendulo.Enquiry.Development.TestPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impendulo.ClientEnquiry.Development
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Impendulo.Enquiry.Development.EnquiriesWorkBanch.frmEnquiriesWorkBanch());
        }
    }
}
