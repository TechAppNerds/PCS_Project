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
    public partial class FormBAADosen : Form
    {
        public static OracleConnection conn;
        public static string dts, userid, pass;
        public FormBAADosen()
        {
            InitializeComponent();
            conn = new OracleConnection();
        }

        private void FormBAADosen_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
            try
            {
                conn.Open(); OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN", conn); DataSet ds = new DataSet();
                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0]; txtSearch.Enabled = false; btnUpdate.Enabled = false; btnDelete.Enabled = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DatabaseRefresh()
        {
            txtSearch.Enabled = false; label9.Text = "0"; btnInsert.Enabled = true; btnUpdate.Enabled = false;
            btnDelete.Enabled = false; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; radioButton1.Checked = false;
            radioButton2.Checked = false; radioButton3.Checked = false; radioButton4.Checked = false; textBox1.Text = "";
            textBox2.Enabled = true; radioButton1.Enabled = true; radioButton2.Enabled = true;
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                if (comboBox1.SelectedIndex < 1)
                {
                    if (comboBox2.SelectedIndex < 1)
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN", conn);
                        DataSet ds = new DataSet(); da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE STATUS_DOSEN='"+ 
                            comboBox2.Items[comboBox2.SelectedIndex] + "'", conn); DataSet ds = new DataSet(); da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else
                {
                    if (comboBox2.SelectedIndex < 1)
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE JK_DOSEN='" +
                            comboBox1.Items[comboBox1.SelectedIndex] + "'", conn); DataSet ds = new DataSet(); da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE JK_DOSEN='" +
                            comboBox1.Items[comboBox1.SelectedIndex] + "' AND STATUS_DOSEN='"+ comboBox2.Items[comboBox2.SelectedIndex] 
                            + "' ", conn); DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            else
            {
                if (radioButton5.Checked == true && radioButton6.Checked == false && radioButton7.Checked == false && radioButton8.Checked == false)
                {
                    if (comboBox1.SelectedIndex < 1)
                    {
                        if (comboBox2.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(KODE_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(KODE_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(KODE_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(KODE_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND"+
                                " STATUS_DOSEN='"+ comboBox2.Items[comboBox2.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        if (comboBox2.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(KODE_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(KODE_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " JK_DOSEN='" + comboBox1.Items[comboBox1.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(KODE_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(KODE_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " JK_DOSEN='" + comboBox1.Items[comboBox1.SelectedIndex] + "' AND STATUS_DOSEN='" + 
                                comboBox2.Items[comboBox2.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }                        
                    }
                }
                else if (radioButton5.Checked == false && radioButton6.Checked == true && radioButton7.Checked == false && radioButton8.Checked == false)
                {
                    if (comboBox1.SelectedIndex < 1)
                    {
                        if (comboBox2.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(NAMA_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(NAMA_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(NAMA_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(NAMA_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " STATUS_DOSEN='" + comboBox2.Items[comboBox2.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        if (comboBox2.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(NAMA_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(NAMA_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " JK_DOSEN='" + comboBox1.Items[comboBox1.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(NAMA_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(NAMA_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " JK_DOSEN='" + comboBox1.Items[comboBox1.SelectedIndex] + "' AND STATUS_DOSEN='" +
                                comboBox2.Items[comboBox2.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                }
                else if (radioButton5.Checked == false && radioButton6.Checked == false && radioButton7.Checked == true && radioButton8.Checked == false)
                {
                    if (comboBox1.SelectedIndex < 1)
                    {
                        if (comboBox2.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(ALAMAT_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(ALAMAT_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(ALAMAT_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(ALAMAT_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " STATUS_DOSEN='" + comboBox2.Items[comboBox2.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        if (comboBox2.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(ALAMAT_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(ALAMAT_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " JK_DOSEN='" + comboBox1.Items[comboBox1.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(ALAMAT_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(ALAMAT_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " JK_DOSEN='" + comboBox1.Items[comboBox1.SelectedIndex] + "' AND STATUS_DOSEN='" +
                                comboBox2.Items[comboBox2.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                }
                else
                {
                    if (comboBox1.SelectedIndex < 1)
                    {
                        if (comboBox2.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(TELP_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(TELP_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(TELP_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(TELP_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " STATUS_DOSEN='" + comboBox2.Items[comboBox2.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        if (comboBox2.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(TELP_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(TELP_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " JK_DOSEN='" + comboBox1.Items[comboBox1.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN WHERE UPPER(TELP_DOSEN) LIKE UPPER('%" +
                                txtSearch.Text + "%') AND LOWER(TELP_DOSEN) LIKE LOWER('%" + txtSearch.Text + "%') AND" +
                                " JK_DOSEN='" + comboBox1.Items[comboBox1.SelectedIndex] + "' AND STATUS_DOSEN='" +
                                comboBox2.Items[comboBox2.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
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
                FormLoginUserSQL.dts = dts; FormLoginUserSQL.userid = userid; FormLoginUserSQL.pass = pass;
                this.Hide(); new FormLoginUserSQL().ShowDialog(); conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        bool ceknotelp = false;
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "") { MessageBox.Show("Nama Dosen Wajib Diisi"); }
                if (radioButton1.Checked == false && radioButton2.Checked == false) { MessageBox.Show("Jenis Kelamin Dosen Wajib Dipilih"); }
                if (String.IsNullOrEmpty(textBox3.Text)) { MessageBox.Show("Email Dosen Wajib Diisi"); }
                if (String.IsNullOrEmpty(textBox4.Text)) { MessageBox.Show("Alamat Dosen Wajib Diisi"); }
                if (String.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("Nomor Telepon Dosen Wajib Diisi"); ceknotelp = false; }
                else { if (textBox1.TextLength <= 11) { MessageBox.Show("Panjang Nomor Telepon Dosen Wajib Diisi Dengan Valid"); ceknotelp = false; }
                    else { if (!textBox1.Text.ToString().Substring(0, 2).Equals("08")) { MessageBox.Show("Nomor Telepon Dosen Tidak Valid"); ceknotelp = false; }
                        else { ceknotelp = true; } } }
                if (radioButton4.Checked == false && radioButton3.Checked == false) { MessageBox.Show("Status Dosen Wajib Dipilih"); }
                else if (textBox2.Text != "" && (radioButton1.Checked != false || radioButton2.Checked != false) && textBox3.Text != "" &&
                    textBox4.Text != "" && ceknotelp==true && (radioButton4.Checked == true || radioButton3.Checked == true))
                {

                    OracleCommand cmd = new OracleCommand(); cmd.Connection = conn; String j = ""; String s = "";
                    if (radioButton1.Checked == true) { j = "L"; } else { j = "P"; }
                    if (radioButton4.Checked == true) { s = "Tetap"; } else { s = "Tidak Tetap"; }
                    cmd.CommandText = "INSERT INTO DOSEN VALUES('','"+textBox2.Text+"','"+j+"','"+ textBox3.Text + "','"+ 
                        textBox4.Text + "','"+ textBox1.Text + "','"+s+"')"; cmd.ExecuteNonQuery(); DatabaseRefresh();
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
                    if (String.IsNullOrEmpty(textBox3.Text)) { MessageBox.Show("Email Dosen Wajib Diisi"); }
                    if (String.IsNullOrEmpty(textBox4.Text)) { MessageBox.Show("Alamat Dosen Wajib Diisi"); }
                    if (String.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("Nomor Telepon Dosen Wajib Diisi"); ceknotelp = false; }
                    else { if (textBox1.TextLength <= 11) { MessageBox.Show("Panjang Nomor Telepon Dosen Wajib Diisi Dengan Valid"); ceknotelp = false; }
                        else { if (!textBox1.Text.ToString().Substring(0, 2).Equals("08")) { MessageBox.Show("Nomor Telepon Dosen Tidak Valid"); ceknotelp = false; }
                            else { ceknotelp = true; } } }
                    if (radioButton4.Checked == false && radioButton3.Checked == false) { MessageBox.Show("Status Dosen Wajib Dipilih"); }
                    else if (textBox3.Text != "" && textBox4.Text != "" && ceknotelp==true && (radioButton4.Checked == true || radioButton3.Checked == true))
                    {

                        OracleCommand cmd = new OracleCommand(); cmd.Connection = conn; String s = "";
                        if (radioButton4.Checked == true) { s = "Tetap"; } else { s = "Tidak Tetap"; }
                        cmd.CommandText = "UPDATE DOSEN SET EMAIL_DOSEN='"+textBox3.Text+"',ALAMAT_DOSEN='"+ textBox4.Text +
                            "',TELP_DOSEN='"+ textBox1.Text + "',STATUS_DOSEN='"+s+"' WHERE "
                            + "KODE_DOSEN='"+label9.Text+"'"; cmd.ExecuteNonQuery(); DatabaseRefresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex; textBox2.Enabled = false; radioButton1.Enabled = false; radioButton2.Enabled = false;
            btnInsert.Enabled = false; btnUpdate.Enabled = true; btnDelete.Enabled = true;
            label9.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value + "" == "L")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[6].Value + "" == "Tetap")
            {
                radioButton4.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;
            }
            timer1.Stop(); waktu = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true || radioButton6.Checked == true || radioButton7.Checked == true || radioButton8.Checked == true)
            {
                waktu = 0; timer1.Start();
            }
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void radioButton7_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void radioButton8_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            waktu = 0; timer1.Start();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            waktu = 0; timer1.Start();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM DOSEN WHERE KODE_DOSEN='" + label9.Text + "'";
                    cmd.ExecuteNonQuery(); DatabaseRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFormMataKuliah_Click(object sender, EventArgs e)
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
    }
}
