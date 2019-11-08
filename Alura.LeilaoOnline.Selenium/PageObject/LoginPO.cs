using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObject
{
    public class LoginPO
    {
        private IWebDriver driver;

        private By byFormLogin;
        private By byInputUsuario;
        private By byInputSenha;
        private By byBotaoLogin;
        private By bySpanErroUsuarioVazio;
        private By bySpanErroSenhaVazia;

        public string UsuarioVazioMensagemErro => driver.FindElement(bySpanErroUsuarioVazio).Text;
        public string SenhaVaziaMensagemErro => driver.FindElement(bySpanErroSenhaVazia).Text;


        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;

            byFormLogin = By.TagName("Form");
            byInputUsuario = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
            bySpanErroUsuarioVazio = By.CssSelector("span.msg-erro[data-valmsg-for=Login]");
            bySpanErroSenhaVazia = By.CssSelector("span.msg-erro[data-valmsg-for=Password]");
        }
            public void VisitarPaginaLogin()
            {
                driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
            }

            public void PreencherLogin(
                string usuario,
                string senha) 
            {
                driver.FindElement(byInputUsuario).SendKeys(usuario);
                driver.FindElement(byInputSenha).SendKeys(senha);
            
            }

            public void Logar() 
            {
                driver.FindElement(byBotaoLogin).Click();
            
            }
    }
}
