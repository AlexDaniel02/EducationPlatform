using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;
using EducationPlatform.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EducationPlatform.ViewModels
{
    public class ClassMasterViewModel
    {
        public static Teacher ClassMaster { get; set; }
        public ICommand ShowAbsencesCommand { get; set; }
        public ICommand ShowGradesCommand { get; set; }



        public ClassMasterViewModel()
        {
            ShowAbsencesCommand = new RelayCommand(ShowAbsences);
            ShowGradesCommand = new RelayCommand(ShowGrades);

        }
        
        private void ShowGrades()
        {
            ClassMasterGradesViewModel.ClassMaster = ClassMaster;
            new ClassMasterGradesWindow().Show();
        }

        private void ShowAbsences()
        {
            ClassMasterAbsencesViewModel.ClassMaster = ClassMaster;
            new ClassMasterAbsencesWindow().Show();
        }
    }   
}
