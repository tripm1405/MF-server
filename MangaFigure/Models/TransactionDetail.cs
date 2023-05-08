using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class TransactionDetail
    {
        public int Id { get; set; }
        public int? Transaction { get; set; }
        public int? Product { get; set; }
        public int? Amount { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public int? Price { get; set; }
        public DateTime? CreateAt { get; set; }
        public virtual Product? ProductNavigation { get; set; }
        public virtual Transaction? TransactionNavigation { get; set; }
    }
}
