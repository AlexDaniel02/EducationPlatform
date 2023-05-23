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
    public class TeacherGradesViewModel : ViewModelBase
    {
        public static Teacher Teacher { get; set; }
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
        public TeacherGradesViewModel()
        {
            LoadGrades();
            AddGradeCommand = new RelayCommand(AddGrade);
            DeleteGradeCommand = new RelayCommand(DeleteGrade);
        }
        public void LoadGrades()
        {
            var teacherClassSubjects = Teacher.ClassSubjects;
            var classes = teacherClassSubjects.Select(cs => cs.Class);
            var grades = App.GradeBLL.GetAllGrades();
            Grades = new ObservableCollection<Grade>(grades.Where(g => teacherClassSubjects.Any(cs =>cs.Class == g.Student.Class && cs.Subject == g.Subject)).ToList());
            var students = App.StudentBLL.GetAllStudents().Where(s => classes.Contains(s.Class));
            Students = new ObservableCollection<Student>(students);
            var subjects = teacherClassSubjects.Select(cs => cs.Subject);
            Subjects = new ObservableCollection<Subject>(subjects);
        }
        public void AddGrade()
        {
            if (Teacher.ClassSubjects.Any(cs => cs.Class.Id == SelectedStudent.Class.Id && cs.Subject.Id == SelectedSubject.Id))
            {
                var newGrade = new Grade
                {
                    Student = SelectedStudent,
                    Subject = SelectedSubject,
                    Value = NewGradeValue
                };
                App.GradeBLL.AddGrade(newGrade);
                RefreshGrades();
            }
            else
            {
                MessageBox.Show("The teacher does not teach the selected student for the selected subject.");
            }
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
