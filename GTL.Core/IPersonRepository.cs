using System.Collections.Generic;

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
