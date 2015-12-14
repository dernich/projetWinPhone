﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using NurseAgenda3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAgenda3.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Patient> _patients;

        public MainViewModel()
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
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Patients = new ObservableCollection<Patient>(AllPatients.GetAllPatients());
        }

        public void OnNavigateTo(Patient clickedItem)
        {
            _navigationService.NavigateTo("InformationPage", clickedItem);
        }
    }
}