using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public QuestionViewModel(IQuestion question)
        {
            _question = question;
            _answers = new ObservableCollection<AnswerViewModel>();
            _correctAnswers = new ObservableCollection<AnswerViewModel>();

            foreach (var answer in question.Answers)
            {
                _answers.Add(new AnswerViewModel(answer));
                if (answer.IsCorrect)
                {
                    _correctAnswers.Add(new AnswerViewModel(answer));
                }
            }
        }

        private IQuestion _question;
        public IQuestion question
        {
            get
            {
                return _question;
            }
        }

        public int ID
        {
            get
            {
                return _question.ID;
            }
            set
            {
                _question.ID = value;
                RaisePropertyChanged("ID");
            }
        }

        public int TestID
        {
            get
            {
                return _question.TestID;
            }
            set
            {
                _question.TestID = value;
                RaisePropertyChanged("TestID");
            }
        }

        public string Text
        {
            get
            {
                return _question.Text;
            }
            set
            {
                _question.Text = value;
                RaisePropertyChanged("Text");
            }
        }

        public int Points
        {
            get
            {
                return _question.Points;
            }
            set
            {
                _question.Points = value;
                RaisePropertyChanged("Points");
            }
        }

        public bool ShouldGivePoints
        {
            get
            {
                bool result = true;
                int counter = 0;
                foreach (var answer in _answers)
                {
                    if (answer.IsMarked && answer.IsCorrect)
                    {
                        //_result = true;
                        counter++;
                        Trace.WriteLine("DOBRA odp");
                    }
                    else if (answer.IsMarked && !answer.IsCorrect)
                    {
                        Trace.WriteLine("ZLA odp - zaznaczona niepoprawna odp!");
                        result = false;
                        break;
                    }
                    else if (!answer.IsMarked && answer.IsCorrect)
                    {
                        Trace.WriteLine("ZLA odp - niezaznaczona poprawna odp!");
                        result = false;
                        break;
                    }
                    //if (counter > 1)
                    //{
                    //    Trace.WriteLine("ZLA odp - niezaznaczona poprawna odp!");
                    //    result = false;
                    //}
                }

                return result;
            }
            set
            {
                ShouldGivePoints = value;
                RaisePropertyChanged("ShouldGivePoints");
            }
        }

        private ObservableCollection<AnswerViewModel> _answers;
        public ObservableCollection<AnswerViewModel> Answers
        {
            get
            {
                return _answers;
            }
            set
            {
                _answers = value;
                RaisePropertyChanged("Answers");
            }
        }

        private ObservableCollection<AnswerViewModel> _correctAnswers;
        public ObservableCollection<AnswerViewModel> CorrectAnswers
        {
            get
            {
                return _correctAnswers;
            }
            set
            {
                _correctAnswers = value;
                RaisePropertyChanged("CorrectAnswers");
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
