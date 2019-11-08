using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Xunit;
using Alura.LeilaoOnline.Selenium.PageObject;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        IWebDriver driver;

        public AoEfetuarLogin(TesteFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveDirecionarParaDashboard()
        {

            //Arrange 
            var registroLogin = new LoginPO(driver);
            registroLogin.VisitarPaginaLogin();

            //Act 
            registroLogin.PreencherLogin("fulano@example.org", "123");
            registroLogin.Logar();

            //Assert 
            Assert.Contains("Dashboard", driver.PageSource);
        }

        [Fact]
        public void DadoCampoUsuarioVazioDeveMonstrarMensagemDeErro()
        {

            //Arrange 
            var registroLogin = new LoginPO(driver);
            registroLogin.VisitarPaginaLogin();

            //Act 
            registroLogin.PreencherLogin("", "123");
            registroLogin.Logar();

            //Assert 
            Assert.Equal("The Usuário field is required.", registroLogin.UsuarioVazioMensagemErro);
        }

        [Fact]
        public void DadoCampoUsuarioInvalidoDeveMonstrarMensagemDeErro()
        {

            //Arrange 
            var registroLogin = new LoginPO(driver);
            registroLogin.VisitarPaginaLogin();

            //Act 
            registroLogin.PreencherLogin("Liliane", "123");
            registroLogin.Logar();

            //Assert 
            Assert.Equal("The Usuário field is required.", registroLogin.UsuarioVazioMensagemErro);
        }

        [Fact]
        public void DadoCampoSenhaVazioDeveMonstrarMensagemDeErro()
        {

            //Arrange 
            var registroLogin = new LoginPO(driver);
            registroLogin.VisitarPaginaLogin();

            //Act 
            registroLogin.PreencherLogin("fulano@example.org", "");
            registroLogin.Logar();

            //Assert 
            Assert.Equal("The Senha field is required.", registroLogin.SenhaVaziaMensagemErro);
        }
    }
}
