using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public class Teacher : SchoolMember
    {
        public Teacher()
        {

        }

        [DisplayName("Stopien naukowy")]
        public string Degree
        { get; set; }
        [DisplayName("Pokój")]
        public string Room
        { get; set; }
        [DisplayName("Numer telefonu")]
        public string TelephoneNumber
        { get; set; }
        [DisplayName("Przedmioty")]
        public virtual ICollection<Subject> CurrentSubjects
        { get; set; }



        


    }
}