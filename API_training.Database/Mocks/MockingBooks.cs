using API_training.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_training.Database.Mocks
{
    public static class MockingBooks
    {
        public static List<Books> Books = new List<Books>
        {
            new Books{Id=1, Author = "Лев Толстой", Name="Война и мир", Publisher = "Лексика", PublishingYear=1996},
            new Books{Id=2, Author = "Михаил Булгаков", Name="Мастер и Маргарита", Publisher = "Аст", PublishingYear=2016},
            new Books{Id=3, Author = "Федор Достоевский", Name="Братья Карамазовы", Publisher = "PocketBook", PublishingYear=2017}
        };
    }
}
