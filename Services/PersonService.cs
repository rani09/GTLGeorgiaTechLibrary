using Autofac;
using DataAccess;
using GTLCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService
    {
        static IContainer _container;
        static PersonService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            _container = builder.Build();
        }
        public static bool Delete(int PersonId)
        {
            return _container.Resolve<IPersonRepository>().Delete(PersonId);
        }
        public static List<Person> GetAll()
        {
            return _container.Resolve<IPersonRepository>().GetAll();
        }
        public static Person Save(Person person, EntityState state)
        {
            if (state == EntityState.Added)
                person.id = _container.Resolve<IPersonRepository>().Insert(person);
            else
                _container.Resolve<IPersonRepository>().Update(person);
            return person;
        }
    }
}
