using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmApp.ViewModels
{
    public class TestListViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public TestListViewModel(RootViewModel vm) : base(vm)
        {
            _dao = Parent.DAO;
            _tests = new ObservableCollection<TestViewModel>();

            foreach (var test in _dao.GetAllTests())
            {
                _tests.Add(new TestViewModel(test));
            }

            _startTestCommand = new RelayCommand((param) => this.StartTest());
        }

        private IDAO _dao;

        private ObservableCollection<TestViewModel> _tests;
        public ObservableCollection<TestViewModel> Tests
        {
            get
            {
                return _tests;
            }
            set
            {
                _tests = value;
                RaisePropertyChanged("Tests");
            }
        }

        private TestViewModel _selectedTest;
        public TestViewModel SelectedTest
        {
            get
            {
                return _selectedTest;
            }
            set
            {
                _selectedTest = value;
                RaisePropertyChanged("SelectedTest");
            }
        }

        private RelayCommand _startTestCommand;
        public ICommand StartTestCommand
        {
            get
            {
                return _startTestCommand;
            }
        }

        private void StartTest()
        {
            if (_selectedTest != null)
            {
                Parent.CurrentView = new QuizViewModel(Parent, _selectedTest);
            }
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
