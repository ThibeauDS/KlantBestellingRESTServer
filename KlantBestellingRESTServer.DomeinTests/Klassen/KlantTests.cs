using Xunit;
using KlantBestellingRESTServer.Domein.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlantBestellingRESTServer.Domein.Exceptions;

namespace KlantBestellingRESTServer.Domein.Klassen.Tests
{
    public class KlantTests
    {
        #region Properties
        private readonly Klant _klant;
        #endregion

        #region Constructors
        public KlantTests()
        {
            _klant = new(1, "Thibeau De Smet", "Sleistraat 26A 9550 Herzele");
        }
        #endregion

        [Theory()]
        [InlineData(0)]
        public void ZetIdTest(int id)
        {
            Assert.Throws<KlantException>(() => _klant.ZetId(id));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetAdresTest(string adres)
        {
            Assert.Throws<KlantException>(() => _klant.ZetAdres(adres));
        }

        [Theory()]
        [InlineData("")]
        public void ZetAdresTest2(string adres)
        {
            Assert.Throws<KlantException>(() => _klant.ZetAdres(adres));
        }

        [Theory()]
        [InlineData("0123456")]
        public void ZetAdresTest3(string adres)
        {
            Assert.Throws<KlantException>(() => _klant.ZetAdres(adres));
        }

        [Theory()]
        [InlineData(null)]
        public void ZetNaamTest(string naam)
        {
            Assert.Throws<KlantException>(() => _klant.ZetNaam(naam));
        }
    }
}