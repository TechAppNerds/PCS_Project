namespace Proyek_PCS
{
    partial class FormBAAHome
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
            this.btnForm_Jadwal_Matakuliah = new System.Windows.Forms.Button();
            this.btnForm_Dosen = new System.Windows.Forms.Button();
            this.btnForm_Mahasiswa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm_Jadwal_Matakuliah
            // 
            this.btnForm_Jadwal_Matakuliah.Location = new System.Drawing.Point(75, 50);
            this.btnForm_Jadwal_Matakuliah.Name = "btnForm_Jadwal_Matakuliah";
            this.btnForm_Jadwal_Matakuliah.Size = new System.Drawing.Size(132, 23);
            this.btnForm_Jadwal_Matakuliah.TabIndex = 0;
            this.btnForm_Jadwal_Matakuliah.Text = "Form Master Matakuliah";
            this.btnForm_Jadwal_Matakuliah.UseVisualStyleBackColor = true;
            this.btnForm_Jadwal_Matakuliah.Click += new System.EventHandler(this.btnForm_Jadwal_Matakuliah_Click);
            // 
            // btnForm_Dosen
            // 
            this.btnForm_Dosen.Location = new System.Drawing.Point(75, 79);
            this.btnForm_Dosen.Name = "btnForm_Dosen";
            this.btnForm_Dosen.Size = new System.Drawing.Size(132, 23);
            this.btnForm_Dosen.TabIndex = 1;
            this.btnForm_Dosen.Text = "Form Master Dosen";
            this.btnForm_Dosen.UseVisualStyleBackColor = true;
            this.btnForm_Dosen.Click += new System.EventHandler(this.btnForm_Dosen_Click);
            // 
            // btnForm_Mahasiswa
            // 
            this.btnForm_Mahasiswa.Location = new System.Drawing.Point(75, 108);
            this.btnForm_Mahasiswa.Name = "btnForm_Mahasiswa";
            this.btnForm_Mahasiswa.Size = new System.Drawing.Size(132, 23);
            this.btnForm_Mahasiswa.TabIndex = 2;
            this.btnForm_Mahasiswa.Text = "Form Master Mahasiswa";
            this.btnForm_Mahasiswa.UseVisualStyleBackColor = true;
            this.btnForm_Mahasiswa.Click += new System.EventHandler(this.btnForm_Mahasiswa_Click);
            // 
            // FormBAAHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnForm_Mahasiswa);
            this.Controls.Add(this.btnForm_Dosen);
            this.Controls.Add(this.btnForm_Jadwal_Matakuliah);
            this.Name = "FormBAAHome";
            this.Text = "FormBAAHome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForm_Jadwal_Matakuliah;
        private System.Windows.Forms.Button btnForm_Dosen;
        private System.Windows.Forms.Button btnForm_Mahasiswa;
    }
}