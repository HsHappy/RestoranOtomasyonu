using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class Table
    {
        [Key] // Birincil anahtar
        public int TableId { get; set; }

        [Required(ErrorMessage = "Masa numarası/adı girilmelidir.")]
        [StringLength(20)]
        public string TableNumber { get; set; }
        public bool IsOccupied { get; set; } // Masa dolu mu boş mu

        
    }
}