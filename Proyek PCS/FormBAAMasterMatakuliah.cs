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
    public partial class FormBAAMasterMatakuliah : Form
    {
        public static OracleConnection conn;
        public static string dts, userid, pass;
        public FormBAAMasterMatakuliah()
        {
            InitializeComponent(); conn = new OracleConnection(); numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 8; numericUpDown2.Minimum = 2; numericUpDown2.Maximum = 4;
            ((TextBox)numericUpDown1.Controls[1]).MaxLength = 1; ((TextBox)numericUpDown2.Controls[1]).MaxLength = 1;
        }

        private void FormBAAMasterMataKuliah_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
            try
            {
                conn.Open(); textBox1.Enabled = false; btnUpdate.Enabled = false; btnDelete.Enabled = false;                
                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH", conn);
                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                OracleDataAdapter da1 = new OracleDataAdapter("SELECT NAMA_MJ FROM MASTER_JURUSAN", conn);
                DataSet ds2 = new DataSet(); da1.Fill(ds2); comboBox1.DataSource = ds2.Tables[0];
                comboBox1.DisplayMember = "NAMA_MJ"; comboBox1.ValueMember = "NAMA_MJ"; timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DatabaseRefresh()
        {
            textBox1.Enabled = false; comboBox1.Enabled = true;
            label4.Text = "0"; textBox2.Text = ""; btnInsert.Enabled = true; btnUpdate.Enabled = false; btnDelete.Enabled = false;
            numericUpDown1.Enabled = true; numericUpDown2.Enabled = true; numericUpDown1.Value = 1; numericUpDown2.Value = 2;
            OracleDataAdapter da1 = new OracleDataAdapter("SELECT NAMA_MJ FROM MASTER_JURUSAN", conn); DataSet ds2 = new DataSet();
            da1.Fill(ds2); comboBox1.DataSource = ds2.Tables[0]; comboBox1.DisplayMember = "NAMA_MJ"; comboBox1.ValueMember = "NAMA_MJ";
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH", conn);
                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];                
            }
            else
            {
                if (radioButtonKode.Checked == true && radioButtonNama.Checked == false && radioButtonJurusan.Checked == false)
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(KODE_MK) LIKE"
                        + " UPPER('%" + textBox1.Text + "%') AND LOWER(KODE_MK) LIKE LOWER('%" + textBox1.Text + "%')", conn);
                    DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];                    
                }
                else if (radioButtonKode.Checked == false && radioButtonNama.Checked == true && radioButtonJurusan.Checked == false)
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(NAMA_MK) LIKE"
                        + " UPPER('%" + textBox1.Text + "%') AND LOWER(NAMA_MK) LIKE LOWER('%" + textBox1.Text + "%')", conn);
                    DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];                    
                }
                else
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(JURUSAN_MK)"
                        + " LIKE UPPER('%" + textBox1.Text + "%') AND LOWER(JURUSAN_MK) LIKE LOWER('%" + textBox1.Text + "%')", conn);
                    DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];                    
                }
            } timer1.Start();
        }

        private void btnBackhome_Click(object sender, EventArgs e)
        {
            try
            {
                FormBAAHome.dts = dts; FormBAAHome.userid = userid; FormBAAHome.pass = pass;
                this.Hide(); new FormBAAHome().ShowDialog(); conn.Close(); this.Close();
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
                FormLoginUserSQL.dts = dts; FormLoginUserSQL.userid = userid; FormLoginUserSQL.pass = pass;
                this.Hide(); new FormLoginUserSQL().ShowDialog(); conn.Close(); this.Close();
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
                FormBAADosen.dts = dts; FormBAADosen.userid = userid; FormBAADosen.pass = pass;
                this.Hide(); new FormBAADosen().ShowDialog(); conn.Close(); this.Close();
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
                FormBAAMahasiswa.dts = dts; FormBAAMahasiswa.userid = userid; FormBAAMahasiswa.pass = pass;
                this.Hide(); new FormBAAMahasiswa().ShowDialog(); conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text=="") {MessageBox.Show("Nama Mata Kuliah Wajib Diisi");}
                if (comboBox1.SelectedValue.ToString() == "") { MessageBox.Show("Jurusan Mata Kuliah Wajib Diisi");}
                else if(!String.IsNullOrEmpty(textBox2.Text)&& comboBox1.SelectedValue.ToString() != "")
                {
                    OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO MASTER_MATAKULIAH VALUES('','"+textBox2.Text+"','"+comboBox1.SelectedValue+"',"+numericUpDown1.Value+
                        ","+numericUpDown2.Value+")"; cmd.ExecuteNonQuery(); DatabaseRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (textBox2.Text == "") { MessageBox.Show("Nama Mata Kuliah Wajib Diisi"); }
                    if (comboBox1.SelectedValue.ToString() == "") { MessageBox.Show("Jurusan Mata Kuliah Wajib Diisi"); }
                    else if (!String.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedValue.ToString() != "")
                    {
                        OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;                      
                        cmd.CommandText = "UPDATE MASTER_MATAKULIAH SET NAMA_MK='" + textBox2.Text + "',SMST_MK='" +
                            numericUpDown1.Value + "',SKS_MATKUL='" + numericUpDown2.Value + "' WHERE KODE_MK='" + 
                            label4.Text + "'"; cmd.ExecuteNonQuery(); DatabaseRefresh();
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
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM MASTER_MATAKULIAH WHERE KODE_MK='"+label4.Text+"'";
                    cmd.ExecuteNonQuery(); DatabaseRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButtonKode.Checked == true || radioButtonNama.Checked == true || radioButtonJurusan.Checked == true)
            {
                waktu = 0;
            }            
        }

        private void btnJadwalMatakuliah_Click(object sender, EventArgs e)
        {
            try
            {
                FormBAAJadwalMatakuliah.dts = dts; FormBAAJadwalMatakuliah.userid = userid; FormBAAJadwalMatakuliah.pass = pass;
                this.Hide(); new FormBAAJadwalMatakuliah().ShowDialog(); conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int index, waktu = 0;
        private void radioButtonNama_Click(object sender, EventArgs e)
        {
            waktu = 0; textBox1.Enabled = true;
        }

        private void radioButtonJurusan_Click(object sender, EventArgs e)
        {
            waktu = 0; textBox1.Enabled = true;
        }

        private void radioButtonKode_Click(object sender, EventArgs e)
        {
            waktu = 0; textBox1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            waktu += 1;
            if (waktu > 2 && waktu < 4)
            {
                DatabaseRefresh();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex; comboBox1.Enabled = false;
            label4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            numericUpDown2.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            btnUpdate.Enabled = true; btnDelete.Enabled = true; btnInsert.Enabled = false;
        }
    }
}
