using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using XUnitChallengeMB.Web.Services;

namespace XUnitChallengeMB.Test
{
    public class TestServiceFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public TestServiceFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ICalcService, CalcService>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
