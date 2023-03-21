using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaFigure.Models
{
    public partial class ProductImage
    {
        public ProductImage()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? Product { get; set; }
        public string? Link { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual Product? ProductNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
