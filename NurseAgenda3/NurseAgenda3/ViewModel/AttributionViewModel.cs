using GalaSoft.MvvmLight;
using NurseAgenda3.DAL;
using NurseAgenda3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace NurseAgenda3.ViewModel
{
    public class AttributionViewModel : ViewModelBase
    {
        private ObservableCollection<Patient> _patients = new ObservableCollection<Patient>();
        private ObservableCollection<Infirmier> _nurses = new ObservableCollection<Infirmier>();
        private MyDataAccess myDataAccess;

        public AttributionViewModel()
        {
            myDataAccess = new MyDataAccess();
            LoadPatients();
            LoadNurses();
            Today = new DateTimeOffset(DateTime.Today);
        }

        public DateTimeOffset Today { get; set; }

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

        private async void LoadPatients()
        {
            List<Patient> listPatient = await myDataAccess.getAllPatient();
            
            foreach (var item in listPatient)
            {
                _patients.Add(item);
            }
        }

        public ObservableCollection<Infirmier> Nurses
        {
            get { return _nurses; }
            set
            {
                _nurses = value;
                RaisePropertyChanged("Nurses");
            }
        }

        private Infirmier _nurseSelected;

        public Infirmier NurseSelected
        {
            get { return _nurseSelected; }
            set
            {
                _nurseSelected = value;
                if (_nurseSelected != null)
                {
                    RaisePropertyChanged("NurseSelected");
                }
            }
        }

        private DateTimeOffset _dateSelected;

        public DateTimeOffset DateSelected
        {
            get { return _dateSelected; }
            set
            {
                _dateSelected = value;
                if (_dateSelected != null)
                {
                    RaisePropertyChanged("DateSelected");
                }
            }
        }

        private async void LoadNurses()
        {
            List<Infirmier> listNurse = await myDataAccess.getAllNurse();
            
            foreach (var item in listNurse)
            {
                _nurses.Add(item);
            }
        }

        public void AddCare()
        {
            Soin soin = new Soin();
            String date = DateSelected.Day + "-" + DateSelected.Month + "-" + DateSelected.Year;
            soin.dateSoin = date;
            soin.IdInfi = NurseSelected.IdInfirmier;
            soin.IdPatient = PatientSelected.IdPatient;
            myDataAccess.AddCare(soin);
            new MessageDialog("Ajout confirmé").ShowAsync();
        }
    }
}
