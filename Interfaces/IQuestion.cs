using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IQuestion
    {
        int ID { get; set; }
        int TestID { get; set; }
        string Text { get; set; }
        int Points { get; set; }

        List<IAnswer> Answers { get; set; }
        List<IAnswer> CorrectAnswers { get; set; }
    }
}
