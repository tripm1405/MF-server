namespace MangaFigure.DTOs
{
    public class HeaderDto
    {
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
