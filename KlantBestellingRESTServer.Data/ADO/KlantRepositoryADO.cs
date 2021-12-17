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

        public Klant KlantToevoegen(Klant klant)
        {
            SqlConnection connection = GetConnection();
            string sql = "INSERT INTO [dbo].[Klant] (Naam, Adres) VALUES (@Naam, @Adres) SELECT SCOPE_IDENTITY();";
            using SqlCommand command = new(sql, connection);
            connection.Open();
            SqlTransaction sqlTransaction = connection.BeginTransaction();
            try
            {
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@Naam", SqlDbType.NVarChar);
                command.Parameters.Add("@Adres", SqlDbType.NVarChar);
                command.Parameters["@Naam"].Value = klant.Naam;
                command.Parameters["@Adres"].Value = klant.Adres;
                int id = Decimal.ToInt32((decimal)command.ExecuteScalar());
                sqlTransaction.Commit();
                return new Klant(id, klant.Naam, klant.Adres);
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                KlantRepositoryADOException klantRepositoryADOException = new("KlantToevoegen niet gelukt", ex);
                klantRepositoryADOException.Data.Add("Klant", klant);
                throw klantRepositoryADOException;
            }
        }

        public void KlantUpdaten(Klant klant)
        {
            SqlConnection connection = GetConnection();
            string sql = "UPDATE [dbo].[Klant] SET Naam = @Naam, Adres = @Adres WHERE Id = @Id";
            using SqlCommand command = new(sql, connection);
            connection.Open();
            SqlTransaction sqlTransaction = connection.BeginTransaction();
            try
            {
                command.Parameters.Add("@Naam", SqlDbType.NVarChar);
                command.Parameters.Add("@Adres", SqlDbType.NVarChar);
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Naam"].Value = klant.Naam;
                command.Parameters["@Adres"].Value = klant.Adres;
                command.Parameters["@Id"].Value = klant.Id;
                command.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                KlantRepositoryADOException klantRepositoryADOException = new("KlantUpdaten niet gelukt", ex);
                klantRepositoryADOException.Data.Add("Klant", klant);
                throw klantRepositoryADOException;
            }
        }

        public void KlantVerwijderen(int id)
        {
            SqlConnection connection = GetConnection();
            string sql = "DELETE FROM [dbo].[Klant] WHERE Id = @Id";
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                KlantRepositoryADOException klantRepositoryADOException = new("KlantVerwijderen niet gelukt", ex);
                klantRepositoryADOException.Data.Add("Klant id", id);
                throw klantRepositoryADOException;
            }
        }

        public Klant KlantWeergeven(int id)
        {
            SqlConnection connection = GetConnection();
            string sql = "SELECT * FROM [dbo].[Klant] WHERE Id = @Id";
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                IDataReader reader = command.ExecuteReader();
                reader.Read();
                Klant klant = new((int)reader["Id"], (string)reader["Naam"], (string)reader["Adres"]);
                reader.Close();
                return klant;
            }
            catch (Exception ex)
            {
                KlantRepositoryADOException klantRepositoryADOException = new("KlantWeergeven niet gelukt", ex);
                klantRepositoryADOException.Data.Add("Klant id", id);
                throw klantRepositoryADOException;
            }
        }
        #endregion
    }
}
