using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace PetShopFinder
{
    public class Chaves
    {
        #region Atributos
        private string chave;
        #endregion

        #region Propriedades
        public string Chave
        {
            get { return chave; }
            set { chave = value; }
        }
        #endregion

        #region Métodos
        public static List<Chaves> ListarChaves()
        {
            List<Chaves> chaves = new List<Chaves>();
            XElement xml = XElement.Load("Chaves.xml");
            foreach (XElement x in xml.Elements())
            {
                Chaves c = new Chaves()
                {
                    chave = x.Attribute("idChave").Value,
                };
                chaves.Add(c);
            }
            return chaves.ToList();
        }
        #endregion
    }
}
