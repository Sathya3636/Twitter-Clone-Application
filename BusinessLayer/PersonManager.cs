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
        public string Save(Person person)
        {
            using (var db = new MVCApplicationEntities())
            {
                var upPerson = db.People.Where(a => a.User_Id.ToLower().Equals(person.User_Id.ToLower()) || a.Email.ToLower().Equals(person.Email.ToLower())).FirstOrDefault();
                var rePerson = db.People.Where(a => a.User_Id.ToLower().Equals(person.User_Id.ToLower()) && a.Active == false && a.Email.ToLower().Equals(person.Email.ToLower())).FirstOrDefault();
                if (upPerson == null)
                {
                    db.People.Add(person);
                    db.SaveChanges();
                }
                else if (upPerson != null && rePerson != null)
                {
                    rePerson.Password = person.Password;
                    rePerson.FullName = person.FullName;
                    rePerson.Email = person.Email;
                    rePerson.Active = true;
                    db.SaveChanges();
                }
                else
                {
                    return "UserName or EmailId already registered with us";
                }

                return "success";
            }
        }

        public string Update(Person person)
        {
            using (var db = new MVCApplicationEntities())
            {
                var upPerson = db.People.Where(a => a.User_Id.ToLower().Equals(person.User_Id.ToLower())).FirstOrDefault();
                var updatePerson = db.People.Where(a => !a.User_Id.ToLower().Equals(person.User_Id.ToLower()) && a.Email.ToLower().Equals(person.Email.ToLower())).FirstOrDefault();
                if (upPerson != null && updatePerson == null)
                {
                    upPerson.Password = person.Password ?? upPerson.Password;
                    upPerson.FullName = person.FullName;
                    upPerson.Email = person.Email;
                    upPerson.Active = person.Active;
                    db.SaveChanges();
                }
                else
                {
                    return "EmailId already registered with other user";
                }

                return "success";
            }
        }

        public Person Login(string userName, string password)
        {
            using (var db = new MVCApplicationEntities())
            {
                var person = db.People.Where(a => a.User_Id.ToLower().Equals(userName.ToLower()) && a.Password.Equals(password) && a.Active == true).FirstOrDefault();
                return person;
            }
        }
    }
}
