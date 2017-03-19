using AgeRanger.Dao;
using AgeRanger.Models;
using System;
using System.Collections.Generic;

namespace AgeRanger.Services
{
    public class AgeRangerService : AgeRangerServiceInterface
    {
        private AgeRangerDao _ageRangerDao = new AgeRangerDao();

        public void AddPerson(Person person)
        {
            _ageRangerDao.AddPerson(person);
        }

        public void DeletePerson(int id)
        {
            _ageRangerDao.DeletePerson(id);
        }

        public List<Person> GetAllPeople()
        {
            return _ageRangerDao.GetAllPerson();
        }

        public Person GetPersonById(int id)
        {
            return _ageRangerDao.GetPersonById(id);
        }

        public List<Person> SearchPersonByFirstName(string firstName)
        {
            return _ageRangerDao.GetPersonByFirstName(firstName);
        }

        public List<Person> SearchPersonByLastName(string lastName)
        {
            return _ageRangerDao.GetPersonByLastName(lastName);
        }

        public Person UpdatePerson(int id, Person person)
        {
           return _ageRangerDao.UpdatePerson(id, person);
        }
    }
}
