using System;

namespace Proyek_PCS
{
    partial class FormBAAMasterMatakuliah
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
            this.btnInsert = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButtonKode = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBackhome = new System.Windows.Forms.Button();
            this.btnFormMahasiswa = new System.Windows.Forms.Button();
            this.btnFormDosen = new System.Windows.Forms.Button();
            this.radioButtonNama = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonJurusan = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btnJadwalMatakuliah = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(694, 251);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(668, 201);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(775, 251);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(856, 251);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(791, 138);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 20);
            this.textBox2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(691, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nama MataKuliah :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(691, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Jurusan MataKuliah :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 20);
            this.textBox1.TabIndex = 26;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioButtonKode
            // 
            this.radioButtonKode.AutoSize = true;
            this.radioButtonKode.Location = new System.Drawing.Point(167, 40);
            this.radioButtonKode.Name = "radioButtonKode";
            this.radioButtonKode.Size = new System.Drawing.Size(50, 17);
            this.radioButtonKode.TabIndex = 27;
            this.radioButtonKode.TabStop = true;
            this.radioButtonKode.Text = "Kode";
            this.radioButtonKode.UseVisualStyleBackColor = true;
            this.radioButtonKode.Click += new System.EventHandler(this.radioButtonKode_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(257, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(192, 25);
            this.label12.TabIndex = 29;
            this.label12.Text = "Master MataKuliah";
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
            // radioButtonNama
            // 
            this.radioButtonNama.AutoSize = true;
            this.radioButtonNama.Location = new System.Drawing.Point(223, 40);
            this.radioButtonNama.Name = "radioButtonNama";
            this.radioButtonNama.Size = new System.Drawing.Size(53, 17);
            this.radioButtonNama.TabIndex = 33;
            this.radioButtonNama.TabStop = true;
            this.radioButtonNama.Text = "Nama";
            this.radioButtonNama.UseVisualStyleBackColor = true;
            this.radioButtonNama.Click += new System.EventHandler(this.radioButtonNama_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(691, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Kode MataKuliah :";
            // 
            // radioButtonJurusan
            // 
            this.radioButtonJurusan.AutoSize = true;
            this.radioButtonJurusan.Location = new System.Drawing.Point(282, 40);
            this.radioButtonJurusan.Name = "radioButtonJurusan";
            this.radioButtonJurusan.Size = new System.Drawing.Size(62, 17);
            this.radioButtonJurusan.TabIndex = 49;
            this.radioButtonJurusan.TabStop = true;
            this.radioButtonJurusan.Text = "Jurusan";
            this.radioButtonJurusan.UseVisualStyleBackColor = true;
            this.radioButtonJurusan.Click += new System.EventHandler(this.radioButtonJurusan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(691, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Semester MataKuliah :";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(810, 190);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(121, 20);
            this.numericUpDown1.TabIndex = 52;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(787, 216);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(144, 20);
            this.numericUpDown2.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(691, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "SKS MataKuliah :";
            // 
            // btnJadwalMatakuliah
            // 
            this.btnJadwalMatakuliah.Location = new System.Drawing.Point(549, 83);
            this.btnJadwalMatakuliah.Name = "btnJadwalMatakuliah";
            this.btnJadwalMatakuliah.Size = new System.Drawing.Size(131, 23);
            this.btnJadwalMatakuliah.TabIndex = 70;
            this.btnJadwalMatakuliah.Text = "Lihat Jadwal Matakuliah";
            this.btnJadwalMatakuliah.UseVisualStyleBackColor = true;
            this.btnJadwalMatakuliah.Click += new System.EventHandler(this.btnJadwalMatakuliah_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(803, 164);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 21);
            this.comboBox1.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(791, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "0";
            // 
            // FormBAAMasterMatakuliah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 325);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnJadwalMatakuliah);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonJurusan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButtonNama);
            this.Controls.Add(this.btnFormDosen);
            this.Controls.Add(this.btnFormMahasiswa);
            this.Controls.Add(this.btnBackhome);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.radioButtonKode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnInsert);
            this.Name = "FormBAAMasterMatakuliah";
            this.Text = "FormBAAMasterMataKuliah";
            this.Load += new System.EventHandler(this.FormBAAMasterMataKuliah_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonKode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnBackhome;
        private System.Windows.Forms.Button btnFormMahasiswa;
        private System.Windows.Forms.Button btnFormDosen;
        private System.Windows.Forms.RadioButton radioButtonNama;
        private System.Windows.Forms.Timer timer1;
        private EventHandler FormBAAMasterMatakuliah_Load;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonJurusan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnJadwalMatakuliah;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}