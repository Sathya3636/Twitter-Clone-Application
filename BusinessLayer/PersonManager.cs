using CommonEntities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PersonManager
    {
        private DatabaseContext db = new DatabaseContext();

        public IQueryable<Person> FindAll()
        {
            return this.db.PersonList;
        }

        public void Save(Person person)
        {
            this.db.PersonList.Add(person);
            this.db.SaveChanges();
        }

        public Person Login(string userName, string password)
        {
            var person = this.db.PersonList.Where(a => a.UserName.Equals(userName) && a.Password.Equals(password)).FirstOrDefault();
            return person;
        }
        //public void Dispose()
        //{
        //    this.db.Dispose();
        //}
    }
}
