using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API_training.DAL.Domain{

    public class Genre : BaseEntity
    {
        /// <summary>
        /// Наименование жанра книги
        /// </summary>
        [StringLength(250)]
        [Required]
        public string Name { get; set; }
    }
}



