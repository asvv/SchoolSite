using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public class Subject
    {
        public Subject()
        {

        }
        public int SubjectId { get; set; }
        [DisplayName("Nazwa przedmiotu")]
        public string SubjectName { get; set; }

        [DisplayName("Imię i nazwisko")]
        public string CurrentTeacherFullName
        { get; set; }

        [DisplayName("Studenci")]
        public virtual ICollection<Student> CurrentStudents
        { get; set; }
        [DisplayName("Oceny")]
        public virtual ICollection<Grade> CurrentGrades
        { get; set; }
        [DisplayName("Nauczyciele")]
        public virtual ICollection<Teacher> CurrentTeachers
        { get; set; }

    }
}