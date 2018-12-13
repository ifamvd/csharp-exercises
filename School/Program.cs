using System;
using System.Collections.Generic;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student("Ismail");
            a.AddGrade(5, 4);
            a.AddGrade(3, 3);
            a.AddGrade(3, 4);
            Console.WriteLine(a.ToString());
            Student b = new Student("Bea");
            b.AddGrade(5, 4);
            b.AddGrade(3, 3);
            b.AddGrade(3, 4);
            Console.WriteLine(b.ToString());
            Student c = new Student("Jocelyn");
            c.AddGrade(5, 4);
            c.AddGrade(3, 3);
            c.AddGrade(3, 4);
            Console.WriteLine(c.ToString());
            Student d = new Student("Alex");
            d.AddGrade(5, 4);
            d.AddGrade(3, 3);
            d.AddGrade(3, 4);
            Console.WriteLine(d.ToString());

            Course math = new Course("Calculus III");

            math.AddStudents(a);
            math.AddStudents(b);
            math.AddStudents(c);
            math.AddStudents(d);

            Console.WriteLine();
            Console.WriteLine(math.ToString());

            Console.ReadLine();
        }
    }

    public class Student
    {
        private static int nextStudentId = 1;
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int NumberOfCredits { get; set; }
        public double Gpa { get; set; }

        public Student(string name, int studentId,
                int numberOfCredits, double gpa)
        {
            Name = name;
            StudentId = studentId;
            NumberOfCredits = numberOfCredits;
            Gpa = gpa;
        }

        public Student(string name, int studentId)
            : this(name, studentId, 0, 0) { }

        public Student(string name)
            : this(name, nextStudentId)
        {
            nextStudentId++;
        }

        public void AddGrade(int courseCredits, double grade)
        {
            // Update the appropriate properties: NumberOfCredits, Gpa
            int totalCredits = courseCredits + NumberOfCredits;
            Gpa = (Gpa * NumberOfCredits + courseCredits * grade) / totalCredits;
            NumberOfCredits += courseCredits;
        }

        public string GetGradeLevel()
        {
            // Determine the grade level of the student based on NumberOfCredits
            string level;
            double year = NumberOfCredits / 30;
            if (year < 1) level = "Freshman";
            else if (year >= 1 && year < 2) level = "Sophomore";
            else if (year >= 2 && year < 3) level = "Junior";
            else if (year >= 3) level = "Senior";
            else level = "N/A";
            return level;
        }

        public override String ToString()
        {
            return Name + " (Credits: " + NumberOfCredits + ", GPA: " + Gpa + ", Grade Level: " + GetGradeLevel() + ")";
        }

        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }
            if (o == null)
            {
                return false;
            }
            if (o.GetType() != GetType())
            {
                return false;
            }
            Student studentObj = o as Student;
            return this.GetGradeLevel() == studentObj.GetGradeLevel();
        }

        public override int GetHashCode()
        {
            return StudentId;
        }
    }
    public class Course
    {
        private static int nextCourseId = 1;

        public string Name { get; set; }
        public int CourseId { get; set; }
        public string Instructor { get; set; }
        public List<Student> Students { get; } = new List<Student>();
        public void AddStudents(Student stu)
        {
            Students.Add(stu);
        }
        public override string ToString()
        {
            string info = string.Format("Course ID: {0} - {1} | Instructor: {2}", CourseId, Name, Instructor);
            info += "\n";
            info += "Student list:\n";
            foreach(Student student in Students)
            {
                int counting = 1;
                info += string.Format("{0}. {1}", counting, student.Name) + "\n";
                counting++;
            }
            return info;
        }

        public Course(string name)
        {
            Name = name;
            CourseId = nextCourseId++;
            Instructor = "TBD";
        }
    }

}
