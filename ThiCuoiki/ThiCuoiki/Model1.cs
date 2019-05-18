namespace ThiCuoiki
{
    using ThiCuoiki.DTO;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            Database.SetInitializer(new Khoitao());
        }
        public DbSet<DocGia> DocGias { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<LoaiSach> LoaiSachs { get; set; }
        public DbSet<Sach> Sachs { get; set; }
        public DbSet<MuonTra> MuonTras { get; set; }
        public class Khoitao : CreateDatabaseIfNotExists<Model1>
        {
            protected override void Seed(Model1 context)
            {
                context.DocGias.Add(new DocGia
                {
                    MaDG = "dg1",
                    HoTen = "Nguyen Van A",
                    DiaChi = "123 Nui Thanh",
                    NgaySinh = new DateTime(1990, 03, 02),
                    GioiTinh = true,
                    CoQuan = "Chinh phu"
                });
                context.DocGias.Add(new DocGia
                {
                    MaDG = "dg2",
                    HoTen = "Nguyen Van B",
                    DiaChi = "124 Nui Thanh",
                    NgaySinh = new DateTime(1991, 03, 02),
                    GioiTinh = true,
                    CoQuan = "Cong ty dien luc"
                });
                context.DocGias.Add(new DocGia
                {
                    MaDG = "dg3",
                    HoTen = "Nguyen Van C",
                    DiaChi = "255 Nui Thanh",
                    NgaySinh = new DateTime(1992, 03, 02),
                    GioiTinh = false,
                    CoQuan = "Cong ti nuoc"
                });
                context.NhanViens.Add(new NhanVien
                {
                    MaNV = "nv1",
                    HoTen = "Le Van A",
                    GioiTinh = true,
                });
                context.NhanViens.Add(new NhanVien
                {
                    MaNV = "nv2",
                    HoTen = "Le Van B",
                    GioiTinh = false,
                });
                context.NhanViens.Add(new NhanVien
                {
                    MaNV = "nv3",
                    HoTen = "Le Van C",
                    GioiTinh = true,
                });
                context.LoaiSachs.Add(new LoaiSach
                {
                    MaLoai = "ls1",
                    TenLoai = "Van hoc",
                    ViTri = "vt1"
                });
                context.LoaiSachs.Add(new LoaiSach
                {
                    MaLoai = "ls2",
                    TenLoai = "Doi Song",
                    ViTri = "vt2"
                });
                context.LoaiSachs.Add(new LoaiSach
                {
                    MaLoai = "ls3",
                    TenLoai = "Khoa Hoc",
                    ViTri = "vt3"
                });
                context.Sachs.Add(new Sach
                {
                    MaSach = "s1",
                    TenSach = "Nhung ngay dep troi",
                    SoTrang = 100,
                    TacGia = "Bang Kieu",
                    MaLoai = "ls1",
                    NhaXB = "NXB Kim Dong",
                    SoLuong = 100
                });
                context.Sachs.Add(new Sach
                {
                    MaSach = "s2",
                    TenSach = "Nhung ngay dep troi phan 2",
                    SoTrang = 100,
                    TacGia = "Bang Kieu",
                    MaLoai = "ls1",
                    NhaXB = "NXB Kim Dong",
                    SoLuong = 100
                });
                context.Sachs.Add(new Sach
                {
                    MaSach = "s3",
                    TenSach = "Nhung ngay dep troi phan 3",
                    SoTrang = 100,
                    TacGia = "Bang Kieu",
                    MaLoai = "ls1",
                    NhaXB = "NXB Kim Dong",
                    SoLuong = 100
                });
                context.MuonTras.Add(new MuonTra
                {
                    STT = 1,
                    MaDG = "dg1",
                    MaNV = "nv1",
                    MaSach = "s1",
                    NgayMuon = new DateTime(2018, 12, 30),
                    NgayTra = new DateTime(2019, 1, 15),
                    NgayHenTra = new DateTime(2019, 1, 18)
                });
                context.SaveChanges();
            }
        }
    }

    
}