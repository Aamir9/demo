using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Repo;

namespace WebApplication1.Services
{
    public class PeopleService : IPeopleService
    {
        InMemoryPeopleRepo InMemoryPeopleServices = new InMemoryPeopleRepo();
        public Person Add(CreatePersonViewModel person)
        {
            var p = new Person();

            p.Name = person.Name;
            p.PhoneNumber = person.PhoneNumber;
            p.City = person.City;
            p.Id = person.Id;

         return  InMemoryPeopleServices.CreatePerson(p);
        }

        public List<PeopleViewModel>  All()
        {
            List<PeopleViewModel> model = new List<PeopleViewModel>();
            var test = new PeopleViewModel();
            test.City = "city";
            test.Name = "name";
            test.PhoneNumber = "Phone";
            test.Id = 1;

            model.Add(test);
            foreach (var item in InMemoryPeopleServices.Read())
            {
                PeopleViewModel data = new PeopleViewModel();

                data.Id = item.Id;
                data.Name = item.Name;
                data.PhoneNumber = item.PhoneNumber;
                data.City = item.City;

                model.Add(data);
            }
            
            return model;
        }

        public Person Edit(int id, Person person)
        {
          return  InMemoryPeopleServices.Update(person);
        }

        public List<PeopleViewModel> FindBy(PeopleViewModel search)
        {
            List<PeopleViewModel> model = All();
            if(search != null)
            {
                if (search.Id  > 0)
                {
                    model = model.Where(a => a.Id == search.Id).ToList();
                }
                if (search.Name != "")
                {
                    model = model.Where(a => a.Name.ToLower() == search.Name.ToLower()).ToList();
                }

                if (search.PhoneNumber != "")
                {
                    model = model.Where(a => a.PhoneNumber.ToLower() == search.PhoneNumber.ToLower()).ToList();
                }

                if (search.City != "")
                {
                    model = model.Where(a => a.City.ToLower() == search.City.ToLower()).ToList();
                }

            }
           
            return model;

        }

        public Person FindBy(int id)
        {
            return InMemoryPeopleServices.Read(id);
        }

        public bool Remove(int id)
        {
            InMemoryPeopleServices.Read();
            return true;
        }

    

       
    }
}
