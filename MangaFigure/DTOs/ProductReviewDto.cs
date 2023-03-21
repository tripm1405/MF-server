﻿namespace MangaFigure.DTOs
{
    public class ProductReviewDto
    {
        public int? Product { get; set; }
        public int? Customer { get; set; }
        public string? Content { get; set; }
        public int? Rate { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
