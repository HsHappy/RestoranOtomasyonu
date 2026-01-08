using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class ActionLog
    {
        [Key]
        public int LogId { get; set; }

        public string PersonelName { get; set; } 
        public string ActionType { get; set; }    
        public string Description { get; set; }   
        public DateTime Date { get; set; }        
    }
}