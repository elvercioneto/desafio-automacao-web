using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class BugUpdatePage : PageBase
    {
        #region Mapping
        By categoriaComboBox = By.Id("category_id");
        By frequenciaComboBox = By.Id("reproducibility");
        By gravidadeComboBox = By.Id("severity");
        By prioridadeComboBox = By.Id("priority");
        By atribuirAComboBox = By.Id("handler_id");
        By resumoField = By.Id("summary");
        By descricaoField = By.Id("description");
        By passosParaReproduzirTextArea = By.Id("steps_to_reproduce");
        By informacoesAdicionaisTextArea = By.Id("additional_info");
        By mensagemDeErro = By.XPath("//p[contains(text(),'APPLICATION ERROR #11')]");
        By uploadFileField = By.Id("ufile[]");//investigar
        By criarNovaTarefaButton = By.XPath("//input[@value='Criar Nova Tarefa']");
        By atualizarIssueButton = By.XPath("//input[@value='Atualizar Informação']");
        By adicionarAnotacaoTextArea = By.XPath("//textarea[@id='bugnote_text']");
        By alterarAnotacao = By.XPath("//button[normalize-space()='Alterar']");
        By apagarAnotacao = By.XPath("//button[normalize-space()='Apagar']");
        By anotacao = By.XPath("//td[@class='bugnote-note bugnote-public']");
        By alterarStatusButton = By.XPath("//input[@value='Alterar Status:']");
        By statusComboBox = By.XPath("//select[@name='new_status']");

        #endregion

        #region Actions
        public void SelecionarCategoria(string categoria)
        {
            ComboBoxSelectByVisibleText(categoriaComboBox, categoria);
        }
        public void SelecionarFrequencia(string categoria)
        {
            ComboBoxSelectByVisibleText(frequenciaComboBox, categoria);
        }
        public void SelecionarGravidade(string gravidade)
        {
            ComboBoxSelectByVisibleText(gravidadeComboBox, gravidade);
        }
        public void SelecionarPrioridade(string prioridade)
        {
            ComboBoxSelectByVisibleText(prioridadeComboBox, prioridade);
        }
        public void SelecionarAtribuirA(string atribuir)
        {
            ComboBoxSelectByVisibleText(atribuirAComboBox, atribuir);
        }

        public void PreencherResumo(string resumo)
        {
            SendKeys(resumoField, Keys.Control + "a");
            SendKeys(resumoField, resumo);
        }

        public void PreencherDescricao(string descricao)
        {
            SendKeys(descricaoField, descricao);
        }
        public void PreencherAnotacao(string anotacao)
        {
            SendKeys(adicionarAnotacaoTextArea, anotacao);
        }

        public void InserirAnexo(string caminhoArquivo)
        {
            SendKeysWithoutWaitVisible(uploadFileField, caminhoArquivo);
        }

        public void ClicarEmSubmitReport()
        {
            Click(criarNovaTarefaButton);
        }
        public void ClicarEmAtualizarIssue()
        {
            Click(atualizarIssueButton);
        }
        public void ClicarEmAlterarAnotacao()
        {
            Click(alterarAnotacao);
        }
        public void ClicarEmApagarAnotacao()
        {
            Click(apagarAnotacao);
        }
        public void ApontarParaBotoes()
        {
            MouseOver(anotacao);
        }
        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemDeErro);
        }
        public void ClicarEmAlterarStatus()
        {
            Click(alterarStatusButton);
        }
        public void SelecionarStatus(string status)
        {
            ComboBoxSelectByVisibleText(statusComboBox, status);
        }
        #endregion
        public ViewPage PreencherDadosDaIssue(String categoria, String frequencia, String gravidade, String prioridade, String atribuir, String resumo, String descricao)
        {

            SelecionarCategoria(categoria);
            SelecionarFrequencia(frequencia);
            SelecionarGravidade(gravidade);
            SelecionarPrioridade(prioridade);
            SelecionarAtribuirA(atribuir);
            PreencherResumo(resumo);
            PreencherDescricao(descricao);
            ClicarEmSubmitReport();
            return new ViewPage();
        }
        public BugReportPage PreencherDadosSemInformarCategoria(String frequencia, String gravidade, String prioridade, String atribuir, String resumo, String descricao)
        {

            //SelecionarCategoria(categoria);
            SelecionarFrequencia(frequencia);
            SelecionarGravidade(gravidade);
            SelecionarPrioridade(prioridade);
            SelecionarAtribuirA(atribuir);
            PreencherResumo(resumo);
            PreencherDescricao(descricao);
            ClicarEmSubmitReport();
            return new BugReportPage();
        }
        public BugReportPage AlterarPrioridade(String prioridade, String resumo)
        {

            SelecionarPrioridade(prioridade);
            PreencherResumo(resumo);
            ClicarEmAtualizarIssue();
            return new BugReportPage();
        }
        public BugReportPage AlterarGravidade(String gravidade, String resumo)
        {

            SelecionarGravidade(gravidade);
            PreencherResumo(resumo);
            ClicarEmAtualizarIssue();
            return new BugReportPage();
        }
        public BugReportPage InserirAnotacao(String anotacao, String resumo)
        {

            PreencherResumo(resumo);
            PreencherAnotacao(anotacao);
            ClicarEmAtualizarIssue();
            return new BugReportPage();
        }
        public BugNoteEditPage AlterarAnotacao()
        {

            ApontarParaBotoes();
            ClicarEmAlterarAnotacao();
            return new BugNoteEditPage();
        }
        public BugNoteEditPage ApagarAnotacao()
        {

            ApontarParaBotoes();
            ClicarEmApagarAnotacao();
            return new BugNoteEditPage();
        }
        public TagAttachPage AlterarStatus(String status)
        {

            ClicarEmAlterarStatus();
            SelecionarStatus(status);

            return new TagAttachPage();
        }
    }
}