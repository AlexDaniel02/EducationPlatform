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
    public class AbsenceBLL
    {
        private readonly AbsenceDAL _absenceRepository;

        public AbsenceBLL(AbsenceDAL absenceRepository)
        {
            _absenceRepository = absenceRepository;
        }

        public Absence GetAbsenceById(int id)
        {
            return _absenceRepository.GetByID(id);
        }

        public void AddAbsence(Absence absence)
        {
            if (ValidateAbsence(absence))
            {
                _absenceRepository.Insert(absence);
            }
        }

        public void UpdateAbsence(Absence absence)
        {
            if (ValidateAbsence(absence))
            {
                var existingAbsence = _absenceRepository.GetByID(absence.Id);
                if (existingAbsence == null)
                {
                    MessageBox.Show("Absence not found.");
                    return;
                }
                _absenceRepository.Update(absence);
            }
        }

        public void DeleteAbsence(Absence absence)
        {
            var existingAbsence = _absenceRepository.GetByID(absence.Id);
            if (existingAbsence == null)
            {
                MessageBox.Show("Absence not found.");
                return;
            }
            _absenceRepository.Delete(absence);
        }

        public IEnumerable<Absence> GetAllAbsences()
        {
            return _absenceRepository.GetAll();
        }

        private bool ValidateAbsence(Absence absence)
        {
            if (absence.Student == null)
            {
                MessageBox.Show("Absence must have a student.");
                return false;
            }
            if (absence.Subject == null)
            {
                MessageBox.Show("Absence must have a subject.");
                return false;
            }
            return true;
        }
    }
}
