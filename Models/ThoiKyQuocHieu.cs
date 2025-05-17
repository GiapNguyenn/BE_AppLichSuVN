// ThoiKyQuocHieu.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryAPI.Models
{
     [Table("ThoiKyQuocHieu")] // Tên bảng chính xác từ DB
    public class ThoiKyQuocHieu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTrieuDai { get; set; }

        [Required]
        public string TenTrieuDai { get; set; } = string.Empty;

        public string? ThoiGianBatDau { get; set; }
        public string? ThoiGianKetThuc { get; set; }
        public string? SoNamTonTai { get; set; }
        public string? ChuHan { get; set; }
        public string? ChuNom { get; set; }
        public string? TrieuDaiCheDo { get; set; }
        public string? MoTa { get; set; }
    }
}