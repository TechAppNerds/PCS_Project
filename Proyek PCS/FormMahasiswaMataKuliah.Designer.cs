namespace Proyek_PCS
{
    partial class FormMahasiswaMatakuliah
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnBackHome = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEndThisSemester = new System.Windows.Forms.Button();
            this.btnAmbilMatakuliah = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(655, 296);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(291, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 25);
            this.label2.TabIndex = 37;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "Jadwal Mata Kuliah Jurusan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "Kelas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 25);
            this.label4.TabIndex = 39;
            this.label4.Text = "X";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 464);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(655, 273);
            this.dataGridView2.TabIndex = 40;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(679, 12);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 42;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnBackHome
            // 
            this.btnBackHome.Location = new System.Drawing.Point(598, 12);
            this.btnBackHome.Name = "btnBackHome";
            this.btnBackHome.Size = new System.Drawing.Size(75, 23);
            this.btnBackHome.TabIndex = 41;
            this.btnBackHome.Text = "Back Home";
            this.btnBackHome.UseVisualStyleBackColor = true;
            this.btnBackHome.Click += new System.EventHandler(this.btnBackHome_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(162, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(331, 25);
            this.label5.TabIndex = 43;
            this.label5.Text = "Mata Kuliah yang Diambil saat ini";
            // 
            // btnEndThisSemester
            // 
            this.btnEndThisSemester.Location = new System.Drawing.Point(679, 568);
            this.btnEndThisSemester.Name = "btnEndThisSemester";
            this.btnEndThisSemester.Size = new System.Drawing.Size(75, 39);
            this.btnEndThisSemester.TabIndex = 44;
            this.btnEndThisSemester.Text = "End This Semester";
            this.btnEndThisSemester.UseVisualStyleBackColor = true;
            this.btnEndThisSemester.Click += new System.EventHandler(this.btnEndThisSemester_Click);
            // 
            // btnAmbilMatakuliah
            // 
            this.btnAmbilMatakuliah.Location = new System.Drawing.Point(679, 206);
            this.btnAmbilMatakuliah.Name = "btnAmbilMatakuliah";
            this.btnAmbilMatakuliah.Size = new System.Drawing.Size(75, 39);
            this.btnAmbilMatakuliah.TabIndex = 45;
            this.btnAmbilMatakuliah.Text = "Ambil Mata Kuliah";
            this.btnAmbilMatakuliah.UseVisualStyleBackColor = true;
            this.btnAmbilMatakuliah.Click += new System.EventHandler(this.btnAmbilMatakuliah_Click);
            // 
            // FormMahasiswaMatakuliah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 749);
            this.Controls.Add(this.btnAmbilMatakuliah);
            this.Controls.Add(this.btnEndThisSemester);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnBackHome);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormMahasiswaMatakuliah";
            this.Text = "FormMahasiswaMatakuliah";
            this.Load += new System.EventHandler(this.FormMahasiswaMatakuliah_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnBackHome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEndThisSemester;
        private System.Windows.Forms.Button btnAmbilMatakuliah;
    }
}