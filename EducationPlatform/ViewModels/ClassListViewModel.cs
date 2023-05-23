using EducationPlatform.Models.BusinessLogicLayer;
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
    public class ClassListViewModel : ViewModelBase
    {
        private ObservableCollection<Class> _classes;
        private Class _selectedClass;
        private List<Specialization> _specializations;
        private Specialization _selectedSpecialization;
        private ObservableCollection<Teacher> _teachers;
        private string _name;
        private Teacher _selectedClassMaster;

        public Teacher SelectedClassMaster
        {
            get { return _selectedClassMaster; }
            set
            {
                if (_selectedClassMaster != value)
                {
                    _selectedClassMaster = value;
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
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
                {
                }
            }
        }

        public Class SelectedClass
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

        public List<Specialization> AllSpecializations
        {
            get { return _specializations; }
            set
            {
                if (_specializations != value)
                {
                    _specializations = value;
                    OnPropertyChanged();
                }
            }
        }

        public Specialization SelectedSpecialization
        {
            get { return _selectedSpecialization; }
            set
            {

                    _selectedSpecialization = value;
                    OnPropertyChanged();
                
            }
        }
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
        public ICommand DeleteClassCommand { get; set; }
        public ICommand AddClassCommand { get; set; }
        public ICommand UpdateClassCommand { get; set; }
        public ClassListViewModel()
        {
            Classes = new(App.ClassBLL.GetAllClasses());
            Teachers = new(App.TeacherBLL.GetAllTeachers());
            AllSpecializations = new(App.SpecializationBLL.GetAllSpecializations());
            DeleteClassCommand = new RelayCommand(DeleteClass);
            AddClassCommand = new RelayCommand(AddClass);
            UpdateClassCommand = new RelayCommand(UpdateClass);
        }

        private void DeleteClass()
        {
            if (SelectedClass != null)
            {
                App.ClassBLL.DeleteClass(SelectedClass);
                SelectedClass = null;
                Refresh();
            }
        }
        private void AddClass()
        {
            Class newClass = new Class();
            newClass.Name = Name;
            newClass.Specialization = SelectedSpecialization;
            newClass.ClassMaster = SelectedClassMaster;
            if (SelectedClassMaster != null && !IsClassMaster(SelectedClassMaster))
            {
                App.ClassBLL.AddClass(newClass);
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select an available class master");
            }

        }
        public bool IsClassMaster(Teacher teacher)
        {
            foreach (var cls in App.ClassBLL.GetAllClasses())
            {
                if (cls.ClassMaster == teacher)
                {
                    return true;
                }
            }
            return false;
        }
        private void UpdateClass()
        {
            if (SelectedClass != null)
            {
                SelectedClass.Name = Name;
                SelectedClass.Specialization = SelectedSpecialization;
                SelectedClass.ClassMaster = SelectedClassMaster;
                if (SelectedClassMaster != null && !IsClassMaster(SelectedClassMaster))
                {
                    App.ClassBLL.UpdateClass(SelectedClass);
                    Refresh();
                }
                else
                {
                    MessageBox.Show("That ClassMaster is not available!");
                }
            }
            else
            {
                MessageBox.Show("Select a class to update");
            }
        }
        private void Refresh()
        {
            Classes.Clear();
            foreach (var item in App.ClassBLL.GetAllClasses())
            {
                Classes.Add(item);
            }
            Teachers.Clear();
            foreach (var item in App.TeacherBLL.GetAllTeachers())
            {
                Teachers.Add(item);
            }

        }
    }
}
