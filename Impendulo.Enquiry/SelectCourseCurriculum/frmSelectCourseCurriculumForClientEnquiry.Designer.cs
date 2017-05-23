namespace Impendulo.Enquiry.SelectCourseCurriculum.Development
{
    partial class frmSelectCourseCurriculumForClientEnquiry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectCourseCurriculumForClientEnquiry));
            this.gbDepartments = new System.Windows.Forms.GroupBox();
            this.cboDepartments = new System.Windows.Forms.ComboBox();
            this.lookupDepartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbCurriculum = new System.Windows.Forms.GroupBox();
            this.toolStripContainerCurriculum = new System.Windows.Forms.ToolStripContainer();
            this.curriculumListBox = new System.Windows.Forms.ListBox();
            this.curriculumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtCurriculumFilterCriteria = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFilterTrainingDepartmentCourses = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefreshCourseSearch = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCurriculum = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelectCurriculum = new System.Windows.Forms.Button();
            this.gbDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDepartmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.gbCurriculum.SuspendLayout();
            this.toolStripContainerCurriculum.ContentPanel.SuspendLayout();
            this.toolStripContainerCurriculum.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerCurriculum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.curriculumBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCurriculum)).BeginInit();
            this.bindingNavigatorCurriculum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDepartments
            // 
            this.gbDepartments.Controls.Add(this.cboDepartments);
            this.gbDepartments.Controls.Add(this.label1);
            this.gbDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDepartments.Location = new System.Drawing.Point(0, 0);
            this.gbDepartments.Name = "gbDepartments";
            this.gbDepartments.Size = new System.Drawing.Size(331, 50);
            this.gbDepartments.TabIndex = 1;
            this.gbDepartments.TabStop = false;
            this.gbDepartments.Text = "Departments";
            // 
            // cboDepartments
            // 
            this.cboDepartments.DataSource = this.lookupDepartmentBindingSource;
            this.cboDepartments.DisplayMember = "DepartmentName";
            this.cboDepartments.FormattingEnabled = true;
            this.cboDepartments.Location = new System.Drawing.Point(79, 19);
            this.cboDepartments.Name = "cboDepartments";
            this.cboDepartments.Size = new System.Drawing.Size(240, 21);
            this.cboDepartments.TabIndex = 2;
            this.cboDepartments.ValueMember = "DepartmentID";
            this.cboDepartments.SelectedIndexChanged += new System.EventHandler(this.cboDepartments_SelectedIndexChanged);
            // 
            // lookupDepartmentBindingSource
            // 
            this.lookupDepartmentBindingSource.DataSource = typeof(Impendulo.Data.Models.LookupDepartment);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Departments";
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(Impendulo.Data.Models.LookupDepartment);
            // 
            // gbCurriculum
            // 
            this.gbCurriculum.Controls.Add(this.toolStripContainerCurriculum);
            this.gbCurriculum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCurriculum.Location = new System.Drawing.Point(0, 0);
            this.gbCurriculum.Name = "gbCurriculum";
            this.gbCurriculum.Size = new System.Drawing.Size(331, 279);
            this.gbCurriculum.TabIndex = 2;
            this.gbCurriculum.TabStop = false;
            this.gbCurriculum.Text = "Curriculum";
            // 
            // toolStripContainerCurriculum
            // 
            // 
            // toolStripContainerCurriculum.ContentPanel
            // 
            this.toolStripContainerCurriculum.ContentPanel.AutoScroll = true;
            this.toolStripContainerCurriculum.ContentPanel.Controls.Add(this.curriculumListBox);
            this.toolStripContainerCurriculum.ContentPanel.Size = new System.Drawing.Size(325, 208);
            this.toolStripContainerCurriculum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainerCurriculum.Location = new System.Drawing.Point(3, 16);
            this.toolStripContainerCurriculum.Name = "toolStripContainerCurriculum";
            this.toolStripContainerCurriculum.Size = new System.Drawing.Size(325, 260);
            this.toolStripContainerCurriculum.TabIndex = 0;
            this.toolStripContainerCurriculum.Text = "toolStripContainer1";
            // 
            // toolStripContainerCurriculum.TopToolStripPanel
            // 
            this.toolStripContainerCurriculum.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainerCurriculum.TopToolStripPanel.Controls.Add(this.bindingNavigatorCurriculum);
            // 
            // curriculumListBox
            // 
            this.curriculumListBox.DataSource = this.curriculumBindingSource;
            this.curriculumListBox.DisplayMember = "CurriculumName";
            this.curriculumListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curriculumListBox.FormattingEnabled = true;
            this.curriculumListBox.Location = new System.Drawing.Point(0, 0);
            this.curriculumListBox.Name = "curriculumListBox";
            this.curriculumListBox.Size = new System.Drawing.Size(325, 208);
            this.curriculumListBox.TabIndex = 0;
            this.curriculumListBox.ValueMember = "CostingModel";
            // 
            // curriculumBindingSource
            // 
            this.curriculumBindingSource.DataSource = typeof(Impendulo.Data.Models.Curriculum);
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.txtCurriculumFilterCriteria,
            this.toolStripSeparator2,
            this.btnFilterTrainingDepartmentCourses,
            this.tsbtnRefreshCourseSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(325, 27);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 2;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 24);
            this.toolStripLabel1.Text = "Filter";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // txtCurriculumFilterCriteria
            // 
            this.txtCurriculumFilterCriteria.Name = "txtCurriculumFilterCriteria";
            this.txtCurriculumFilterCriteria.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.txtCurriculumFilterCriteria.Size = new System.Drawing.Size(220, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnFilterTrainingDepartmentCourses
            // 
            this.btnFilterTrainingDepartmentCourses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFilterTrainingDepartmentCourses.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterTrainingDepartmentCourses.Image")));
            this.btnFilterTrainingDepartmentCourses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilterTrainingDepartmentCourses.Name = "btnFilterTrainingDepartmentCourses";
            this.btnFilterTrainingDepartmentCourses.Size = new System.Drawing.Size(24, 24);
            this.btnFilterTrainingDepartmentCourses.Text = "toolStripButton1";
            this.btnFilterTrainingDepartmentCourses.Click += new System.EventHandler(this.btnFilterTrainingDepartmentCourses_Click);
            // 
            // tsbtnRefreshCourseSearch
            // 
            this.tsbtnRefreshCourseSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRefreshCourseSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefreshCourseSearch.Image")));
            this.tsbtnRefreshCourseSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefreshCourseSearch.Name = "tsbtnRefreshCourseSearch";
            this.tsbtnRefreshCourseSearch.Size = new System.Drawing.Size(24, 24);
            this.tsbtnRefreshCourseSearch.Text = "toolStripButton2";
            // 
            // bindingNavigatorCurriculum
            // 
            this.bindingNavigatorCurriculum.AddNewItem = null;
            this.bindingNavigatorCurriculum.CanOverflow = false;
            this.bindingNavigatorCurriculum.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorCurriculum.DeleteItem = null;
            this.bindingNavigatorCurriculum.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigatorCurriculum.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigatorCurriculum.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigatorCurriculum.Location = new System.Drawing.Point(0, 27);
            this.bindingNavigatorCurriculum.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorCurriculum.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorCurriculum.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorCurriculum.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorCurriculum.Name = "bindingNavigatorCurriculum";
            this.bindingNavigatorCurriculum.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorCurriculum.Size = new System.Drawing.Size(325, 25);
            this.bindingNavigatorCurriculum.Stretch = true;
            this.bindingNavigatorCurriculum.TabIndex = 0;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbDepartments);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbCurriculum);
            this.splitContainer1.Size = new System.Drawing.Size(331, 333);
            this.splitContainer1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSelectCurriculum);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 298);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 35);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnSelectCurriculum
            // 
            this.btnSelectCurriculum.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectCurriculum.Image")));
            this.btnSelectCurriculum.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectCurriculum.Location = new System.Drawing.Point(219, 3);
            this.btnSelectCurriculum.Name = "btnSelectCurriculum";
            this.btnSelectCurriculum.Size = new System.Drawing.Size(109, 29);
            this.btnSelectCurriculum.TabIndex = 0;
            this.btnSelectCurriculum.Text = "Select";
            this.btnSelectCurriculum.UseVisualStyleBackColor = true;
            this.btnSelectCurriculum.Click += new System.EventHandler(this.btnSelectCurriculum_Click);
            // 
            // frmSelectCourseCurriculumForClientEnquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 333);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSelectCourseCurriculumForClientEnquiry";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Course Curriculum For Client Enquiry";
            this.Load += new System.EventHandler(this.frmSelectCourseCurriculumForClientEnquiry_Load);
            this.gbDepartments.ResumeLayout(false);
            this.gbDepartments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDepartmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.gbCurriculum.ResumeLayout(false);
            this.toolStripContainerCurriculum.ContentPanel.ResumeLayout(false);
            this.toolStripContainerCurriculum.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerCurriculum.TopToolStripPanel.PerformLayout();
            this.toolStripContainerCurriculum.ResumeLayout(false);
            this.toolStripContainerCurriculum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.curriculumBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCurriculum)).EndInit();
            this.bindingNavigatorCurriculum.ResumeLayout(false);
            this.bindingNavigatorCurriculum.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDepartments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCurriculum;
        private System.Windows.Forms.ToolStripContainer toolStripContainerCurriculum;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox txtCurriculumFilterCriteria;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFilterTrainingDepartmentCourses;
        private System.Windows.Forms.ToolStripButton tsbtnRefreshCourseSearch;
        private System.Windows.Forms.BindingNavigator bindingNavigatorCurriculum;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSelectCurriculum;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private System.Windows.Forms.ListBox curriculumListBox;
        private System.Windows.Forms.BindingSource curriculumBindingSource;
        private System.Windows.Forms.ComboBox cboDepartments;
        private System.Windows.Forms.BindingSource lookupDepartmentBindingSource;
    }
}