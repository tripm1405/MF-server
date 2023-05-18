using MangaFigure.Models;

namespace MangaFigure.DTOs;

public class ProductPaginationResponse
{
    public ICollection<Product> Products { get; set; }
    public int Total { get; set; }
}