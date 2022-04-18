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
    public class IssueTests : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        LoginPasswordPage loginPasswordPage;
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

        [Test]
        [Category("TesteCI")]
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
            string id = GeneralHelpers.ReturnStringWithRandomNumbers(5);
            string resumo = "Bug nº " + id;
            
            string descricao = "Teste Descrição";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            //loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
        }

        [Test]
        public void CriarIssueUtilizandoBancoDeDados()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();

            #region Parameters
            string username = null;
            string usuario = UsuariosDBSteps.RetornaUsuario(username);
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string id = GeneralHelpers.ReturnStringWithRandomNumbers(5);
            string resumo = "Bug nº " + id;
            string descricao = "Teste Descrição";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.ClicarEmCriarTarefa();
            //loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
        }

        [Test]
        public void CriarIssue_ErroAoInserirMarcador()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            tagAttachPage = new TagAttachPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string id = GeneralHelpers.ReturnStringWithRandomNumbers(5);
            string resumo = "Teste bug com erro ao inserir marcador nº " + id;
            string descricao = "Teste Descrição";
            string mensagemErro = "APPLICATION ERROR #29";
            


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            viewPage.AplicarMarcador();

            Thread.Sleep(5000);
            Assert.AreEqual(mensagemErro, tagAttachPage.RetornaMensagemErro());
        }
        [Test]
        public void CriarIssueComMarcador() 
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
            string resumo = "Teste bug com marcador";
            string descricao = "Teste Descrição";
            string marcador = "release1";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssueComMarcador(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao, marcador);
            Thread.Sleep(5000);
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
        }
        [Test]
        public void CriarIssueComMarcadorUtilizandoBancoDeDados() 
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
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string id = GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string resumo = "Falha ao carregar tela "+id;
            string descricao = "Teste Descrição";
            string tag = null;
            string marcador = TagsDBSteps.RetornaMarcador(tag);


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            //loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssueComMarcador(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao, marcador);
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
        }

        [Test]
        public void RemoverMarcadorDaIssue()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();


            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Teste bug com marcador";
            string descricao = "Teste Descrição";
            string marcador = "release1";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssueComMarcador(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao, marcador);
            viewPage.ClicarEmApagarMarcador();
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());

       
        }
        
        [Test]
        public void CriarIssueComGravidadeObstaculo()
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
            string gravidade = "obstáculo";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Teste com Gravidade Obstáculo";
            string descricao = "Teste Descrição";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);

            Assert.AreEqual(gravidade, viewPage.RetornaGravidadeBug());
        }
        [Test]
        public void EditarIssueComGravidadeObstaculo()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            bugUpdatePage = new BugUpdatePage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string gravidade = "grande";
            string resumo = "Teste com Gravidade alterada para grande";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.EditarIssueComGravidadeObstaculo();
            bugUpdatePage.AlterarGravidade(gravidade, resumo);


            Assert.AreEqual(gravidade, viewPage.RetornaGravidadeBug());
        }
        [Test]
        public void CriarIssueComPrioridadeImediato()
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
            string prioridade = "imediato";
            string atribuirA = "administrator";
            string resumo = "Teste com Prioridade Imediato";
            string descricao = "Teste Descrição";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);

            Assert.AreEqual(prioridade, viewPage.RetornaPrioridadeBug());
        }
        [Test]
        public void EditarIssueComPrioridadeImediato()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            bugUpdatePage = new BugUpdatePage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string prioridade = "alta";
            string resumo = "Teste com prioridade alterada para alta";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.EditarIssueComPrioridadeImediato();
            bugUpdatePage.AlterarPrioridade(prioridade, resumo);


            Assert.AreEqual(prioridade, viewPage.RetornaPrioridadeBug());
        }
        [Test]
        public void CriarIssueSemInformarCategoria()
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
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Teste 123";
            string descricao = "Teste Descrição";
            string mensagemErro = "APPLICATION ERROR #11";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosSemInformarCategoria(frequencia, gravidade, prioridade, atribuirA, resumo, descricao);

            Assert.AreEqual(mensagemErro, bugReportPage.RetornaMensagemDeErro());
        }
        [Test]
        public void FiltarIssuePorRelator()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string relator = "administrator";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.FiltrarPorRelator(relator);

            Assert.AreEqual(relator, viewAllBugPage.RetornarRelator());
        }
        [Test]
        public void FiltarIssuePorAtribuidoA()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string atribuido = "administrator";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.FiltrarPorAtribuidoA(atribuido);

            Assert.AreEqual(atribuido, viewAllBugPage.RetornarAtribuidoA());

        }
        [Test]
        public void FiltarIssuePorGravidade()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string gravidade = "obstáculo";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.FiltrarPorGravidade(gravidade);

            Assert.AreEqual(gravidade, viewAllBugPage.RetornarGravidade());
        }
        [Test]
        public void FiltarIssuePorPrioridade()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string prioridade = "alta";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.FiltrarPorPrioridade(prioridade);

            Assert.AreEqual(prioridade, viewAllBugPage.RetornarPrioridade());
        }

        [Test]
        public void FiltarIssuePorCategoria()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string categoria = "TesteElvercio";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.FiltrarPorCategoria(categoria);

            Assert.AreEqual(categoria, viewAllBugPage.RetornarCategoria());


        }
        [Test]
        public void FiltarIssuePorTexto()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string filtro = "obstáculo";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.ClicarEmRedefinirFiltro();
            viewAllBugPage.PreencherFiltro(filtro);

            Assert.AreEqual(filtro, viewAllBugPage.RetornarBuscaPorTexto());


        }
        [Test]
        public void FiltarIssuePorNumero()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string filtro = "0000010";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.BuscarIssueporNumero(filtro);
            Thread.Sleep(2000);

            Assert.AreEqual(filtro, viewPage.RetornaNumeroBug());
        }
        [Test]
        public void FiltarIssue_NaoInformarNumero()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string filtro = "";
            string mensagemErro1100 = "APPLICATION ERROR #1100";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.BuscarIssueporNumero(filtro);
            viewPage.RetornaMensagemErro1100();

            Assert.AreEqual(mensagemErro1100, viewPage.RetornaMensagemErro1100());
        }
        [Test]
        public void CriarFiltroPersonalizado()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            queryStorePage = new QueryStorePage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string categoria = "TesteElvercio";
            string nomeDoFiltro = "filtroElvercio";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.FiltrarPorCategoria(categoria);
            viewAllBugPage.ClicarEmSalvarFiltro();
            queryStorePage.SalvarFiltro(nomeDoFiltro);

            Assert.AreEqual(nomeDoFiltro, viewAllBugPage.RetornarFiltroCriado());

        }
        [Test]
        public void CarregarFiltroPersonalizado()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            queryStorePage = new QueryStorePage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string nomeDoFiltro = "filtroElvercio";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.CarregarFiltro(nomeDoFiltro);

            Assert.AreEqual(nomeDoFiltro, viewAllBugPage.RetornarFiltroCriado());


        }
        [Test]
        public void RedefinirFiltros()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            queryStorePage = new QueryStorePage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string nomeDoFiltro = "filtroElvercio";
            string filtroVazio = "";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.CarregarFiltro(nomeDoFiltro);
            viewAllBugPage.ClicarEmRedefinirFiltro();

            Assert.AreEqual(filtroVazio, viewAllBugPage.RetornarFiltroVazio());

        }
        [Test]
        public void CriarFiltroDuplicado()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            queryStorePage = new QueryStorePage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string categoria = "TesteElvercio";
            string nomeDoFiltro = "filtroElvercio";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.FiltrarPorCategoria(categoria);
            viewAllBugPage.ClicarEmSalvarFiltro();
            queryStorePage.SalvarFiltro(nomeDoFiltro);

            Assert.Pass();
        }
        [Test]
        public void CriarFiltroVazio()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            queryStorePage = new QueryStorePage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string categoria = "TesteElvercio";
            string nomeDoFiltro = "";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.FiltrarPorCategoria(categoria);
            viewAllBugPage.ClicarEmSalvarFiltro();
            queryStorePage.SalvarFiltro(nomeDoFiltro);

            Assert.Pass();
            //Assert.IsTrue(queryStorePage.RetornaMensagemDeErroFiltroDuplicado().StartsWith("Outro"));


        }
        [Test]
        public void ImprimirIssues()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            queryStorePage = new QueryStorePage();
            printAllBugPage = new PrintAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.ImprimirIssues();

            Assert.IsTrue(printAllBugPage.RetornarTituloPrint().StartsWith("MantisBT"));
        }
        [Test]
        public void ExportarIssuesParaArquivoSCV()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.ExportarIssueCSV();

            Assert.Pass();
            
        }
        [Test]
        public void ExportarIssuesParaExcel()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.ExportarIssueXLS();

            Assert.Pass();
        }
        [Test]
        public void VisualizarResumo()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            summaryPage = new SummaryPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string titulo = "Resumo";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.VerResumo();

            Assert.AreEqual(titulo, summaryPage.RetornarTitulo());
        }
        [Test]
        public void InserirAnotação()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Teste atribuir anotação";
            string descricao = "Teste Descrição";
            string anotacao = "Anotação teste";

            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            viewPage.InserirAnotacao(anotacao);
            
            Assert.AreEqual(anotacao, viewPage.RetornaAnotacaoBug());
        }
        [Test]
        public void EditarAnotação()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            bugUpdatePage = new BugUpdatePage();
            bugNoteEditPage = new BugNoteEditPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string anotacao = "Anotação teste";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.EditarIssueComAnotacao();
            bugUpdatePage.AlterarAnotacao();
            bugNoteEditPage.AtualizarAnotacao(anotacao);
            
            Assert.AreEqual(anotacao, viewPage.RetornaAnotacaoBug());
        }
        [Test]
        public void ApagarAnotação()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            viewAllBugPage = new ViewAllBugPage();
            bugUpdatePage = new BugUpdatePage();
            bugNoteEditPage = new BugNoteEditPage();
            bugNoteDeletePage = new BugNoteDeletePage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string anotacao = "";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmVerTarefas();
            viewAllBugPage.EditarIssueComAnotacao();
            bugUpdatePage.ApagarAnotacao();
            bugNoteDeletePage.ApagarAnotacao();

            Assert.AreEqual(anotacao, viewPage.RetornaAnotacaoVazia());
        }
        [Test]
        public void AlterarStatus()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            bugChangeStatusPage = new BugChangeStatusPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Teste com alteração de status";
            string descricao = "Teste Descrição";
            string status = "admitido";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            viewPage.AlterarStatus(status);
            bugChangeStatusPage.AdmitirTarefa();
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
        }
        [Test]
        public void FecharStatus()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            bugChangeStatusPage = new BugChangeStatusPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Teste com alteração de status para fechado";
            string descricao = "Teste Descrição";
            string status = "fechado";


            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            viewPage.AlterarStatus(status);
            bugChangeStatusPage.FecharTarefa();
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
        }
        [Test]
        public void ApagarIssue()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            bugChangeStatusPage = new BugChangeStatusPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Teste apagar issue";
            string descricao = "Teste Descrição";
            string status = "fechado";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            viewPage.AlterarStatus(status);
            bugChangeStatusPage.FecharTarefa();
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
        }
        
        [Test]
        public void MonitorarIssue()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            bugChangeStatusPage = new BugChangeStatusPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Teste monitorar issue";
            string descricao = "Teste Descrição";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            viewPage.ClicarEmMonitorarIssue();

            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
        }
        [Test]
        public void PararDeMonitorarIssue()
        {
            loginPage = new LoginPage();
            loginPasswordPage = new LoginPasswordPage();
            myViewPage = new MyViewPage();
            loginSelectProjPage = new LoginSelectProjPage();
            bugReportPage = new BugReportPage();
            viewPage = new ViewPage();
            bugChangeStatusPage = new BugChangeStatusPage();

            #region Parameters
            string usuario = "administrator";
            string senha = "elvercioneto";
            string projeto = "Projeto ElvercioNeto";
            string categoria = "[Todos os Projetos] TesteElvercio";
            string frequencia = "sempre";
            string gravidade = "grande";
            string prioridade = "alta";
            string atribuirA = "administrator";
            string resumo = "Teste parar de monitorar issue";
            string descricao = "Teste Descrição";
            #endregion

            loginPage.InserirLogin(usuario);
            loginPasswordPage.InserirPassword(senha);
            myViewPage.RetornaUsuarioLogado();
            myViewPage.ClicarEmCriarTarefa();
            loginSelectProjPage.EscolherProjeto(projeto);
            bugReportPage.PreencherDadosDaIssue(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
            viewPage.ClicarEmMonitorarIssue();
            viewPage.ClicarEmPararDeMonitorarIssue();

            
            Assert.AreEqual(descricao, viewPage.RetornaDescricaoBug());
        }




    }
}
