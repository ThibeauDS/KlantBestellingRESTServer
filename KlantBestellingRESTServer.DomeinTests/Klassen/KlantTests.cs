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
        [Theory()]
        [InlineData(5)]
        public void ZetIdTestMoetBovenNulZijn(int id)
        {
            Assert.InRange(id, 0, 999);
        }

        [Fact()]
        public void ZetIdTestMoetExceptionGeven()
        {
            Klant klant= new(0, "Thibeau De Smet", "Sleistraat 26A, 9550 Woubrechtegem");
            Assert.Throws<KlantException>(() => klant.ZetId(-1));
        }

        [Theory()]
        [InlineData("Sleistraat 26A, 9550 Woubrechtegem")]
        public void ZetAdresTestMoetMinimumTienKaraktersHebben(string adres)
        {
            Assert.InRange(adres.Length, 10, 999);
        }

        [Theory()]
        [InlineData("Sleistraat 26A, 9550 Woubrechtegem")]
        public void ZetAdresTestMagNietLeegZijn(string adres)
        {
            Assert.NotEmpty(adres);
        }

        [Fact()]
        public void ZetAdresTestMoetExceptionGeven()
        {
            Klant klant = new(0, "Thibeau De Smet", "Sleistraat 26A, 9550 Woubrechtegem");
            Assert.Throws<KlantException>(() => klant.ZetAdres(" "));
        }

        [Theory()]
        [InlineData("Thibeau De Smet")]
        public void ZetNaamTestMagNietLeegZijn(string naam)
        {
            Assert.NotEmpty(naam);
        }

        [Fact()]
        public void ZetNaamTestMoetExceptionGeven()
        {
            Klant klant = new(0, "Thibeau De Smet", "Sleistraat 26A, 9550 Woubrechtegem");
            Assert.Throws<KlantException>(() => klant.ZetNaam(""));
        }
    }
}