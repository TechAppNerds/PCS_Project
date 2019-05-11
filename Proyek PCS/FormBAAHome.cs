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
    public partial class FormBAAHome : Form
    {
        public static OracleConnection conn;
        public static string dts, userid, pass;
        public FormBAAHome()
        {
            InitializeComponent();
            conn = new OracleConnection();
            conn.ConnectionString= "Data Source="+dts+";User ID="+userid+";password="+pass+"";
        }

        private void btnForm_Jadwal_Matakuliah_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); FormBAAMasterMatakuliah.dts = dts;
                FormBAAMasterMatakuliah.userid = userid; FormBAAMasterMatakuliah.pass = pass;
                this.Hide(); new FormBAAMasterMatakuliah().ShowDialog();
                conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnForm_Dosen_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); FormBAADosen.dts = dts;
                FormBAADosen.userid = userid; FormBAADosen.pass = pass;
                this.Hide(); new FormBAADosen().ShowDialog();
                conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnForm_Mahasiswa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); FormBAAMahasiswa.dts = dts;
                FormBAAMahasiswa.userid = userid; FormBAAMahasiswa.pass = pass;
                this.Hide(); new FormBAAMahasiswa().ShowDialog();
                conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
