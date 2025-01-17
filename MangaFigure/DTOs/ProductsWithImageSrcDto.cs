﻿namespace MangaFigure.DTOs
{
    public class ProductsWithImageSrcDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Image { get; set; }
        public bool? Type { get; set; }
        public int? Catalog { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public int? Amount { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? SrcImg { get; set; }
        public string? CatalogMeta { get; set; }
    }
}
