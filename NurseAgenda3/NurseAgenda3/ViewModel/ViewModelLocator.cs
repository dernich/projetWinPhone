using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAgenda3.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<InformationViewModel>();
            SimpleIoc.Default.Register<DeleteViewModel>();
            SimpleIoc.Default.Register<AttributionViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();

            NavigationService nagivationPages = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => nagivationPages);
            nagivationPages.Configure("MainPage", typeof(MainPage));
            nagivationPages.Configure("InformationPage", typeof(InformationPage));
            nagivationPages.Configure("DeletePage", typeof(DeletePage));
            nagivationPages.Configure("AttributionPage", typeof(AttributionPage));
            nagivationPages.Configure("LoginPage", typeof(LoginPage));
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public InformationViewModel Information
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InformationViewModel>();
            }
        }

        public DeleteViewModel Delete
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DeleteViewModel>();
            }
        }

        public AttributionViewModel Attribution
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AttributionViewModel>();
            }
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
    }
}
