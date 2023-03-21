﻿using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class ProductReview
    {
        public int Id { get; set; }
        public int? Product { get; set; }
        public int? Customer { get; set; }
        public string? Content { get; set; }
        public int? Rate { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual Customer? CustomerNavigation { get; set; }
    }
}
