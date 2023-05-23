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
    public class SpecializationsListViewModel : ViewModelBase
    {
        private ObservableCollection<Specialization> _specializations;
        private Specialization _selectedSpecialization;
        private string _newSpecializationName;

        public ObservableCollection<Specialization> Specializations
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
                if (_selectedSpecialization != value)
                {
                    _selectedSpecialization = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewSpecializationName
        {
            get { return _newSpecializationName; }
            set
            {
                if (_newSpecializationName != value)
                {
                    _newSpecializationName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddSpecializationCommand { get; set; }
        public ICommand UpdateSpecializationCommand { get; set; }
        public ICommand DeleteSpecializationCommand { get; set; }

        public SpecializationsListViewModel()
        {
            Specializations = new(App.SpecializationBLL.GetAllSpecializations());
            AddSpecializationCommand = new RelayCommand(AddSpecialization);
            UpdateSpecializationCommand = new RelayCommand(UpdateSpecialization);
            DeleteSpecializationCommand = new RelayCommand(DeleteSpecialization);
        }

        private void AddSpecialization()
        {
                Specialization newSpecialization = new Specialization
                {
                    Name = NewSpecializationName
                };
                NewSpecializationName = string.Empty;
            App.SpecializationBLL.AddSpecialization(newSpecialization);
            Refresh();

        }

        private void UpdateSpecialization()
        {
            if (SelectedSpecialization != null)
            {
                SelectedSpecialization.Name = NewSpecializationName;
                App.SpecializationBLL.UpdateSpecialization(SelectedSpecialization);
                Refresh();
            }
            else
            {
                MessageBox.Show("Please select a specialization to update");
            }

        }

        private void DeleteSpecialization()
        {
            if (SelectedSpecialization != null)
            {
                App.SpecializationBLL.DeleteSpecialization(SelectedSpecialization);
                Refresh();
                SelectedSpecialization = null;
            }
            else
            {
                MessageBox.Show("Please select a specialization to delete");
            }
            
        }
        private void Refresh()
        {
            Specializations.Clear();
            
            foreach (Specialization specialization in App.SpecializationBLL.GetAllSpecializations())
            {
                Specializations.Add(specialization);
            }
        }
    }
}
