﻿using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class SlideShow
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
