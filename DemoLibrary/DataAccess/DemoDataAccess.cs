using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private readonly List<PersonModel> people = new();
        public DemoDataAccess()
        {
            people.Add(new PersonModel { FirstName = "Beka", LastName = "Pux", Id = 1 });
            people.Add(new PersonModel { FirstName = "Jemal", LastName = "James", Id = 2 });
        }

        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel GetPersonByID(int ID)
        {
            return people.FirstOrDefault(p => p.Id == ID);
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel p = new() { FirstName = firstName, LastName = lastName };
            p.Id = people.Max(x => x.Id) + 1;
            people.Add(p);
            return p;
        }
    }
}
