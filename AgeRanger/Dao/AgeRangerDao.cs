using Dapper;
using AgeRanger.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace AgeRanger.Dao
{
    public class AgeRangerDao
    {
        public List<Person> GetAllPerson()
        {
            using (var conn = DBConnection.NewConnection())
            {
                string query = @"select  p.Id Id, p.FirstName, p.LastName, p.Age, a.Description AgeGroup 
                                from Person p, AgeGroup a where p.Age between a.MinAge and a.MaxAge-1";
                var result = conn.Query<Person>(query);

                List<Person> people = result.ToList();
                return people;
            }
        }

        public List<Person> GetPersonByFirstName(String firstName)
        {
            using (var conn = DBConnection.NewConnection())
            {
                string query = @"select  p.Id Id, p.FirstName, p.LastName, p.Age, a.Description AgeGroup 
                                from Person p, AgeGroup a where p.FirstName = @FirstName and p.Age between a.MinAge and a.MaxAge-1";
                var result = conn.Query<Person>(query, new { firstName });

                List<Person> people = result.ToList();
                return people;
            }
        }

        public List<Person> GetPersonByLastName(String lastName)
        {
            using (var conn = DBConnection.NewConnection())
            {
                string query = @"select  p.Id Id, p.FirstName FirstName, p.LastName LastName, p.Age, a.Description AgeGroup 
                                from Person p, AgeGroup a where  p.LastName = @LastName and p.Age between a.MinAge and a.MaxAge-1";
                var result = conn.Query<Person>(query, new { lastName });

                List<Person> people = result.ToList();
                return people;
            }
        }

        public Person GetPersonById(int id)
        {
            using (var conn = DBConnection.NewConnection())
            {
                string query = @"select  p.Id Id, p.FirstName FirstName, p.LastName LastName, p.Age, a.Description AgeGroup 
                                from Person p, AgeGroup a where p.Id = @Id and p.Age between a.MinAge and a.MaxAge-1";
                var person = conn.Query<Person>(query, new { id }).SingleOrDefault(); ;
                return person;
            }
        }

        public void AddPerson(Person person)
        {
            using (var conn = DBConnection.NewConnection())
            {
                string query = @"INSERT INTO Person (FirstName, LastName, Age) VALUES(@FirstName, @LastName, @Age)";
                conn.Execute(query, new { person.FirstName, person.LastName, person.Age });
            } 
        }

        public Person UpdatePerson(int id, Person person)
        {
            using (var conn = DBConnection.NewConnection())
            {
                Person originalPerson = GetPersonById(id);
                if(originalPerson != null)
                {
                    string query = @"UPDATE Person SET FirstName = @FirstName, LastName = @LastName, Age = @Age 
                                    WHERE Id = @Id";
                    conn.Execute(query, new {
                        person.FirstName,
                        person.LastName,
                        person.Age,
                        Id = id
                    });
                }
                return GetPersonById(id);
            }
        }

        public void DeletePerson(int id)
        {
            using (var conn = DBConnection.NewConnection())
            {
                string query = "DELETE FROM Person WHERE Id = @Id";

                conn.Execute(query, new { Id = id });

            }
        }

    }
}
