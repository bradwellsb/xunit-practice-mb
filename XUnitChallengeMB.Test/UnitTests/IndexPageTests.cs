using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        [Fact]
        public void OnPost_IfInvalidModel_ReturnBadRequest()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //arrange
                var pageModel = new IndexModel(_serviceProvider.GetService<ICalcService>());                

                //act
                pageModel.ModelState.AddModelError("Error", "Description");
                var result = pageModel.OnPostMultiplyNumbers();

                //assert
                Assert.IsType<BadRequestResult>(result);            
            }
        }

        [Fact]
        public void OnPost_IfValidModel_ReturnPage()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //arrange
                var pageModel = new IndexModel(_serviceProvider.GetService<ICalcService>());

                //act                
                var result = pageModel.OnPostMultiplyNumbers();

                //assert
                Assert.IsType<PageResult>(result);
            }
        }

    }
}
