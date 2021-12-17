using KlantBestellingRESTServer.Data.Exceptions;
using KlantBestellingRESTServer.Domein.Interfaces;
using KlantBestellingRESTServer.Domein.Klassen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
            SqlConnection connection = GetConnection();
            string sql = "SELECT k.*, b.Id AS BestellingId, b.KlantId, b.ProductId, b.Aantal FROM [dbo].[Klant] k INNER JOIN [dbo].[Bestelling] b ON k.Id = b.KlantId WHERE k.Id = @Id";
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                IDataReader reader = command.ExecuteReader();
                Klant klant = null;
                List<Bestelling> bestellingList = new();
                while (reader.Read())
                {
                    if (klant == null)
                    {
                        klant = new((int)reader["Id"], (string)reader["Naam"], (string)reader["Adres"]);
                    }
                    Bestelling bestelling = new((int)reader["BestellingId"], (int)reader["ProductId"], (int)reader["Aantal"], klant);
                    bestellingList.Add(bestelling);
                }
                reader.Close();
                return bestellingList;
            }
            catch (Exception ex)
            {
                throw new BestellingRepositoryADOException("GeefBestellingenKlant niet gelukt", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public Bestelling BestellingWeergeven(int klantId, int id)
        {
            SqlConnection connection = GetConnection();
            string sql = "SELECT k.*, b.Id AS BestellingId, b.KlantId, b.ProductId, b.Aantal FROM [dbo].[Klant] k INNER JOIN [dbo].[Bestelling] b ON k.Id = b.KlantId WHERE k.Id = @KlantId AND b.Id = @Id";
            Klant klant = null;
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.Add("@KlantId", SqlDbType.Int);
                command.Parameters["@KlantId"].Value = klantId;
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = id;
                IDataReader reader = command.ExecuteReader();
                reader.Read();
                if (klant == null)
                {
                    klant = new((int)reader["Id"], (string)reader["Naam"], (string)reader["Adres"]);
                }
                Bestelling bestelling = new((int)reader["BestellingId"], (int)reader["ProductId"], (int)reader["Aantal"], klant);
                reader.Close();
                return bestelling;
            }
            catch (Exception ex)
            {
                throw new BestellingRepositoryADOException("BestellingWeergeven niet gelukt", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool BestaatBestelling(int bestellingId)
        {
            SqlConnection connection = GetConnection();
            string sql = "SELECT count(*) FROM [dbo].[Bestelling] WHERE Id = @Id";
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", bestellingId);
                int n = (int)command.ExecuteScalar();
                if (n > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                BestellingRepositoryADOException bestellingRepositoryADOException = new("BestaatBestelling niet gelukt", ex);
                bestellingRepositoryADOException.Data.Add("Id", bestellingId);
                throw bestellingRepositoryADOException;
            }
            finally
            {
                connection.Close();
            }
        }

        public void BestellingVerwijderen(int bestellingId)
        {
            SqlConnection connection = GetConnection();
            string sql = "DELETE FROM [dbo].[Bestelling] WHERE Id = @Id";
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", bestellingId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                BestellingRepositoryADOException bestellingRepositoryADOException = new("BestellingVerwijderen niet gelukt", ex);
                bestellingRepositoryADOException.Data.Add("Klant id", bestellingId);
                throw bestellingRepositoryADOException;
            }
        }

        public Bestelling BestellingToevoegen(Bestelling bestelling)
        {
            SqlConnection connection = GetConnection();
            string sql = "INSERT INTO [dbo].[Bestelling] (ProductId, Aantal, KlantId) VALUES (@ProductId, @Aantal, @KlantId) SELECT SCOPE_IDENTITY();";
            using SqlCommand command = new(sql, connection);
            connection.Open();
            SqlTransaction sqlTransaction = connection.BeginTransaction();
            try
            {
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@ProductId", SqlDbType.Int);
                command.Parameters.Add("@Aantal", SqlDbType.Int);
                command.Parameters.Add("@KlantId", SqlDbType.Int);
                command.Parameters["@ProductId"].Value = (int)bestelling.Product;
                command.Parameters["@Aantal"].Value = bestelling.Aantal;
                command.Parameters["@KlantId"].Value = bestelling.Klant.Id;
                int id = Decimal.ToInt32((decimal)command.ExecuteScalar());
                sqlTransaction.Commit();
                return new Bestelling(id, (int)bestelling.Product, bestelling.Aantal, bestelling.Klant);
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                BestellingRepositoryADOException bestellingRepositoryADOException = new("BestellingToevoegen niet gelukt", ex);
                bestellingRepositoryADOException.Data.Add("Bestelling", bestelling);
                throw bestellingRepositoryADOException;
            }
        }

        public void BestellingUpdaten(Bestelling bestelling)
        {
            SqlConnection connection = GetConnection();
            string sql = "UPDATE [dbo].[Bestelling] SET ProductId = @ProductId, Aantal = @Aantal, KlantId = @KlantId WHERE Id = @Id";
            using SqlCommand command = new(sql, connection);
            connection.Open();
            SqlTransaction sqlTransaction = connection.BeginTransaction();
            try
            {
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@ProductId", SqlDbType.Int);
                command.Parameters.Add("@Aantal", SqlDbType.Int);
                command.Parameters.Add("@KlantId", SqlDbType.Int);
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@ProductId"].Value = (int)bestelling.Product;
                command.Parameters["@Aantal"].Value = bestelling.Aantal;
                command.Parameters["@KlantId"].Value = bestelling.Klant.Id;
                command.Parameters["@Id"].Value = bestelling.Id;
                command.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                BestellingRepositoryADOException bestellingRepositoryADOException = new("BestellingUpdaten niet gelukt", ex);
                bestellingRepositoryADOException.Data.Add("Bestelling", bestelling);
                throw bestellingRepositoryADOException;
            }
        }

        public bool HeeftBestellingenKlant(int id)
        {
            SqlConnection connection = GetConnection();
            string sql = "SELECT COUNT(*) FROM [dbo].[Bestelling] WHERE KlantId = @Id";
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
                throw new BestellingRepositoryADOException("HeeftBestellingenKlant niet gelukt", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}
