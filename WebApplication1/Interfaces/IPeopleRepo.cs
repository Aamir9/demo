using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
   public interface IPeopleRepo
    {
        public Person CreatePerson(Person person);
        public List<Person> Read();
        public Person Read(int Id);
        public Person Update(Person person);

        public void Remove(int Id);



    }
}
