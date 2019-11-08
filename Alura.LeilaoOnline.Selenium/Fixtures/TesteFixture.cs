using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TesteFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //SetUp
        public TesteFixture()
        {
            Driver = new ChromeDriver(TesteHelper.PastaDoExecutavel);
        }


        //TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
