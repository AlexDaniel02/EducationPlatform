using EducationPlatform.Models.BusinessLogicLayer;
using EducationPlatform.Models.DataAccessLayer;
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
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string _password;
        public User LoggedUser { get; set; }
        public ICommand LoginCommand { get; set; }
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }
        public LoginViewModel()
        {
            LoggedUser = new User();
            LoginCommand = new RelayCommand(Login);
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool AccountExists(string username, string password)
        {
            LoggedUser = App.UserBLL.GetByUsername(username);
            if (LoggedUser != null && LoggedUser.Password == password)
            {
                return true;
            }
            return false;
        }
        public void Login()
        {

            if (AccountExists(Username, Password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                switch (LoggedUser.Role)
                {
                    case Role.Admin:
                        {
                            new AdminWindow().Show();
                            AdminViewModel adminViewModel = new AdminViewModel(LoggedUser);
                            Application.Current.MainWindow.Close();
                            break;
                        }
                    case Role.ClassMaster:
                        {
                            Teacher classMaster = App.TeacherBLL.GetTeacherById(LoggedUser.IdPerson);
                            ClassMasterViewModel.ClassMaster = classMaster;
                            new ClassMasterWindow().Show();
                            Application.Current.MainWindow.Close();
                            break;
                        }
                    case Role.Teacher:
                        {
                            Teacher teacher = App.TeacherBLL.GetTeacherById(LoggedUser.IdPerson);
                            TeacherViewModel.Teacher = teacher;
                            new TeacherWindow().Show();
                            Application.Current.MainWindow.Close();
                            break;
                        }
                    case Role.Student:
                        {
                            Student student = App.StudentBLL.GetStudentById(LoggedUser.IdPerson);
                            StudentViewModel.Student = student;
                            new StudentWindow().Show();
                            Application.Current.MainWindow.Close();
                            break;
                        }
                }

            }
            else
            {
                MessageBox.Show("Login failed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
