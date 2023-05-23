using EducationPlatform.Exceptions;
using EducationPlatform.Models.DataAccessLayer;
using EducationPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EducationPlatform.Models.BusinessLogicLayer
{
    public class StudentBLL
    {
        private readonly StudentDAL _studentRepository;
        public StudentBLL(StudentDAL studentRepository)
        {
            _studentRepository = studentRepository;
        }
        
        public Student GetStudentById(int id)
        {
            return _studentRepository.GetByID(id);
        }

        public void AddStudent(Student student)
        {
            if (ValidateStudent(student))
            {
                _studentRepository.Insert(student);
            }
        }

        public void UpdateStudent(Student student)
        {
            if (ValidateStudent(student))
            {
                _studentRepository.Update(student);
            }
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                MessageBox.Show("Invalid student ID.");
                return;
            }

            _studentRepository.Delete(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }
        public bool ValidateStudent(Student student)
        {
            if (student == null)
            {
                MessageBox.Show("Student object cannot be null.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.Name))
            {
                MessageBox.Show("Student name is required.");
                return false;
            }
            return true;
        }

    }
}
