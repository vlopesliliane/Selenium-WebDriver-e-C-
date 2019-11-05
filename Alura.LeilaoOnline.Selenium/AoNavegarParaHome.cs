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
        public void DadoChromeAbertoDeveMostrarLeil�esNoT�tulo()
        {
            // arrange - 
            
            // act- 
            driver.Navigate().GoToUrl("http://localhost:5000");

            // assert - 
            Assert.Contains("Leil�es", driver.Title);
        }
        [Fact]
        public void DadoChromeAbertoDeveMostrarLeil�esNaP�gina()
        {
            // arrange - 

            // act- 
            driver.Navigate().GoToUrl("http://localhost:5000");

            // assert - 
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);


        }

     
    }
}
