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
    public class TeacherAbsencesViewModel : ViewModelBase
    {
        public static Teacher Teacher { get; set; }
        private ObservableCollection<Absence> _absences;
        public ObservableCollection<Student> _students;
        public ObservableCollection<Subject> _subjects;
        private Absence _selectedAbsence;
        private DateTime _selectedDate;
        private bool _isMotivated;
        private Student _selectedStudent;
        private Subject _selectedSubject;
        public ICommand AddAbsenceCommand { get; set; }
        public ICommand UpdateAbsenceCommand { get; set; }
        public ICommand DeleteAbsenceCommand { get; set; }
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
        public Absence SelectedAbsence
        {
            get { return _selectedAbsence; }
            set
            {
                if (_selectedAbsence != value)
                {
                    _selectedAbsence = value;
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
        public bool IsMotivated
        {
            get { return _isMotivated; }
            set
            {
                if (_isMotivated != value)
                {
                    _isMotivated = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<Absence> Absences
        {
            get { return _absences; }
            set
            {
                _absences = value;
                OnPropertyChanged();
            }
        }
        public TeacherAbsencesViewModel()
        {
            LoadAbsences();
            AddAbsenceCommand = new RelayCommand(AddAbsence);
            UpdateAbsenceCommand = new RelayCommand(UpdateAbsence);
        }
        public void LoadAbsences()
        {
            var teacherClassSubjects = Teacher.ClassSubjects;
            var classes = teacherClassSubjects.Select(cs => cs.Class);
            var subjects = teacherClassSubjects.Select(cs => cs.Subject);
            var allAbsences = App.AbsenceBLL.GetAllAbsences();
            var filteredAbsences = allAbsences.Where(a =>
                classes.Contains(a.Student.Class) &&
                subjects.Contains(a.Subject));

            Students = new ObservableCollection<Student>(filteredAbsences.Select(a => a.Student).Distinct());
            Subjects = new ObservableCollection<Subject>(filteredAbsences.Select(a => a.Subject).Distinct());
            Absences = new ObservableCollection<Absence>(filteredAbsences);
        }
        public void UpdateAbsence()
        {
            if (SelectedAbsence != null)
            {
                SelectedAbsence.IsMotivated = !SelectedAbsence.IsMotivated;
                App.AbsenceBLL.UpdateAbsence(SelectedAbsence);
                RefreshAbsences();
            }
            else
            {
                MessageBox.Show("Absence not found in the database");
            }
        }
    
        public void AddAbsence()
        {
            if (Teacher.ClassSubjects.Any(cs => cs.Class.Id == SelectedStudent.Class.Id && cs.Subject.Id == SelectedSubject.Id))
            {
                var newAbsence = new Absence
                {
                    Student = SelectedStudent,
                    Subject = SelectedSubject,
                    Date = SelectedDate,
                    IsMotivated = IsMotivated              
                };
                App.AbsenceBLL.AddAbsence(newAbsence);
                RefreshAbsences();
            }
            else
            {
                MessageBox.Show("The teacher does not teach the selected student for the selected subject.");
            }
        }
        public void DeleteAbsence()
        {
            if (SelectedAbsence != null)
            {
                App.AbsenceBLL.DeleteAbsence(SelectedAbsence);
                RefreshAbsences();
            }
        }

        public void RefreshAbsences()
        {
            Absences.Clear();
            LoadAbsences();
        }
    }

}
