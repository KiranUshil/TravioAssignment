using System;
using System.Collections.Generic;

namespace TravioSofAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessModels businessModels = new BusinessModels();
            List<Professors> lst = new List<Professors>();
           lst =  businessModels.GetProfessors();
            Console.WriteLine("Student Names With Professor and Subjects Enrolled\n\n");

            foreach (Professors pr in lst)
            {
                Console.WriteLine("Student Name : " + pr.StudentName + "\t" + "Professor Name : " + pr.ProfessorName + "\t" + "Course Name : " + pr.CourseName);

            }

            Console.WriteLine("Professor With No Enrollment\n\n");
            List<Professors> lstProf = new List<Professors>();
            lstProf = businessModels.GetProfessorsWithNoEnrollment();
            foreach (Professors pr in lstProf)
            {
                Console.WriteLine( "Professor Name : " + pr.ProfessorName + "\t" + "Course Name : " + pr.CourseName);

            }

            Console.ReadKey();
        }
    }
}
