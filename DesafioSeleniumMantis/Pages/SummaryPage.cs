using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class SummaryPage : PageBase
    {
        #region Mapping
        By retornarTitulo = By.XPath("//a[contains(text(),'Resumo')]");

        #endregion

        #region Actions

        public string RetornarTitulo()
        {
            return GetText(retornarTitulo);
        }

            #endregion
            //    public ManageTagsPage ApagarMarcador()
            //    {
            //        ClicarEmApagarMarcador();


            //        return new ManageTagsPage();
            //    }
            //}

        }
    }
