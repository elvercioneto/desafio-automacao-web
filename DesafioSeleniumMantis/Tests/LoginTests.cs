using DesafioSeleniumMantis.Bases;
using DesafioSeleniumMantis.Pages;
using NUnit.Framework;
using System.Threading;
using DesafioSeleniumMantis.DataBaseSteps;

namespace DesafioSeleniumMantis.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        LoginPasswordPage loginPasswordPage;
        LostPasswordPage lostPasswordPage;
        MyViewPage myViewPage;
        #endregion

        [Test]
        [Property("Priority", 1)]
        [Category("TesteCI")]
        public void RealizarLoginComSucesso()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();

            #region Parameters

            string usuario = "administrator";
            string senha = "elvercioneto";
            #endregion
                        
            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();

            Assert.AreEqual(usuario, myViewPage.RetornaUsuarioLogado());
        }

        [Test]
        public void RealizarLoginComSucessoUsandoBancoDeDados()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();

            #region Parameters
            string username = null;
            string usuario = UsuariosDBSteps.RetornaUsuario(username);
            string senha = "elvercioneto";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();

            Assert.AreEqual(usuario, myViewPage.RetornaUsuarioLogado());
        }

        [Test]
        [Category("TesteCI")]
        public void ExibirMensagemErroLogin()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();

            #region Parameters
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.ClicarEmLogin();
            loginPage.RetornaTextoReajustes();

            Assert.AreEqual(mensagemErro, loginPage.RetornaTextoReajustes());
            Thread.Sleep(10000);
        }
        [Test]
        [Category("TesteCI")]
        public void ExibirMensagemErroLoginCampoVazio()
        {
            loginPage = new LoginPage();

            #region Parameters
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            string usuario = "";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPage.RetornaTextoReajustes();

            Assert.AreEqual(mensagemErro, loginPage.RetornaTextoReajustes());
        }

        [Test]
        public void ExibirMensagemErroSenhaIncorreta()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "123";
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);


            Assert.AreEqual(mensagemErro, loginPage.RetornaTextoReajustes());
        }
        [Test]
        public void ExibirMensagemErroSenhaIncorretaUsandoBancoDeDados()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();

            #region Parameters
            string username = null;
            string usuario = UsuariosDBSteps.RetornaUsuario(username);
            string senha = "123";
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);


            Assert.AreEqual(mensagemErro, loginPage.RetornaTextoReajustes());
            Thread.Sleep(5000);
        }

        [Test]
        public void ExibirMensagemErroSenhaCampoVazio()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "";
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);


            Assert.AreEqual(mensagemErro, loginPage.RetornaTextoReajustes());
        }

        [Test]
        public void VerificarReajusteDeSenhaEmailVazio()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            lostPasswordPage = new LostPasswordPage();


            #region Parameters
            string usuario = "administrator";
            string email = "";
            string mensagemErro = "E-mail inválido.";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.ClicarPerdeuASenha();
            lostPasswordPage.ReajustarSenhaEmailVazio(email);


            Assert.AreEqual(mensagemErro, lostPasswordPage.RetornaMensagemDeErro());
        }
        [Test]
        public void VerificarReajusteDeSenhaEmailInvalido()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            lostPasswordPage = new LostPasswordPage();


            #region Parameters
            string usuario = "administrator";
            string email = "teste";
            string mensagemErro = "E-mail inválido.";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.ClicarPerdeuASenha();
            lostPasswordPage.ReajustarSenhaEmailInvalido(email);


            Assert.AreEqual(mensagemErro, lostPasswordPage.RetornaMensagemDeErro());
        }

    }
}
