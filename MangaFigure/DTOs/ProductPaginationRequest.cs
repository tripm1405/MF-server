namespace MangaFigure.DTOs;

public class ProductPaginationRequest
{
    public int PageSize { get; set; } = 10;
    public int Page { get; set; } = 1;
    public bool? Type { get; set; }
    public string? CatalogMeta { get; set; }
}