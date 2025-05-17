using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryAPI.Models
{
    [Table("LanhTho")] // Tên bảng chính xác từ DB
    public class LanhTho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLanhTho { get; set; }

        [Required]
        public string TenGiaiDoan { get; set; } = string.Empty;

        public string? ThoiGian { get; set; }
        public string? MoTa { get; set; }
        public string? BanDoURL { get; set; }

        [ForeignKey("ThoiKyQuocHieu")]
        public int? MaTrieuDai { get; set; }
        public ThoiKyQuocHieu? ThoiKyQuocHieu { get; set; }
    }
}