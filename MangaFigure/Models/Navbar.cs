using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class Navbar
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
