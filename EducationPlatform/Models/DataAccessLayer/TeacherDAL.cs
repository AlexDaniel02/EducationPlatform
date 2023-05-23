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
    public class TeacherDAL : BaseDAL<Teacher>
    {
        private string _connectionString = "Server=localhost;Database=EducationPlatform;Integrated Security=SSPI;TrustServerCertificate=True\r\n";
        public TeacherDAL(EducationPlatformDbContext dbContext) : base(dbContext)
        {
            
        }
        public void DeleteTeacher(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteTeacher", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void InsertTeacher(Teacher teacher)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddTeacher", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", teacher.Name));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
