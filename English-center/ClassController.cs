using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class ClassController
    {
        private ClassModel ClassModel = new ClassModel();
        public List<Class_Users> GetClasses()
        {
            return ClassModel.GetClasses();
        }
        public bool FindCourses1(string coursename)
        {
            return ClassModel.Find(coursename);
        }
        public string getId()
        {
            return ClassModel.AutoID();
        }
        public List<Class_Users> FindCourses(string coursename)
        {
            return ClassModel.FindClasses(coursename);
        }


        public void AddClass(string Classid, string coursename, string TeacherName, string status,string quantity)
        {
            Class_Users users = new Class_Users();
            users.id = Classid;
            users.NameCourse = coursename;
            users.status = status;
            users.TeacherName = TeacherName;
            users.Quantity = quantity;
            ClassModel.AddClass(users);
        }
        public void UpdateClass(string Classid, string coursename, string TeacherName, string status,string quantity)
        {
            Class_Users users = new Class_Users();
            users.id = Classid;
            users.NameCourse = coursename;
            users.status = status;
            users.TeacherName = TeacherName;
            users.Quantity = quantity;
            ClassModel.UpdateClass(users);
        }
        public void DeleteClass(string Id)
        {
            ClassModel.DeleteClass(Id);
        }

    }
}
