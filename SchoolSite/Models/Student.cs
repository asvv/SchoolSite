using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public class Student : SchoolMember
    {

        public Student()
        {
            

        }


        public virtual ICollection<Grade> CurrentGrades
        { get; set; }


    }
}