using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitFibre.Interviews.SoftwareEngineer.Models.Orders;
using LitFibre.Interviews.SoftwareEngineer.Services.Interfaces;

namespace LitFibre.Interviews.SoftwareEngineer.Services.Implementations
{
    internal class Implement : IMemoryDatabase<Order>
    {
        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Query(Predicate<Order> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
