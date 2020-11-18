using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API_training.Models.DTO
{
    public class DTOBooks
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Name { get; set; }
        public string Publisher { get; set; }
        [MaxLength(4)]
        public int PublishingYear { get; set; }
    }
}
