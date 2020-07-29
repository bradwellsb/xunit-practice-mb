using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitChallengeMB.Web.Models;
using XUnitChallengeMB.Web.Services;

namespace XUnitChallengeMB.Test.UnitTests
{    
    public class CalcServiceTests
    {
        ICalcService calcService = new CalcService();

        [Theory]
        [InlineData(1, 2)]
        public void StoreResults_StoresResult_InMemory(int value1, int value2)
        {
            CalcModel calculation = new CalcModel() { Value1 = value1, Value2 = value2 };
            calcService.StoreResult(calculation);
            
            //should break this into two different tests. One for store, one for fetch
            Assert.Equal(2, calcService.GetPreviousResult().Result());
        }
    }
}
