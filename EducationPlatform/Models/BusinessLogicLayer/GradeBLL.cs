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
    public class GradeBLL
    {
        private readonly GradeDAL _gradeRepository;

        public GradeBLL(GradeDAL gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public Grade GetGradeById(int id)
        {
            return _gradeRepository.GetByID(id);
        }

        public void AddGrade(Grade grade)
        {
            if (ValidateGrade(grade))
            {
                _gradeRepository.Insert(grade);
            }
        }

        public void UpdateGrade(Grade grade)
        {
            if (ValidateGrade(grade))
            {
                var existingGrade = _gradeRepository.GetByID(grade.Id);
                if (existingGrade == null)
                {
                    MessageBox.Show("Grade not found.");
                    return;
                }
                _gradeRepository.Update(grade);
            }
        }

        public void DeleteGrade(Grade grade)
        {
            var existingGrade = _gradeRepository.GetByID(grade.Id);
            if (existingGrade == null)
            {
                MessageBox.Show("Grade not found.");
                return;
            }
            _gradeRepository.Delete(grade);
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return _gradeRepository.GetAll();
        }

        private bool ValidateGrade(Grade grade)
        {
            if (grade.Subject == null)
            {
                MessageBox.Show("Subject shouldn`t be empty");
                return false;
            }
            if (grade.Student == null)
            {
                MessageBox.Show("Student shouldn`t be empty");
                return false;
            }
            if (grade.Value < 1 || grade.Value > 10)
            {
                MessageBox.Show("Value should be between 1 and 10");
                return false;
            }
            return true;
        }
    }
}
