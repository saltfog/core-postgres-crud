
using ASPCoreSample.Models;
using System.Collections.Generic;

namespace ASPCoreSample.Repository
{
    public interface IRepository
    {
        void Add(Customer item);
        void Remove(int id);
        void Update(Customer item);
        Customer FindByID(int id);
        IEnumerable<Customer> FindAll();
    }
}
