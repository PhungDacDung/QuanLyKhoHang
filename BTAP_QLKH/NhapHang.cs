using DevExpress.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTAP_QLKH
{
    public partial class NhapHang : Form
    {
        public NhapHang()
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
            dgvNhapHang.DataSource = dt;
        }

        public void hienThiHangHoa()
        {
            con.Open();
            SqlCommand command = new SqlCommand("select * from HangHoa", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            con.Close();
            dgvHangHoa.DataSource = dt;
        }

        private void btnDSNhap_Click(object sender, EventArgs e)
        {


        }
        private void dgvNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvNhapHang.CurrentCell.RowIndex;
            txtMaSP.Text = dgvNhapHang.Rows[t].Cells[0].Value.ToString();
            txtTenSP.Text = dgvNhapHang.Rows[t].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvNhapHang.Rows[t].Cells[2].Value.ToString();
            txtGia.Text = dgvNhapHang.Rows[t].Cells[3].Value.ToString();
            txtCungCap.Text = dgvNhapHang.Rows[t].Cells[4].Value.ToString();

            dtpNgayNhap.Text = dgvNhapHang.Rows[t].Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into NhapSP values('" + txtMaSP.Text + "','" + txtTenSP.Text + "','" + txtSoLuong.Text + "','" + txtGia.Text + "','" + txtCungCap.Text + "','" + dtpNgayNhap.Value.ToString("yyyy-MM-dd") + "')";
                SqlCommand command = new SqlCommand(query, con);
                string query1 = "insert into HangHoa values('" + txtMaSP.Text + "','" + txtTenSP.Text + "','" + txtGia.Text + "','" + txtSoLuong.Text + "')";
                command.ExecuteNonQuery();
                SqlCommand comm = new SqlCommand(query1, con);
                comm.ExecuteNonQuery();
                con.Close();
                //btnAdd_Click(sender, e);
                hienThi();
                MessageBox.Show("Thêm hàng thành công !");


                txtGia.Clear();
                txtMaSP.Clear();
                txtSoLuong.Clear();
                txtTenSP.Clear();
                txtCungCap.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Da xay ra loi" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "delete from NhapSP where MaSP  = '" + txtMaSP.Text + "'";
                SqlCommand command = new SqlCommand(sql, con);
                command.ExecuteNonQuery();
                con.Close();
                hienThi();
                MessageBox.Show("Da xoa");

                txtGia.Clear();
                txtMaSP.Clear();
                txtSoLuong.Clear();
                txtTenSP.Clear();
                txtCungCap.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Da xay ra loi" + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "update NhapSP set SoLuong ='" + txtSoLuong.Text + "',NhaCungCap = '" + txtCungCap.Text + "',NgayNhap = '" + dtpNgayNhap.Value.ToString("yyyy-MM-dd") + "',GiaSP = '" + txtGia.Text + "' where MaSP = '" + txtMaSP.Text + "' ";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                hienThi();
                MessageBox.Show("Sua thanh cong");

                txtGia.Clear();
                txtMaSP.Clear();
                txtSoLuong.Clear();
                txtTenSP.Clear();
                txtCungCap.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Da xay ra loi" + ex.Message);
            }
        }

        private void btnCannel_Click(object sender, EventArgs e)
        {
            txtGia.Clear();
            txtMaSP.Clear();
            txtSoLuong.Clear();
            txtTenSP.Clear();
        }

        private void grNhapHang_Enter(object sender, EventArgs e)
        {

        }

        private void grQuanLy_Enter(object sender, EventArgs e)
        {

        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            hienThi();
            hienThiHangHoa();
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvHangHoa.CurrentCell.RowIndex;
            txtMaSP.Text = dgvHangHoa.Rows[t].Cells[0].Value.ToString();
            txtTenSP.Text = dgvHangHoa.Rows[t].Cells[1].Value.ToString();
            txtGia.Text = dgvHangHoa.Rows[t].Cells[2].Value.ToString();
        }

        private void addSoLuong_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = @"update HangHoa set SoLuong = SoLuong + @SoLuong where MaSP = @MaSP";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar);
            cmd.Parameters["@MaSP"].Value = txtMaSP.Text;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters["@SoLuong"].Value = txtSoLuong.Text;
            cmd.ExecuteNonQuery();

            con.Close();
            hienThiHangHoa();
        }
    }
}
