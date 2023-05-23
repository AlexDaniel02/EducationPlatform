using EducationPlatform.Models.EntityLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.DataAccessLayer
{
    public class SubjectDAL : BaseDAL<Subject>
    {
        public SubjectDAL(EducationPlatformDbContext dbContext) : base(dbContext)
        {
        }

        private string _connectionString = "Server=localhost;Database=EducationPlatform;Integrated Security=SSPI;TrustServerCertificate=True\r\n";

        public void InsertSubject(Subject subject)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertSubject", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@ID", subject.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", subject.Name));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSubject(Subject subject)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateSubject", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", subject.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", subject.Name));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSubject(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteSubject", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Subject GetSubjectById(int id)
        {
            Subject subject = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSubjectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            subject = new Subject();
                            subject.Id = (int)reader["Id"];
                            subject.Name = (string)reader["Name"];
                        }
                    }
                }
            }

            return subject;
        }

   
    }
}