//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBAAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project_new
    {
        public int Project_id { get; set; }
        public string Project_Name { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public string Priority { get; set; }
        public Nullable<int> User_id { get; set; }
    }
}
