using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XUnitChallengeMB.Web.Models;

namespace XUnitChallengeMB.Web.Services
{    
    public interface ICalcService
    {
        void StoreResult(CalcModel calcModel);
        CalcModel GetPreviousResult();
    }
    public class CalcService : ICalcService
    {
        public CalcModel PreviousResult { get; set; }
        public void StoreResult(CalcModel result)
        {
            PreviousResult = result;
        }

        public CalcModel GetPreviousResult()
        {
            if (PreviousResult != null)
                return PreviousResult;
            else
                return new CalcModel();
        }
    }
}
