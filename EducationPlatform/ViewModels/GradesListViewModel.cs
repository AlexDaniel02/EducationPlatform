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
    public class GradesListViewModel : ViewModelBase
    {
        private ObservableCollection<Grade> _grades;
        private Grade _selectedGrade;
        private int _newGradeValue;
        private Student _selectedStudent;
        private Subject _selectedSubject;
        private DateTime _selectedDate;
        private bool _isSemestrial;
        private ObservableCollection<Student> _students;

        public ObservableCollection<Grade> Grades
        {
            get { return _grades; }
            set
            {
                if (_grades != value)
                {
                    _grades = value;
                    OnPropertyChanged();
                }
            }
        }

        public Grade SelectedGrade
        {
            get { return _selectedGrade; }
            set
            {
                if (_selectedGrade != value)
                {
                    _selectedGrade = value;
                    OnPropertyChanged();
                }
            }
        }

        public int NewGradeValue
        {
            get { return _newGradeValue; }
            set
            {
                if (_newGradeValue != value)
                {
                    _newGradeValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    OnPropertyChanged();
                }
            }
        }

        public Subject SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                if (_selectedSubject != value)
                {
                    _selectedSubject = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSemestrial
        {
            get { return _isSemestrial; }
            set
            {
                if (_isSemestrial != value)
                {
                    _isSemestrial = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Subject> Subjects { get; set; }

        public ICommand AddGradeCommand { get; set; }
        public ICommand UpdateGradeCommand { get; set; }
        public ICommand DeleteGradeCommand { get; set; }

        public GradesListViewModel()
        {
            Grades = new(App.GradeBLL.GetAllGrades());
            Students = new(App.StudentBLL.GetAllStudents());
            Subjects = new(App.SubjectBLL.GetAllSubjects());
            AddGradeCommand = new RelayCommand(AddGrade);
            UpdateGradeCommand = new RelayCommand(UpdateGrade);
            DeleteGradeCommand = new RelayCommand(DeleteGrade);
            SelectedDate = DateTime.Now; // Set the initial selected date to current date
        }

        private void AddGrade()
        {
            Grade newGrade = new Grade
            {
                Value = NewGradeValue,
                Student = SelectedStudent,
                Subject = SelectedSubject,
                Date = SelectedDate,
                IsSemestrial = IsSemestrial
            };
            App.GradeBLL.AddGrade(newGrade);
            NewGradeValue = 0;
            SelectedStudent = null;
            SelectedSubject = null;
            SelectedDate = DateTime.Now;
            IsSemestrial = false;
            Refresh();
        }

        private void UpdateGrade()
        {
            if (SelectedGrade != null)
            {
                SelectedGrade.Subject = SelectedSubject;
                SelectedGrade.Student = SelectedStudent;
                SelectedGrade.Value = NewGradeValue;
                SelectedGrade.Date = SelectedDate;
                SelectedGrade.IsSemestrial = IsSemestrial;
                App.GradeBLL.UpdateGrade(SelectedGrade);               
            }
            else
            {
                MessageBox.Show("Select a grade to update");
            }
        }

        private void DeleteGrade()
        {
            if (SelectedGrade != null)
            {
                App.GradeBLL.DeleteGrade(SelectedGrade);
                SelectedGrade = null;
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select a grade to delete");
            }
        }
        private void Refresh()
        {
            Grades.Clear();
            foreach (var grade in App.GradeBLL.GetAllGrades())
            {
                Grades.Add(grade);
            }
        }
    }
}
