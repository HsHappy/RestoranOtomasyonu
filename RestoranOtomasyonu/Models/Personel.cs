using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoranOtomasyonu.Models
{
    public class Personel
    {
        [Key] // Birincil anahtar 
        public int PersonelId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        public string Role { get; set; } // Personel rolü (örneğin: Garson, Mutfak, Yönetici)

    }
}