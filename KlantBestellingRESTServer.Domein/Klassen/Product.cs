using KlantBestellingRESTServer.Domein.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantBestellingRESTServer.Domein.Klassen
{
    public class Product
    {
        #region Properties
        public int Id { get; private set; }
        public string Naam { get; private set; }
        #endregion

        #region Constructors
        public Product(int id, string naam) : this(naam)
        {
            ZetId(id);
        }
        public Product(string naam)
        {
            ZetNaam(naam);
        }
        #endregion

        #region Methods
        public void ZetId(int id)
        {
            if (id <= 0)
            {
                throw new ProductException("Product heeft een ongeldig ID nummer.");
            }
            Id = id;
        }

        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new ProductException("Productnaam is leeg of NULL");
            }
            Naam = naam;
        }
        #endregion
    }
}
