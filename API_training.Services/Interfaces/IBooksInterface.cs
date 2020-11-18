using API_training.Database.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_training.Services.Interfaces
{
    public interface IBooksInterface
    {
        List<Books> Get();
        List<Books> GetByName(string name);
        List<Books> Delete(long id);
        List<Books> Post(string name, string author, long id, string publisher, int publishingYear);
    }
}
