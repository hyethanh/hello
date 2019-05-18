using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiCuoiki.DTO
{
    [Table("MuonTra")]
    public class MuonTra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
        public string MaNV { get; set; }
        public string MaDG { get; set; }
        public string MaSach { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public DateTime NgayHenTra { get; set; }
        [ForeignKey("MaNV")]
        public virtual NhanVien nhanvien { get; set; }
        [ForeignKey("MaDG")]
        public virtual DocGia docgia { get; set; }
        [ForeignKey("MaSach")]
        public virtual Sach sach { get; set; }

    }
}
