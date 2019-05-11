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
            InitializeComponent();
            conn = new OracleConnection(); textBox4.Enabled = false;
        }

        private void FormBAAMasterMataKuliah_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
            try
            {
                conn.Open();
                OracleDataAdapter da1 = new OracleDataAdapter("SELECT KODE_DOSEN FROM DOSEN", conn); DataSet ds2 = new DataSet();
                da1.Fill(ds2); comboBox3.DataSource = ds2.Tables[0];
                comboBox3.DisplayMember = "KODE_DOSEN"; comboBox3.ValueMember = "KODE_DOSEN";
                da1 = new OracleDataAdapter("SELECT KELAS_MK FROM MASTER_MATAKULIAH UNION SELECT 'NO FILTER' FROM DUAL", conn);
                DataSet ds3 = new DataSet(); da1.Fill(ds3); comboBox1.DataSource = ds3.Tables[0];
                comboBox1.DisplayMember = "KELAS_MK"; comboBox1.ValueMember = "KELAS_MK";
                btnUpdate.Enabled = false; btnDelete.Enabled = false;
                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH", conn);
                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                if (comboBox1.SelectedValue.ToString() == "NO FILTER")
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH", conn);
                    DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE KELAS_MK='" +
                            comboBox1.SelectedValue + "'", conn);
                    DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else
            {
                if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton3.Checked == false && radioButton7.Checked == false)
                {
                    if (comboBox1.SelectedValue.ToString() == "NO FILTER")
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(KODE_MK) LIKE"
                            + " UPPER('%" + textBox1.Text + "%') AND LOWER(KODE_MK) LIKE LOWER('%" + textBox1.Text + "%')", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(KODE_MK) LIKE"
                            + " UPPER('%" + textBox1.Text + "%') AND LOWER(KODE_MK) LIKE LOWER('%" + textBox1.Text + "%')"
                            + " AND KELAS_MK='" + comboBox1.SelectedValue + "'", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (radioButton1.Checked == false && radioButton2.Checked == true && radioButton3.Checked == false && radioButton7.Checked == false)
                {
                    if (comboBox1.SelectedValue.ToString() == "NO FILTER")
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(NAMA_MK) LIKE"
                            + " UPPER('%" + textBox1.Text + "%') AND LOWER(NAMA_MK) LIKE LOWER('%" + textBox1.Text + "%')", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(NAMA_MK) LIKE"
                            + " UPPER('%" + textBox1.Text + "%') AND LOWER(NAMA_MK) LIKE LOWER('%" + textBox1.Text + "%')"
                            + " AND KELAS_MK='" + comboBox1.SelectedValue + "'", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == true && radioButton7.Checked == false)
                {
                    if (comboBox1.SelectedValue.ToString() == "NO FILTER")
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(KODE_PENGAJAR)"
                            + " LIKE UPPER('%" + textBox1.Text + "%') AND LOWER(KODE_PENGAJAR) LIKE LOWER('%" + textBox1.Text + "%')", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(KODE_PENGAJAR)"
                            + " LIKE UPPER('%" + textBox1.Text + "%') AND LOWER(KODE_PENGAJAR) LIKE LOWER('%" + textBox1.Text
                            + "%') AND KELAS_MK='" + comboBox1.SelectedValue + "'", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else
                {
                    if (comboBox1.SelectedValue.ToString() == "NO FILTER")
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(JURUSAN_MK)"
                            + " LIKE UPPER('%" + textBox1.Text + "%') AND LOWER(JURUSAN_MK) LIKE LOWER('%" + textBox1.Text + "%')", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MASTER_MATAKULIAH WHERE UPPER(JURUSAN_MK)"
                            + " LIKE UPPER('%" + textBox1.Text + "%') AND LOWER(JURUSAN_MK) LIKE LOWER('%" + textBox1.Text
                            + "%') AND KELAS_MK='" + comboBox1.SelectedValue + "'", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            } timer1.Start();
        }

        private void btnBackhome_Click(object sender, EventArgs e)
        {
            try
            {
                FormBAAHome.dts = dts; FormBAAHome.userid = userid; FormBAAHome.pass = pass;
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
                FormBAADosen.dts = dts; FormBAADosen.userid = userid; FormBAADosen.pass = pass;
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
                FormBAAMahasiswa.dts = dts; FormBAAMahasiswa.userid = userid; FormBAAMahasiswa.pass = pass;
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
                if (radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked == false)
                {MessageBox.Show("Kelas Mata Kuliah Wajib Dipilih");}
                else if(!String.IsNullOrEmpty(textBox2.Text)&&textBox3.Text!=""&&
                    (radioButton4.Checked==true||radioButton5.Checked==true||radioButton6.Checked==true))
                {
                    OracleCommand cmd = new OracleCommand(); cmd.Connection = conn; string k="";
                    if (radioButton4.Checked==true){ k = "A"; }
                    if (radioButton5.Checked == true) { k = "B"; }
                    if (radioButton6.Checked == true) { k = "C"; }
                    cmd.CommandText = "INSERT INTO MASTER_MATAKULIAH VALUES('','" + textBox2.Text + "','" + textBox3.Text 
                        + "','" + k + "','" + comboBox3.SelectedValue + "')";
                    cmd.ExecuteNonQuery(); refresh();
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
                    if (radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked == false)
                    { MessageBox.Show("Kelas Mata Kuliah Wajib Dipilih"); }
                    else if (!String.IsNullOrEmpty(textBox2.Text) && textBox3.Text != "" &&
                        (radioButton4.Checked == true || radioButton5.Checked == true || radioButton6.Checked == true))
                    {
                        OracleCommand cmd = new OracleCommand(); cmd.Connection = conn; string k = "";
                        if (radioButton4.Checked == true) { k = "A"; }
                        if (radioButton5.Checked == true) { k = "B"; }
                        if (radioButton6.Checked == true) { k = "C"; }
                        string nokode = dataGridView1.Rows[index].Cells[0].Value.ToString();
                        if (radioButton4.Enabled==false||radioButton5.Enabled == false|| radioButton6.Enabled == false)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT SUBSTR(KODE_MK,4,3) FROM MASTER_MATAKULIAH"
                            + " WHERE JURUSAN_MK='" + textBox3.Text + "' AND KELAS_MK='"+dataGridView1.Rows[index].Cells[3].Value 
                            + "' AND NAMA_MK='"+ dataGridView1.Rows[index].Cells[1].Value + "' ", conn); DataSet maks = new DataSet(); da.Fill(maks);
                            if (Convert.ToInt32(maks.Tables[0].Rows[0][0])<10)
                            {
                                cmd.CommandText = "UPDATE MASTER_MATAKULIAH SET KODE_MK=SUBSTR(KODE_MK,1,5)||" + maks.Tables[0].Rows[0][0]
                                + ",NAMA_MK='" + textBox2.Text + "',KODE_PENGAJAR='" + comboBox3.SelectedValue + "' WHERE KODE_MK='" + nokode 
                                + "' AND KELAS_MK='"+dataGridView1.Rows[index].Cells[3].Value+"'";
                            }
                            else if (Convert.ToInt32(maks.Tables[0].Rows[0][0]) >= 10 && Convert.ToInt32(maks.Tables[0].Rows[0][0]) < 100)
                            {
                                cmd.CommandText = "UPDATE MASTER_MATAKULIAH SET KODE_MK=SUBSTR(KODE_MK,1,4)||" + maks.Tables[0].Rows[0][0]
                                + ",NAMA_MK='" + textBox2.Text + "',KODE_PENGAJAR='" + comboBox3.SelectedValue + "' WHERE KODE_MK='" + nokode
                                + "' AND KELAS_MK='" + dataGridView1.Rows[index].Cells[3].Value + "'";
                            }
                            else
                            {
                                cmd.CommandText = "UPDATE MASTER_MATAKULIAH SET KODE_MK=SUBSTR(KODE_MK,1,3)||" + maks.Tables[0].Rows[0][0]
                                + ",NAMA_MK='" + textBox2.Text + "',KODE_PENGAJAR='" + comboBox3.SelectedValue + "' WHERE KODE_MK='" + nokode
                                + "' AND KELAS_MK='" + dataGridView1.Rows[index].Cells[3].Value + "'";
                            }                            
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT MAX(SUBSTR(KODE_MK,4,3))+1 FROM MASTER_MATAKULIAH"
                            + " WHERE JURUSAN_MK='" + textBox3.Text + "'", conn); DataSet maks = new DataSet(); da.Fill(maks);
                            if (Convert.ToInt32(maks.Tables[0].Rows[0][0]) <= 9)
                            {
                                cmd.CommandText = "UPDATE MASTER_MATAKULIAH SET KODE_MK=SUBSTR(KODE_MK,1,5)||" +
                                maks.Tables[0].Rows[0][0] + ",NAMA_MK='" + textBox2.Text + "',KELAS_MK='" + k + "',KODE_PENGAJAR='" +
                                comboBox3.SelectedValue + "' WHERE KODE_MK='" + nokode + "' AND KELAS_MK='" + dataGridView1.Rows[index].Cells[3].Value + "'";
                            }
                            else if (Convert.ToInt32(maks.Tables[0].Rows[0][0]) >= 10 && Convert.ToInt32(maks.Tables[0].Rows[0][0]) <= 99)
                            {
                                cmd.CommandText = "UPDATE MASTER_MATAKULIAH SET KODE_MK=SUBSTR(KODE_MK,1,4)||" +
                                maks.Tables[0].Rows[0][0] + ",NAMA_MK='" + textBox2.Text + "',KELAS_MK='" + k + "',KODE_PENGAJAR='" +
                                comboBox3.SelectedValue + "' WHERE KODE_MK='" + nokode + "' AND KELAS_MK='" + dataGridView1.Rows[index].Cells[3].Value + "'";
                            }
                            else
                            {
                                cmd.CommandText = "UPDATE MASTER_MATAKULIAH SET KODE_MK=SUBSTR(KODE_MK,1,3)||" +
                                maks.Tables[0].Rows[0][0] + ",NAMA_MK='" + textBox2.Text + "',KELAS_MK='" + k + "',KODE_PENGAJAR='" +
                                comboBox3.SelectedValue + "' WHERE KODE_MK='" + nokode + "' AND KELAS_MK='" + dataGridView1.Rows[index].Cells[3].Value + "'";
                            }                            
                        } cmd.ExecuteNonQuery(); refresh();
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
                    string nokode = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    cmd.CommandText = "DELETE FROM MASTER_MATAKULIAH WHERE KODE_MK='"+nokode+"' AND KELAS_MK='"+
                        dataGridView1.Rows[index].Cells[3].Value+"'";
                    cmd.ExecuteNonQuery(); refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "A")
            {
                radioButton4.Checked = true;
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "B")
            {
                radioButton5.Checked = true;
            }
            else
            {
                radioButton6.Checked = true;
            }
            comboBox3.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            btnUpdate.Enabled = true; btnDelete.Enabled = true; btnInsert.Enabled = false; textBox3.Enabled = false;
        }
        int index,waktu=0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            waktu = 0;
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
            waktu = 0;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            waktu = 0;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            waktu = 0;
        }

        private void radioButton7_Click(object sender, EventArgs e)
        {
            waktu = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (radioButton1.Checked==true||radioButton2.Checked==true||radioButton3.Checked==true||radioButton7.Checked==true)
            //{
                waktu += 1; label1.Text = waktu + "";
            //}
            //if (comboBox1.SelectedText!="")
            //{
            //    waktu += 1; label1.Text = waktu + "";
            //}
            if (waktu>2&&waktu<4)
            {
                refresh();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
