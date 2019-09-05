using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDAO
    {
        IEnumerable<ITest> GetAllTests();

        IEnumerable<IQuestion> GetAllQuestions();
        IEnumerable<IQuestion> GetQuestions(int testID);

        IEnumerable<IAnswer> GetAllAnswers();
        IEnumerable<IAnswer> GetAnswers(int questionID);
    }
}
