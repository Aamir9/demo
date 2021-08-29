using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
   public interface IPeopleService
    {
        public Person Add(CreatePersonViewModel person);
        public List<PeopleViewModel> All();
        public List<PeopleViewModel> FindBy(PeopleViewModel search);
        public Person FindBy(int id);
        Person Edit(int id, Person person);
        public bool Remove(int Id);







    }
}
