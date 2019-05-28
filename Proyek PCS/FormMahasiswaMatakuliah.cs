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
    public partial class FormMahasiswaMatakuliah : Form
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

        private void btnAmbilMatakuliah_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    OracleDataAdapter da = new OracleDataAdapter("SELECT COUNT(*) FROM PENGAMBILAN_MATAKULIAH WHERE KODE_MK='"+
                        dataGridView1.Rows[index].Cells[0].Value+"' ", conn); DataSet ds = new DataSet(); da.Fill(ds);
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) < 1)
                    {
                        OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO PENGAMBILAN_MATAKULIAH VALUES(" + idmhs + ",'" + dataGridView1.Rows[index].Cells[0].Value +
                            "',0,0,0,'','',0)";
                        cmd.ExecuteNonQuery(); ReloadPage();
                    }
                    else
                    {
                        MessageBox.Show("Mata Kuliah Sudah Diambil Semester Ini");
                    }
                }
                index = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEndThisSemester_Click(object sender, EventArgs e)
        {
            OracleTransaction obTrans = conn.BeginTransaction();
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        OracleDataAdapter da = new OracleDataAdapter("SELECT MM.SKS_MATKUL FROM MASTER_MATAKULIAH MM INNER JOIN PENGAMBILAN_MATAKULIAH PM ON MM.KODE_MK=PM.KODE_MK AND NRP_MHS='"+idmhs+"'", conn);
                        DataSet ds = new DataSet(); da.Fill(ds); 
                        //int bebanmutu=
                        cmd.CommandText = "INSERT INTO MATAKULIAH_MAHASISWA VALUES("+idmhs+",'"+dataGridView2.Rows[i].Cells[1].Value+
                            "','"+dataGridView2.Rows[i].Cells[2].Value+"','"+dataGridView2.Rows[i].Cells[3].Value+"','"+ dataGridView2.Rows[i].Cells[4].Value +
                            "','"+ dataGridView2.Rows[i].Cells[5].Value + "','"+ dataGridView2.Rows[i].Cells[6].Value + "','"+ dataGridView2.Rows[i].Cells[7].Value + "') ";
                        cmd.ExecuteNonQuery();
                    }

                    obTrans.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); obTrans.Rollback();
            }
        }

        int index = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
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

        public FormMahasiswaMatakuliah()
        {
            InitializeComponent();
            conn = new OracleConnection();
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
        }
        private void FormMahasiswaMatakuliah_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                ReloadPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReloadPage()
        {
            OracleDataAdapter da = new OracleDataAdapter("SELECT JURUSAN_MHS FROM MAHASISWA WHERE NRP_MHS='"+idmhs+"'", conn);
            DataSet ds = new DataSet(); da.Fill(ds); label2.Text = ds.Tables[0].Rows[0][0].ToString();
            da = new OracleDataAdapter("SELECT KELAS_MHS FROM MAHASISWA WHERE NRP_MHS='"+idmhs+"'", conn); DataSet ds1 = new DataSet();
            da.Fill(ds1); label4.Text = ds1.Tables[0].Rows[0][0].ToString();
            da = new OracleDataAdapter("SELECT MM.KODE_MK,MM.NAMA_MK,MM.SKS_MATKUL,JM.HARI_MK,JM.JAM_MK,JM.RUANG_MK,JM.KODE_PENGAJAR,JM.KELAS_MK FROM MASTER_MATAKULIAH MM, JADWAL_MATAKULIAH JM "
            + " WHERE MM.KODE_MK=JM.KODE_MK AND MM.JURUSAN_MK='" + ds.Tables[0].Rows[0][0].ToString() + "' AND JM.KELAS_MK='" + ds1.Tables[0].Rows[0][0].ToString() + "'", conn);
            DataSet ds2 = new DataSet(); da.Fill(ds2); dataGridView1.DataSource = ds2.Tables[0];
            da = new OracleDataAdapter("SELECT*FROM PENGAMBILAN_MATAKULIAH WHERE NRP_MHS='"+idmhs+"'", conn); DataSet ds3 = new DataSet();
            da.Fill(ds3); dataGridView2.DataSource = ds3.Tables[0];
        }
    }
}
