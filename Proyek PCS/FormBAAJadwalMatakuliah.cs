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
        public static string dts, userid, pass;
        public static bool cekdelete = false;
        public FormBAAJadwalMatakuliah()
        {
            InitializeComponent();
            conn = new OracleConnection();
        }

        private void FormBAAJadwalMatakuliah_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
            try
            {
                conn.Open(); OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH", conn); DataSet ds = new DataSet();
                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0]; DataGridViewButtonColumn delbtn = new DataGridViewButtonColumn();
                delbtn.FlatStyle = FlatStyle.Standard; delbtn.HeaderText = "ACTION"; delbtn.Name = "DeleteButton"; delbtn.Text = "Delete";
                delbtn.UseColumnTextForButtonValue = true; dataGridView1.Columns.Add(delbtn); timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DatabaseRefresh()
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                if (comboBox1.SelectedIndex < 1)
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH", conn); DataSet ds = new DataSet();
                    da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {                    
                    OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH WHERE KELAS_MK='"+
                        comboBox1.Items[comboBox1.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                    da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else
            {
                if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
                {
                    if (comboBox1.SelectedIndex < 1)
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH WHERE UPPER(KODE_MK) LIKE"
                            + " UPPER('%" + txtSearch.Text + "%') AND LOWER(KODE_MK) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH WHERE UPPER(KODE_MK) LIKE"
                            + " UPPER('%" + txtSearch.Text + "%') AND LOWER(KODE_MK) LIKE LOWER('%" + txtSearch.Text + "%')"
                            + " AND KELAS_MK='" + comboBox1.Items[comboBox1.SelectedIndex] + "'", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (radioButton1.Checked == false && radioButton2.Checked == true && radioButton3.Checked == false && radioButton4.Checked == false)
                {
                    if (comboBox1.SelectedIndex < 1)
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH WHERE UPPER(NAMA_MK) LIKE"
                            + " UPPER('%" + txtSearch.Text + "%') AND LOWER(NAMA_MK) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH WHERE UPPER(NAMA_MK) LIKE"
                            + " UPPER('%" + txtSearch.Text + "%') AND LOWER(NAMA_MK) LIKE LOWER('%" + txtSearch.Text + "%')"
                            + " AND KELAS_MK='" + comboBox1.Items[comboBox1.SelectedIndex] + "'", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == true && radioButton4.Checked == false)
                {
                    if (comboBox1.SelectedIndex < 1)
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH WHERE UPPER(JURUSAN_MK) LIKE"
                            + " UPPER('%" + txtSearch.Text + "%') AND LOWER(JURUSAN_MK) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH WHERE UPPER(JURUSAN_MK) LIKE"
                            + " UPPER('%" + txtSearch.Text + "%') AND LOWER(JURUSAN_MK) LIKE LOWER('%" + txtSearch.Text + "%')"
                            + " AND KELAS_MK='" + comboBox1.Items[comboBox1.SelectedIndex] + "'", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else
                {
                    if (comboBox1.SelectedIndex < 1)
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH WHERE UPPER(KODE_PENGAJAR) LIKE"
                            + " UPPER('%" + txtSearch.Text + "%') AND LOWER(KODE_PENGAJAR) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM JADWAL_MATAKULIAH WHERE UPPER(KODE_PENGAJAR) LIKE"
                            + " UPPER('%" + txtSearch.Text + "%') AND LOWER(KODE_PENGAJAR) LIKE LOWER('%" + txtSearch.Text + "%')"
                            + " AND KELAS_MK='" + comboBox1.Items[comboBox1.SelectedIndex] + "'", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }        

        private void btnMasterMatakuliah_Click(object sender, EventArgs e)
        {
            try
            {
                FormBAAMasterMatakuliah.dts = dts; FormBAAMasterMatakuliah.userid = userid; FormBAAMasterMatakuliah.pass = pass;
                this.Hide(); new FormBAAMasterMatakuliah().ShowDialog(); conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int index = 0, waktu = 0;
        private void radioButton1_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            waktu = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true)
            {
                waktu = 0;
            }                
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
            index = e.RowIndex; txtSearch.Enabled = false;
            if (dataGridView1.Columns[e.ColumnIndex].Name=="DeleteButton")
            {
                OracleTransaction obTrans = conn.BeginTransaction();
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        ConfirmDelete.dts = dts; ConfirmDelete.userid = userid; ConfirmDelete.pass = pass; new ConfirmDelete().ShowDialog();
                        if (cekdelete == true)
                        {
                            OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;
                            string nokode = dataGridView1.Rows[index].Cells[0].Value.ToString(); MessageBox.Show(nokode);                            
                            cmd.CommandText = "DELETE FROM JADWAL_MATAKULIAH WHERE KODE_MK='" + nokode + "' AND KELAS_MK='" +
                                dataGridView1.Rows[index].Cells[5].Value + "'"; cmd.ExecuteNonQuery(); DatabaseRefresh();
                        } obTrans.Commit(); txtSearch.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); obTrans.Rollback();
                }
            }
        }
    }
}
