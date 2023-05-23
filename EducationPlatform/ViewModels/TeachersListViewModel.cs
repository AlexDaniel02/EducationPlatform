using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EducationPlatform.ViewModels
{
    public class TeachersListViewModel : ViewModelBase
    {
        private ObservableCollection<Teacher> _teachers;
        private Teacher _selectedTeacher;
        private string _newTeacherName;
        private ObservableCollection<Class> _classes;
        public ObservableCollection<Teacher> Teachers
        {
            get { return _teachers; }
            set
            {
                if (_teachers != value)
                {
                    _teachers = value;
                    OnPropertyChanged();
                }
            }
        }

        public Teacher SelectedTeacher
        {
            get { return _selectedTeacher; }
            set
            {
                if (_selectedTeacher != value)
                {
                    _selectedTeacher = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewTeacherName
        {
            get { return _newTeacherName; }
            set
            {
                if (_newTeacherName != value)
                {
                    _newTeacherName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Class> Classes
        {
            get { return _classes; }
            set
            {
                if (_classes != value)
                {
                    _classes = value;
                    OnPropertyChanged();
                }
            }
        }



        public ICommand AddTeacherCommand { get; set; }
        public ICommand UpdateTeacherCommand { get; set; }
        public ICommand DeleteTeacherCommand { get; set; }

        public TeachersListViewModel()
        {
            Teachers = new(App.TeacherBLL.GetAllTeachers());
            Classes = new(App.ClassBLL.GetAllClasses());
            AddTeacherCommand = new RelayCommand(AddTeacher);
            UpdateTeacherCommand = new RelayCommand(UpdateTeacher);
            DeleteTeacherCommand = new RelayCommand(DeleteTeacher);
        }
        private void AddTeacher()
        {
            Teacher newTeacher = new Teacher
            {
                Name = NewTeacherName,
            };
            App.TeacherBLL.AddTeacher(newTeacher);
            Refresh();
            NewTeacherName = string.Empty;
        }
        private void UpdateTeacher()
        {
            if (SelectedTeacher != null)
            {
                SelectedTeacher.Name = NewTeacherName;
                Refresh();
            }
            else
            {
                MessageBox.Show("Select a teacher to update");
            }
        }
        private void DeleteTeacher()
        {
            if (SelectedTeacher != null)
            {
                App.TeacherBLL.DeleteTeacher(SelectedTeacher);
                SelectedTeacher = null;
                Refresh();
            }
            else
            {
                MessageBox.Show("Select a teacher to delete");
            }
        }
        private void Refresh()
        {
            Teachers.Clear();
            foreach (var teacher in App.TeacherBLL.GetAllTeachers())
            {
                Teachers.Add(teacher);
            }
            Classes.Clear();
            foreach (var Class in App.ClassBLL.GetAllClasses())
            {
                Classes.Add(Class);
            }
        }
    }
}

