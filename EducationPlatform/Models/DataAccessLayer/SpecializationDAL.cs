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
    public class SpecializationDAL : BaseDAL<Specialization>
    {
        public SpecializationDAL(EducationPlatformDbContext dbContext) : base(dbContext)
        {
        }

        private string _connectionString = "Server=localhost;Database=EducationPlatform;Integrated Security=SSPI;TrustServerCertificate=True\r\n";

        public void InsertSpecialization(Specialization specialization)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertSpecialization", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@ID", specialization.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", specialization.Name));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSpecialization(Specialization specialization)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateSpecialization", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", specialization.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", specialization.Name));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSpecialization(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteSpecialization", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Specialization GetSpecializationById(int id)
        {
            Specialization specialization = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSpecializationById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            specialization = new Specialization();
                            specialization.Id = (int)reader["Id"];
                            specialization.Name = (string)reader["Name"];
                        }
                    }
                }
            }

            return specialization;
        }

    }
}