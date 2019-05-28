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
    public partial class FormDosenHome : Form
    {
        public static OracleConnection conn;
        public static string dts, userid, pass, iddosen, namedosen;
        public FormDosenHome()
        {
            InitializeComponent(); conn = new OracleConnection();
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
        }

        private void btnViewMyJadwal_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); FormDosenJadwal.dts = dts; FormDosenJadwal.userid = userid; FormDosenJadwal.pass = pass;
                FormDosenJadwal.iddosen = iddosen; FormDosenJadwal.namedosen = namedosen;
                this.Hide(); new FormDosenJadwal().ShowDialog(); conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open(); FormDosenProfile.dts = dts; FormDosenProfile.userid = userid; FormDosenProfile.pass = pass;
                FormDosenProfile.iddosen = iddosen; FormDosenProfile.namedosen = namedosen;
                this.Hide(); new FormDosenProfile().ShowDialog(); conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
