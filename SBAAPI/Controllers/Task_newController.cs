using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBAAPI.Models;

namespace SBAAPI.Controllers
{
    public class TaskParent
    {
        public int taskId { get; set; }
        public int parentId { get; set; }
        public string taskName { get; set; }
        public string parentTaskName { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public String priority { get; set; }
        public int UserId { get; set; }
        public Boolean isParent { get; set; }
        public int projectId { get; set; }
    }
    public class Task_newController : ApiController
    {

        // GET: api/Task_new
        public List<TaskParent> Get()
        {
            List<TaskParent> tskParentList = new List<TaskParent>();
            using (SBAEntities db = new SBAEntities())
            {
                List<Task_New> taskList = db.Task_New.ToList();
                List<Parent_Task_New> parentTaskList = db.Parent_Task_New.ToList();
                var r4taskParent = from i in taskList
                                   join
                                   i2 in parentTaskList
                                   on i.Parent_id equals i2.Parent_Id
                                   select new { i.Parent_id, i.Priority, i.Start_Date, i.End_Date, i2.Parent_Task, i.Task_Name, i.User_id, i.Project_id };
                foreach (var itemTaskParent in r4taskParent)
                {
                    TaskParent tskParent = new TaskParent();
                    tskParent.parentId = itemTaskParent.Parent_id;
                    tskParent.parentTaskName = itemTaskParent.Parent_Task;
                    tskParent.priority = itemTaskParent.Priority;
                    tskParent.Start_Date = itemTaskParent.Start_Date.Value;
                    tskParent.End_Date = itemTaskParent.End_Date.Value;
                    tskParent.taskName = itemTaskParent.Task_Name;
                    tskParent.UserId = itemTaskParent.User_id.Value;
                    tskParentList.Add(tskParent);
                }
                return tskParentList;
            }

        }
        // GET: api/Task_new/5
        public TaskParent Get(int id)
        {
            TaskParent tskParent = new TaskParent();
            using (SBAEntities db = new SBAEntities())
            {
                List<Task_New> taskList = db.Task_New.ToList();
                List<Parent_Task_New> parentTaskList = db.Parent_Task_New.ToList();
                var r4taskParent = from i in taskList
                                   join
                                   i2 in parentTaskList
                                   on i.Parent_id equals i2.Parent_Id
                                   where i.Task_id == id
                                   select new { i.Parent_id, i.Priority, i.Start_Date, i.End_Date, i2.Parent_Task, i.Task_Name, i.User_id, i.Project_id };
                foreach (var itemTaskParent in r4taskParent)
                {
                    tskParent.End_Date = itemTaskParent.End_Date.Value;
                    tskParent.Start_Date = itemTaskParent.Start_Date.Value;
                    if (itemTaskParent.Parent_id.Equals(0))
                    {
                        tskParent.isParent = true;
                        tskParent.parentId = 0;
                    }
                    else
                    {
                        tskParent.parentId = itemTaskParent.Parent_id;
                        tskParent.isParent = true;
                    }

                }
                return tskParent;
            }           

            
        }
        // POST: api/Project
        public void Post(TaskParent item)
        {
            Task_New tskNew = new Task_New();
            Parent_Task_New tskParentNew = new Parent_Task_New();
            using (SBAEntities db = new SBAEntities())
            {
                tskNew.Task_id = item.taskId;
                tskNew.Task_Name = item.taskName;
                tskNew.Project_id = item.projectId;
                tskNew.Start_Date = item.Start_Date;
                tskNew.End_Date = item.End_Date;
                tskNew.Priority = item.priority;
                tskNew.User_id = item.UserId;
                db.Task_New.Add(tskNew);
                db.SaveChanges();
            }
        }
        // DELETE: api/User/5
        public void Delete(int id)
        {
            using (SBAEntities db = new SBAEntities())
            {
                List<Task_New> taskList = db.Task_New.ToList();
                Task_New objTask = db.Task_New.Find(id);
                Parent_Task_New objParentTask = db.Parent_Task_New.Find(id);
                objTask.Status = "Completed";
                db.SaveChanges();
                db.Parent_Task_New.Remove(objParentTask);
                db.SaveChanges();                
            }

        }
        // PUT: api/Project/5
        public void Put(TaskParent item)
        {
            using (SBAEntities db = new SBAEntities())
            {
                Task_New tskNew = db.Task_New.Find(item.taskId);
                tskNew.User_id = item.UserId;
                tskNew.End_Date = item.End_Date;
                tskNew.Start_Date = item.Start_Date;
                tskNew.Project_id = item.projectId;
                tskNew.Task_Name = item.taskName;
                tskNew.Parent_id = item.parentId;
                tskNew.Priority = item.priority;
                db.SaveChanges();
                if (item.isParent == true)
                {
                    Parent_Task_New tskParentNew = db.Parent_Task_New.Find(item.taskId);
                    tskParentNew.Parent_Task = item.parentTaskName;
                    db.SaveChanges();
                }               
                                
            }
        }
    }
}
