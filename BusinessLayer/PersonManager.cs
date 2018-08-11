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

        //public void Dispose()
        //{
        //    this.db.Dispose();
        //}
    }
}
