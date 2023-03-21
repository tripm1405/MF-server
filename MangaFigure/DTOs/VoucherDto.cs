namespace MangaFigure.DTOs
{
    public class VoucherDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Condition { get; set; }
        public int? Type { get; set; }
        public int? Percent { get; set; }
        public int? Money { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
