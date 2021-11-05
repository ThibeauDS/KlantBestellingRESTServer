using KlantBestellingRESTServer.Data.Exceptions;
using KlantBestellingRESTServer.Domein.Interfaces;
using KlantBestellingRESTServer.Domein.Klassen;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KlantBestellingRESTServer.Data.ADO
{
    public class KlantRepositoryADO : IKlantRepository
    {
        #region Properties
        private readonly string _connectieString;
        #endregion

        #region Constructors
        public KlantRepositoryADO(string connectieString)
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

        public bool BestaatKlant(int id)
        {
            SqlConnection connection = GetConnection();
            string sql = "SELECT count(*) FROM [dbo].[Klant] WHERE Id = @Id";
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                int n = (int)command.ExecuteScalar();
                if (n > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                KlantRepositoryADOException klantRepositoryADOException = new("BestaatKlant niet gelukt", ex);
                klantRepositoryADOException.Data.Add("Id", id);
                throw klantRepositoryADOException;
            }
            finally
            {
                connection.Close();
            }
        }

        public void KlantToevoegen(Klant klant)
        {
            SqlConnection connection = GetConnection();
            string sql = "INSERT INTO [dbo].[Klant] (Naam, Adres) VALUES (@Naam, @Adres)";
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.Add("@Naam", SqlDbType.NVarChar);
                command.Parameters.Add("@Adres", SqlDbType.NVarChar);
                command.Parameters["@Naam"].Value = klant.Naam;
                command.Parameters["@Adres"].Value = klant.Adres;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                KlantRepositoryADOException klantRepositoryADOException = new("KlantToevoegen niet gelukt", ex);
                klantRepositoryADOException.Data.Add("Klant", klant);
                throw klantRepositoryADOException;
            }
        }

        public void KlantUpdaten(Klant klant)
        {
            throw new NotImplementedException();
        }

        public void KlantVerwijderen(Klant klant)
        {
            throw new NotImplementedException();
        }

        public Klant KlantWeergeven(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
