using System;
using System.Collections.Generic;
using System.Linq;

namespace AUA_test.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Length { get; set; }
        public string Days { get; set; }


        public static List<Class> GetClass(int userId)
        {

            List<Class> Class = new List<Class>();
            using (AuaDbContext db = new AuaDbContext())
            {
                var userClases = db.UserClasses.Where(item => item.fk_User == userId).ToList();

                foreach (var item in userClases)
                {
                    
                    var b = db.Classes.Where(a => a.Id == item.fk_Class).FirstOrDefault();
                    if(b!=null)
                    Class.Add(b);
                }
            }
            return Class;
        }
    }
}