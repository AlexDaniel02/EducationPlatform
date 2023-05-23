using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;
using EducationPlatform.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EducationPlatform.ViewModels
{
    public class AdminViewModel
    {
        public User LoggedUser { get; set; }
        public ICommand ClassesCommand { get; set; }
        public ICommand StudentsCommand { get; set; }
        public ICommand TeachersCommand { get; set; }
        public ICommand GradesCommand { get; set; }
        public ICommand SubjectsCommand { get; set; }

        public ICommand AbsencesCommand { get; set; }
        public ICommand UsersCommand { get; set; }
        public ICommand SpecializationsCommand { get; set; }
        public ICommand ClassSubjectsCommand { get; set; }

        public AdminViewModel(User loggedUser)
        {
            LoggedUser = loggedUser;
        }
        public AdminViewModel()
        {
            ClassesCommand = new RelayCommand(ShowClasses);
            StudentsCommand = new RelayCommand(ShowStudents);
            TeachersCommand = new RelayCommand(ShowTeachers);
            GradesCommand = new RelayCommand(ShowGrades);
            SubjectsCommand = new RelayCommand(ShowSubjects);
            AbsencesCommand = new RelayCommand(ShowAbsences);
            UsersCommand = new RelayCommand(ShowUsers);
            SpecializationsCommand = new RelayCommand(ShowSpecializations);
            ClassSubjectsCommand = new RelayCommand(ShowClassSubjects);
        }
        public void ShowClasses()
        {
            var classListViewModel = new ClassListViewModel();
            new ClassListWindow().Show();
        }
        public void ShowGrades()
        {
            var gradesListViewModel = new GradesListViewModel();
            new GradesListWindow().Show();

        }
        public void ShowClassSubjects()
        {
            var classSubjectsListViewModel = new ClassSubjectsListViewModel();
            new ClassSubjectsListWindow().Show();
        }
        public void ShowStudents()
        {
            var studentsListViewModel = new StudentsListViewModel();
            new StudentsListWindow().Show();
        }
        public void ShowTeachers()
        {
            var teachersListViewModel = new TeachersListViewModel();
            new TeachersListWindow().Show();
        }
        public void ShowSubjects()
        {
            var subjectsListViewModel = new SubjectsListViewModel();
            new SubjectsListWindow().Show();
        }
        public void ShowAbsences()
        {
            var absencesListViewModel = new AbsencesListViewModel();
            new AbsencesListWindow().Show();
        }
        public void ShowUsers()
        {
            var usersListViewModel = new UsersListViewModel();
            new UsersListWindow().Show();
            
        }
        public void ShowSpecializations()
        {
            var specializationsListViewModel = new SpecializationsListViewModel();
            new SpecializationsListWindow().Show();
        }
    }
}
