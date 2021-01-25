using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUA_test.Models
{
    public class LoginDetails
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public int UserPosition { get; set; }
    }
}