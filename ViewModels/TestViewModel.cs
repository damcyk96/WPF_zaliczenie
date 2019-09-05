using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public TestViewModel(ITest test)
        {
            _test = test;
            _testResult = 0;

            _questions = new ObservableCollection<QuestionViewModel>();

            foreach (var question in test.Questions)
            {
                _testResult += question.Points;
                _questionCount++;
                _questions.Add(new QuestionViewModel(question));
            }
        }

        private int _questionCount;
        public int QuestionCount
        {
            get
            {
                return _questionCount;
            }
        }

        private int _pointsTotal;
        public int PointsTotal
        {
            get
            {
                return _test.PointsTotal;
            }
        }

        private int _testResult;
        public int TestResult
        {
            get
            {
                foreach (var question in _test.Questions)
                {
                    _testResult += question.Points;
                }
                return _testResult;
            }
            set
            {
                _testResult = value;
                RaisePropertyChanged("TestResult");
            }
        }

        private ITest _test;
        public ITest Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
            }
        }

        private int _id;
        public int ID
        {
            get
            {
                return _test.ID;
            }
        }

        private int _time;
        public int Time
        {
            get
            {
                return _test.Time;
            }
        }

        private ObservableCollection<QuestionViewModel> _questions;
        public ObservableCollection<QuestionViewModel> Questions
        {
            get {
                return _questions;
            }
            set
            {
                _questions = value;
                RaisePropertyChanged("Questions");
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
