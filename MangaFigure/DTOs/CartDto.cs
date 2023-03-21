namespace MangaFigure.DTOs
{
    public class CartDto
    {
        public int? Customer { get; set; }
        public int? Product { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
