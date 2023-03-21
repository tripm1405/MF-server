namespace MangaFigure.DTOs
{
    public class ProductImageDto
    {
        public int? Product { get; set; }
        public string? Link { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
