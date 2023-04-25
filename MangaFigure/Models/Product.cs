using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            ProductImages = new HashSet<ProductImage>();
            TransactionDetails = new HashSet<TransactionDetail>();
        }

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

        public virtual Catalog? CatalogNavigation { get; set; }
        public virtual ProductImage? ImageNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
