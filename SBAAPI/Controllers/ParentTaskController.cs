using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBAAPI.Models;

namespace SBAAPI.Controllers
{
    public class ParentTaskController : ApiController
    {
        public List<Parent_Task_New> Get()

        {
            using (SBAEntities db = new SBAEntities())
            {
                return db.Parent_Task_New.ToList();
            }

        }

        // GET: api/ParentTask/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post(Parent_Task_New item)
        {
            using (SBAEntities db = new SBAEntities())
            {
                db.Parent_Task_New.Add(item);
                db.SaveChanges();
            }
        }

        // PUT: api/ParentTask/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ParentTask/5
        public void Delete(int id)
        {
        }
    }
}
