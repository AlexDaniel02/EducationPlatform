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
    public class SubjectBLL
    {
        private readonly SubjectDAL _subjectRepository;

        public SubjectBLL(SubjectDAL subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public void AddSubject(Subject subject)
        {
            if (ValidateSubject(subject))
            {
                _subjectRepository.InsertSubject(subject);
            }
        }

        public void UpdateSubject(Subject subject)
        {
            if (ValidateSubject(subject))
            {
                var existingSubject = _subjectRepository.GetSubjectById(subject.Id);
                if (existingSubject == null)
                {
                    MessageBox.Show("Subject doesn`t exist!");
                    return;
                }
                _subjectRepository.UpdateSubject(subject);
            }
        }

        public void DeleteSubject(Subject subject)
        {
            if (subject == null)
            {
                MessageBox.Show("Invalid subject ID.");
                return;
            }
            _subjectRepository.DeleteSubject(subject.Id);
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _subjectRepository.GetAll();
        }

        public Subject GetSubjectById(int id)
        {
            return _subjectRepository.GetSubjectById(id);
        }

        private bool ValidateSubject(Subject subject)
        {
            if (string.IsNullOrEmpty(subject.Name))
            {
                MessageBox.Show("Subject name cannot be empty.");
                return false;
            }
            return true;

        }
    }
}