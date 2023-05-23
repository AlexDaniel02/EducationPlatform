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
    public class StudentsListViewModel : ViewModelBase
    {
        private string _newStudentName;
        private Class _selectedClass;
        private Student _selectedStudent;
        private ObservableCollection<Class> _classes;

        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Class> Classes
        {
            get => _classes;
            set
            {
                _classes = value;
                OnPropertyChanged();
            }
        }

        public string NewStudentName
        {
            get { return _newStudentName; }
            set
            {
                if (_newStudentName != value)
                {
                    _newStudentName = value;
                    OnPropertyChanged();
                }
            }
        }

        public Class? SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                if (_selectedClass != value)
                {
                    _selectedClass = value;
                    OnPropertyChanged();
                }
            }
        }
        public Student SelectedStudent
        {
            get
            {
                { return _selectedStudent; }
            }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddStudentCommand { get; }
        public ICommand UpdateStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public StudentsListViewModel()
        {
            Students = new(App.StudentBLL.GetAllStudents());
            Classes = new(App.ClassBLL.GetAllClasses());
            AddStudentCommand = new RelayCommand(AddStudent);
            UpdateStudentCommand = new RelayCommand(UpdateStudent);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
        }

        private void AddStudent()
        {
            Student newStudent = new Student
            {
                Name = NewStudentName,
                Class = SelectedClass
            };
            App.StudentBLL.AddStudent(newStudent);
            // Add the student to the collection
            NewStudentName = string.Empty;
            SelectedClass = null;
            Refresh();
        }

        private void UpdateStudent()
        {
            if (SelectedStudent != null)
            {
                SelectedStudent.Name = NewStudentName;
                SelectedStudent.Class = SelectedClass;
                App.StudentBLL.UpdateStudent(SelectedStudent);
                Refresh();
            }
            else
            {
                MessageBox.Show("Select a student to update");
            }
        }

        private void DeleteStudent()
        {
            if (SelectedStudent != null)
            {
                App.StudentBLL.DeleteStudent(SelectedStudent);
                Refresh();
            }
            else
            {
                MessageBox.Show("Select a student to delete");
            }
        }
        private void Refresh()
        {
            Students.Clear();
            foreach (var student in App.StudentBLL.GetAllStudents())
            {
                Students.Add(student);
            }
        }
    }
}
