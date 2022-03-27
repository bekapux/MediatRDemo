using DemoLibrary.Models;
using System.Collections.Generic;

namespace DemoLibrary.DataAccess
{
    public interface IDataAccess
    {
        List<PersonModel> GetPeople();
        PersonModel GetPersonByID(int ID);
        PersonModel InsertPerson(string firstName, string lastName);
    }
}