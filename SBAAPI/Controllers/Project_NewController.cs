using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBAAPI.Models;

namespace SBAAPI.Controllers
{
    public class TaskProject
    {
        public int projectId { get; set; }
        public int taskCount { get; set; }
        public string projectName { get; set; }
        public int statusCompleted { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public String priority { get; set; }
    }
    public class Project_NewController : ApiController
    {
        // GET: api/Project_New
        public List<TaskProject> Get()
        {
            Project_new prj = new Project_new();
            Task_New tsk = new Task_New();
            List<TaskProject> taskProjects = new List<TaskProject>();
            int taskCount;
            int taskCompleted;
            using (SBAEntities db = new SBAEntities())
            {
                List<Project_new> prjList = db.Project_new.ToList();
                List<Task_New> tskList = db.Task_New.ToList();
                var r4Project = from i in prjList
                                join
                                i2 in tskList
                                on i.Project_id equals i2.Project_id
                                select new { i.Project_id, i.Project_Name, i.Start_Date, i.End_Date, i.Priority, i2.Task_id, i2.Status };
                var r3Project = from i in prjList
                                select new { i.End_Date, i.Start_Date, i.Project_id, i.Project_Name, i.Priority };

                foreach (var itemPrj in r3Project)
                {
                    TaskProject objTaskProject = new TaskProject();
                    objTaskProject.Start_Date = itemPrj.Start_Date.Value;
                    objTaskProject.End_Date = itemPrj.End_Date.Value;
                    objTaskProject.priority = itemPrj.Priority;
                    objTaskProject.projectId = itemPrj.Project_id;
                    objTaskProject.projectName = itemPrj.Project_Name;
                    taskCount = 0;
                    taskCompleted = 0;
                    foreach (var item in r4Project)
                    {
                        if (objTaskProject.projectId == item.Project_id)
                        {
                            taskCount = taskCount + 1;
                        }

                    }
                    objTaskProject.taskCount = taskCount;
                    foreach (var item in r4Project)
                    {
                        if (objTaskProject.projectId == item.Project_id || (item.Status == "Completed"))
                        {
                            taskCompleted = taskCompleted + 1;
                        }
                    }
                    objTaskProject.statusCompleted = taskCompleted;
                    taskProjects.Add(objTaskProject);
                }
                return taskProjects;
            }

        }

        // GET: api/Project/5
        public Project_new Get(int id)
        {
            Project_new prj = new Project_new();
            using (SBAEntities db = new SBAEntities())
            {
                List<Project_new> projList = db.Project_new.ToList();
                var r4 = from i in projList
                         where i.Project_id == id
                         select new { i.Project_id, i.User_id, i.Priority, i.Start_Date, i.End_Date, i.Project_Name };
                foreach (var item in r4)
                {
                    prj.Project_id = item.Project_id;
                    prj.User_id = item.User_id;
                    prj.Priority = item.Priority;
                    prj.Start_Date = item.Start_Date;
                    prj.End_Date = item.End_Date;
                    prj.Project_Name = item.Project_Name;
                }
            }
            return prj;
        }

        // POST: api/Project
        public void Post(Project_new item)
        {
            using (SBAEntities db = new SBAEntities())
            {
                db.Project_new.Add(item);
                db.SaveChanges();
            }
        }

        // PUT: api/Project/5
        public void Put(Project_new item)
        {
            using (SBAEntities db = new SBAEntities())
            {
                Project_new obj = db.Project_new.Find(item.Project_id);
                obj.User_id = item.User_id;
                obj.Priority = item.Priority;
                obj.Project_Name = item.Project_Name;
                obj.Start_Date = item.Start_Date;
                obj.End_Date = item.End_Date;
                db.SaveChanges();
            }
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
            using (SBAEntities db = new SBAEntities())
            {
                Project_new obj = db.Project_new.Find(id);
                db.Project_new.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
