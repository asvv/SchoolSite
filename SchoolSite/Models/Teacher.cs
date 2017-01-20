using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public class Teacher : SchoolMember
    {
        public Teacher()
        {

        }

        public string Degree
        { get; set; }
        
        public virtual ICollection<Subject> CurrentSubjects
        { get; set; }



        


    }
}