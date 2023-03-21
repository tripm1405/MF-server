using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class Catalog
    {
        public Catalog()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? Type { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
