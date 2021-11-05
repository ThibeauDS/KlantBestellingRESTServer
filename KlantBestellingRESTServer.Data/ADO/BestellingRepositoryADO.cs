using KlantBestellingRESTServer.Data.Exceptions;
using KlantBestellingRESTServer.Domein.Interfaces;
using KlantBestellingRESTServer.Domein.Klassen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantBestellingRESTServer.Data.ADO
{
    public class BestellingRepositoryADO : IBestellingRepository
    {
        #region Properties
        private readonly string _connectieString;
        #endregion

        #region Constructors
        public BestellingRepositoryADO(string connectieString)
        {
            _connectieString = connectieString;
        }
        #endregion

        #region Methods
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new(_connectieString);
            return connection;
        }

        public IEnumerable<Bestelling> GeefBestellingenKlant(int id)
        {
            SqlConnection conn = GetConnection();
            string sql = "SELECT * FROM [dbo].[Klant] k INNER JOIN [dbo].[Bestelling] b ON k.Id = b.KlantId WHERE k.Id = @Id";
            using SqlCommand command = new(sql, conn);
            try
            {
                conn.Open();
                command.Parameters.AddWithValue("@Id", id);
                IDataReader dataReader = command.ExecuteReader();
                Klant klant = null;
                List<Bestelling> bestellingList = new();
                while (dataReader.Read())
                {
                    if (klant == null)
                    {
                        klant = new((int)dataReader["Id"], (string)dataReader["Naam"], (string)dataReader["Adres"]);
                    }
                    Bestelling bestelling = new((int)dataReader["Id"], (int)dataReader["Aantal"], klant);
                    bestellingList.Add(bestelling);
                }
                dataReader.Close();
                return bestellingList;
            }
            catch (Exception ex)
            {
                throw new BestellingRepositoryADOException("GeefBestellingenKlant niet gelukt", ex);
            }
            finally
            {
                conn.Close();
            }
        } 
        #endregion
    }
}
