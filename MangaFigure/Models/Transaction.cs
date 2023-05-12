using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionDetails = new HashSet<TransactionDetail>();
        }

        public int Id { get; set; }
        public int? Customer { get; set; }
        public int? Employee { get; set; }
        public int? Status { get; set; }
        public int? Rate { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? Price { get; set; }
        public string? Address { get; set; }
        public int? Fee { get; set; }
        public virtual Customer? CustomerNavigation { get; set; }
        public virtual Employee? EmployeeNavigation { get; set; }
        public virtual TransactionStatus? StatusNavigation { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
