using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryAPI.Models
{
   [Table("CauChuyen")] // Tên bảng chính xác từ DB
    public class CauChuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCauChuyen { get; set; }

        [Required]
        public string TieuDe { get; set; } = string.Empty;

        public string? NoiDung { get; set; }

    }
}