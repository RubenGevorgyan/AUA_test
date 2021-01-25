using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUA_test.Models
{
    public class UserClasses
    {
        public int Id { get; set; }
        public int fk_Class { get; set; }
        public int fk_User { get; set; }
    }
}