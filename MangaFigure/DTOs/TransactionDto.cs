namespace MangaFigure.DTOs
{
    public class TransactionDto
    {
        public int? Customer { get; set; }
        public int? Employee { get; set; }
        public int? Status { get; set; }
        public int? Rate { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public int? Price { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
