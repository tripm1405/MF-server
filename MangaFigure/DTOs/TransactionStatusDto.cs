namespace MangaFigure.DTOs
{
    public class TransactionStatusDto
    {
        public string? Content { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
