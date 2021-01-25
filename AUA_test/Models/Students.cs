using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUA_test.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public static List<Students> GetStudents(int classId)
        {
            List<Students> students = new List<Students>();
            using (AuaDbContext db = new AuaDbContext())
            {
                var userClases = db.UserClasses.Where(item => item.fk_Class == classId).ToList();

                foreach (var item in userClases)
                {
                    var b = db.Students.Where(a => a.Id == item.fk_User ).FirstOrDefault();
                    if(b!= null)
                    students.Add(b);
                }
            }
            return students;
        }
    }
}