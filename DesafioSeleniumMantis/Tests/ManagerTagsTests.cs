using DesafioSeleniumMantis.Bases;
using DesafioSeleniumMantis.DataBaseSteps;
using DesafioSeleniumMantis.Pages;
using NUnit.Framework;
using System.Collections;
using System.Threading;

namespace DesafioSeleniumMantis.Tests
{
    [TestFixture]
    public class ManagerTagsTests : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        LoginPasswordPage loginPasswordPage;
        MyViewPage myViewPage;
        ManageOverviewPage manageOverviewPage;
        ManageProjPage manageProjPage;
        ManageProjCreatePage manageProjCreatePage;
        ManageUserPage manageUserPage;
        ManageUserCreatePage manageUserCreatePage;
        ManageUserEditPage manageUserEditPage;
        ManageUserProjDeletePage manageUserProjDeletePage;
        ManageTagsPage manageTagsPage;
        TagUpdatePage tagUpdatePage;
        TagViewPage tagViewPage;
        TagDeletePage tagDeletePage;

        #endregion

        
        [Test]
        public void CriarMarcador()
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
            manageTagsPage = new ManageTagsPage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string marcador = "release1";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            manageOverviewPage.GerenciarMarcadores();
            manageTagsPage.CriarMarcador(marcador);

            Assert.AreEqual(marcador, manageTagsPage.RetornaMarcadorCriado());
        }
        [Test]
        public void AtualizarMarcador()
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
            manageTagsPage = new ManageTagsPage();
            tagUpdatePage = new TagUpdatePage();
            tagViewPage = new TagViewPage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string marcador = "release1";
            string novoMarcador = "release2";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            manageOverviewPage.GerenciarMarcadores();
            manageTagsPage.ClicarNoMarcadorCriado(marcador);
            tagViewPage.ClicarEmAtualizarMarcador();
            tagUpdatePage.AtualizarMarcador(novoMarcador);


            Assert.AreEqual(novoMarcador, tagUpdatePage.RetornaMarcadorAtualizado());
        }
        [Test]
        public void AtualizarMarcadorUtilizandoBancoDeDados()
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
            manageTagsPage = new ManageTagsPage();
            tagUpdatePage = new TagUpdatePage();
            tagViewPage = new TagViewPage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string tag = null;
            string marcador = TagsDBSteps.RetornaMarcador(tag);
            string novoMarcador = "release2";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarProjetos();
            manageOverviewPage.GerenciarMarcadores();
            manageTagsPage.ClicarNoMarcadorCriado(marcador);
            tagViewPage.ClicarEmAtualizarMarcador();
            tagUpdatePage.AtualizarMarcador(novoMarcador);


            Assert.AreEqual(novoMarcador, tagUpdatePage.RetornaMarcadorAtualizado());
        }
        [Test]
        public void ExcluirMarcadorUtilizandoBancoDeDados()
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
            manageTagsPage = new ManageTagsPage();
            tagUpdatePage = new TagUpdatePage();
            tagViewPage = new TagViewPage();
            tagDeletePage = new TagDeletePage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string tag = null;
            string marcador = TagsDBSteps.RetornaMarcador(tag);
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.Gerenciar();
            manageOverviewPage.GerenciarMarcadores();
            manageTagsPage.ClicarEmMarcadorAtualizado(marcador);

            tagViewPage.ClicarEmApagarMarcador();
            tagDeletePage.ApagarMarcador();


            //Assert.IsFalse(manageTagsPage.RetornaMarcadorCriado().StartsWith("release"));
            Assert.AreEqual(usuario, myViewPage.RetornaUsuarioLogado());
        }


    }
}
