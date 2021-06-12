using PizzaLoveApp.DataAccess.Abstract;
using PizzaLoveApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLoveApp.DataAccess.Concrete.EfCore
{
    public class EfCorePizzaDal : EfCoreGenericRepository<Pizza,PizzaLoveAppContext>, IPizzaDal
    {
    }
}
