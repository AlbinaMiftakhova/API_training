using System;
using System.Collections.Generic;
using System.Text;

namespace API_training.Database.Domain
{
    public class Books
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int PublishingYear { get; set; }
    }
}
