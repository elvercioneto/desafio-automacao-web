using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class TagDeletePage : PageBase
    {
        #region Mapping
        By apagarMarcadorButton = By.XPath("//input[@value='Apagar Marcador']");
       
        #endregion

        #region Actions

        public void ClicarEmApagarMarcador()
        {
            Click(apagarMarcadorButton);
        }
        
        #endregion
        public ManageTagsPage ApagarMarcador()
        {
            ClicarEmApagarMarcador();
            

            return new ManageTagsPage();
        }
    }
       

}
