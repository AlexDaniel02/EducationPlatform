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
    public class SubjectsListViewModel:ViewModelBase
    {
        private string _newSubjectName;
        private Subject _selectedSubject;

        public ObservableCollection<Subject> Subjects { get; set; }
        public ICommand AddSubjectCommand { get; set; }
        public ICommand DeleteSubjectCommand { get; set; }
        public ICommand UpdateSubjectCommand { get; set; }

        public string NewSubjectName
        {
            get { return _newSubjectName; }
            set
            {
                if (_newSubjectName != value)
                {
                    _newSubjectName = value;
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

        public SubjectsListViewModel()
        {
            Subjects = new(App.SubjectBLL.GetAllSubjects());
            AddSubjectCommand = new RelayCommand(AddSubject);
            DeleteSubjectCommand = new RelayCommand(DeleteSubject);
            UpdateSubjectCommand = new RelayCommand(UpdateSubject);
        }

        private void AddSubject()
        {
            Subject newSubject = new Subject { Name = NewSubjectName };
            App.SubjectBLL.AddSubject(newSubject);
            NewSubjectName = string.Empty;
            Refresh();
        }

        private void DeleteSubject()
        {
            if (SelectedSubject != null)
            {
                App.SubjectBLL.DeleteSubject(SelectedSubject);
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select a Subject to delete");
            }
        }
        private void UpdateSubject()
        {
            if (SelectedSubject != null)
            {
                SelectedSubject.Name = NewSubjectName;
                App.SubjectBLL.UpdateSubject(SelectedSubject);
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select a Subject to update");
            }
        }
        private void Refresh()
        {
            Subjects.Clear();
            foreach (var subject in App.SubjectBLL.GetAllSubjects())
            {
                Subjects.Add(subject);
            }
        }
    }
}
