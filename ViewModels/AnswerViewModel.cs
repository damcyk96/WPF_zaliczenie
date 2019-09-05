using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
    public class AnswerViewModel : INotifyPropertyChanged
    {
        public AnswerViewModel(IAnswer answer)
        {
            _answer = answer;
        }

        private IAnswer _answer;
        public IAnswer Answer
        {
            get
            {
                return _answer;
            }
        }

        public int ID
        {
            get
            {
                return _answer.ID;
            }
            set
            {
                _answer.ID = value;
                RaisePropertyChanged("ID");
            }
        }

        public int QuestionID
        {
            get { return _answer.QuestionID; }
            set
            {
                _answer.QuestionID = value;
                RaisePropertyChanged("QuestionID");
            }
        }

        public string Text
        {
            get
            {
                return _answer.Text;
            }
            set
            {
                _answer.Text = value;
                RaisePropertyChanged("Text");
            }
        }

        public bool IsCorrect
        {
            get { return _answer.IsCorrect; }
            set
            {
                _answer.IsCorrect = value;
                RaisePropertyChanged("IsCorrect");
            }
        }

        private bool _isMarked;
        public bool IsMarked
        {
            get
            {
                return _isMarked;
            }
            set
            {
                _isMarked = value;
                RaisePropertyChanged("IsMarked");
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
