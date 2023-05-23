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
    public class ClassMasterAbsencesViewModel : ViewModelBase
    {
        public static Teacher ClassMaster { get; set; }
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
                    LoadAbsences();
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
        public ClassMasterAbsencesViewModel()
        {
            LoadAbsences();
            AddAbsenceCommand = new RelayCommand(AddAbsence);
            UpdateAbsenceCommand = new RelayCommand(UpdateAbsence);
        }

        public void LoadAbsences()
        {
            var Class = App.ClassBLL.GetAllClasses().FirstOrDefault(c => c.ClassMaster == ClassMaster);

            if (Class != null)
            {
                Students = new(Class.Students);
                Subjects = new(Class.ClassSubjects.Select(cs => cs.Subject));
                
                if (SelectedStudent != null && SelectedSubject != null)
                {
                    Absences = new(App.AbsenceBLL.GetAllAbsences()
                        .Where(a => a.Student == SelectedStudent && a.Subject == SelectedSubject));
                }
                else
                {
                    Absences = new(App.AbsenceBLL.GetAllAbsences()
                    .Where(a => a.Student.Class == Class));
                }
            }
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
