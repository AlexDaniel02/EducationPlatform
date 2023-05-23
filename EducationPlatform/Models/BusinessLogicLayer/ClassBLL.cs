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
    public class ClassBLL
    {
        private readonly ClassDAL _classDAL;

        public ClassBLL(ClassDAL classRepository)
        {
            _classDAL = classRepository;
        }

        public Class GetClassById(int id)
        {
            return _classDAL.GetByID(id);
        }

        public void AddClass(Class @class)
        {
            if (ValidateClass(@class))
            {
                _classDAL.Insert(@class);
            }
        }

        public void UpdateClass(Class @class)
        {

            if (ValidateClass(@class)) ;
            {
                var existingClass = _classDAL.GetByID(@class.Id);
                if (existingClass == null)
                {
                    MessageBox.Show("Class not found.");
                    return;
                }
                _classDAL.Update(@class);
            }
        }

        public void DeleteClass(Class @class)
        {
            var existingClass = _classDAL.GetByID(@class.Id);
            if (existingClass == null)
            {
                MessageBox.Show("Class not found.");
                return;
            }
            _classDAL.Delete(@class);
        }

        public List<Class> GetAllClasses()
        {
            return _classDAL.GetAll();
        }

        private bool ValidateClass(Class @class)
        {
            if (string.IsNullOrWhiteSpace(@class.Name))
            {
                MessageBox.Show("Name is required.");
                return false;
            }
            if (@class.Specialization == null)
            {
                MessageBox.Show("Specialization is required.");
                return false;
            }
            return true;
        }
    }
}
