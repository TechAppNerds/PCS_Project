namespace Proyek_PCS
{
    partial class FormDosenHome
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
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnViewMyJadwal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(66, 78);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(149, 23);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "View My Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnViewMyJadwal
            // 
            this.btnViewMyJadwal.Location = new System.Drawing.Point(66, 107);
            this.btnViewMyJadwal.Name = "btnViewMyJadwal";
            this.btnViewMyJadwal.Size = new System.Drawing.Size(149, 23);
            this.btnViewMyJadwal.TabIndex = 1;
            this.btnViewMyJadwal.Text = "View My Jadwal Matakuliah";
            this.btnViewMyJadwal.UseVisualStyleBackColor = true;
            this.btnViewMyJadwal.Click += new System.EventHandler(this.btnViewMyJadwal_Click);
            // 
            // FormDosenHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnViewMyJadwal);
            this.Controls.Add(this.btnProfile);
            this.Name = "FormDosenHome";
            this.Text = "FormDosenHome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnViewMyJadwal;
    }
}