namespace Impendulo.Enquiry.Development.InitialDocumentation.ApprenticeshipDocumentation
{
    partial class frmInitailDocumentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInitailDocumentation));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEmailDocumentation = new System.Windows.Forms.Button();
            this.btnManuallyGiven = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnEmailDocumentation);
            this.groupBox1.Controls.Add(this.btnManuallyGiven);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 222);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // btnEmailDocumentation
            // 
            this.btnEmailDocumentation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmailDocumentation.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailDocumentation.Image")));
            this.btnEmailDocumentation.Location = new System.Drawing.Point(16, 19);
            this.btnEmailDocumentation.Name = "btnEmailDocumentation";
            this.btnEmailDocumentation.Size = new System.Drawing.Size(135, 125);
            this.btnEmailDocumentation.TabIndex = 3;
            this.btnEmailDocumentation.Text = "Email Documentation";
            this.btnEmailDocumentation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmailDocumentation.UseVisualStyleBackColor = true;
            this.btnEmailDocumentation.Click += new System.EventHandler(this.btnEmailDocumentation_Click);
            // 
            // btnManuallyGiven
            // 
            this.btnManuallyGiven.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManuallyGiven.Image = ((System.Drawing.Image)(resources.GetObject("btnManuallyGiven.Image")));
            this.btnManuallyGiven.Location = new System.Drawing.Point(169, 19);
            this.btnManuallyGiven.Name = "btnManuallyGiven";
            this.btnManuallyGiven.Size = new System.Drawing.Size(141, 125);
            this.btnManuallyGiven.TabIndex = 2;
            this.btnManuallyGiven.Text = "Manual Given To Client";
            this.btnManuallyGiven.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManuallyGiven.UseVisualStyleBackColor = true;
            this.btnManuallyGiven.Click += new System.EventHandler(this.btnManuallyGiven_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(16, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(294, 51);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmInitailDocumentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 222);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInitailDocumentation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInitailDocumentation_FormClosing);
            this.Load += new System.EventHandler(this.frmAprenticeshipInitailDocumentation_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEmailDocumentation;
        private System.Windows.Forms.Button btnManuallyGiven;
        private System.Windows.Forms.Button btnCancel;
    }
}