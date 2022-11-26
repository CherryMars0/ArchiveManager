using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using static StudentManager.Poco_Model;


namespace StudentManager
{
    public class Poco_Model
    {
        public static class ModelManager
        {
            //loader students
            public static List<Student> LoadStudent(DataSet data)
            {
                List<Student> students = new List<Student>();
                for(int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    long Id = Convert.ToInt64(data.Tables[0].Rows[i]["ID"]);
                    string Name = Convert.ToString(data.Tables[0].Rows[i]["name"]);
                    string EnrollmentDates = Convert.ToString(data.Tables[0].Rows[i]["enrollmentDates"]);
                    string Sex = Convert.ToString(data.Tables[0].Rows[i]["sex"]);
                    string Address = Convert.ToString(data.Tables[0].Rows[i]["address"]);
                    long IdCard = Convert.ToInt64(data.Tables[0].Rows[i]["IdCart"]);
                    long ClassId = Convert.ToInt64(data.Tables[0].Rows[i]["classID"]);
                    long Tel = Convert.ToInt64(data.Tables[0].Rows[i]["tel"]);
                    students.Add(new Student(Id, Name, EnrollmentDates, Sex,Address,IdCard,ClassId,Tel));
                }
                return students;
            }

            //loader admin
            public static List<Admin> LoadAdmin(DataSet data)
            {
                List<Admin> admins = new List<Admin>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    int ID = Convert.ToInt32(data.Tables[0].Rows[i]["ID"]);
                    string Name = Convert.ToString(data.Tables[0].Rows[i]["Name"]);
                    string Password = Convert.ToString(data.Tables[0].Rows[i]["Password"]);
                    int Permissions = Convert.ToInt32(data.Tables[0].Rows[i]["Permissions"]);
                    admins.Add(new Admin(ID,Name, Password, Permissions));
                }
                return admins;
            }


            //loader class
            public static List<Class> LoadClass(DataSet data)
            {
                List<Class> Classes = new List<Class>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    long ID = Convert.ToInt64(data.Tables[0].Rows[i]["ID"]);
                    long MajorID = Convert.ToInt64(data.Tables[0].Rows[i]["MajorID"]);
                    string ClassName = Convert.ToString(data.Tables[0].Rows[i]["ClassName"]);
                    Classes.Add(new Class(ID, MajorID, ClassName));
                }
                return Classes;
            }


            //loader major
            public static List<Major> LoadMajor(DataSet data)
            {
                List<Major> Majors = new List<Major>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    long ID = Convert.ToInt64(data.Tables[0].Rows[i]["ID"]);
                    string MajorName = Convert.ToString(data.Tables[0].Rows[i]["MajorName"]);
                    long DepartmentID = Convert.ToInt64(data.Tables[0].Rows[i]["DepartmentID"]);
                    Majors.Add(new Major(ID, MajorName, DepartmentID));
                }
                return Majors;
            }

            //loader department
            public static List<Department> LoadDepartment(DataSet data)
            {
                List<Department> Departments = new List<Department>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    long ID = Convert.ToInt64(data.Tables[0].Rows[i]["ID"]);
                    string DepartmentName = Convert.ToString(data.Tables[0].Rows[i]["DepartmentName"]);
                    long AcademyID = Convert.ToInt64(data.Tables[0].Rows[i]["AcademyID"]);
                    Departments.Add(new Department(ID, DepartmentName, AcademyID));
                }
                return Departments;
            }

            //loader academy
            public static List<Academy> LoadAcademy(DataSet data)
            {
                List<Academy> Academys = new List<Academy>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    long ID = Convert.ToInt64(data.Tables[0].Rows[i]["ID"]);
                    string AcademyName = Convert.ToString(data.Tables[0].Rows[i]["AcademyName"]);
                    Academys.Add(new Academy(ID, AcademyName));
                }
                return Academys;
            }

            //loader course
            public static List<Course> LoadCourse(DataSet data)
            {
                List<Course> Courses = new List<Course>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    long ID = Convert.ToInt64(data.Tables[0].Rows[i]["ID"]);
                    string CourseName = Convert.ToString(data.Tables[0].Rows[i]["CourseName"]);
                    double CourseCredits = Convert.ToDouble(data.Tables[0].Rows[i]["CourseCredits"]);
                    int CourseHours = Convert.ToInt32(data.Tables[0].Rows[i]["CourseHours"]);
                    string Teacher = Convert.ToString(data.Tables[0].Rows[i]["Teacher"]);
                    Courses.Add(new Course(ID, CourseName, CourseCredits, CourseHours, Teacher));
                }
                return Courses;
            }

            //loader grades
            public static List<Grades> LoadGrade(DataSet data)
            {
                List<Grades> Gradeses = new List<Grades>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    long CourseID = Convert.ToInt64(data.Tables[0].Rows[i]["CourseID"]);
                    long StudentID = Convert.ToInt64(data.Tables[0].Rows[i]["StudentID"]);
                    double Score = Convert.ToDouble(data.Tables[0].Rows[i]["Score"]);
                    Gradeses.Add(new Grades(CourseID, StudentID, Score));
                }
                return Gradeses;
            }

            //loader event
            public static List<Event> LoadEvent(DataSet data)
            {
                List<Event> Events = new List<Event>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    long ID = Convert.ToInt64(data.Tables[0].Rows[i]["ID"]);
                    long StudentID = Convert.ToInt64(data.Tables[0].Rows[i]["StudentID"]);
                    long AcademyID = Convert.ToInt64(data.Tables[0].Rows[i]["AcademyID"]);
                    long DepatmentID = Convert.ToInt64(data.Tables[0].Rows[i]["DepartmentID"]);
                    long MajorID = Convert.ToInt64(data.Tables[0].Rows[i]["MajorID"]);
                    string EventDetail = Convert.ToString(data.Tables[0].Rows[i]["EventDetail"]);
                    Events.Add(new Event(ID, StudentID, AcademyID, DepatmentID, MajorID, EventDetail));
                }
                return Events;
            }

            //loader teacher
            public static List<Teacher> LoadTeacher(DataSet data)
            {
                List<Teacher> Teachers = new List<Teacher>();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    long TeacherID = Convert.ToInt64(data.Tables[0].Rows[i]["TeacherID"]);
                    string TeacherName = Convert.ToString(data.Tables[0].Rows[i]["ReacherName"]);
                    long TeacherTel = Convert.ToInt64(data.Tables[0].Rows[i]["TeacherTel"]);
                    Teachers.Add(new Teacher(TeacherID, TeacherTel, TeacherName));
                }
                return Teachers;
            }
        }



        // Plain Ordinary C# Object
        public class Student
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string EnrollmentDates { get; set; }
            public string Sex { get; set; }
            public string Address { get; set; }
            public long IdCard { get; set; }
            public long ClassId { get; set; }
            public long Tel { get; set; }

            //空参构造器
            public Student()
            {

            }

            // 普通赋值
            public Student(long Id, string Name, string EnrollmentDates, string Sex, string Address, long IdCard, long ClassId, long Tel)
            {
                this.Id = Id;
                this.Name = Name;
                this.EnrollmentDates = EnrollmentDates;
                this.Sex = Sex;
                this.Address = Address;
                this.IdCard = IdCard;
                this.ClassId = ClassId;
                this.Tel = Tel;
            }

            //Mapper
            public Student(DataSet student)
            {
                if (student.Tables[0].Rows.Count != 0)
                {
                    this.Id = Convert.ToInt64(student.Tables[0].Rows[0]["ID"]);
                    this.Name = Convert.ToString(student.Tables[0].Rows[0]["name"]);
                    this.EnrollmentDates = Convert.ToString(student.Tables[0].Rows[0]["enrollmentDates"]);
                    this.IdCard = Convert.ToInt64(student.Tables[0].Rows[0]["IdCart"]);
                    this.ClassId = Convert.ToInt64(student.Tables[0].Rows[0]["classID"]);
                    this.Tel = Convert.ToInt64(student.Tables[0].Rows[0]["tel"]);
                    this.Sex = Convert.ToString(student.Tables[0].Rows[0]["sex"]);
                    this.Address = Convert.ToString(student.Tables[0].Rows[0]["address"]);
                }
                else
                {
                    this.Id = -1;
                    this.Name = null;
                    this.EnrollmentDates = null;
                    this.Sex = null;
                    this.Address = null;
                    this.IdCard = -1;
                    this.ClassId = -1;
                    this.Tel = -1;
                }
            }

            public override string ToString()
            {
                return "student: " + this.Name + "\nid: " + this.Id + "\nsex: " + this.Sex + "\naddress: " + this.Address +
                       "\nidcard: " + this.IdCard + "\nclassid: " + this.ClassId + "\ntel: " + this.Tel + "\nenrollmentdates: " + this.EnrollmentDates;
            }
        }

        public class Class
        {
            public long Id { get; set; }
            public long MajorId { get; set; }
            public string ClassName { get; set; }

            //空参构造器
            public Class()
            {

            }

            public Class(long Id, long MajorId, string ClassName)
            {
                this.Id = Id;
                this.MajorId = MajorId;
                this.ClassName = ClassName;
            }
        }
        public class Major
        {
            public long Id { get; set; }
            public string MajorName { get; set; }
            public long DepartmentId { get; set; }

            //空参构造器
            public Major()
            {

            }

            public Major(long Id, string MajorName, long DepartmentId)
            {
                this.Id = Id;
                this.MajorName = MajorName;
                this.DepartmentId = DepartmentId;
            }
        }
        public class Department
        {
            public long Id { get; set; }
            public string DepartmentName { get; set; }
            public long AcademyId { get; set; }

            //空参构造器
            public Department()
            {

            }

            public Department(long Id, string DepartmentName, long AcademyId)
            {
                this.Id = Id;
                this.DepartmentName = DepartmentName;
                this.AcademyId = AcademyId;
            }
        }
        public class Academy
        {
            public long Id { get; set; }
            public string AcademyName { get; set; }

            //空参构造器
            public Academy()
            {

            }

            public Academy(long Id, string AcademyName)
            {
                this.Id = Id;
                this.AcademyName = AcademyName;
            }
        }
        public class Course
        {
            public long Id { get; set; }
            public string CourseName { get; set; }
            public double CourseCredits { get; set; }
            public int CourseHours { get; set; }
            public string Teacher { get; set; }

            //空参构造器
            public Course()
            {

            }

            public Course(long Id, string CourseName, double CourseCredits, int CourseHours, string Teacher)
            {
                this.Id = Id;
                this.CourseName = CourseName;
                this.CourseCredits = CourseCredits;
                this.CourseHours = CourseHours;
                this.Teacher = Teacher;
            }
        }
        public class Grades
        {
            public long CourseId { get; set; }
            public long StudentId { get; set; }
            public double Score { get; set; }

            //空参构造器
            public Grades()
            {

            }

            public Grades(long CourseId, long StudentId, double Score)
            {
                this.CourseId = CourseId;
                this.StudentId = StudentId;
                this.Score = Score;
            }
        }
        public class Event
        {
            public long Id { get; set; }
            public long StudentId { get; set; }
            public long AcademyId { get; set; }
            public long DepartmentId { get; set; }
            public long MajorId { get; set; }
            public string EventDetail { get; set; }

            //空参构造器
            public Event()
            {

            }

            public Event(long Id, long StudentId, long AcademyId, long DepartmentId, long MajorId, string EventDetail)
            {
                this.Id = Id;
                this.StudentId = StudentId;
                this.AcademyId = AcademyId;
                this.DepartmentId = DepartmentId;
                this.MajorId = MajorId;
                this.EventDetail = EventDetail;
            }
        }
        public class Teacher
        {
            public long TeacherId { get; set; }
            public string TeacherName { get; set; }
            public long TeacherTel { get; set; }

            //空参构造器
            public Teacher()
            {

            }

            public Teacher(long TeacherId, long TeacherTel, string TeacherName)
            {
                this.TeacherId = TeacherId;
                this.TeacherTel = TeacherTel;
                this.TeacherName = TeacherName;
            }
        }

        public class Admin
        {
            public int ID { get; set; }
            public string AdminName { get; set; }
            public string AdminPassword { get; set; }
            public int AdminPermissions { get; set; }

            //空参构造器
            public Admin()
            {
                
            }

            // Mapper
            public Admin(DataSet token)
            {
                if(token.Tables[0].Rows.Count != 0)
                {
                    this.ID = (int)token.Tables[0].Rows[0]["ID"];
                    this.AdminName = (string)token.Tables[0].Rows[0]["name"];
                    this.AdminPassword = (string)token.Tables[0].Rows[0]["password"];
                    this.AdminPermissions = (int)token.Tables[0].Rows[0]["permissions"];
                }
                else
                {
                    this.ID = -1;
                    this.AdminName = null;
                    this.AdminPassword = null;
                    this.AdminPermissions = -1;
                }
            }

            public override string ToString()
            {
                return "admin: " + "\nid: "+ this.ID + "\nname: " + this.AdminName + "\npassword: " + this.AdminPassword + "\npermissions: " + this.AdminPermissions;
            }

            // 普通赋值
            public Admin(int ID,string AdminName, string AdminPassword, int AdminPermissions)
            {
                this.ID=ID;
                this.AdminPermissions = AdminPermissions;
                this.AdminName = AdminName;
                this.AdminPassword = AdminPassword;
            }

            public bool Empty()
            {
                if(this.AdminName == null && this.AdminPassword == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
