using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using Xunit;
using Alura.LeilaoOnline.Selenium.PageObject;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {

        private IWebDriver driver;

        
        public AoEfetuarRegistro(TesteFixture fixture)
        {
            driver = fixture.Driver; 
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario("Liliane Lopes", "vlopes.liliane@gmail.com", "123", "123");

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Contains("Obrigado", driver.PageSource);

        }

        [Theory]
        [InlineData("", "vlopes.liliane@gmail.com", "123", "123")]
        [InlineData("Liliane Lopes", "vlopes", "123", "123")]
        [InlineData("", "vlopes.liliane@gmail.com", "123", "125")]
        [InlineData("", "vlopes.liliane@gmail.com", "123", "")]
        
        public void DadoInfoInvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmaSenha)
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome, email, senha, confirmaSenha);

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Contains("section-registro", driver.PageSource);

        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //act
            registroPO.SubmeteFormulario();

            //assert - 
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "",
                email: "daniel",
                senha: "",
                confirmaSenha: ""
             );

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }

    }
}

