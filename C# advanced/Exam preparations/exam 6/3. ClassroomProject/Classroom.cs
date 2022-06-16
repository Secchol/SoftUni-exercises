using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public List<Student> Students { get { return students; } set { students = value; } }
        public int Capacity { get; set; }
        public int Count { get; private set; }
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            Students = new List<Student>();


        }
        public string RegisterStudent(Student student)
        {
            if (Students.Count < Capacity)
            {
                Students.Add(student);
                Count++;
                return $"Added student {student.FirstName} {student.LastName}";

            }
            return "No seats in the classroom";


        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student == null)
                return "Student not found";
            Count--;
            Students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";


        }
        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsWithSubject = Students.Where(x => x.Subject == subject).ToList();
            if (studentsWithSubject.Count == 0)
                return "No students enrolled for the subject";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (Student student in studentsWithSubject)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");

            }
            return sb.ToString().TrimEnd();


        }
        public int GetStudentsCount()
        {
            return Count;


        }
        public Student GetStudent(string firstName, string lastName)
        {
            return Students.First(x => x.FirstName == firstName && x.LastName == lastName);


        }
    }
}
