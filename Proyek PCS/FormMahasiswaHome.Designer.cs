namespace Proyek_PCS
{
    partial class FormMahasiswaHome
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
            this.btnJadwalMK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(60, 77);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(160, 23);
            this.btnProfile.TabIndex = 0;
            this.btnProfile.Text = "View My Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnJadwalMK
            // 
            this.btnJadwalMK.Location = new System.Drawing.Point(60, 106);
            this.btnJadwalMK.Name = "btnJadwalMK";
            this.btnJadwalMK.Size = new System.Drawing.Size(160, 23);
            this.btnJadwalMK.TabIndex = 1;
            this.btnJadwalMK.Text = "View My Matakuliah";
            this.btnJadwalMK.UseVisualStyleBackColor = true;
            this.btnJadwalMK.Click += new System.EventHandler(this.btnJadwalMK_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(60, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "View My Laporan Matakuliah";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMahasiswaHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnJadwalMK);
            this.Controls.Add(this.btnProfile);
            this.Name = "FormMahasiswaHome";
            this.Text = "FormMahasiswaHome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnJadwalMK;
        private System.Windows.Forms.Button button2;
    }
}