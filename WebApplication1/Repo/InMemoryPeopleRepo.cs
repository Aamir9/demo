using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repo
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> persons = new List<Person>();
        private  int IdCounter = 0;
        public Person CreatePerson(Person person)
        {
            Person p = new Person();
            p.Name = person.Name;
            p.PhoneNumber = person.PhoneNumber;
            p.City = person.City;
            p.Id= person.Id;
            persons.Add(p);
            return p;
        }

        public List<Person> Read()
        {
            return persons;
        }

        public Person Read(int Id)
        {
            return persons.Where(a => a.Id == Id).SingleOrDefault();
        }

        public void Remove(int Id)
        {
            persons.RemoveAll(x => x.Id == Id);
        }

        public Person Update(Person person)
        {
            int  index =  persons.FindIndex(a => a.Id == person.Id);
            if (index != -1)
            {
                persons[index].Name = person.Name;
                persons[index].PhoneNumber = person.PhoneNumber;
                persons[index].City = person.City;
                persons[index].Id = person.Id;

            }

            return person;
        }
    }
}
