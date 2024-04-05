using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTAP_QLKH
{
    public partial class TimKiem : Form
    {
        public TimKiem()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=TABALO\SQLEXPRESS;Initial Catalog=QL_KhoHang;Integrated Security=True");


        public void hienThi()
        {
            con.Open();
            SqlCommand command = new SqlCommand("select * from NhapSP ", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            con.Close();
            dgvTimKiem.DataSource = dt;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("select * from NhapSP where TenSP = '"+txtTenSP+"'", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            con.Close();
            dgvTimKiem.DataSource = dt;
        }

        private void TimKiem_Load(object sender, EventArgs e)
        {
            hienThi();
        }

        private void dgvTimKiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvTimKiem.CurrentCell.RowIndex;
            txtTenSP.Text = dgvTimKiem.Rows[t].Cells[1].Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTenSP.Clear();
        }
    }
}
