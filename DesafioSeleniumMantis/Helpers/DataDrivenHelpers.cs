using System;
using System.Collections.Generic;
using System.IO;
using DesafioSeleniumMantis.Helpers;
using NUnit.Framework;

namespace DataDriven_NetCore_NUnit
{
    public class DataDrivenHelpers
    {


        public static List<TestCaseData> CriarIssues_CSV 
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(GeneralHelpers.GetProjectPath() + @"\DataDriven\Files\Issues.csv")) 
                using (var sr = new StreamReader(fs))
                {
                    string headerLine = sr.ReadLine();

                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();

                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            string categoria = Convert.ToString(split[0]); 
                            string frequencia = Convert.ToString(split[1]); 
                            string gravidade = Convert.ToString(split[2]); 
                            string prioridade = Convert.ToString(split[3]); 
                            string atribuirA = Convert.ToString(split[4]); 
                            string resumo = Convert.ToString(split[5]); 
                            string descricao = Convert.ToString(split[6]); 

                            var testCase = new TestCaseData(categoria, frequencia, gravidade, prioridade, atribuirA, resumo, descricao);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }


        //static object[] PersonData =
        //{
        //    new object[] { "Irene J. Hunt", "1156736694" },  //TestCase1
        //    new object[] { "Michael D. Young", "8056736694"} //TestCase2
        //};




    }
}