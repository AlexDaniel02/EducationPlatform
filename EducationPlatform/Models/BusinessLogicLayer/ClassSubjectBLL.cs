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
    public class ClassSubjectBLL
    {
        private readonly ClassSubjectDAL _subjectClassDAL;

        public ClassSubjectBLL(ClassSubjectDAL subjectClassRepository)
        {
            _subjectClassDAL = subjectClassRepository;
        }

        public void AddClassSubject(ClassSubject classSubjects)
        {
            if (classSubjects.Subject == null)
            {
                MessageBox.Show("Subject is required.");
                return;
            }

            if (classSubjects.Class == null)
            {
                MessageBox.Show("Classroom is required.");
                return;
            }

            if (classSubjects.Teacher == null)
            {
                MessageBox.Show("Teacher is required.");
                return;
            }
            _subjectClassDAL.Insert(classSubjects);
        }

        public void UpdateClassSubject(ClassSubject subjectClass)
        {
            if (subjectClass.Subject == null)
            {
                MessageBox.Show("Subject is required.");
                return;
            }

            if (subjectClass.Class == null)
            {
                MessageBox.Show("Classroom is required.");
                return;
            }

            if (subjectClass.Teacher == null)
            {
                MessageBox.Show("Teacher is required.");
                return;
            }

            var existingSubjectClass = _subjectClassDAL.GetByID(subjectClass.Id);
            if (existingSubjectClass == null)
            {
                MessageBox.Show("SubjectClass not found.");
                return;
            }
            _subjectClassDAL.Update(subjectClass);
        }

        public void DeleteClassSubject(ClassSubject subjectClass)
        {
            var existingSubjectClass = _subjectClassDAL.GetByID(subjectClass.Id);
            if (existingSubjectClass == null)
            {
                MessageBox.Show("SubjectClass not found.");
                return;
            }

            _subjectClassDAL.Delete(subjectClass);
        }

        public IEnumerable<ClassSubject> GetAllClassSubjects()
        {
            return _subjectClassDAL.GetAll();
        }
        public ClassSubject GetClassSubjectById(int id)
        {
            return _subjectClassDAL.GetByID(id);
        }
    }
}
