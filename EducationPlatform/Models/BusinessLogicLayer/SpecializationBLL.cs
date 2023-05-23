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
    public class SpecializationBLL
    {
        private readonly SpecializationDAL _specializationDAL;

        public SpecializationBLL(SpecializationDAL specializationRepository)
        {
            _specializationDAL = specializationRepository;
        }

        public Specialization GetById(int id)
        {
            return _specializationDAL.GetSpecializationById(id);
        }

        public void AddSpecialization(Specialization specialization)
        {
            if (ValidateSpecialization(specialization))
            {
                // _specializationRepository.InsertSpecialization(specialization);
                _specializationDAL.InsertSpecialization(specialization);
            }
        }

        public void UpdateSpecialization(Specialization specialization)
        {
            if (ValidateSpecialization(specialization))
            {
                var existingSpecialization = _specializationDAL.GetByID(specialization.Id);
                if (existingSpecialization == null)
                {
                    MessageBox.Show("Specialization doesn`t exist!");
                    return;
                }
                _specializationDAL.UpdateSpecialization(existingSpecialization);
            }
        }

        public void DeleteSpecialization(Specialization specialization)
        {
            var existingSpecialization = _specializationDAL.GetByID(specialization.Id);
            if (existingSpecialization == null)
            {
                MessageBox.Show("Specialization doesn`t exist!");
                return;
            }
            _specializationDAL.DeleteSpecialization(existingSpecialization.Id);
        }

        public IEnumerable<Specialization> GetAllSpecializations()
        {
            return _specializationDAL.GetAll();
        }

        private bool ValidateSpecialization(Specialization specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization.Name))
            {
                MessageBox.Show("Specialization name is required!");
                return false;
            }
            return true;
        }
    }
}