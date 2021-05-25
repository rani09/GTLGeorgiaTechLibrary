using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTLCore
{
    public interface IPersonRepository
    {
        List<Person> GetAll();
        int Insert(Person person);
        bool Update(Person person);
        bool Delete(int PersonId);
    }
}
