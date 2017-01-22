using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public abstract class SchoolMember
    {

        public SchoolMember()
        {

            BirthDate = DateTime.Now;       
        }
        [DisplayName("Imię")]
        public string Name
        { get; set; }
        [DisplayName("Nazwisko")]
        public string Surname
        { get; set; }


       public int SchoolMemberId
        { get; set; }
        [DisplayName("Szkoła")]
        public string School
        { get; set; }

        public byte[] Avatar
        { get; set; }
        [DisplayName("Opis")]
        public string Description
        { get; set; }
        [DisplayName("Data urodzenia")]
        public DateTime BirthDate
        {  get; set; }

    }
}