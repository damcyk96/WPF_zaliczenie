using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO : IDAO
    {
        private List<ITest> _tests;
        private List<IQuestion> _questions;
        private List<IAnswer> _answers;

        public DAO()
        {
            MakeTests();
        }

        public IEnumerable<ITest> GetAllTests()
        {
            return _tests;
        }

        public IEnumerable<IQuestion> GetAllQuestions()
        {
            return _questions;
        }

        public IEnumerable<IQuestion> GetQuestions(int testID)
        {
            var selected = (from question in _questions
                where question.TestID == testID
                select question);
            return selected;
        }

        public IEnumerable<IAnswer> GetAllAnswers()
        {
            return _answers;
        }

        public IEnumerable<IAnswer> GetAnswers(int questionID)
        {
            var selected = (from answer in _answers
                where answer.QuestionID == questionID
                select answer);
            return selected;
        }
    
        private void MakeTests()
        {
            //_answers = new List<IAnswer>();
            //using (SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\sqle2012; Initial Catalog=LoginDB; Integrated Security=True;"));
            //{
            //    connection.Open();
            //    string query = "SELECT * FROM dbo.Answer";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                columnData.Add(reader.GetString(0));
            //            }
            //        }
            //    }
            //}
            _answers = new List<IAnswer>()
            {
                new DO.Answer(0, 0, "BOIO", false),
                new DO.Answer(1, 0, "Analiza", false),
                new DO.Answer(2, 0, "P4", true),

                new DO.Answer(3, 1, "Tak", true),
                new DO.Answer(4, 1, "Nie", false),

                new DO.Answer(4, 2, "Tak", true),
                new DO.Answer(5, 2, "Nie", false),

                new DO.Answer(6, 3, "6", false),
                new DO.Answer(7, 3, "7", true),
                new DO.Answer(8, 3, "8", false),

                new DO.Answer(9, 4, "Koleś 1", false),
                new DO.Answer(10, 4, "Koleś 2", false),
                new DO.Answer(11, 4, "Koleś 3", true),

                new DO.Answer(12, 5, "1945", false),
                new DO.Answer(13, 5, "1946", true),
                new DO.Answer(14, 5, "1947", false),

                new DO.Answer(15, 6, "954 km", false),
                new DO.Answer(16, 6, "1402 km", false),
                new DO.Answer(17, 6, "1047 km p", true)
            };

            _questions = new List<IQuestion>()
            {
                new DO.Question(0, 0, "Jak nie nazywa się przedmiot, który zaliczę tym projektem ?", 1),

                new DO.Question(1, 0, "Czy Ziemia jest okrągła?", 1),

                new DO.Question(2, 1, "Czy księżyc krąży wokół Ziemi?", 1),

                new DO.Question(3, 2, "Z iloma krajami graniczy Polska:", 1),
                new DO.Question(4, 2, "Pytanie o ziomka z czego 3 jest git:", 1),
                new DO.Question(5, 2, "Która data jest po środku", 1),
                new DO.Question(6, 2, "Długość Wisły to:", 1),
            };

            _tests = new List<ITest>()
            {
                new DO.Test(0, "Krótki Test 1", 5),
                new DO.Test(1, "Jakiś teścik 2", 5),
                new DO.Test(2, "Teścik 3", 5)
            };

            foreach (var test in _tests)
            {
                foreach (var question in _questions)
                {
                    if (question.TestID == test.ID)
                    {
                        test.Questions.Add(question);
                        test.PointsTotal += question.Points;    
                    }
                }
            }

            foreach (var question in _questions)
            {
                foreach (var answer in _answers)
                {
                    if (answer.QuestionID == question.ID)
                    {
                        // add answer to question
                        question.Answers.Add(answer);
                    }
                }
            }
        }
    }
}
