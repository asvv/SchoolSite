﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public class Student : SchoolMember
    {

        public Student()
        {
            

        }
        [DisplayName("Specializacja")]
        public string Specialization
        { get; set; }
        [DisplayName("Nazwa Studiów")]
        public string StudiesName
        { get; set; }
        [DisplayName("Rok studiów")]
        public int YearOfStudies
        { get; set; }
        [DisplayName("Rok rozpoczęcia studiów")]
        public string StartStudiesDate
        { get; set; }
        [DisplayName("Przedmioty")]
        public virtual ICollection<Subject> CurrentSubjects
        { get; set; }
        [DisplayName("Oceny")]
        public virtual ICollection<Grade> CurrentGrades
        { get; set; }


    }
}