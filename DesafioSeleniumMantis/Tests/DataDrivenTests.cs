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
        LostPasswordPage lostPasswordPage;
        MyViewPage myViewPage;
        LoginSelectProjPage loginSelectProjPage;
        BugReportPage bugReportPage;
        ViewPage viewPage;
        ViewAllBugPage viewAllBugPage;
        QueryStorePage queryStorePage;
        PrintAllBugPage printAllBugPage;
        SummaryPage summaryPage;
        BugUpdatePage bugUpdatePage;
        BugNoteEditPage bugNoteEditPage;
        BugNoteDeletePage bugNoteDeletePage;
        TagAttachPage tagAttachPage;
        BugChangeStatusPage bugChangeStatusPage;
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
            Thread.Sleep(5000);

            //Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
            //Assert.Pass();
        }

        /*
         * [Test]
        public void CriarIssue()
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
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Bug ao tentar gerenciar marcadores";
            string descricao = "Teste Descrição";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            Thread.Sleep(5000);
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
         * */
    }
}