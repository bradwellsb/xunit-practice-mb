using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitChallengeMB.Web.Models;
using XUnitChallengeMB.Web.Pages;
using XUnitChallengeMB.Web.Services;

namespace XUnitChallengeMB.Test.UnitTests
{
    public class IndexPageTests : IClassFixture<TestServiceFixture>
    {
        private ServiceProvider _serviceProvider;

        public IndexPageTests(TestServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Theory]
        [InlineData(0, 0)]
        public void OnPost_IfNoPreviousResult_ReturnNewModel(int value1, int value2)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var pageModel = new IndexModel(_serviceProvider.GetService<ICalcService>());
                pageModel.CurrentResult = new CalcModel() { Value1 = value1, Value2 = value2 };

                //act
                pageModel.OnPostMultiplyNumbers();

                //assert
                Assert.Equal(new CalcModel().Result(), pageModel.PreviousResult.Result());
            }
        }

    }
}
