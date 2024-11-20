using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotizAPI2.Models;

    public class Notiz
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;
    }
