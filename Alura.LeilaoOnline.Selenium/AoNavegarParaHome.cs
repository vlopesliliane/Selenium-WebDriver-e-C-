using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System;
using Alura.LeilaoOnline.Selenium.Helpers;

namespace Alura.LeilaoOnline.Selenium
{
    public class AoNavegarParaHome : IDisposable 
    {
        private ChromeDriver driver; 
        
        //Setup Construtor
        public AoNavegarParaHome() {
            
            driver = new ChromeDriver(TesteHelpers.PastaDoExcutavel);

        }

        //TearDown 
        public void Dispose()
        {
            driver.Quit();
        }


        [Fact]
        public void DadoChromeAbertoDeveMostrarLeilõesNoTítulo()
        {
            // arrange - 
            
            // act- 
            driver.Navigate().GoToUrl("http://localhost:5000");

            // assert - 
            Assert.Contains("Leilões", driver.Title);
        }
        [Fact]
        public void DadoChromeAbertoDeveMostrarLeilõesNaPágina()
        {
            // arrange - 

            // act- 
            driver.Navigate().GoToUrl("http://localhost:5000");

            // assert - 
            Assert.Contains("Próximos Leilões", driver.PageSource);


        }

     
    }
}
