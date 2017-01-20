using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public class Grade
    {
        public Grade()
        {

        }
        public int Id
        { get; set; }
        public string Name
        { get; set; }

        public int Value
        { get; set; }
        public string Description
        { get;set; }
        public virtual Subject CurrentSubject
        { get; set; }


    }
}