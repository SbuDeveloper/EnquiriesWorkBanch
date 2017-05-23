using Impendulo.Common.FileHandeling;
using Impendulo.Data.Models;
using Impendulo.StudentForms.Development;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impendulo.Enquiry.Development.EnquiryProcessing.Aprenticeship.Step2___DocumentationRecieved.Development
{
    public partial class frmDocumentationRecieved : Form
    {
        public frmDocumentationRecieved()
        {
            InitializeComponent();
        }

        private void frmDocumentationRecieved_Load(object sender, EventArgs e)
        {

        }

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            frmAddUpdateStudent frm = new frmAddUpdateStudent();
            frm.ShowDialog();
        }

        private void btnUploadEnrollmentForm_Click(object sender, EventArgs e)
        {
            List<File> UploadedFiles = FileHandeling.UploadFile();
            foreach (File CurrentFile in UploadedFiles)
            {

            }
        }

        private void btnUploadIDDocument_Click(object sender, EventArgs e)
        {
            List<File> UploadedFiles = FileHandeling.UploadFile();
            foreach (File CurrentFile in UploadedFiles)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
