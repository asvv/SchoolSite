using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public class Grade
    {
        public Grade()
        {

        }
        public int GradeId
        { get; set; }
        [DisplayName("Nazwa")]
        public string Name
        { get; set; }
        [DisplayName("Wartość")]
        public int Value
        { get; set; }
        [DisplayName("Opis")]
        public string Description
        { get;set; }
        [DisplayName("Nauczyciel wystawiający")]
        public virtual Teacher CurrentTeacher
        { get; set; }
        [DisplayName("Przedmiot")]
        public virtual Subject CurrentSubject
        { get; set; }


    }
}