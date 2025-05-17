using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryAPI.Models
{
   [Table("NhanVat")] // Tên bảng chính xác từ DB
    public class NhanVat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhanVat { get; set; }

        [Required]
        public string TenNhanVat { get; set; } = string.Empty;

        public string? NamSinh { get; set; }
        public string? NamMat { get; set; }
        public string? TieuSu { get; set; }
        public string? VaiTro { get; set; }
    }
}