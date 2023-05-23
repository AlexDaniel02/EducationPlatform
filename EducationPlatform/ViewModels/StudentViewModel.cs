using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;
using EducationPlatform.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EducationPlatform.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public ICommand ShowAbsencesCommand { get; set; }
        public ICommand ShowGradesCommand { get; set; }
        public static Student Student { get; set; }
        public StudentViewModel()
        {
            ShowAbsencesCommand = new RelayCommand(ShowAbsences);
            ShowGradesCommand = new RelayCommand(ShowGrades);
        }
        public void ShowAbsences()
        {
            new StudentAbsencesWindow().Show();
        }
        public void ShowGrades()
        {
            new StudentGradesWindow().Show();
        }
    }
}
