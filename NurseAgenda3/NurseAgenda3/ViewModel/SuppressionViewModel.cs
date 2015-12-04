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
    public class SuppressionViewModel : ViewModelBase
    {
        private ObservableCollection<Patient> _patients;

        public SuppressionViewModel()
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
