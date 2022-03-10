using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class BugReportPage : PageBase
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
        By marcadorComboBox = By.XPath("//select[@id='tag_select']"); 
        By uploadFileField = By.Id("ufile[]");//investigar
        By criarNovaTarefaButton = By.XPath("//input[@value='Criar Nova Tarefa']");
        #endregion

        #region Actions
        public void SelecionarCategoria(string categoria)
        {
            ComboBoxSelectByVisibleText(categoriaComboBox, categoria);
        }
        public void SelecionarFrequencia(string frequencia)
        {
            ComboBoxSelectByVisibleText(frequenciaComboBox, frequencia);
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
            SendKeys(resumoField, resumo);
        }

        public void PreencherDescricao(string descricao)
        {
            SendKeys(descricaoField, descricao);
        }
        public void SelecionarMarcador(string marcador)
        {
            ComboBoxSelectByVisibleText(marcadorComboBox, marcador);
        }

        public void InserirAnexo(string caminhoArquivo)
        {
            SendKeysWithoutWaitVisible(uploadFileField, caminhoArquivo);
        }

        public void ClicarEmSubmitReport()
        {
            Click(criarNovaTarefaButton);
        }
        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemDeErro);
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
        public ViewPage PreencherDadosDaIssueComMarcador(String categoria, String frequencia, String gravidade, String prioridade, String atribuir, String resumo, String descricao, String marcador)
        {

            SelecionarCategoria(categoria);
            SelecionarFrequencia(frequencia);
            SelecionarGravidade(gravidade);
            SelecionarPrioridade(prioridade);
            SelecionarAtribuirA(atribuir);
            PreencherResumo(resumo);
            PreencherDescricao(descricao);
            SelecionarMarcador(marcador);
            ClicarEmSubmitReport();
            return new ViewPage();
        }
    }
}