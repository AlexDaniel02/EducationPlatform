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
    public class TeacherBLL
    {
        private readonly TeacherDAL _teacherRepository;

        public TeacherBLL(TeacherDAL teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void AddTeacher(Teacher teacher)
        {
            if (ValidateTeacher(teacher))
            {
                _teacherRepository.InsertTeacher(teacher);
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            if (ValidateTeacher(teacher))
            {
                _teacherRepository.Update(teacher);
            }
        }

        public void DeleteTeacher(Teacher teacher)
        {           
            if (teacher == null)
            {
                MessageBox.Show("Invalid teacher ID.");
                return;
            }
            _teacherRepository.Delete(teacher);
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }
        public Teacher GetTeacherById(int id)
        {
            return _teacherRepository.GetByID(id);
        }
        public bool ValidateTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                MessageBox.Show("Teacher object cannot be null.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(teacher.Name))
            {
                MessageBox.Show("Teacher name is required.");
                return false;
            }
            return true;
        }
    }
}
