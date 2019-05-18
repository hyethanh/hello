using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiCuoiki.DTO
{
    [Table("LoaiSach")]
    public class LoaiSach
    {
        [Key]
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string ViTri { get; set; }
    }
}
