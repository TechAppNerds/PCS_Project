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
            InitializeComponent(); conn = new OracleConnection(); textBox4.Enabled = false; numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 8; numericUpDown2.Minimum = 2; numericUpDown2.Maximum = 4; numericUpDown3.Minimum = 7;
            numericUpDown3.Maximum = 22; numericUpDown4.Minimum = 0; numericUpDown4.Increment = 5; numericUpDown4.Maximum = 60;
            numericUpDown5.Minimum = 1; numericUpDown5.Maximum = 9; numericUpDown6.Minimum = 0; numericUpDown6.Maximum = 9;
        }

        private void FormBAAMasterMataKuliah_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
            try
            {
                conn.Open(); OracleDataAdapter da1 = new OracleDataAdapter("SELECT KODE_DOSEN FROM DOSEN", conn);
                DataSet ds2 = new DataSet(); da1.Fill(ds2); comboBox3.DataSource = ds2.Tables[0];
                comboBox3.DisplayMember = "KODE_DOSEN"; comboBox3.ValueMember = "KODE_DOSEN"; textBox1.Enabled = false;
                btnUpdate.Enabled = false; btnDelete.Enabled = false; btnIIJMK.Enabled = false; comboBox3.Enabled = false;
                comboBox2.Enabled = false; textBox5.Enabled = false; numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false; numericUpDown5.Enabled = false; numericUpDown6.Enabled = false;
                radioButton4.Enabled = false; radioButton5.Enabled = false; radioButton6.Enabled = false;
                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH", conn);
                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0]; timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DatabaseRefresh()
        {
            textBox4.Text = ""; textBox2.Text = ""; textBox3.Text = ""; radioButton4.Enabled = false; radioButton5.Enabled = false;
            radioButton6.Enabled = false; OracleDataAdapter da1 = new OracleDataAdapter("SELECT KODE_DOSEN FROM DOSEN", conn);
            DataSet ds2 = new DataSet(); da1.Fill(ds2); comboBox3.DataSource = ds2.Tables[0]; comboBox3.DisplayMember = "KODE_DOSEN";
            comboBox3.ValueMember = "KODE_DOSEN"; btnInsert.Enabled = true; btnUpdate.Enabled = false; btnDelete.Enabled = false;
            btnIIJMK.Enabled = false; numericUpDown5.Enabled = false; numericUpDown1.Enabled = true; numericUpDown2.Enabled = true;
            comboBox2.Enabled = false; textBox5.Enabled = false; numericUpDown3.Enabled = false; numericUpDown4.Enabled = false;
            numericUpDown6.Enabled = false; radioButton4.Checked = false; radioButton5.Checked = false; radioButton6.Checked = false;
            numericUpDown1.Value = 1; numericUpDown2.Value = 2; comboBox2.SelectedItem = ""; numericUpDown3.Value = 7;
            numericUpDown4.Value = 0; numericUpDown5.Value = 1; numericUpDown6.Value = 0; textBox5.Text = ""; comboBox3.Enabled = false;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH", conn);
                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];                
            }
            else
            {
                if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton3.Checked == false && radioButton7.Checked == false)
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(KODE_MK) LIKE"
                        + " UPPER('%" + textBox1.Text + "%') AND LOWER(KODE_MK) LIKE LOWER('%" + textBox1.Text + "%')", conn);
                    DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];                    
                }
                else if (radioButton1.Checked == false && radioButton2.Checked == true && radioButton3.Checked == false && radioButton7.Checked == false)
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(NAMA_MK) LIKE"
                        + " UPPER('%" + textBox1.Text + "%') AND LOWER(NAMA_MK) LIKE LOWER('%" + textBox1.Text + "%')", conn);
                    DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];                    
                }
                else if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == true && radioButton7.Checked == false)
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(KODE_PENGAJAR)"
                        + " LIKE UPPER('%" + textBox1.Text + "%') AND LOWER(KODE_PENGAJAR) LIKE LOWER('%" + textBox1.Text + "%')", conn);
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
                this.Hide(); new FormLogin().ShowDialog(); conn.Close(); this.Close();
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
                if (textBox3.Text == "") { MessageBox.Show("Jurusan Mata Kuliah Wajib Diisi");}
                else if(!String.IsNullOrEmpty(textBox2.Text)&&textBox3.Text!="")
                {
                    OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO MASTER_MATAKULIAH VALUES('','"+textBox2.Text+"','"+textBox3.Text+"',"+numericUpDown1.Value+
                        ","+numericUpDown2.Value+")"; cmd.ExecuteNonQuery(); DatabaseRefresh(); textBox1.Enabled = false;
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
                    if (textBox3.Text == "") { MessageBox.Show("Jurusan Mata Kuliah Wajib Diisi"); }
                    else if (!String.IsNullOrEmpty(textBox2.Text) && textBox3.Text != "")
                    {
                        OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;                      
                        cmd.CommandText = "UPDATE MASTER_MATAKULIAH SET NAMA_MK='" + textBox2.Text + "',SMST_MK='" +
                            numericUpDown1.Value + "',SKS_MATKUL='" + numericUpDown2.Value + "' WHERE KODE_MK='" + 
                            textBox4.Text + "'"; cmd.ExecuteNonQuery(); DatabaseRefresh(); textBox1.Enabled = false;                        
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
                    cmd.CommandText = "DELETE FROM MASTER_MATAKULIAH WHERE KODE_MK='"+textBox4.Text+"'";
                    cmd.ExecuteNonQuery(); DatabaseRefresh(); textBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton7.Checked == true)
            {
                waktu = 0;
            }            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            waktu = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text==dataGridView1.Rows[index].Cells[1].Value.ToString())
            {
                radioButton4.Enabled = false; radioButton5.Enabled = false; radioButton6.Enabled = false;
            }
            else
            {
                radioButton4.Enabled = true; radioButton5.Enabled = true; radioButton6.Enabled = true;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            waktu = 0; textBox1.Enabled = true;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            waktu = 0; textBox1.Enabled = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            waktu = 0; textBox1.Enabled = true;
        }

        private void btnIIJMK_Click(object sender, EventArgs e)
        {
            OracleTransaction obTrans = conn.BeginTransaction();
            try
            {
                if (dataGridView1.Rows.Count>0)
                {
                    OracleCommand cmd=new OracleCommand(); cmd.Connection=conn; string k = "";
                    if (radioButton4.Checked == true) { k = "A"; }
                    if (radioButton5.Checked == true) { k = "B"; }
                    if (radioButton6.Checked == true) { k = "C"; }
                    OracleDataAdapter da = new OracleDataAdapter("SELECT COUNT(*) FROM JADWAL_MATAKULIAH WHERE "
                        +"KODE_MK='"+dataGridView1.Rows[index].Cells[0].Value+"' AND KELAS_MK='"+k+ "'", conn);
                    DataSet dsc = new DataSet(); da.Fill(dsc);
                    if (Convert.ToInt32(dsc.Tables[0].Rows[0][0])>0){MessageBox.Show("Mata Kuliah sudah ada di Jadwal");}
                    else
                    {
                        if (textBox2.Text == "") { MessageBox.Show("Nama Mata Kuliah Wajib Diisi"); }
                        if (textBox3.Text == "") { MessageBox.Show("Jurusan Mata Kuliah Wajib Diisi"); }
                        if (radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked == false)
                        { MessageBox.Show("Kelas Mata Kuliah Wajib Dipilih"); }
                        if (String.IsNullOrEmpty(comboBox2.SelectedItem+"")){MessageBox.Show("Hari Mata Kuliah wajib diisi");}
                        if (String.IsNullOrEmpty(textBox5.Text)){MessageBox.Show("Tempat Ruang Matakuliah Wajib Diisi");}
                        else if (textBox5.Text!=""&& !String.IsNullOrEmpty(textBox2.Text) && textBox3.Text != "" && 
                            !String.IsNullOrEmpty(comboBox2.SelectedItem + "") &&
                        (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true))
                        {
                            string j = ""; string m = "";
                            if (numericUpDown3.Value < 10){ j = "0" + numericUpDown3.Value + ":"; }
                            else { j = numericUpDown3.Value + ":"; }
                            if (numericUpDown4.Value<=9){m = "0" + numericUpDown4.Value;}
                            else { m = numericUpDown4.Value.ToString();}
                            cmd.CommandText = "INSERT INTO JADWAL_MATAKULIAH VALUES('"+dataGridView1.Rows[index].Cells[0].Value+
                                "','"+ dataGridView1.Rows[index].Cells[1].Value + "','"+ dataGridView1.Rows[index].Cells[2].Value
                                + "',"+ dataGridView1.Rows[index].Cells[3].Value + ","+ dataGridView1.Rows[index].Cells[4].Value 
                                + ",'"+k+"','"+comboBox2.SelectedItem+"','"+j+m+"',UPPER('"+textBox5.Text+"'||'-'||'"+numericUpDown5.Value+
                                "'||'0'||'"+numericUpDown6.Value+"'),'"+comboBox3.SelectedValue+"')";
                            cmd.ExecuteNonQuery(); DatabaseRefresh(); textBox1.Enabled = false;
                        }
                    } obTrans.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); obTrans.Rollback();
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

        private void radioButton7_Click(object sender, EventArgs e)
        {
            waktu = 0; textBox1.Enabled = true;
        }

        int index, waktu = 0;
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
            index = e.RowIndex;
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            numericUpDown2.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            btnIIJMK.Enabled = true; btnUpdate.Enabled = true; btnDelete.Enabled = true; btnInsert.Enabled = false;
            textBox3.Enabled = false; comboBox2.Enabled = true; radioButton4.Enabled = true; radioButton5.Enabled = true;
            radioButton6.Enabled = true; textBox5.Enabled = true; numericUpDown3.Enabled = true; numericUpDown4.Enabled = true;
            numericUpDown5.Enabled = true; numericUpDown6.Enabled = true; textBox1.Enabled = false; comboBox3.Enabled = true;
        }
    }
}
