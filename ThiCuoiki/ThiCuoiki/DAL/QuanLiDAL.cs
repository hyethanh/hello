using ThiCuoiki.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiCuoiki.DAL
{
    public class QuanLiDAL
    {
        Model1 db = new Model1();
        public List<object> GetListDAL()
        {
            List<object> kq = null;
                kq = db.MuonTras.Select(c => new
                {
                    c.STT,
                    c.sach.TenSach,
                    NhanVien = c.nhanvien.HoTen,
                    DocGia = c.docgia.HoTen,
                    c.NgayMuon,
                    c.NgayTra,
                    c.NgayHenTra
                }).ToList<object>();
            return kq;
        }
        //public void AddDocGiaDAL(DocGia dg)
        //{
        //    try
        //    {
        //        db.DocGias.Add(dg);
        //        db.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Ma Doc Gia trung, xin nhap lai");
        //    }
        //}
        //public void AddNhanVienDAL(NhanVien nv)
        //{
        //    try
        //    {
        //        db.NhanViens.Add(nv);
        //        db.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Ma Nhan Vien trung, xin nhap lai");
        //    }
        //}
        //public void AddLoaiSachDAL(LoaiSach ls)
        //{
        //    try
        //    {
        //        db.LoaiSachs.Add(ls);
        //        db.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Ma Loai Sach trung, xin nhap lai");
        //    }
        //}
        //public void AddSachDAL(Sach s)
        //{
        //    try
        //    {
        //        db.Sachs.Add(s);
        //        db.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Ma Sach trung hoac Nhap Sai Ma Loai, xin nhap lai");
        //    }
        //}
        public void AddMuonTraDAL(MuonTra mt)
        {
            try
            {
                db.MuonTras.Add(mt);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("Nhap sai Ma Doc gia, Nhan vien hoac Ma Sach, xin nhap lai");
            }
        }
        public MuonTra GetMuonTraDAL(string s)
        {
            int a = Convert.ToInt32(s);
            MuonTra mt = new MuonTra();
            mt = db.MuonTras.Where(p => p.STT == a).SingleOrDefault();
            return mt;
        }
        public void DelMuonTraDAL(string s)
        {
            int a = Convert.ToInt32(s);
            MuonTra mt = db.MuonTras.Where(p => p.STT == a).SingleOrDefault();
            db.MuonTras.Remove(mt);
            db.SaveChanges();
        }
        public void UpdateMuonTraDAL(MuonTra mt)
        {
            try
            {
                MuonTra mt1 = db.MuonTras.Where(p => p.STT == mt.STT).SingleOrDefault();
                mt1.MaDG = mt.MaDG;
                mt1.MaNV = mt.MaNV;
                mt1.MaSach = mt.MaSach;
                mt1.NgayMuon = mt.NgayMuon;
                mt1.NgayTra = mt.NgayTra;
                mt1.NgayHenTra = mt.NgayHenTra;
                db.SaveChanges();
            }
            catch(Exception)
            {
                MessageBox.Show("Sai ma DocGia, NhanVien, hoac ma Sach");
            }
        }
        public List<object> SortMuonTraDAL(string s)
        {
            List<object> list = null;
            if (s == "TenDG")
            {
                list = db.MuonTras.Select(p => new
                {
                    p.STT,
                    p.MaDG,
                    DocGia = p.docgia.HoTen,
                    p.MaNV,
                    NhanVien = p.nhanvien.HoTen,
                    p.MaSach,
                    p.sach.TenSach,
                    p.sach.loaisach.TenLoai,
                    p.NgayMuon,
                    p.NgayTra,
                    p.NgayHenTra
                }).OrderBy(p => p.DocGia).ToList<object>();
            }
            else if (s == "TenNV")
            {
                list = (from p in db.MuonTras
                        select new
                        {
                            p.STT,
                            p.MaDG,
                            DocGia = p.docgia.HoTen,
                            p.MaNV,
                            NhanVien = p.nhanvien.HoTen,
                            p.MaSach,
                            p.sach.TenSach,
                            p.sach.loaisach.TenLoai,
                            p.NgayMuon,
                            p.NgayTra,
                            p.NgayHenTra
                        }).OrderBy(p => p.NhanVien).ToList<object>();
            }
            else if (s == "TenSach")
            {
                list = (from p in db.MuonTras
                        select new
                        {
                            p.STT,
                            p.MaDG,
                            DocGia = p.docgia.HoTen,
                            p.MaNV,
                            NhanVien = p.nhanvien.HoTen,
                            p.MaSach,
                            p.sach.TenSach,
                            p.sach.loaisach.TenLoai,
                            p.NgayMuon,
                            p.NgayTra,
                            p.NgayHenTra
                        }).OrderBy(p => p.TenSach).ToList<object>();
            }
            return list;
        }
        public List<object> TimKiemMuonTraDAL(string s1, string s2)
        {
            List<object> list = null;
            if (s1 == "DocGia")
            {
                list = db.MuonTras.Where(p => p.docgia.HoTen.Contains(s2)).ToList<object>();
            }
            else if(s1=="NhanVien")
            {
                list = db.MuonTras.Where(p => p.nhanvien.HoTen.Contains(s2)).ToList<object>();
            }
            else if(s1=="LoaiSach")
            {
                list = db.MuonTras.Where(p => p.sach.loaisach.TenLoai.Contains(s2)).ToList<object>();
            }
            else if(s1=="Sach")
            {
                list = db.MuonTras.Where(p => p.sach.TenSach.Contains(s2)).ToList<object>();
            }
            return list;
        }
    }
}
