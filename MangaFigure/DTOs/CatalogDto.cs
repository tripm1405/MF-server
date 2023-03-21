namespace MangaFigure.DTOs;

public class CatalogDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool? Type { get; set; }
    public string? Meta { get; set; }
    public bool? Active { get; set; }
    public int? Order { get; set; }
    public DateTime? CreateAt { get; set; }
}