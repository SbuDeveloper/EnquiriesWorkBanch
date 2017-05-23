namespace Impendulo.Enquiry.UpdateSelectedCurriculumEnrollQty.Development
{
    partial class frmUpdateSelectedCurriculumEnrollQty
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdateSelectedCurriculum = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nudQtyToEnroll = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtyToEnroll)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdateSelectedCurriculum);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudQtyToEnroll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 93);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update";
            // 
            // btnUpdateSelectedCurriculum
            // 
            this.btnUpdateSelectedCurriculum.Location = new System.Drawing.Point(15, 56);
            this.btnUpdateSelectedCurriculum.Name = "btnUpdateSelectedCurriculum";
            this.btnUpdateSelectedCurriculum.Size = new System.Drawing.Size(158, 25);
            this.btnUpdateSelectedCurriculum.TabIndex = 14;
            this.btnUpdateSelectedCurriculum.Text = "Update";
            this.btnUpdateSelectedCurriculum.UseVisualStyleBackColor = true;
            this.btnUpdateSelectedCurriculum.Click += new System.EventHandler(this.btnUpdateSelectedCurriculum_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Qty To Enroll";
            // 
            // nudQtyToEnroll
            // 
            this.nudQtyToEnroll.Location = new System.Drawing.Point(97, 30);
            this.nudQtyToEnroll.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtyToEnroll.Name = "nudQtyToEnroll";
            this.nudQtyToEnroll.Size = new System.Drawing.Size(76, 20);
            this.nudQtyToEnroll.TabIndex = 11;
            this.nudQtyToEnroll.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmUpdateSelectedCurriculumEnrollQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 93);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUpdateSelectedCurriculumEnrollQty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Qty";
            this.Load += new System.EventHandler(this.frmUpdateSelectedCurriculumEnrollQty_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtyToEnroll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdateSelectedCurriculum;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown nudQtyToEnroll;
    }
}