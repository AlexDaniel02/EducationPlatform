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
    public class ClassSubjectsListViewModel : ViewModelBase
    {
        private ObservableCollection<Subject> _subjects;
        private ObservableCollection<Class> _classes;
        private ObservableCollection<Teacher> _teachers;
        private ClassSubject _selectedClassSubject;
        private ObservableCollection<ClassSubject> _classSubjects;
        private Subject _selectedSubject;
        private Class _selectedClass;
        private Teacher _selectedTeacher;

        public ObservableCollection<Subject> Subjects
        {
            get { return _subjects; }
            set
            {
                _subjects = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Class> Classes
        {
            get { return _classes; }
            set
            {
                _classes = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ClassSubject> ClassSubjects
        {
            get { return _classSubjects; }
            set
            {
                _classSubjects = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Teacher> Teachers
        {
            get { return _teachers; }
            set
            {
                _teachers = value;
                OnPropertyChanged();
            }
        }

        public ClassSubject SelectedClassSubject
        {
            get { return _selectedClassSubject; }
            set
            {
                _selectedClassSubject = value;
                OnPropertyChanged();
            }
        }
        public Class SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                OnPropertyChanged();
            }
        }
        public Teacher SelectedTeacher
        {
            get { return _selectedTeacher; }
            set
            {
                _selectedTeacher = value;
                OnPropertyChanged();
            }
        }
        public Subject SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                _selectedSubject = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddClassSubjectCommand { get; private set; }
        public ICommand UpdateClassSubjectCommand { get; private set; }
        public ICommand DeleteClassSubjectCommand { get; private set; }

        public ClassSubjectsListViewModel()
        {
            AddClassSubjectCommand = new RelayCommand(AddClassSubject);
            UpdateClassSubjectCommand = new RelayCommand(UpdateClassSubject);
            DeleteClassSubjectCommand = new RelayCommand(DeleteClassSubject);
            ClassSubjects = new(App.ClassSubjectBLL.GetAllClassSubjects());
            Subjects = new(App.SubjectBLL.GetAllSubjects());
            Classes = new(App.ClassBLL.GetAllClasses());
            Teachers = new(App.TeacherBLL.GetAllTeachers());
        }

        private void AddClassSubject()
        {
            ClassSubject classSubject = new();
            classSubject.Subject = SelectedSubject;
            classSubject.Class = SelectedClass;
            classSubject.Teacher = SelectedTeacher;
            App.ClassSubjectBLL.AddClassSubject(classSubject);
            Refresh();
        }

        private void UpdateClassSubject()
        {
            if (SelectedClassSubject != null)
            {
                SelectedClassSubject.Subject = SelectedSubject;
                SelectedClassSubject.Class = SelectedClass;
                SelectedClassSubject.Teacher = SelectedTeacher;
                App.ClassSubjectBLL.UpdateClassSubject(SelectedClassSubject);
                SelectedClassSubject = null;
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select a class subject to update");
            }
        }

        private void DeleteClassSubject()
        {
            if(SelectedClassSubject!=null)
            {
                App.ClassSubjectBLL.DeleteClassSubject(SelectedClassSubject);
                SelectedClassSubject = null;
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select a class subject to delete");
            }
        }
        private void Refresh()
        {
            ClassSubjects.Clear();
            foreach (ClassSubject classSubject in App.ClassSubjectBLL.GetAllClassSubjects())
            {
                ClassSubjects.Add(classSubject);
            }
        }
    }
}
