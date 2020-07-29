using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitChallengeMB.Web.Models;

namespace XUnitChallengeMB.Test.UnitTests
{
    public class CalcModelTests
    {
        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        public void OnValue1Value2_ReturnMultipliedResult(int value1, int value2, int expectedResult)
        {
            //act
            CalcModel calcModel = new CalcModel() { Value1 = value1, Value2 = value2 };

            //assert
            Assert.Equal(expectedResult, calcModel.Result());
        }
    }
}
