using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITest
    {
        int ID { get; set; }
        string Text { get; set; }
        int Time { get; set; }
        int PointsTotal { get; set; }

        int QuestionNr { get; set; }
        List<IQuestion> Questions { get; set; }
    }
}
