using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class Voucher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Condition { get; set; }
        public int? Type { get; set; }
        public int? Percent { get; set; }
        public int? Money { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
