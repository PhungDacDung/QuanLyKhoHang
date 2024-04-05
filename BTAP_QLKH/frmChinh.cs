using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTAP_QLKH
{
    public partial class frmChinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        public frmChinh()
        {
            InitializeComponent();
        }

        public bool ExistForm(Form form)
        {
            foreach (var child in MdiChildren)
            {
                if (child.Name == form.Name)
                {
                    child.Activate();
                    return true;
                }
            }
            return false;
        }

        

        private void btnXuatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            XuatHang f = new XuatHang();
            if (ExistForm(f)) return;
            f.MdiParent = this;
            f.Show();
        }

        private void btnKiemTra_ItemClick(object sender, ItemClickEventArgs e)
        {
            TimKiem f = new TimKiem();
            if (ExistForm(f)) return;
            f.MdiParent = this;
            f.Show();
        }

        private void btnUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            User f = new User();
            if (ExistForm(f)) return;
            f.MdiParent = this;
            f.Show();
        }

        private void btnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            NhanVien f = new NhanVien();
            if (ExistForm(f)) return;
            f.MdiParent = this;
            f.Show();
        }
        public event EventHandler Logout;
        public bool isExit = true;

        private void barStaticItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrangChu f = new TrangChu();
            if (ExistForm(f)) return;
            f.MdiParent = this;
            f.Show();
        }

        private void btnNhapHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            NhapHang f = new NhapHang();
            if (ExistForm(f)) return;
            f.MdiParent = this;
            f.Show();
        }
    }
}