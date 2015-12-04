using GalaSoft.MvvmLight;
using NurseAgenda3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAgenda3.ViewModel
{
    public class InformationViewModel : ViewModelBase, INotifyPropertyChanged
    {

        internal void OnNavigatedTo(Patient parameter)
        {
            PatientSelected = parameter;
            AdresseConcat = _patientSelected.Rue;
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

        private String _adresseConcat;

        public String AdresseConcat
        {
            get { return _adresseConcat; }
            set {
                _adresseConcat = _patientSelected.Rue + ", " + _patientSelected.Numero + "\n" + _patientSelected.CodePostal + " " + _patientSelected.Localite;
                RaisePropertyChanged("AdresseConcat");
            }
        }
    }
}
