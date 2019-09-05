using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvmApp.ViewModels
{
    public class QuizViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public QuizViewModel(RootViewModel vm, TestViewModel testvm) : base (vm)
        {
            Test = testvm.Test;
            TestViewModel = testvm;
            _currentQuestion = testvm.Questions.FirstOrDefault();       //TODO: here is null?

            _questionCounter = 0;

            _nextQuestionCommand = new RelayCommand((param) => this.NextQuestion());
        }

        private int _questionCounter;
        private int _quizResult = 0;

        public ITest Test { get; set; }
        public TestViewModel TestViewModel { get; set; }

        private QuestionViewModel _currentQuestion;
        public QuestionViewModel CurrentQuestion
        {
            get
            {
                return _currentQuestion;
            }
            set
            {
                _currentQuestion = value;
                RaisePropertyChanged("CurrentQuestion");
            }
        }

        private RelayCommand _nextQuestionCommand;
        public ICommand NextQuestionCommand
        {
            get
            {
                return _nextQuestionCommand;
            }
        }

        private void NextQuestion()
        {
            _questionCounter += 1;

            // zlicz wynik
            if (_currentQuestion.ShouldGivePoints)
            {
                _quizResult += _currentQuestion.Points;
            }
            
            // w zależności od tego czy są jeszcze pytania....
            if (_questionCounter >= TestViewModel.Questions.Count)
            {
                // zakończ test
                MessageBoxResult result = MessageBox.Show(
                    "Gratulacje, twój wynik to: " + _quizResult + " / " + Test.PointsTotal + " pkt",
                    "Wynik testu", MessageBoxButton.OK
                    );

                Parent.CurrentView = new TestListViewModel(Parent);

            }
            else
            {
                // przejdź do następnego pytania
                CurrentQuestion = TestViewModel.Questions.ElementAt(_questionCounter);
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
