using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThiCuoiki.DTO;
using ThiCuoiki.BLL;
namespace ThiCuoiki.GUI
{
    public partial class AddForm : Form
    {
        QuanLiBLL bll;
        public AddForm()
        {
            InitializeComponent();
            bll = new QuanLiBLL();
        }
        public delegate void bt_OK();
        public bt_OK On_btOK;
        public MuonTra GetFormMuontra()
        {
            return new MuonTra()
            {
                MaNV = tbMaNVMT.Text,
                MaDG = tbMaDGMT.Text,
                MaSach = tbMaSachMT.Text,
                NgayMuon = dtpNgayMuon.Value,
                NgayTra = dtpNgayTra.Value,
                NgayHenTra = dtpNgayHenTra.Value
            };
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            if (tbMaDGMT.Text == "" || tbMaNVMT.Text == "" || tbMaSachMT.Text == "")
            {
                MessageBox.Show("Ban chua nhap day du Thong tin Muon Tra sach");
            }
            else
            {
                if (On_btOK != null)
                {
                    On_btOK();
                }
                MuonTra mt = GetFormMuontra();
                bll.AddMuonTraBLL(mt);
                MessageBox.Show("Thanh cong");
                Close();
            }
        }
    }
}
