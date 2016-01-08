using GalaSoft.MvvmLight;
using NurseAgenda3.DAL;
using NurseAgenda3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace NurseAgenda3.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private ObservableCollection<Infirmier> _nurses = new ObservableCollection<Infirmier>();
        private MyDataAccess myDataAccess;

        public LoginViewModel()
        {
            myDataAccess = new MyDataAccess();
            if (NetworkInterface.GetIsNetworkAvailable())
                LoadNurses();
            else
                new MessageDialog("NoConnection").ShowAsync();
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

        private async void LoadNurses()
        {
            List<Infirmier> listNurse = await myDataAccess.getAllNurse();
            
            foreach (var item in listNurse)
            {
                _nurses.Add(item);
            }
        }

        public String Login
        {
            get { return Login; }
            set
            {
                Login = value;
                RaisePropertyChanged("Login");
            }
        }

        public String Password
        {
            get { return Password; }
            set
            {
                Password = value;
                RaisePropertyChanged("Password");
            }
        }

        public void Connection()
        {
            foreach (var nurse in _nurses)
            {
                if(Login != null && nurse.Login == Login)
                {
                    if(nurse.MotDePasse == Password)
                    {
                        //return true;
                        new MessageDialog(nurse.Nom).ShowAsync();
                    }
                    else
                    {
                        //return false;
                    }
                }
                else
                {
                    //return false;
                }
            }
            //return false;
        }
    }
}
