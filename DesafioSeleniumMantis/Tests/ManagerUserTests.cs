using DesafioSeleniumMantis.Bases;
using DesafioSeleniumMantis.DataBaseSteps;
using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Pages;
using NUnit.Framework;
using System.Collections;
using System.Threading;

namespace DesafioSeleniumMantis.Tests
{
    [TestFixture]
    public class ManagerUserTests : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        LoginPasswordPage loginPasswordPage;
        MyViewPage myViewPage;
        ManageOverviewPage manageOverviewPage;
        ManageUserPage manageUserPage;
        ManageUserCreatePage manageUserCreatePage;
        ManageUserEditPage manageUserEditPage;
        ManageProjPage manageProjPage;
        ManageProjCreatePage manageProjCreatePage;
        ManageUserProjDeletePage manageUserProjDeletePage;


        #endregion

        [Test]
        public void CriarUsuario()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            manageOverviewPage = new ManageOverviewPage();
            manageProjPage = new ManageProjPage();
            manageProjCreatePage = new ManageProjCreatePage();
            manageUserPage = new ManageUserPage();
            manageUserCreatePage = new ManageUserCreatePage();
            


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            //string id = GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string nomeUsuario = "tester";//+id;
            string mensagemSucesso = "Clique aqui para prosseguir";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarUsuarios();
            manageUserPage.ClicarEmCriarNovaConta();
            manageUserCreatePage.CriarNovoUsuario(nomeUsuario);


            Assert.AreEqual(mensagemSucesso, manageUserCreatePage.RetornaAlertaDeSucesso());
        }
        [Test]
        public void CriarUsuarioRepetidoUtilizandoBancoDeDados()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            manageOverviewPage = new ManageOverviewPage();
            manageProjPage = new ManageProjPage();
            manageProjCreatePage = new ManageProjCreatePage();
            manageUserPage = new ManageUserPage();
            manageUserCreatePage = new ManageUserCreatePage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string nomeUsuarioBD = null;
            string nomeUsuario = UsuariosDBSteps.RetornaUsuarioRepetido(nomeUsuarioBD);
            string mensagemErro = "APPLICATION ERROR #800";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarUsuarios();
            manageUserPage.ClicarEmCriarNovaConta();
            manageUserCreatePage.CriarNovoUsuario(nomeUsuario);


            Assert.AreEqual(mensagemErro, manageUserCreatePage.RetornaAlertaDeErro());
        }

        [Test]
        public void AtribuirUsuarioAoProjeto()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            manageOverviewPage = new ManageOverviewPage();
            manageProjPage = new ManageProjPage();
            manageProjCreatePage = new ManageProjCreatePage();
            manageUserPage = new ManageUserPage();
            manageUserCreatePage = new ManageUserCreatePage();
            manageUserEditPage = new ManageUserEditPage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string nomeDoProjeto = "Projeto ElvercioNeto";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            myViewPage.SelecionarProjetoCriado();
            manageOverviewPage.GerenciarUsuarios();

            manageUserPage.EscolherUsuarioCriado();
            manageUserEditPage.AtribuirUsuarioAoProjeto(nomeDoProjeto);


           Assert.AreEqual(usuario, myViewPage.RetornaUsuarioLogado());
        }


        [Test]
        public void RemoverUsuarioDeUmProjeto()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            manageOverviewPage = new ManageOverviewPage();
            manageProjPage = new ManageProjPage();
            manageProjCreatePage = new ManageProjCreatePage();
            manageUserPage = new ManageUserPage();
            manageUserCreatePage = new ManageUserCreatePage();
            manageUserEditPage = new ManageUserEditPage();
            manageUserProjDeletePage = new ManageUserProjDeletePage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            myViewPage.SelecionarProjetoCriado();
            manageOverviewPage.GerenciarUsuarios();

            manageUserPage.EscolherUsuarioCriado();
            manageUserEditPage.RemoverUsuarioDoProjeto();
            manageUserProjDeletePage.ClicarEmRemoverUsuario();



           Assert.AreEqual(usuario, myViewPage.RetornaUsuarioLogado());
        }
        


    }
}
