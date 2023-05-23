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
    public class AverageBLL
    {
        private readonly AverageDAL _averageRepository;

        public AverageBLL(AverageDAL averageRepository)
        {
            _averageRepository = averageRepository;
        }

        public void AddAverage(Average average)
        {
            if (ValidateAverage(average))
            {
                _averageRepository.Insert(average);
            }
        }

        public void UpdateAverage(Average average)
        {
            if (ValidateAverage(average))
            {
                var existingAverage = _averageRepository.GetByID(average.Id);
                if (existingAverage == null)
                {
                    MessageBox.Show("Average not found.");
                    return;
                }
                _averageRepository.Update(average);
            }
        }

        public void DeleteAverage(Average average)
        {
            var existingAverage = _averageRepository.GetByID(average.Id);
            if (existingAverage == null)
            {
                MessageBox.Show("Average not found.");
                return;
            }

            _averageRepository.Delete(average);
        }

        public IEnumerable<Average> GetAllAverages()
        {
            return _averageRepository.GetAll();
        }

        private bool ValidateAverage(Average average)
        {
            if (average.Student == null)
            {
                MessageBox.Show("Student is required.");
                return false;
            }

            if (average.Subject == null)
            {
                MessageBox.Show("Subject is required.");
                return false;
            }
            return true;
        }
    }
}
