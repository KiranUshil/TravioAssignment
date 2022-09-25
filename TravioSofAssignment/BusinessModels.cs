using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TravioSofAssignment
{
    class BusinessModels
    {

        public List<Professors> GetProfessors()
        {
            List<Professors> professors = new List<Professors>();
            try
            {

                SqlCommand sqlCommand = new SqlCommand();
                string sQeury = string.Empty;
                short ExecutionResult = 0;
                string sResult = string.Empty;

                StringBuilder sb = new StringBuilder();
                sb.Append(" select  s.StudentName, p.ProfessorName,c.CourseName from Students s ");
                sb.Append(" join StudentEnrollment e on s.StudentId = e.StudentId ");
                sb.Append(" join Professors p on e.CourseId = p.CourseId ");
                sb.Append(" join Courses c on p.CourseId = c.CourseId ");
                sb.Append(" order by StudentName ");
               sQeury  = sb.ToString();
                sqlCommand.CommandText = sQeury;

DataTable dtProfessor = new DataTable();
                dtProfessor = new DBConnection.DBConnect().SqlQueryExecutorWithCommand(sqlCommand, ref ExecutionResult, ref sResult);

                if(dtProfessor!= null && dtProfessor.Rows.Count > 0)
                {
                    foreach(DataRow dr in dtProfessor.Rows)
                    {
                        Professors professor = new Professors();
                        professor.ProfessorName = dr["ProfessorName"].ToString();
                        professor.StudentName = dr["StudentName"].ToString();
                        professor.CourseName = dr["CourseName"].ToString();
                        professors.Add(professor);
                    }
                }



            }
            catch ( Exception ex)
            {

            }
            return professors;

        }


        public List<Professors> GetProfessorsWithNoEnrollment()
        {
            List<Professors> professors = new List<Professors>();
            try
            {

                SqlCommand sqlCommand = new SqlCommand();
                string sQeury = string.Empty;
                short ExecutionResult = 0;
                string sResult = string.Empty;

                StringBuilder sb = new StringBuilder();
                sb.Append(" select ProfessorName, c.CourseName from Professors p join Courses c on p.CourseId = c.CourseId ");
                sb.Append(" where p.CourseId not in(select CourseId from StudentEnrollment) ");
                
                sQeury = sb.ToString();
                sqlCommand.CommandText = sQeury;

                DataTable dtProfessor = new DataTable();
                dtProfessor = new DBConnection.DBConnect().SqlQueryExecutorWithCommand(sqlCommand, ref ExecutionResult, ref sResult);

                if (dtProfessor != null && dtProfessor.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtProfessor.Rows)
                    {
                        Professors professor = new Professors();
                        professor.ProfessorName = dr["ProfessorName"].ToString();
                        professor.CourseName = dr["CourseName"].ToString();
                        professors.Add(professor);
                    }
                }



            }
            catch (Exception ex)
            {

            }
            return professors;

        }


    }
}
