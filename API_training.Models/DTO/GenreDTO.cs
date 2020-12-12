using API_training.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API_training.Models.DTO
{
    /// <summary>
    /// Жанр книги
    /// </summary>
    public class GenreDTO : BaseDto { 

        /// <summary>
        /// Наименование жанра книги
        /// </summary>
        public string Name { get; set; }
    }
}



