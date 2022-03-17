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
    public class ManagerProjectsTests : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        LoginPasswordPage loginPasswordPage;
        MyViewPage myViewPage;
        ManageOverviewPage manageOverviewPage;
        ManageProjPage manageProjPage;
        ManageProjCreatePage manageProjCreatePage;
        ManageProjCatPage manageProjCatPage;
        ManageProjEditPage manageProjEditPage;

        #endregion

        [Test]
        public void CriarNovoProjeto()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            manageOverviewPage = new ManageOverviewPage();
            manageProjPage = new ManageProjPage();
            manageProjCreatePage = new ManageProjCreatePage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string nomeDoProjeto = "Projeto ElvercioNeto11";
            string descricao = "Desafio Selenium Mantis1";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            manageProjPage.CriarNovoProjeto();
            manageProjCreatePage.PreencherDadosNovoProjeto(nomeDoProjeto, descricao);


            Assert.AreEqual(usuario, myViewPage.RetornaUsuarioLogado());
        }

        [Test]
        public void EditarProjeto()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            manageOverviewPage = new ManageOverviewPage();
            manageProjPage = new ManageProjPage();
            manageProjCreatePage = new ManageProjCreatePage();
            manageProjEditPage = new ManageProjEditPage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            //string nomeProjetoBD = null;
            string nomeDoProjeto = "Projeto ElvercioNeto";
            //string nomeDoProjeto = ProjectsDBSteps.RetornarProjeto(nomeProjetoBD);
            string descricao = "Projeto ElvercioNeto";
            string novaDescricao = "Projeto alterado";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            manageProjPage.CriarNovoProjeto();
            manageProjCreatePage.PreencherDadosNovoProjeto(nomeDoProjeto, descricao);
            manageProjPage.ClicarEmProjetoCriado();
            manageProjEditPage.PreencherNovaDescricao(novaDescricao);
            manageProjEditPage.ClicarEmAlterarProjeto();

            Assert.AreEqual(usuario, myViewPage.RetornaUsuarioLogado());
        }
        [Test]
        public void CriarCategoria()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            manageOverviewPage = new ManageOverviewPage();
            manageProjPage = new ManageProjPage();
            manageProjCreatePage = new ManageProjCreatePage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string categoria = "TesteElvercio1";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            manageProjPage.CriarCategoria(categoria);


            Assert.AreEqual(usuario, myViewPage.RetornaUsuarioLogado());
        }
        [Test]
        public void CriarCategoriaVazia()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            manageOverviewPage = new ManageOverviewPage();
            manageProjPage = new ManageProjPage();
            manageProjCreatePage = new ManageProjCreatePage();
            manageProjCatPage = new ManageProjCatPage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string categoria = "";
            string mensagemErro = "APPLICATION ERROR #11";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            manageProjPage.CriarCategoria(categoria);
            manageProjCatPage.RetornaMensagemDeErro();


            Assert.AreEqual(mensagemErro, manageProjCatPage.RetornaMensagemDeErro());
        }
        [Test]
        public void CriarCategoriaDuplicadaUtilizandoBancoDeDados()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            manageOverviewPage = new ManageOverviewPage();
            manageProjPage = new ManageProjPage();
            manageProjCreatePage = new ManageProjCreatePage();
            manageProjCatPage = new ManageProjCatPage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string categoriaBD = null;
            string categoria = ProjectsDBSteps.RetornarCategoriaDuplicada(categoriaBD);
            string mensagemErro = "APPLICATION ERROR #1500";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            manageProjPage.CriarCategoria(categoria);
            manageProjCatPage.RetornaMensagemDeErro();


            Assert.AreEqual(mensagemErro, manageProjCatPage.RetornaMensagemDeErro());
        }


    }
}
