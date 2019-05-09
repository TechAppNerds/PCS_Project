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
        public FormBAAHome()
        {
            InitializeComponent();
            conn = new OracleConnection();
            conn.ConnectionString= "Data Source=orcl;User ID=BAA;password=BAA";
        }

        private void btnForm_Jadwal_Matakuliah_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                this.Hide(); new FormBAAJadwalMatakuliah().ShowDialog();
                conn.Close();
                this.Close();
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
                conn.Open();
                this.Hide(); new FormBAADosen().ShowDialog();
                conn.Close();
                this.Close();
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
                conn.Open();
                this.Hide(); new FormBAAMahasiswa().ShowDialog();
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
