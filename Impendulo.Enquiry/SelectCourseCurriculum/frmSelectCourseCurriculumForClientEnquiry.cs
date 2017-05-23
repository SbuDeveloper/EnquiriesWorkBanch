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

namespace Impendulo.Enquiry.SelectCourseCurriculum.Development
{
    public partial class frmSelectCourseCurriculumForClientEnquiry : Form
    {
        public frmSelectCourseCurriculumForClientEnquiry()
        {
            InitializeComponent();
        }
        public Curriculum currentCurriculum { get; set; }
        public List<Curriculum> SelectedCurriculum { get; set; }
        private void frmSelectCourseCurriculumForClientEnquiry_Load(object sender, EventArgs e)
        {
            refreshDepartments();
            refreshDepartmentCurriculums();
        }

        private void refreshDepartments()
        {
            populateDepartments();
        }

        private void populateDepartments()
        {
            using (var Dbconnection = new MCDEntities())
            {
                lookupDepartmentBindingSource.DataSource = (from a in Dbconnection.LookupDepartments
                                                            orderby a.DepartmentName
                                                            select a).ToList<LookupDepartment>();
            };
        }

        private void refreshDepartmentCurriculums()
        {
            int _DepartmentID = 0;
            if (cboDepartments.SelectedValue != null)
            {
                _DepartmentID = Convert.ToInt32(cboDepartments.SelectedValue);
            };
            this.populateDepartmentCurriculums(_DepartmentID);
        }
        private void populateDepartmentCurriculums(int _DepartmentID)
        {

            using (var Dbconnection = new MCDEntities())
            {
                if (SelectedCurriculum == null)
                {
                    SelectedCurriculum = new List<Curriculum>();
                }
                List<Curriculum> allCurriculum = (from a in Dbconnection.Curriculums
                                                  .Include("LookupDepartment")
                                                  where a.DepartmentID == _DepartmentID &&
                                                  a.CurriculumName.Contains(this.txtCurriculumFilterCriteria.Text)
                                                  orderby a.CurriculumName
                                                  select a).ToList<Curriculum>();

                List<Curriculum> FilteredListOfCurriculum = new List<Curriculum>();

                foreach (Curriculum CurObj in allCurriculum)
                {
                    if (!CurriculumAlreadyListed(CurObj.CurriculumID))
                    {
                        FilteredListOfCurriculum.Add(CurObj);
                    }
                }

                curriculumBindingSource.DataSource = FilteredListOfCurriculum;
            };

        }

        private Boolean CurriculumAlreadyListed(int _CurriculumID)
        {
            Boolean Rtn = false;

            foreach (Curriculum FilterCurObj in SelectedCurriculum)
            {
                if (_CurriculumID == FilterCurObj.CurriculumID)
                {
                    Rtn = true;
                }
            }
            return Rtn;
        }

        private void cboDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.refreshDepartmentCurriculums();
            this.EnableOrDisableSelectButton();
        }

        private void EnableOrDisableSelectButton()
        {
            if (curriculumBindingSource.Count > 0)
            {
                this.btnSelectCurriculum.Enabled = true;
            }
            else
            {
                this.btnSelectCurriculum.Enabled = false;
            }
        }
        private void btnFilterTrainingDepartmentCourses_Click(object sender, EventArgs e)
        {
            this.refreshDepartmentCurriculums();
        }

        private void btnSelectCurriculum_Click(object sender, EventArgs e)
        {
            if (curriculumBindingSource.Count > 0)
            {
                this.currentCurriculum = (Curriculum)curriculumBindingSource.Current;
            }
            this.Close();
        }


    }
}
