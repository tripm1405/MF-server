using MangaFigure.Models;

namespace MangaFigure.DTOs
{
    public class MyTransactionDto
    {
        public int? Id { get; set; }
        public int? Customer { get; set; }
        public string? CustomerName { get; set; }
        public int? Employee { get; set; }
        public string? EmployeeName { get; set; }
        public int? Status { get; set; }
        public string? StatusName { get; set; }
        public int? Rate { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
