using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiCuoiki.DTO
{
    [Table("Sach")]
    public class Sach
    {
        [Key]
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoTrang { get; set; }
        public string TacGia { get; set; }
        public string MaLoai { get; set; }
        public string NhaXB { get; set; }
        public int SoLuong { get; set; }
        [ForeignKey("MaLoai")]
        public virtual LoaiSach loaisach { get; set; }
    }
}
