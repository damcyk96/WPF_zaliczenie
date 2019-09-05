using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DO
{
    public class Test : ITest
    {
        private int _ID;
        private string _text;
        private int _time;
        private int _pointsTotal;

        private int _questionNr;
        private List<IQuestion> _questions;

        public Test(int ID, string text, int time)
        {
            _ID = ID;
            _text = text;
            _time = time;
            _pointsTotal = 0;
            _questions = new List<IQuestion>();
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

        public int Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        public int PointsTotal
        {
            get
            {
                return _pointsTotal;
            }
            set
            {
                _pointsTotal = value;
            }
        }

        public int QuestionNr
        {
            get
            {
                return _questionNr;
            }
            set
            {
                _questionNr = value;
            }
        }

        public List<IQuestion> Questions
        {
            get
            {
                return _questions;
            }
            set
            {
                _questions = value;
            }
        }
    }
}
