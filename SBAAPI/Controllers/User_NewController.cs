using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBAAPI.Models;

namespace SBAAPI.Controllers
{
    public class User_NewController : ApiController
    {
        public List<User_New> Get()

        {
            using (SBAEntities db = new SBAEntities())
            {
                return db.User_New.ToList();
            }

        }

        // GET: api/User/5
        public User_New Get(int id)
        {
            User_New usr = new User_New();
            using (SBAEntities db = new SBAEntities())
            {
                List<User_New> userList = db.User_New.ToList();
                var r4 = from i in userList
                         where i.User_id == id
                         select new { i.Employee_id, i.First_Name, i.Last_name };
                foreach (var item in r4)
                {
                    usr.Employee_id = item.Employee_id;
                    usr.First_Name = item.First_Name;
                    usr.Last_name = item.Last_name;
                }
            }
            return usr;
        }

        // POST: api/User
        public void Post(User_New item)
        {
            using (SBAEntities db = new SBAEntities())
            {
                db.User_New.Add(item);
                db.SaveChanges();
            }
        }

        // PUT: api/User/5
        public void Put(User_New item)
        {
            using (SBAEntities db = new SBAEntities())
            {
                User_New obj = db.User_New.Find(item.User_id);
                obj.Employee_id = item.Employee_id;
                obj.First_Name = item.First_Name;
                obj.Last_name = item.Last_name;
                db.SaveChanges();
            }
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            using (SBAEntities db = new SBAEntities())
            {
                User_New obj = db.User_New.Find(id);
                db.User_New.Remove(obj);
                db.SaveChanges();
            }

        }
    }
}
