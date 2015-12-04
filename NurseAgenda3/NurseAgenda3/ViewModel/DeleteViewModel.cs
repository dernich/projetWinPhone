using GalaSoft.MvvmLight;
using NurseAgenda3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAgenda3.ViewModel
{
    public class DeleteViewModel : ViewModelBase
    {
        private ObservableCollection<Patient> _patients;

        public DeleteViewModel()
        {
            Patients = new ObservableCollection<Patient>(AllPatients.GetAllPatients());
        }

        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set
            {
                _patients = value;
                RaisePropertyChanged("Patients");
            }
        }

        private Patient _selectedPatient;

        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                if (_selectedPatient != null)
                {
                    RaisePropertyChanged("SelectedPatient");
                }
            }
        }
    }
}
