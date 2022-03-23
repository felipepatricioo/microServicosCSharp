using RestWithASPNETUdemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(string id)
        {
           
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();

            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }

            return people;
        }

        public Person FindById(string id) => new Person
        {
            Id = IncrementAndGet(),
            FistName = "Felipe",
            LastName = "Patricio",
            Address = "Curitiba",
            Gender = "Male"
        };

        private string IncrementAndGet()
        {
            return Interlocked.Increment(ref count).ToString();
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id =  (i + 1).ToString(),
                FistName = "Felipe",
                LastName = "Patricio",
                Address = "Curitiba",
                Gender = "Male"
            };
        }

    }
}
