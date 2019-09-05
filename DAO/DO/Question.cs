using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DO
{
    public class Question : IQuestion
    {
        private int _ID;
        private int _testID;
        private string _text;
        private int _points;

        private List<IAnswer> _answers;
        private List<IAnswer> _correctAnswers;

        public Question(int ID, int testID, string text, int points)
        {
            _ID = ID;
            _testID = testID;
            _text = text;
            _points = points;

            _answers = new List<IAnswer>();
            _correctAnswers = new List<IAnswer>();
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

        public int TestID
        {
            get
            {
                return _testID;
            }
            set
            {
                _testID = value;
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

        public int Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }

        public List<IAnswer> Answers
        {
            get
            {
                return _answers;
            }
            set
            {
                _answers = value;
            }
        }

        public List<IAnswer> CorrectAnswers
        {
            get
            {
                return _correctAnswers;
            }
            set
            {
                _correctAnswers = value;
            }
        }
    }
}
