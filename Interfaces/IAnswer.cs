using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAnswer
    {
        int ID { get; set; }
        int QuestionID { get; set; }
        string Text { get; set; }
        bool IsCorrect { get; set; }
    }
}
