using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Proyek_PCS
{
    public partial class FormBAAJadwalMatakuliah : Form
    {
        public static OracleConnection conn;
        public FormBAAJadwalMatakuliah()
        {
            InitializeComponent();
            conn = new OracleConnection();
        }

        private void FormBAAJadwalMatakuliah_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=orcl;User ID=BAA;password=BAA";
            try
            {
                conn.Open();
                refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void refresh()
        {
            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            da = new OracleDataAdapter("SELECT HARI_MK FROM JADWAL_MATAKULIAH UNION SELECT 'NO FILTER' FROM DUAL", conn);
            DataSet ds1 = new DataSet(); da.Fill(ds1); comboBox1.DataSource = ds1.Tables[0];
            comboBox1.DisplayMember = "HARI_MK"; comboBox1.ValueMember = "HARI_MK";
            da = new OracleDataAdapter("SELECT KODE_DOSEN FROM DOSEN",conn); DataSet ds2 = new DataSet(); da.Fill(ds2);
            comboBox3.DataSource = ds2.Tables[0]; comboBox3.DisplayMember = "KODE_DOSEN"; comboBox3.ValueMember = "KODE_DOSEN";
            btnUpdate.Enabled = false; btnDelete.Enabled = false;
        }

        private void btnBackhome_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide(); new FormBAAHome().ShowDialog();
                conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide(); new FormLogin().ShowDialog();
                conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFormDosen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide(); new FormBAADosen().ShowDialog();
                conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFormMahasiswa_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide(); new FormBAAMahasiswa().ShowDialog();
                conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try{
                if (textBox2.Text=="") {MessageBox.Show("Nama Mata Kuliah Wajib Diisi");}
                if (textBox3.Text == "") { MessageBox.Show("Jurusan Mata Kuliah Wajib Diisi");}
                if (numericUpDown1.Value<1) {MessageBox.Show("Semester Mata Kuliah Tidak Boleh 0");}
                if (numericUpDown2.Value < 1){MessageBox.Show("SKS Mata Kuliah Tidak Boleh 0");}
                if (radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked == false)
                {MessageBox.Show("Kelas Mata Kuliah Wajib Dipilih");}
                if (comboBox2.SelectedItem==null){MessageBox.Show("Hari Mata Kuliah Wajib Dipilih");}
                if (textBox6.Text == "") { MessageBox.Show("Jam Mata Kuliah Wajib Diisi"); }
                if (textBox7.Text == "") { MessageBox.Show("Ruang Mata Kuliah Wajib Diisi"); }
                else if(!String.IsNullOrEmpty(textBox2.Text)&&textBox3.Text!=""&&numericUpDown1.Value>0&&numericUpDown2.Value>0&&
                    (radioButton4.Checked==true||radioButton5.Checked==true||radioButton6.Checked==true)&&comboBox2.SelectedIndex>-1
                    && !String.IsNullOrEmpty(textBox6.Text)&& !String.IsNullOrEmpty(textBox7.Text))
                {
                    OracleCommand cmd = new OracleCommand(); cmd.Connection = conn; string k="";
                    if (radioButton4.Checked==true){ k = "A"; }
                    if (radioButton5.Checked == true) { k = "B"; }
                    if (radioButton6.Checked == true) { k = "C"; }
                    cmd.CommandText = "INSERT INTO JADWAL_MATAKULIAH VALUES('','" + textBox2.Text + "','" + textBox3.Text + "',"
                        + numericUpDown1.Value + ","+numericUpDown2.Value+",'"+k+"','"+comboBox2.SelectedItem+"','"
                        +textBox6.Text+"','"+textBox7.Text+"','"+comboBox3.SelectedValue+"')";
                    cmd.ExecuteNonQuery(); refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //int c = 0;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (textBox2.Text == "") { MessageBox.Show("Nama Mata Kuliah Wajib Diisi"); }
                    if (textBox3.Text == "") { MessageBox.Show("Jurusan Mata Kuliah Wajib Diisi"); }
                    if (numericUpDown1.Value < 1) { MessageBox.Show("Semester Mata Kuliah Tidak Boleh 0"); }
                    if (numericUpDown2.Value < 1) { MessageBox.Show("SKS Mata Kuliah Tidak Boleh 0"); }
                    if (radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked == false)
                    { MessageBox.Show("Kelas Mata Kuliah Wajib Dipilih"); }
                    if (comboBox2.SelectedItem == null) { MessageBox.Show("Hari Mata Kuliah Wajib Dipilih"); }
                    if (textBox6.Text == "") { MessageBox.Show("Jam Mata Kuliah Wajib Diisi"); }
                    if (textBox7.Text == "") { MessageBox.Show("Ruang Mata Kuliah Wajib Diisi"); }
                    else if (!String.IsNullOrEmpty(textBox2.Text) && textBox3.Text != "" && numericUpDown1.Value > 0 && numericUpDown2.Value > 0 &&
                        (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true) && comboBox2.SelectedIndex > -1
                        && !String.IsNullOrEmpty(textBox6.Text) && !String.IsNullOrEmpty(textBox7.Text))
                    {
                        OracleCommand cmd = new OracleCommand(); cmd.Connection = conn; string k = "";
                        if (radioButton4.Checked == true) { k = "A"; }
                        if (radioButton5.Checked == true) { k = "B"; }
                        if (radioButton6.Checked == true) { k = "C"; }
                        string nokode = dataGridView1.Rows[index].Cells[0].Value.ToString();

                        //cmd.CommandText = "UPDATE JADWAL_MATAKULIAH SET NAMA_MK='" + textBox2.Text+"',SMST_MK='"+numericUpDown1.Value 
                        //    + "',SKS_MATKUL='" + numericUpDown2.Value + "',KELAS_MK='" +k + "',HARI_MK='" + comboBox2.SelectedItem +
                        //    "',JAM_MK='" + textBox6.Text + "',RUANG_MK='" + textBox7.Text+ "',KODE_PENGAJAR='" + 
                        //    comboBox3.SelectedValue + "' WHERE KODE_MK='" + nokode + "' AND JURUSAN_MK='"+
                        //    dataGridView1.Rows[index].Cells[2].Value+"' AND KELAS_MK='"+dataGridView1.Rows[index].Cells[5].Value+"'";
                        //cmd.ExecuteNonQuery(); refresh();
                        //int c = 0;
                        //cmd.CommandText = "SELECT COUNT(*) INTO " + c + " FROM JADWAL_MATAKULIAH WHERE KODE_MK='" + dataGridView1.Rows[index].Cells[0].Value +
                        //    "' AND NAMA_MK='" + dataGridView1.Rows[index].Cells[1].Value + "' AND JURUSAN_MK='" + dataGridView1.Rows[index].Cells[2].Value
                        //    + "' AND KELAS_MK='" + dataGridView1.Rows[index].Cells[5].Value + "' ";
                        OracleDataAdapter da = new OracleDataAdapter("SELECT COUNT(*) FROM JADWAL_MATAKULIAH WHERE KODE_MK = '"
                            + dataGridView1.Rows[index].Cells[0] + "' AND NAMA_MK='" + dataGridView1.Rows[index].Cells[1]
                            + "' AND JURUSAN_MK='" + dataGridView1.Rows[index].Cells[2] + "' AND KELAS_MK='" +
                            dataGridView1.Rows[index].Cells[5] + "'", conn); DataSet jum = new DataSet(); da.Fill(jum);
                        MessageBox.Show(jum.Tables[0].Rows[0][0].ToString());
                        //MessageBox.Show(jum.Tables[0].Rows[0][0].ToString());

                        //cmd.CommandText = "INSERT INTO JADWAL_MATAKULIAH VALUES('','" + textBox2.Text + "','" + textBox3.Text + "',"
                        //    + numericUpDown1.Value + ","+numericUpDown2.Value+",'"+k+"','"+comboBox2.SelectedItem+"','"
                        //    +textBox6.Text+"','"+textBox7.Text+"','"+comboBox3.SelectedValue+"')";
                        /*cmd.ExecuteNonQuery();*/
                        refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
            //{
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            numericUpDown2.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "A")
            {
                radioButton4.Checked = true;
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "B")
            {
                radioButton5.Checked = true;
            }
            else
            {
                radioButton6.Checked = true;
            }
            comboBox2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            comboBox3.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[9].Value;
            btnUpdate.Enabled = true; btnDelete.Enabled = true; btnInsert.Enabled = false;
            textBox3.Enabled = false;

            //}
        }
        int index;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
