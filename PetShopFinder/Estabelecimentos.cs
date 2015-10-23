using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace PetShopFinder
{
    public class Estabelecimentos
    {
        #region Atributos
        private string idEstabelecimento;
        private string estabelecimento;
        #endregion

        #region Propriedades
        public string Estabelecimento
        {
            get { return estabelecimento; }
            set { estabelecimento = value; }
        }

        public string IdEstabelecimento
        {
            get { return idEstabelecimento;  }
        }
        #endregion

        #region Métodos
        public static List<Estabelecimentos> ListarEstabelecimentos()
        {
            List<Estabelecimentos> estabelecimentos = new List<Estabelecimentos>();
            XElement xml = XElement.Load("Estabelecimentos.xml");
            foreach (XElement x in xml.Elements())
            {
                Estabelecimentos e = new Estabelecimentos()
                {
                    estabelecimento = x.Attribute("nomeEstabelecimento").Value,
                    idEstabelecimento = x.Attribute("idEstabelecimentoBaseDados").Value,
                };
                estabelecimentos.Add(e);
            }
            return estabelecimentos.ToList();
        }
        #endregion
    }
}
