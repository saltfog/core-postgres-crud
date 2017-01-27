
using ASPCoreSample.Models;
using System.Collections.Generic;

namespace ASPCoreSample.Repository
{
    public interface IRepository
    {
        void Add(Falls item);
        void Remove(int id);
        void Update(Falls item);
        Falls FindByID(int id);
        IEnumerable<Falls> FindAll();
        Falls CheckForDuplicates(string name);
        IEnumerable<Falls> Public();
        IEnumerable<Falls> Private();
    }
}
