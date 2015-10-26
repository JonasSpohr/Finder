using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace PetShopFinder
{
    public class Estados
    {
        #region Atributos
        private int idEstado;
        private int idPais;
        private int estadoAtivo;
        private string nomeEstado;
        private string siglaEstado;
        #endregion

        #region Propriedades
        public int IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }

        public int IdPais
        {
            get { return idPais; }
            set { idPais = value; }
        }

        public int EstadoAtivo
        {
            get { return estadoAtivo; }
            set { estadoAtivo = value; }
        }

        public string NomeEstado
        {
            get { return nomeEstado; }
            set { nomeEstado = value; }
        }

        public string SiglaEstado
        {
            get { return siglaEstado; }
            set { siglaEstado = value; }
        }
        #endregion

        #region Métodos
        public static List<Estados> ListarEstados()
        {
            List<Estados> listEstados = new List<Estados>();
            XElement xml = XElement.Load("Estados.xml");
            foreach (XElement x in xml.Elements())
            {
                Estados e = new Estados()
                {
                    idEstado = int.Parse(x.Attribute("idEstado").Value),
                    idPais = int.Parse(x.Attribute("idPais").Value),
                    estadoAtivo = int.Parse(x.Attribute("estadoAtivo").Value),
                    nomeEstado = x.Attribute("nomeEstado").Value,
                    siglaEstado = x.Attribute("siglaEstado").Value
                };
                listEstados.Add(e);
            }
            return listEstados.ToList();
        }
        #endregion
    }
}
