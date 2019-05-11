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
        public FormBAADosen()
        {
            InitializeComponent();
            conn = new OracleConnection();
        }

        private void FormBAADosen_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=orcl;User ID=BAA;password=BAA";
            try
            {
                conn.Open();
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void refresh()
        {
            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM DOSEN", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            //dataGridView2.DataSource = ds.Tables[0].Columns[0];
        }

        private void btnBackhome_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                new FormBAAHome().ShowDialog();
                conn.Close();
                this.Close();
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
                this.Hide();
                new FormLogin().ShowDialog();
                conn.Close();
                this.Close();
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
                this.Hide();
                new FormBAAJadwalMatakuliah().ShowDialog();
                conn.Close();
                this.Close();
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
                this.Hide();
                new FormBAAMahasiswa().ShowDialog();
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
