using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryAPI.Models
{
   [Table("SuKien")] // Tên bảng chính xác từ DB
    public class SuKien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSuKien { get; set; }

        [Required]
        public string TenSuKien { get; set; } = string.Empty;

        public string? ThoiGianDienRa { get; set; }
        public string? DiaDiem { get; set; }
        public string? MoTa { get; set; }

        [ForeignKey("ThoiKyQuocHieu")]
        public int? MaTrieuDai { get; set; }
        public ThoiKyQuocHieu? ThoiKyQuocHieu { get; set; }
    }
}