﻿using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Meta { get; set; }
        public bool? Active { get; set; }
        public int? Order { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
