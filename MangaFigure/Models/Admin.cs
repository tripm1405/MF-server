using System;
using System.Collections.Generic;

namespace MangaFigure.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
