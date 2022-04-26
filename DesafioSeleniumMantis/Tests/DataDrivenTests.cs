using DesafioSeleniumMantis.Bases;
using DesafioSeleniumMantis.Pages;
using NUnit.Framework;
using System.Threading;

namespace DataDriven_NetCore_NUnit
{
    public class DataDrivenTests : TestBase 
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        LoginPasswordPage loginPasswordPage;
        MyViewPage myViewPage;
        LoginSelectProjPage loginSelectProjPage;
        BugReportPage bugReportPage;
        ViewPage viewPage;
        #endregion

        [TestCaseSource(typeof(DataDrivenHelpers), "CriarIssues_CSV")] 
        public void CriarIssueUsandoDataDriven(string categoria, string frequencia, string gravidade, string prioridade, string atribuirA, string resumo, string descricao)
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
           

            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);

            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
            
        }

    }
}