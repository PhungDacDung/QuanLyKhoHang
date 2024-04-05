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
    public partial class XuatHang : Form
    {
        public XuatHang()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=TABALO\SQLEXPRESS;Initial Catalog=QL_KhoHang;Integrated Security=True");

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

        public void hienThiXuatSP()
        {
            con.Open();
            SqlCommand comm = new SqlCommand("select * from XuatSP", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            con.Close();
            dgvXuatHang.DataSource = dt;
        }

        private void XuatHang_Load(object sender, EventArgs e)
        {
            hienThiHangHoa();
            hienThiXuatSP();
        }

        private void grNhapHang_Enter(object sender, EventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {

            con.Open();
            string query = "insert into XuatSP values('" + txtMaSP.Text + "','" + txtTenSP.Text + "','" + txtSoLuong.Text + "','" + txtGia.Text + "','" + txtKH.Text + "','" + txtTongTien.Text + "','" + txtNgayXuat.Value.ToString("yyyy-MM-dd") + "')";
            SqlCommand comm = new SqlCommand(query, con);
            comm.ExecuteNonQuery();

                //SqlCommand comm1 = new SqlCommand("update HangHoa set SoLuong = 'SoLuong - "+ int.Parse(txtSoLuong.Text) +"'",con);
                // comm1.ExecuteNonQuery();
                string update = @"update HangHoa set SoLuong = SoLuong - @SoLuong where MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@MaSP", SqlDbType.NVarChar);
                cmd.Parameters["@MaSP"].Value = txtMaSP.Text;
                cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
                cmd.Parameters["@SoLuong"].Value = txtSoLuong.Text;
                cmd.ExecuteNonQuery();

                con.Close();
                hienThiXuatSP();
                hienThiHangHoa();

               
                MessageBox.Show("Xuat san pham thanh cong !");

            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSoLuong.Clear();
            txtGia.Clear();
            txtKH.Clear();
            txtTongTien.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Da xay ra loi" + ex.Message);
            }
            

        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvHangHoa.CurrentCell.RowIndex;
            txtMaSP.Text = dgvHangHoa.Rows[t].Cells[0].Value.ToString();
            txtTenSP.Text = dgvHangHoa.Rows[t].Cells[1].Value.ToString();
            txtGia.Text = dgvHangHoa.Rows[t].Cells[2].Value.ToString();
        }

       

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTongTien_Click(object sender, EventArgs e)
        {
            double gia = 0, soluong = 0, tongtien = 0;
            gia = double.Parse(txtGia.Text);
            soluong = double.Parse(txtSoLuong.Text);

            tongtien = gia * soluong;

            txtTongTien.Text = tongtien.ToString();
        }

        private void btnCannel_Click(object sender, EventArgs e)
        {

            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSoLuong.Clear();
            txtGia.Clear();
            txtKH.Clear();
            txtTongTien.Clear();
        }
    }
}
