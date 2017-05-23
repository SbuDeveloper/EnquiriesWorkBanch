namespace Impendulo.Enquiry.ViewContactInformation.Development
{
    partial class frmEnquiryViewContactInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnquiryViewContactInformation));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dgvIndividualContactDetails = new System.Windows.Forms.DataGridView();
            this.colContactType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactDetailValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSendEmail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.contactDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRemoveContactDetails = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddNewContactDetails = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateContactDetails = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContactInformationCompanyName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndividualContactDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveContactDetails)).BeginInit();
            this.btnRemoveContactDetails.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.txtContactName);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtContactInformationCompanyName);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contact Information";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(380, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.toolStripContainer1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 89);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(475, 241);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contact Details";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvIndividualContactDetails);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(469, 197);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 16);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(469, 222);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.btnRemoveContactDetails);
            // 
            // dgvIndividualContactDetails
            // 
            this.dgvIndividualContactDetails.AllowUserToAddRows = false;
            this.dgvIndividualContactDetails.AllowUserToDeleteRows = false;
            this.dgvIndividualContactDetails.AutoGenerateColumns = false;
            this.dgvIndividualContactDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIndividualContactDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colContactType,
            this.contactDetailValueDataGridViewTextBoxColumn,
            this.colSendEmail});
            this.dgvIndividualContactDetails.DataSource = this.contactDetailBindingSource;
            this.dgvIndividualContactDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIndividualContactDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvIndividualContactDetails.Name = "dgvIndividualContactDetails";
            this.dgvIndividualContactDetails.ReadOnly = true;
            this.dgvIndividualContactDetails.RowHeadersWidth = 15;
            this.dgvIndividualContactDetails.RowTemplate.Height = 24;
            this.dgvIndividualContactDetails.Size = new System.Drawing.Size(469, 197);
            this.dgvIndividualContactDetails.TabIndex = 0;
            this.dgvIndividualContactDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIndividualContactDetails_CellContentClick);
            this.dgvIndividualContactDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvIndividualContactDetails_DataBindingComplete);
            this.dgvIndividualContactDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvIndividualContactDetails_DataError);
            // 
            // colContactType
            // 
            this.colContactType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colContactType.HeaderText = "Contact Type";
            this.colContactType.MinimumWidth = 120;
            this.colContactType.Name = "colContactType";
            this.colContactType.ReadOnly = true;
            this.colContactType.Width = 120;
            // 
            // contactDetailValueDataGridViewTextBoxColumn
            // 
            this.contactDetailValueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.contactDetailValueDataGridViewTextBoxColumn.DataPropertyName = "ContactDetailValue";
            this.contactDetailValueDataGridViewTextBoxColumn.HeaderText = "Contact Detail";
            this.contactDetailValueDataGridViewTextBoxColumn.Name = "contactDetailValueDataGridViewTextBoxColumn";
            this.contactDetailValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colSendEmail
            // 
            this.colSendEmail.HeaderText = "";
            this.colSendEmail.Name = "colSendEmail";
            this.colSendEmail.ReadOnly = true;
            this.colSendEmail.Text = "";
            this.colSendEmail.TrackVisitedState = false;
            // 
            // contactDetailBindingSource
            // 
            this.contactDetailBindingSource.DataSource = typeof(Impendulo.Data.Models.ContactDetail);
            // 
            // btnRemoveContactDetails
            // 
            this.btnRemoveContactDetails.AddNewItem = null;
            this.btnRemoveContactDetails.BindingSource = this.contactDetailBindingSource;
            this.btnRemoveContactDetails.CountItem = this.bindingNavigatorCountItem;
            this.btnRemoveContactDetails.DeleteItem = null;
            this.btnRemoveContactDetails.Dock = System.Windows.Forms.DockStyle.None;
            this.btnRemoveContactDetails.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.btnRemoveContactDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnAddNewContactDetails,
            this.bindingNavigatorDeleteItem,
            this.btnUpdateContactDetails});
            this.btnRemoveContactDetails.Location = new System.Drawing.Point(0, 0);
            this.btnRemoveContactDetails.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.btnRemoveContactDetails.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.btnRemoveContactDetails.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.btnRemoveContactDetails.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.btnRemoveContactDetails.Name = "btnRemoveContactDetails";
            this.btnRemoveContactDetails.PositionItem = this.bindingNavigatorPositionItem;
            this.btnRemoveContactDetails.Size = new System.Drawing.Size(469, 25);
            this.btnRemoveContactDetails.Stretch = true;
            this.btnRemoveContactDetails.TabIndex = 0;
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
            // btnAddNewContactDetails
            // 
            this.btnAddNewContactDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNewContactDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewContactDetails.Image")));
            this.btnAddNewContactDetails.Name = "btnAddNewContactDetails";
            this.btnAddNewContactDetails.RightToLeftAutoMirrorImage = true;
            this.btnAddNewContactDetails.Size = new System.Drawing.Size(23, 22);
            this.btnAddNewContactDetails.Text = "Add new";
            this.btnAddNewContactDetails.Click += new System.EventHandler(this.btnAddNewContactDetails_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // btnUpdateContactDetails
            // 
            this.btnUpdateContactDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateContactDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateContactDetails.Image")));
            this.btnUpdateContactDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateContactDetails.Name = "btnUpdateContactDetails";
            this.btnUpdateContactDetails.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateContactDetails.Text = "toolStripButton1";
            this.btnUpdateContactDetails.Click += new System.EventHandler(this.btnUpdateContactDetails_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 330);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(475, 28);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(397, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtContactName
            // 
            this.txtContactName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtContactName.Location = new System.Drawing.Point(79, 55);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.ReadOnly = true;
            this.txtContactName.Size = new System.Drawing.Size(288, 20);
            this.txtContactName.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Contact:";
            // 
            // txtContactInformationCompanyName
            // 
            this.txtContactInformationCompanyName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtContactInformationCompanyName.Location = new System.Drawing.Point(79, 29);
            this.txtContactInformationCompanyName.Name = "txtContactInformationCompanyName";
            this.txtContactInformationCompanyName.ReadOnly = true;
            this.txtContactInformationCompanyName.Size = new System.Drawing.Size(288, 20);
            this.txtContactInformationCompanyName.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Company:";
            // 
            // frmEnquiryViewContactInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 361);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEnquiryViewContactInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enquiry Contactn Information";
            this.Load += new System.EventHandler(this.frmEnquiryViewContactInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndividualContactDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemoveContactDetails)).EndInit();
            this.btnRemoveContactDetails.ResumeLayout(false);
            this.btnRemoveContactDetails.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtContactInformationCompanyName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridView dgvIndividualContactDetails;
        private System.Windows.Forms.BindingNavigator btnRemoveContactDetails;
        private System.Windows.Forms.ToolStripButton btnAddNewContactDetails;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource contactDetailBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton btnUpdateContactDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactType;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactDetailValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn colSendEmail;
    }
}