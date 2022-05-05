using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CourseProject.DB.Interaction
{

    public sealed class DBMediator
    {

        #region Commands templates

        private const string AuthQueryTemplate =
            "SELECT [r].[id_user] " +
            "FROM [dbo].[register] AS [r] " +
            "WHERE [r].[login_user] = '{0}' and [r].[password_user] = '{1}'";

        private const string CheckUserExistsQueryTemplate =
            "SELECT 1 " +
            "FROM [dbo].[register] AS [r]" +
            "WHERE [r].[login_user] = '{0}'";

        private const string RegisterUserQueryTemplate =
            "INSERT INTO [dbo].[register]" +
            "(login_user, password_user) " +
            "VALUES('{0}','{1}')";

        #endregion

        private readonly string _connectionString;

        public DBMediator(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private SqlConnection Connection =>
            new SqlConnection(_connectionString);

        private SqlCommand Command(string commandText, SqlConnection connection)
        {
            return new SqlCommand(commandText, connection);
        }

        public async Task<bool> AuthenticateAsync(
            string login, string password, CancellationToken token = default)
        {
            try
            {
                using var connection = Connection;
                await connection.OpenAsync(token);
                var commandText = string.Format(AuthQueryTemplate, login, password);
                using var command = Command(commandText, connection);

                using var reader = await command.ExecuteReaderAsync(token);
                return await reader.ReadAsync(token);
            }
            catch (SqlException)
            {
                // TODO: local exception on sql server instance side handling...
                return false;
            }
            catch (Exception)
            {
                // TODO: local other exception types...
                return false;
            }
        }

        [Obsolete]
        public async Task<bool?> CheckUserExistenceAsync(
            string login, CancellationToken token = default)
        {
            try
            {
                using var connection = Connection;
                await connection.OpenAsync(token);
                var commandText = string.Format(CheckUserExistsQueryTemplate, login);
                using var command = Command(commandText, connection);

                using var reader = await command.ExecuteReaderAsync(token);
                return await reader.ReadAsync(token);
            }
            catch (SqlException)
            {
                // TODO: local exception on sql server instance side handling...
                return null;
            }
            catch (Exception)
            {
                // TODO: local other exception types...
                return null;
            }
        }

        public async Task<bool> RegisterUserAsync(
            string login, string password, CancellationToken token = default)
        {
            try
            {
                using var connection = Connection;
                await connection.OpenAsync(token);
                var commandText = string.Format(RegisterUserQueryTemplate, login, password);
                using var command = Command(commandText, connection);

                await command.ExecuteScalarAsync(token);
                return true;
            }
            catch (SqlException)
            {
                // TODO: local exception on sql server instance side handling...
                return false;
            }
            catch (Exception)
            {
                // TODO: local other exception types...
                return false;
            }
        }

    }

}