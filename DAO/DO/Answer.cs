using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DO
{
    public class Answer : IAnswer
    {
        private int _ID;
        private int _questionID;
        private string _text;
        private bool _isCorrect;

        public Answer(int ID, int questionID, string text, bool isCorrect)
        {
            _ID = ID;
            _questionID = questionID;
            _text = text;
            _isCorrect = isCorrect;
        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public int QuestionID
        {
            get
            {
                return _questionID;
            }
            set
            {
                _questionID = value;
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public bool IsCorrect
        {
            get
            {
                return _isCorrect;
            }
            set
            {
                _isCorrect = value;
            }
        }
    }
}
