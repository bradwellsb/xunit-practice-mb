using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XUnitChallengeMB.Web.Models
{
    public class CalcModel
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Result()
        {
            return Value1 * Value2;
        }
    }
}
