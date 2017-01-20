using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public class SchoolMember
    {

        public SchoolMember()
        {
                
        }
        public string Name
        { get; set; }
        public string Surname
        { get; set; }


       public int Id
        { get; set; }

       public string School
        { get; set; }

        public byte[] Avatar
        { get; set; }

        public string Description
        { get; set; }
        public DateTime BirthDate
        {  get; set; }

    }
}