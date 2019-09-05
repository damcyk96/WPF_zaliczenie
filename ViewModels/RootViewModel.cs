using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
    public class RootViewModel : INotifyPropertyChanged
    {
        public RootViewModel()
        {
            _dao = new DAO.DAO();
            _dao.GetAllTests();

            CurrentView = new TestListViewModel(this);
        }

        private BaseViewModel _currentView;
        public BaseViewModel CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }

        public IDAO _dao;
        public IDAO DAO
        {
            get
            {
                return _dao;
            }
        }

        public ITest CurrentTest
        {
            get;
            set;
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
