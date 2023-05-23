using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;
using EducationPlatform.Views;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EducationPlatform.ViewModels
{
    public class TeacherViewModel : ViewModelBase
    {
        public static Teacher Teacher { get; set; }
        public ICommand ShowAbsencesCommand { get; set; }
        public ICommand ShowGradesCommand { get; set; }
        


        public TeacherViewModel()
        {
            ShowAbsencesCommand = new RelayCommand(ShowAbsences);
            ShowGradesCommand = new RelayCommand(ShowGrades);

        }
       
        private void ShowGrades()
        {
            TeacherGradesViewModel.Teacher = Teacher;
            new TeacherGradesWindow().Show();
        }   

        private void ShowAbsences()
        {
            TeacherAbsencesViewModel.Teacher = Teacher;
            new TeacherAbsencesWindow().Show();
        }
    }
}
