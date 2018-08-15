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
       // private MVCApplicationEntities db = new MVCApplicationEntities();

        //public IQueryable<Person> FindAll()
        //{
        //    return this.db.People;
        //}

        public void Save(Person person)
        {
            using (var db = new MVCApplicationEntities())
            {
                db.People.Add(person);
                db.SaveChanges();
            }  
        }

        public Person Login(string userName, string password)
        {
            using (var db = new MVCApplicationEntities())
            {
                var person = db.People.Where(a => a.User_Id.Equals(userName) && a.Password.Equals(password)).FirstOrDefault();
                return person;
            }
        }
        //public void Dispose()
        //{
        //    this.db.Dispose();
        //}
    }
}
