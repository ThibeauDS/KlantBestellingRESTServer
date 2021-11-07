using KlantBestellingRESTServer.Domein.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantBestellingRESTServer.Domein.Klassen
{
    public class Klant
    {
        #region Properties
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public string Adres { get; private set; }
        #endregion

        #region Constructors
        public Klant(int id, string naam, string adres) : this(naam, adres)
        {
            ZetId(id);
        }
        public Klant(string naam, string adres)
        {
            ZetNaam(naam);
            ZetAdres(adres);
        }
        #endregion

        #region Methods
        public void ZetId(int id)
        {
            if (id <= 0)
            {
                throw new KlantException("Het ID is ongeldig. Het moet 1 of meer zijn.");
            }
            Id = id;
        }
        public void ZetAdres(string adres)
        {
            if (string.IsNullOrWhiteSpace(adres))
            {
                throw new KlantException("Het adres mag niet leeg zijn.");
            }
            if (adres.Length <= 10)
            {
                throw new KlantException("Het andres moet minstens uit 10 karakters bestaan.");
            }
            Adres = adres;
        }

        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new KlantException("De naam mag niet leeg zijn.");
            }
            Naam = naam;
        }
        #endregion
    }
}
