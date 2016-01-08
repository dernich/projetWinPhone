using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NurseAgenda3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

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
                _adresseConcat = "";
                _adresseConcat = _patientSelected.Rue + ", " + _patientSelected.Numero + "\n" + _patientSelected.CodePostal + " " + _patientSelected.Localite;
                RaisePropertyChanged("AdresseConcat");
            }
        }

        private ICommand _itinerary;

        public ICommand Itinerary
        {
            get
            {
                if (this._itinerary == null)
                {
                    this._itinerary = new RelayCommand(() => LaunchMap());
                }
                return this._itinerary;
            }
        }

        private string baseUri = "bingmaps:?";

        public void LaunchMap()
        {
            string end = _adresseConcat + " Belgium";
            string start = "Rue joseph calozet, 19 5000 Namur Belgium";
            string uri = string.Format("{0}rtp=adr.{1}~adr.{2}", baseUri, Uri.EscapeDataString(start), Uri.EscapeDataString(end));
            uri += "&mode=d";
            Launch(new Uri(uri));
        }

        private static async void Launch(Uri uri)
        {
            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);

            if (!success)
            {
                //Failed to launch maps 
                var msg = new MessageDialog("Failed to launch maps app.");
                await msg.ShowAsync();
            }
        }
    }
}
