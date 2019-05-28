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
    public partial class FormMahasiswaHome : Form
    {
        public static OracleConnection conn;
        public static string dts, userid, pass, idmhs, namemhs;

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open(); FormMahasiswaLaporanMatakuliah.dts = dts; FormMahasiswaLaporanMatakuliah.userid = userid;
            FormMahasiswaLaporanMatakuliah.pass = pass; FormMahasiswaLaporanMatakuliah.idmhs = idmhs; FormMahasiswaLaporanMatakuliah.namemhs = namemhs;
            this.Hide(); new FormMahasiswaLaporanMatakuliah().ShowDialog(); conn.Close(); this.Close();
        }

        private void btnJadwalMK_Click(object sender, EventArgs e)
        {
            conn.Open(); FormMahasiswaMatakuliah.dts = dts; FormMahasiswaMatakuliah.userid = userid;
            FormMahasiswaMatakuliah.pass = pass; FormMahasiswaMatakuliah.idmhs = idmhs; FormMahasiswaMatakuliah.namemhs = namemhs;
            this.Hide(); new FormMahasiswaMatakuliah().ShowDialog(); conn.Close(); this.Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            conn.Open(); FormMahasiswaProfile.dts = dts; FormMahasiswaProfile.userid = userid; FormMahasiswaProfile.pass = pass;
            FormMahasiswaProfile.idmhs = idmhs; FormMahasiswaProfile.namemhs = namemhs;
            this.Hide(); new FormMahasiswaProfile().ShowDialog(); conn.Close(); this.Close();
        }

        public FormMahasiswaHome()
        {
            InitializeComponent();
            conn = new OracleConnection();
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
        }
    }
}
