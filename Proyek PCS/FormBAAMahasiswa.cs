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
    public partial class FormBAAMahasiswa : Form
    {
        public static OracleConnection conn;
        public static string dts, userid, pass;
        public FormBAAMahasiswa()
        {
            InitializeComponent(); conn = new OracleConnection(); ((TextBox)numericUpDown1.Controls[1]).MaxLength = 4;
        }

        private void FormBAAMahasiswa_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
            try
            {
                conn.Open(); OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA", conn); DataSet ds = new DataSet();
                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0]; da = new OracleDataAdapter("SELECT TO_CHAR(THN_REG) AS THN_REG FROM MAHASISWA UNION SELECT 'NO FILTER' FROM DUAL", conn);
                DataSet ds1 = new DataSet(); da.Fill(ds1); comboBox3.DataSource = ds1.Tables[0]; comboBox3.DisplayMember = "THN_REG"; comboBox3.ValueMember = "THN_REG"; comboBox3.SelectedValue = "NO FILTER";
                da = new OracleDataAdapter("SELECT NAMA_MJ FROM MASTER_JURUSAN", conn); DataSet ds2 = new DataSet(); da.Fill(ds2);
                comboBox2.DataSource = ds2.Tables[0]; comboBox2.DisplayMember = "NAMA_MJ"; comboBox2.ValueMember = "NAMA_MJ";
                da = new OracleDataAdapter("SELECT KODE_DOSEN FROM DOSEN", conn); DataSet ds3 = new DataSet(); da.Fill(ds3);
                comboBox1.DataSource = ds3.Tables[0]; comboBox1.DisplayMember = "KODE_DOSEN"; comboBox1.ValueMember = "KODE_DOSEN";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DatabaseRefresh()
        {
            txtSearch.Enabled = false; label14.Text = "0"; btnInsert.Enabled = true; btnUpdate.Enabled = false; btnDelete.Enabled = false;
            numericUpDown1.Value = 1950; textBox2.Text = ""; textBox4.Text = ""; textBox6.Text = ""; textBox5.Text = ""; textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now; radioButton1.Checked = false; radioButton2.Checked = false; radioButton4.Checked = false;
            radioButton5.Checked = false; radioButton9.Checked = false; numericUpDown1.Enabled = true; textBox2.Enabled = true;
            comboBox2.Enabled = true; radioButton1.Enabled = true; radioButton2.Enabled = true; label17.Text = "0";
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                if (comboBox3.SelectedValue + "" == "NO FILTER")
                {
                    if (comboBox5.SelectedIndex < 1)
                    {
                        if (comboBox6.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE STATUS_MHS='"+
                                comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        if (comboBox6.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE JK_MHS='"+
                                comboBox5.Items[comboBox5.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE JK_MHS='"+
                                comboBox5.Items[comboBox5.SelectedIndex] + "' AND STATUS_MHS='" +
                                comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                }
                else
                {
                    if (comboBox5.SelectedIndex < 1)
                    {
                        if (comboBox6.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE THN_REG='" +
                                comboBox3.SelectedValue + "'", conn); DataSet ds = new DataSet();
                            da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE THN_REG='" +
                                comboBox3.SelectedValue + "' AND STATUS_MHS='"+ comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        if (comboBox6.SelectedIndex < 1)
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE THN_REG='" +
                                comboBox3.SelectedValue + "' AND JK_MHS='" + comboBox5.Items[comboBox5.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE THN_REG='" +
                                comboBox3.SelectedValue + "' AND JK_MHS='" + comboBox5.Items[comboBox5.SelectedIndex] +
                                "' AND STATUS_MHS='"+ comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                            DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                }
            }
            else
            {
                if (radioButton3.Checked == true && radioButton6.Checked == false && radioButton10.Checked == false && radioButton8.Checked == false)
                {
                    if (comboBox3.SelectedValue + "" == "NO FILTER")
                    {
                        if (comboBox5.SelectedIndex < 1)
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NRP_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(NRP_MHS) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NRP_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(NRP_MHS) LIKE LOWER('%" + txtSearch.Text + "%') AND STATUS_MHS='"+
                                    comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                        else
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NRP_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(NRP_MHS) LIKE LOWER('%" + txtSearch.Text + "%') AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NRP_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(NRP_MHS) LIKE LOWER('%" + txtSearch.Text + "%') AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "' AND STATUS_MHS='"+ comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                    else
                    {
                        if (comboBox5.SelectedIndex < 1)
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NRP_MHS) LIKE"
                                    +" UPPER('%"+txtSearch.Text+"%') AND LOWER(NRP_MHS) LIKE LOWER('%"+txtSearch.Text
                                    +"%') AND THN_REG='" + comboBox3.SelectedValue + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NRP_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(NRP_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND STATUS_MHS='"+ 
                                    comboBox6.Items[comboBox6.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                        else
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NRP_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(NRP_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NRP_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(NRP_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND JK_MHS='" + comboBox5.Items[comboBox5.SelectedIndex] 
                                    + "' AND STATUS_MHS='"+ comboBox6.Items[comboBox6.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                }
                else if (radioButton3.Checked == false && radioButton6.Checked == true && radioButton10.Checked == false && radioButton8.Checked == false)
                {
                    if (comboBox3.SelectedValue + "" == "NO FILTER")
                    {
                        if (comboBox5.SelectedIndex < 1)
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NAMA_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(NAMA_MHS) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NAMA_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(NAMA_MHS) LIKE LOWER('%" + txtSearch.Text + "%') AND STATUS_MHS='" +
                                    comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                        else
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NAMA_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(NAMA_MHS) LIKE LOWER('%" + txtSearch.Text + "%') AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NAMA_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(NAMA_MHS) LIKE LOWER('%" + txtSearch.Text + "%') AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "' AND STATUS_MHS='" + comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                    else
                    {
                        if (comboBox5.SelectedIndex < 1)
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NAMA_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(NAMA_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NAMA_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(NAMA_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND STATUS_MHS='" +
                                    comboBox6.Items[comboBox6.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                        else
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NAMA_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(NAMA_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(NAMA_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(NAMA_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND JK_MHS='" + comboBox5.Items[comboBox5.SelectedIndex]
                                    + "' AND STATUS_MHS='" + comboBox6.Items[comboBox6.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                }
                else if (radioButton3.Checked == false && radioButton6.Checked == false && radioButton10.Checked == true && radioButton8.Checked == false)
                {
                    if (comboBox3.SelectedValue + "" == "NO FILTER")
                    {
                        if (comboBox5.SelectedIndex < 1)
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(JURUSAN_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(JURUSAN_MHS) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(JURUSAN_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(JURUSAN_MHS) LIKE LOWER('%" + txtSearch.Text + "%') AND STATUS_MHS='" +
                                    comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                        else
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(JURUSAN_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(JURUSAN_MHS) LIKE LOWER('%" + txtSearch.Text + "%') AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(JURUSAN_MHS) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(JURUSAN_MHS) LIKE LOWER('%" + txtSearch.Text + "%') AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "' AND STATUS_MHS='" + comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                    else
                    {
                        if (comboBox5.SelectedIndex < 1)
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(JURUSAN_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(JURUSAN_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(JURUSAN_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(JURUSAN_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND STATUS_MHS='" +
                                    comboBox6.Items[comboBox6.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                        else
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(JURUSAN_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(JURUSAN_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(JURUSAN_MHS) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(JURUSAN_MHS) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND JK_MHS='" + comboBox5.Items[comboBox5.SelectedIndex]
                                    + "' AND STATUS_MHS='" + comboBox6.Items[comboBox6.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                }
                else
                {
                    if (comboBox3.SelectedValue + "" == "NO FILTER")
                    {
                        if (comboBox5.SelectedIndex < 1)
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(KODE_DOSEN_WALI) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(KODE_DOSEN_WALI) LIKE LOWER('%" + txtSearch.Text + "%')", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(KODE_DOSEN_WALI) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(KODE_DOSEN_WALI) LIKE LOWER('%" + txtSearch.Text + "%') AND STATUS_MHS='" +
                                    comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                        else
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(KODE_DOSEN_WALI) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(KODE_DOSEN_WALI) LIKE LOWER('%" + txtSearch.Text + "%') AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(KODE_DOSEN_WALI) LIKE UPPER('%" +
                                    txtSearch.Text + "%') AND LOWER(KODE_DOSEN_WALI) LIKE LOWER('%" + txtSearch.Text + "%') AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "' AND STATUS_MHS='" + comboBox6.Items[comboBox6.SelectedIndex] + "'", conn);
                                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                    }
                    else
                    {
                        if (comboBox5.SelectedIndex < 1)
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(KODE_DOSEN_WALI) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(KODE_DOSEN_WALI) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(KODE_DOSEN_WALI) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(KODE_DOSEN_WALI) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND STATUS_MHS='" +
                                    comboBox6.Items[comboBox6.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                        }
                        else
                        {
                            if (comboBox6.SelectedIndex < 1)
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(KODE_DOSEN_WALI) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(KODE_DOSEN_WALI) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND JK_MHS='" +
                                    comboBox5.Items[comboBox5.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA WHERE UPPER(KODE_DOSEN_WALI) LIKE"
                                    + " UPPER('%" + txtSearch.Text + "%') AND LOWER(KODE_DOSEN_WALI) LIKE LOWER('%" + txtSearch.Text
                                    + "%') AND THN_REG='" + comboBox3.SelectedValue + "' AND JK_MHS='" + comboBox5.Items[comboBox5.SelectedIndex]
                                    + "' AND STATUS_MHS='" + comboBox6.Items[comboBox6.SelectedIndex] + "'", conn); DataSet ds = new DataSet();
                                da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                            }
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex; label17.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox2.SelectedValue= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            label14.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            if (dataGridView1.Rows[e.RowIndex].Cells[7].Value + "" == "L")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[11].Value + "" == "Aktif")
            {
                radioButton4.Checked = true;
            }
            else if (dataGridView1.Rows[e.RowIndex].Cells[11].Value + "" == "Cuti")
            {
                radioButton5.Checked = true;
            }
            else
            {
                radioButton9.Checked = true;
            }
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            numericUpDown1.Enabled = false; comboBox2.Enabled = false; btnInsert.Enabled = false;
            textBox2.Enabled = false; radioButton1.Enabled = false; radioButton2.Enabled = false;
            btnUpdate.Enabled = true; btnDelete.Enabled = true; timer1.Stop(); waktu = 0;
        }

        bool ceknotelp = false;
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(textBox2.Text)) { MessageBox.Show("Field Nama Mahasiswa Wajib Diisi");}
                if (String.IsNullOrEmpty(textBox4.Text)) { MessageBox.Show("Field Kelas Mahasiswa Wajib Diisi"); }
                if (radioButton1.Checked == false && radioButton2.Checked == false) { MessageBox.Show("Field Jenis Kelamin Mahasiswa Wajib Dipilih"); }
                if (String.IsNullOrEmpty(textBox6.Text)) { MessageBox.Show("Field Email Mahasiswa Wajib Diisi"); }
                if (String.IsNullOrEmpty(textBox5.Text)) { MessageBox.Show("Field Alamat Mahasiswa Wajib Diisi"); }
                if (String.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("Nomor Telepon Mahasiswa Wajib Diisi"); ceknotelp = false; }
                else {
                    if (textBox1.TextLength <= 11) { MessageBox.Show("Panjang Nomor Telepon Mahasiswa Wajib Diisi Dengan Valid"); ceknotelp = false; }
                    else {
                        if (!textBox1.Text.ToString().Substring(0, 2).Equals("08")) { MessageBox.Show("Nomor Telepon Mahasiswa Tidak Valid"); ceknotelp = false; }
                        else { ceknotelp = true; }
                    }
                }
                if (radioButton4.Checked == false && radioButton5.Checked == false && radioButton9.Checked == false) { MessageBox.Show("Field Status Mahasiswa Wajib Dipilih"); }
                else if(textBox2.Text!=""&&textBox4.Text!=""&&textBox6.Text!=""&&textBox5.Text!=""&&(radioButton1.Checked==true||radioButton2.Checked==true)
                    && ceknotelp == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton9.Checked == true))
                {
                    OracleCommand cmd = new OracleCommand(); cmd.Connection = conn; string j = ""; string s = "";
                    if (radioButton1.Checked == true)
                    {
                        j = "L";
                    }
                    else
                    {
                        j = "P";
                    }
                    if (radioButton4.Checked == true)
                    {
                        s = "Aktif";
                    }
                    else if (radioButton5.Checked == true)
                    {
                        s = "Cuti";
                    }
                    else
                    {
                        s = "Tidak Aktif";
                    }
                    cmd.CommandText = "INSERT INTO MAHASISWA VALUES(0," + numericUpDown1.Value + ",'" + textBox2.Text + "','" + comboBox2.SelectedValue +
                        "','" + textBox4.Text + "',1,TO_DATE('" + String.Format("{0:dd-MM-yyyy}", dateTimePicker1.Value) + "','DD-MM-YYYY'),'" +
                        j + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox1.Text + "','" + s + "','" + comboBox1.SelectedValue + "')";
                    cmd.ExecuteNonQuery(); comboBox5.SelectedItem = "NO FILTER";
                    OracleDataAdapter da1 = new OracleDataAdapter("SELECT TO_CHAR(THN_REG) AS THN_REG FROM MAHASISWA UNION SELECT 'NO FILTER' FROM DUAL", conn);
                    DataSet ds1 = new DataSet(); da1.Fill(ds1); comboBox3.DataSource = ds1.Tables[0]; comboBox3.DisplayMember = "THN_REG";
                    comboBox3.ValueMember = "THN_REG"; comboBox3.SelectedValue = "NO FILTER"; comboBox6.SelectedItem = "NO FILTER"; DatabaseRefresh();
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
                    if (String.IsNullOrEmpty(textBox2.Text)) { MessageBox.Show("Field Nama Mahasiswa Wajib Diisi"); }
                    if (String.IsNullOrEmpty(textBox4.Text)) { MessageBox.Show("Field Kelas Mahasiswa Wajib Diisi"); }
                    if (radioButton1.Checked == false && radioButton2.Checked == false) { MessageBox.Show("Field Jenis Kelamin Mahasiswa Wajib Dipilih"); }
                    if (String.IsNullOrEmpty(textBox6.Text)) { MessageBox.Show("Field Email Mahasiswa Wajib Diisi"); }
                    if (String.IsNullOrEmpty(textBox5.Text)) { MessageBox.Show("Field Alamat Mahasiswa Wajib Diisi"); }
                    if (String.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("Nomor Telepon Mahasiswa Wajib Diisi"); ceknotelp = false; }
                    else {
                        if (textBox1.TextLength <= 11) { MessageBox.Show("Panjang Nomor Telepon Mahasiswa Wajib Diisi Dengan Valid"); ceknotelp = false; }
                        else {
                            if (!textBox1.Text.ToString().Substring(0, 2).Equals("08")) { MessageBox.Show("Nomor Telepon Mahasiswa Tidak Valid"); ceknotelp = false; }
                            else { ceknotelp = true; }
                        }
                    }
                    if (radioButton4.Checked == false && radioButton5.Checked == false && radioButton9.Checked == false) { MessageBox.Show("Field Status Mahasiswa Wajib Dipilih"); }
                    else if (textBox2.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox5.Text != "" && (radioButton1.Checked == true || radioButton2.Checked == true)
                        && ceknotelp == true && (radioButton4.Checked == true || radioButton5.Checked == true || radioButton9.Checked == true))
                    {
                        OracleCommand cmd = new OracleCommand(); cmd.Connection = conn; string s = "";
                        if (radioButton4.Checked == true)
                        {
                            s = "Aktif";
                        }
                        else if (radioButton5.Checked == true)
                        {
                            s = "Cuti";
                        }
                        else
                        {
                            s = "Tidak Aktif";
                        }
                        cmd.CommandText = "UPDATE MAHASISWA SET KELAS_MHS='"+textBox4.Text+"',TGL_LAHIR_MHS=TO_DATE('" + 
                            String.Format("{0:dd-MM-yyyy}", dateTimePicker1.Value) + "','DD-MM-YYYY'),EMAIL_MHS='"+textBox6.Text+
                            "',ALAMAT_MHS='"+textBox5.Text+ "',TELP_MHS='"+textBox1.Text+"',STATUS_MHS='"+s+ "',KODE_DOSEN_WALI='"+
                            comboBox1.SelectedValue+"' WHERE NRP_MHS='"+label17.Text+"'"; cmd.ExecuteNonQuery(); comboBox5.SelectedItem = "NO FILTER";
                        OracleDataAdapter da1 = new OracleDataAdapter("SELECT TO_CHAR(THN_REG) AS THN_REG FROM MAHASISWA UNION SELECT 'NO FILTER' FROM DUAL", conn);
                        DataSet ds1 = new DataSet(); da1.Fill(ds1); comboBox3.DataSource = ds1.Tables[0]; comboBox3.DisplayMember = "THN_REG";
                        comboBox3.ValueMember = "THN_REG"; comboBox3.SelectedValue = "NO FILTER"; comboBox6.SelectedItem = "NO FILTER"; DatabaseRefresh();
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
                    cmd.CommandText = "DELETE FROM MAHASISWA WHERE NRP_MHS='" + label17.Text + "'";
                    cmd.ExecuteNonQuery(); comboBox5.SelectedItem = "NO FILTER";
                    OracleDataAdapter da1 = new OracleDataAdapter("SELECT TO_CHAR(THN_REG) AS THN_REG FROM MAHASISWA UNION SELECT 'NO FILTER' FROM DUAL", conn);
                    DataSet ds1 = new DataSet(); da1.Fill(ds1); comboBox3.DataSource = ds1.Tables[0]; comboBox3.DisplayMember = "THN_REG";
                    comboBox3.ValueMember = "THN_REG"; comboBox3.SelectedValue = "NO FILTER"; comboBox6.SelectedItem = "NO FILTER"; DatabaseRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            waktu = 0; timer1.Start();
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            waktu = 0; timer1.Start();
        }

        private void comboBox6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            waktu = 0; timer1.Start();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void radioButton10_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void radioButton8_Click(object sender, EventArgs e)
        {
            waktu = 0; txtSearch.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true || radioButton6.Checked == true || radioButton10.Checked == true || radioButton8.Checked == true)
            {
                waktu = 0; timer1.Start();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
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
    }
}
