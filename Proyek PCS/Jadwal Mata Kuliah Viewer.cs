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
    public partial class Jadwal_Mata_Kuliah_Viewer : Form
    {
        public Jadwal_Mata_Kuliah_Viewer()
        {
            InitializeComponent();
        }

        private void Jadwal_Mata_Kuliah_Viewer_Load(object sender, EventArgs e)
        {
            //using (OracleCommand cmd = new OracleCommand("SELECT * FROM JADWAL_MATAKULIAH", FormBAAJadwalMatakuliah.conn))
            //{
            //    using (OracleDataReader dr = cmd.ExecuteReader())
            //    {
            //        List<object> listmhs = new List<object>();

            //        while (dr.Read())
            //        {
            //            listmhs.Add(new
            //            {
            //                Nrp = dr.GetString(0),
            //                Nama = dr.GetString(0) + " - " + dr.GetString(1)
            //            });
            //        }

            //        comboBox1.DataSource = listmhs;
            //        comboBox1.DisplayMember = "Nama";
            //        comboBox1.ValueMember = "Nrp";
            //    }
            //}

            //Jadwal_Mata_Kuliah jm = new Jadwal_Mata_Kuliah();
            //jm.SetDatabaseLogon("BAA", "BAA");
            //crystalReportViewer1.ReportSource = jm;
        }
    }
}
