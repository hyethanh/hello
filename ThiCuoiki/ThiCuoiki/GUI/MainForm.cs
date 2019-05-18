using ThiCuoiki.BLL;
using ThiCuoiki.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiCuoiki.GUI
{
    public partial class MainForm : Form
    {
        QuanLiBLL bll;
        public MainForm()
        {
            InitializeComponent();
            bll = new QuanLiBLL();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            List<string> ltk = new List<string>();
            ltk.Add("Doc Gia");
            ltk.Add("Nhan Vien");
            ltk.Add("Loai Sach");
            ltk.Add("Sach");
            cbbTimKiem.Items.AddRange(ltk.ToArray());
            List<string> lsort = new List<string>();
            lsort.Add("TenDG");
            lsort.Add("TenNV");
            lsort.Add("TenSach");
            cbbSapXep.Items.AddRange(lsort.ToArray());
        }
        private void btHienThi_Click(object sender, EventArgs e)
        {
            showMuonTra();
        }
        public MuonTra GetFormMuontra()
        {
            return new MuonTra()
            {
                STT = Convert.ToInt32(tbSTT.Text),
                MaNV = tbMaNVMT.Text,
                MaDG = tbMaDGMT.Text,
                MaSach = tbMaSachMT.Text,
                NgayMuon = dtpNgayMuon.Value,
                NgayTra = dtpNgayTra.Value,
                NgayHenTra = dtpNgayHenTra.Value
            };
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            f.On_btOK += showMuonTra;
            f.Show();
        }
        public void showMuonTra()
        {
            dataGridView1.DataSource = bll.GetListBLL();
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string stt;
            stt = dataGridView1.SelectedRows[0].Cells["STT"].Value.ToString();
            MuonTra mt = bll.GetMuonTraBLL(stt);
            tbSTT.Text = mt.STT.ToString();
            tbMaDGMT.Text = mt.MaDG;
            tbMaNVMT.Text = mt.MaNV;
            tbMaSachMT.Text = mt.MaSach;
            dtpNgayMuon.Value = mt.NgayMuon;
            dtpNgayTra.Value = mt.NgayTra;
            dtpNgayHenTra.Value = mt.NgayHenTra;
        }
        private void btSua_Click(object sender, EventArgs e)
        {
            if (tbMaDGMT.Text == "" || tbMaNVMT.Text == "" || tbMaSachMT.Text == "")
            {
                MessageBox.Show("Ban chua nhap day du Thong tin Muon Tra sach");
            }
            else
            {
                MuonTra mt = GetFormMuontra();
                bll.UpdateMuonTraBLL(mt);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string stt;
                foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                {
                    stt = r.Cells["STT"].Value.ToString();
                    bll.DelMuonTraBLL(stt);
                }
                showMuonTra();
            }
            catch (Exception)
            {
                MessageBox.Show("Ban chua chon");
            }
        }
        private void btSapXep_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.SortMuonTraBLL(cbbSapXep.SelectedItem.ToString());
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.TimKiemMuonTraBLL(cbbTimKiem.SelectedItem.ToString(), tbTimKiem.Text);
        }
    }
}
