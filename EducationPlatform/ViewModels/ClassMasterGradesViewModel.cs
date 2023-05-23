using EducationPlatform.Models.EntityLayer;
using EducationPlatform.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace EducationPlatform.ViewModels
{
    public class ClassMasterGradesViewModel : ViewModelBase
    {
        public static Teacher ClassMaster { get; set; }
        private ObservableCollection<Grade> _grades;
        public ObservableCollection<Student> _students;
        public ObservableCollection<Subject> _subjects;
        private Grade _selectedGrade;
        private int _newGradeValue;
        private DateTime _selectedDate;
        private bool _isSemestrial;
        private Student _selectedStudent;
        private Subject _selectedSubject;
        public ICommand AddGradeCommand { get; set; }
        public ICommand DeleteGradeCommand { get; set; }
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Subject> Subjects
        {
            get { return _subjects; }
            set
            {
                _subjects = value;
                OnPropertyChanged();
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
        public ObservableCollection<Grade> Grades
        {
            get { return _grades; }
            set
            {
                _grades = value;
                OnPropertyChanged();
            }
        }
        public ClassMasterGradesViewModel()
        {
            LoadGrades();
            AddGradeCommand = new RelayCommand(AddGrade);
            DeleteGradeCommand = new RelayCommand(DeleteGrade);
        }
        public void LoadGrades()
        {
            var Class = App.ClassBLL.GetAllClasses().FirstOrDefault(c => c.ClassMaster == ClassMaster);

            if (Class != null)
            {
                Students = new(Class.Students);
                Grades = new(App.GradeBLL.GetAllGrades()
                    .Where(g => g.Student.Class == Class));
                Subjects = new(App.ClassSubjectBLL.GetAllClassSubjects()
                    .Where(cs => cs.Class == Class)
                    .Select(cs => cs.Subject));
            }
        }
        public void AddGrade()
        {
                var newGrade = new Grade
                {
                    Student = SelectedStudent,
                    Subject = SelectedSubject,
                    Value = NewGradeValue,
                    Date = SelectedDate
                };
                App.GradeBLL.AddGrade(newGrade);
                RefreshGrades();
        }
        public void DeleteGrade()
        {
            if (SelectedGrade != null)
            {
                App.GradeBLL.DeleteGrade(SelectedGrade);
                RefreshGrades();
            }
        }

        public void RefreshGrades()
        {
            Grades.Clear();
            LoadGrades();
        }
    }

}

