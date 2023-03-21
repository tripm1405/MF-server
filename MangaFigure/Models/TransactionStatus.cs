using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class TransactionStatus
    {
        public TransactionStatus()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string? Content { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
