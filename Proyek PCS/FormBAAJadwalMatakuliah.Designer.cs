namespace Proyek_PCS
{
    partial class FormBAAJadwalMatakuliah
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBackhome = new System.Windows.Forms.Button();
            this.btnFormMahasiswa = new System.Windows.Forms.Button();
            this.btnFormDosen = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnMasterMatakuliah = new System.Windows.Forms.Button();
            this.btnCetakJadwalMatakuliah = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(919, 303);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(851, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(65, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(384, 20);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(65, 40);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(50, 17);
            this.radioButton1.TabIndex = 27;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Kode";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(392, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(193, 25);
            this.label12.TabIndex = 29;
            this.label12.Text = "Jadwal MataKuliah";
            // 
            // btnBackhome
            // 
            this.btnBackhome.Location = new System.Drawing.Point(770, 12);
            this.btnBackhome.Name = "btnBackhome";
            this.btnBackhome.Size = new System.Drawing.Size(75, 23);
            this.btnBackhome.TabIndex = 30;
            this.btnBackhome.Text = "Back Home";
            this.btnBackhome.UseVisualStyleBackColor = true;
            this.btnBackhome.Click += new System.EventHandler(this.btnBackhome_Click);
            // 
            // btnFormMahasiswa
            // 
            this.btnFormMahasiswa.Location = new System.Drawing.Point(669, 12);
            this.btnFormMahasiswa.Name = "btnFormMahasiswa";
            this.btnFormMahasiswa.Size = new System.Drawing.Size(95, 23);
            this.btnFormMahasiswa.TabIndex = 31;
            this.btnFormMahasiswa.Text = "Form Mahasiswa";
            this.btnFormMahasiswa.UseVisualStyleBackColor = true;
            this.btnFormMahasiswa.Click += new System.EventHandler(this.btnFormMahasiswa_Click);
            // 
            // btnFormDosen
            // 
            this.btnFormDosen.Location = new System.Drawing.Point(588, 12);
            this.btnFormDosen.Name = "btnFormDosen";
            this.btnFormDosen.Size = new System.Drawing.Size(75, 23);
            this.btnFormDosen.TabIndex = 32;
            this.btnFormDosen.Text = "Form Dosen";
            this.btnFormDosen.UseVisualStyleBackColor = true;
            this.btnFormDosen.Click += new System.EventHandler(this.btnFormDosen_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(121, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 17);
            this.radioButton2.TabIndex = 33;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Nama";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(248, 40);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(95, 17);
            this.radioButton4.TabIndex = 37;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Kode Pengajar";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Click += new System.EventHandler(this.radioButton4_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Filter Kelas :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "NO FILTER",
            "A",
            "B",
            "C"});
            this.comboBox1.Location = new System.Drawing.Point(83, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(91, 21);
            this.comboBox1.TabIndex = 47;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // btnMasterMatakuliah
            // 
            this.btnMasterMatakuliah.Location = new System.Drawing.Point(658, 83);
            this.btnMasterMatakuliah.Name = "btnMasterMatakuliah";
            this.btnMasterMatakuliah.Size = new System.Drawing.Size(128, 23);
            this.btnMasterMatakuliah.TabIndex = 49;
            this.btnMasterMatakuliah.Text = "Lihat Master Matakuliah";
            this.btnMasterMatakuliah.UseVisualStyleBackColor = true;
            this.btnMasterMatakuliah.Click += new System.EventHandler(this.btnMasterMatakuliah_Click);
            // 
            // btnCetakJadwalMatakuliah
            // 
            this.btnCetakJadwalMatakuliah.Location = new System.Drawing.Point(792, 83);
            this.btnCetakJadwalMatakuliah.Name = "btnCetakJadwalMatakuliah";
            this.btnCetakJadwalMatakuliah.Size = new System.Drawing.Size(139, 23);
            this.btnCetakJadwalMatakuliah.TabIndex = 50;
            this.btnCetakJadwalMatakuliah.Text = "Cetak Jadwal Matakuliah";
            this.btnCetakJadwalMatakuliah.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(180, 40);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(62, 17);
            this.radioButton3.TabIndex = 51;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Jurusan";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // FormBAAJadwalMatakuliah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 440);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.btnCetakJadwalMatakuliah);
            this.Controls.Add(this.btnMasterMatakuliah);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.btnFormDosen);
            this.Controls.Add(this.btnFormMahasiswa);
            this.Controls.Add(this.btnBackhome);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormBAAJadwalMatakuliah";
            this.Text = "FormBAAJadwalMatakuliah";
            this.Load += new System.EventHandler(this.FormBAAJadwalMatakuliah_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnBackhome;
        private System.Windows.Forms.Button btnFormMahasiswa;
        private System.Windows.Forms.Button btnFormDosen;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnMasterMatakuliah;
        private System.Windows.Forms.Button btnCetakJadwalMatakuliah;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}