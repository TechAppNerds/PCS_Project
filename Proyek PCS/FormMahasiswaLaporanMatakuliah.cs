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
    public partial class FormMahasiswaLaporanMatakuliah : Form
    {
        public static OracleConnection conn;
        public static string dts, userid, pass, idmhs, namemhs;

        private void btnLogOut_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ReloadPage();
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            try
            {
                FormMahasiswaHome.dts = dts; FormMahasiswaHome.userid = userid; FormMahasiswaHome.pass = pass;
                FormMahasiswaHome.idmhs = idmhs; FormMahasiswaHome.namemhs = namemhs;
                this.Hide(); new FormMahasiswaHome().ShowDialog(); conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public FormMahasiswaLaporanMatakuliah()
        {
            InitializeComponent();
            conn = new OracleConnection();
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
        }

        private void FormMahasiswaLaporanMatakuliah_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); OracleDataAdapter da = new OracleDataAdapter("SELECT TO_CHAR(SMST_MHS) AS SMST_MHS FROM MATAKULIAH_MAHASISWA WHERE NRP_MHS='" + idmhs+"' UNION SELECT 'NO FILTER' FROM DUAL", conn);
                DataSet ds1 = new DataSet(); da.Fill(ds1); comboBox1.DataSource = ds1.Tables[0]; comboBox1.DisplayMember = "SMST_MHS";
                comboBox1.ValueMember = "SMST_MHS"; comboBox1.SelectedValue = "NO FILTER"; ReloadPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReloadPage()
        {
            if (comboBox1.SelectedValue.ToString().Equals("NO FILTER"))
            {
                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MATAKULIAH_MAHASISWA WHERE NRP_MHS='" + idmhs + "'", conn);
                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MATAKULIAH_MAHASISWA WHERE NRP_MHS='" + idmhs + "' AND SMST_MHS='"+comboBox1.SelectedValue+"'", conn);
                DataSet ds = new DataSet(); da.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
