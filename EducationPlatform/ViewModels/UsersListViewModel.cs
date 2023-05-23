using EducationPlatform.Models.BusinessLogicLayer;
using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;
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
    public class UsersListViewModel : ViewModelBase
    {
        private string _newUsername;
        private string _newPassword;
        private Role _selectedRole;
        private int _personId;
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Role> Roles { get; set; }
        private User _selectedUser;
        public string NewUsername
        {
            get { return _newUsername; }
            set
            {
                _newUsername = value;
                OnPropertyChanged();
            }
        }
        public int PersonId {
            get { return _personId; }
            set
            {
                _personId = value;
                OnPropertyChanged();
            }
        }
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }

        public Role SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                _selectedRole = value;
                OnPropertyChanged();
            }
        }
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UsersListViewModel()
        {
            // Initialize the collections and commands
            Users = new (App.UserBLL.GetAllUsers());
            Roles = new ObservableCollection<Role>
            {
                Role.Admin,
                Role.ClassMaster,
                Role.Teacher,
                Role.Student
            };

            AddUserCommand = new RelayCommand(AddUser);
            UpdateUserCommand = new RelayCommand(UpdateUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
        }

        private void AddUser()
        {
            if (SelectedRole == Role.Student || SelectedRole == Role.Teacher || SelectedRole==Role.ClassMaster)
            {
                if (PersonId>=0)
                {
                    bool personExists = PersonIdExists();

                    if (personExists)
                    {
                        User user = new User
                        {
                            Username = NewUsername,
                            Password = NewPassword,
                            Role = SelectedRole,
                            IdPerson = PersonId
                        };
                        App.UserBLL.AddUser(user);
                        Refresh();
                    }
                    else
                    {
                        MessageBox.Show("PersonId or Role is not correct!");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a Person ID for the selected role.");
                    return;
                }
            }
            else
            {
                User user = new User
                {
                    Username = NewUsername,
                    Password = NewPassword,
                    Role = SelectedRole
                };

                App.UserBLL.AddUser(user);
                Refresh();
            }
        }
        private bool PersonIdExists()
        {
            if (SelectedRole == Role.Student)
            {
                return App.StudentBLL.GetAllStudents().Any(student => student.Id == PersonId);
            }
            if (SelectedRole == Role.Teacher)
            {
                return App.TeacherBLL.GetAllTeachers().Any(teacher => teacher.Id == PersonId);
            }
            if (SelectedRole == Role.ClassMaster)
            {
                bool isClassMaster = App.ClassBLL.GetAllClasses().Any(@class => @class.ClassMaster.Id == PersonId);
                return App.TeacherBLL.GetAllTeachers().Any(teacher => teacher.Id == PersonId && isClassMaster);
            }
            return true;
        }
        private void UpdateUser()
        {
            if (SelectedUser != null)
            {
                SelectedUser.Username = NewUsername;
                SelectedUser.Password = NewPassword;
                SelectedUser.Role = SelectedRole;
                App.UserBLL.UpdateUser(SelectedUser);
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select a user to update.");
            }
        }

        private void DeleteUser()
        {
            if (SelectedUser != null)
            {
                App.UserBLL.DeleteUser(SelectedUser);
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }
        private void Refresh()
        {
            Users.Clear();
            foreach (var user in App.UserBLL.GetAllUsers())
            {
                Users.Add(user);
            }
        }
    }
}
