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
    public class AbsencesListViewModel : ViewModelBase
    {
        private Student _selectedStudent;
        private Subject _selectedSubject;
        private DateTime _selectedDate;
        private bool _isMotivated;
        private Absence _selectedAbsence;

        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public ObservableCollection<Absence> Absences { get; set; }
        public ICommand AddAbsenceCommand { get; set; }
        public ICommand DeleteAbsenceCommand { get; set; }
        public ICommand UpdateAbsenceCommand { get; set; }

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
        public Absence ?SelectedAbsence
        {
            get { return _selectedAbsence; }
            set
            {
                if(_selectedAbsence!=value)
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

        public AbsencesListViewModel()
        {
            Students = new(App.StudentBLL.GetAllStudents());
            Subjects = new(App.SubjectBLL.GetAllSubjects());
            Absences = new(App.AbsenceBLL.GetAllAbsences());
            AddAbsenceCommand = new RelayCommand(AddAbsence);
            DeleteAbsenceCommand = new RelayCommand(DeleteAbsence);
            UpdateAbsenceCommand = new RelayCommand(UpdateAbsence);
        }

        private void AddAbsence()
        {
            Absence newAbsence = new Absence
            {
                Student = SelectedStudent,
                Subject = SelectedSubject,
                Date = SelectedDate,
                IsMotivated = IsMotivated
            };
            App.AbsenceBLL.AddAbsence(newAbsence);
            Refresh();
        }

        private void DeleteAbsence()
        {
            if(SelectedAbsence!=null)
            {
                App.AbsenceBLL.DeleteAbsence(SelectedAbsence);
                Refresh();
            }
            else
            {
                MessageBox.Show("Select an absence!");
            }
        }

        private void UpdateAbsence()
        {
            if (SelectedAbsence != null)
            {
                SelectedAbsence.Student = SelectedStudent;
                SelectedAbsence.Subject = SelectedSubject;
                SelectedAbsence.Date = SelectedDate;
                SelectedAbsence.IsMotivated = IsMotivated;
                App.AbsenceBLL.UpdateAbsence(SelectedAbsence);
                SelectedAbsence = null;
                Refresh();
            }
            else
            {
                MessageBox.Show("Select an absence!");
            }
        }
        private void Refresh()
        {
            Absences.Clear();
            foreach (var absence in App.AbsenceBLL.GetAllAbsences())
            {
                Absences.Add(absence);
            }
        }
    }
}

