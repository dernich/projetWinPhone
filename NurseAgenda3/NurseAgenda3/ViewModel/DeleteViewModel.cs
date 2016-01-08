using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using NurseAgenda3.DAL;
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
        private ObservableCollection<Patient> _patients = new ObservableCollection<Patient>();
        private MyDataAccess myDataAccess;

        public DeleteViewModel()
        {
            //Patients = new ObservableCollection<Patient>(AllPatients.GetAllPatients());
            myDataAccess = new MyDataAccess();
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

        private Patient _patientSelected;

        public Patient PatientSelected
        {
            get { return _patientSelected; }
            set
            {
                _patientSelected = value;
                if (_patientSelected != null)
                {
                    RaisePropertyChanged("PatientSelected");
                }
            }
        }

        private INavigationService _navigationService;

        [PreferredConstructor]
        public DeleteViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            myDataAccess = new MyDataAccess();
            LoadPatients();
        }

        private async void LoadPatients()
        {
            List<Patient> listPatient = await myDataAccess.getAllPatient();

            //_patients.Clear();
            foreach (var item in listPatient)
            {
                _patients.Add(item);
            }
        }

        public void OnNavigateTo(Patient clickedItem)
        {
            _navigationService.NavigateTo("InformationPage", clickedItem);
        }
    }
}
