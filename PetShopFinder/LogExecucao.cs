using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace PetShopFinder
{
    public class LogExecucao
    {
        #region Atributos

        private string dataHoraExecucao;
        private string chave;
        private string estabelecimento;
        private string nomeEstado;
        private string nomeCidade;
        private string nomeBairro;
        private int requisicoesEfetuadas;
        private int registrosImportados;

        #endregion


        #region Propriedades

        public string DataHoraExecucao
        {
            get { return dataHoraExecucao; }
            set { dataHoraExecucao = value; }
        }            

        public string Chave
        {
            get { return chave; }
            set { chave = value; }
        }

        public string Estabelecimento
        {
            get { return estabelecimento; }
            set { estabelecimento = value; }
        }

        public string NomeEstado
        {
            get { return nomeEstado; }
            set { nomeEstado = value; }
        }

        public string NomeCidade
        {
            get { return nomeCidade; }
            set { nomeCidade = value; }
        }

        public string NomeBairro
        {
            get { return nomeBairro; }
            set { nomeBairro = value; }
        }

        public int RequisicoesEfetuadas
        {
            get { return requisicoesEfetuadas; }
            set { requisicoesEfetuadas = value; }
        }

        public int RegistrosImportados
        {
            get { return registrosImportados; }
            set { registrosImportados = value; }
        }
        
        #endregion


        #region Métodos

        public static List<LogExecucao> ListarLogExecucao()
        {
            List<LogExecucao> logsexecucao = new List<LogExecucao>();
            XElement xml = XElement.Load("LogExecucao.xml");
            foreach (XElement x in xml.Elements())
            {
                LogExecucao log = new LogExecucao()
                {
                    dataHoraExecucao = x.Attribute("dataHoraExecucao").Value,
                    chave = x.Attribute("chave").Value,
                    estabelecimento = x.Attribute("estabelecimento").Value,
                    nomeEstado = x.Attribute("nomeEstado").Value,
                    nomeCidade = x.Attribute("nomeCidade").Value,
                    nomeBairro = x.Attribute("nomeBairro").Value,
                    requisicoesEfetuadas = int.Parse(x.Attribute("requisicoesEfetuadas").Value),
                    registrosImportados = int.Parse(x.Attribute("registrosImportados").Value)
                };
                logsexecucao.Add(log);
            }
            return logsexecucao.OrderByDescending(log => log.dataHoraExecucao).ToList();
        }

        public static XElement ListarUltimoLogExecucao()
        {
            XElement xml = XElement.Load("LogExecucao.xml");
            return xml.Descendants("LogExecucao").Reverse().Take(1).FirstOrDefault();
        }

        public static string IncluirLogExecucao(LogExecucao log)
        {

            XElement x = new XElement("LogExecucao");
            try
            {
                x.Add(new XAttribute("dataHoraExecucao", log.dataHoraExecucao.ToString()));
                x.Add(new XAttribute("chave", log.chave));
                x.Add(new XAttribute("estabelecimento", log.estabelecimento));
                x.Add(new XAttribute("nomeEstado", log.nomeEstado));
                x.Add(new XAttribute("nomeCidade", log.nomeCidade));
                x.Add(new XAttribute("nomeBairro", log.nomeBairro));
                x.Add(new XAttribute("requisicoesEfetuadas", log.requisicoesEfetuadas));
                x.Add(new XAttribute("registrosImportados", log.registrosImportados));
                XElement xml = XElement.Load("LogExecucao.xml");
                xml.Add(x);
                xml.Save("LogExecucao.xml");

                return xml.ToString();
            }
            catch { }

            return x.ToString();
        }

        public static void LimparLogExecucao()
        {
            XElement xml = XElement.Load("LogExecucao.xml");
            xml.RemoveAll();
            xml.Save("LogExecucao.xml");
        }
               
        #endregion
    }
}
