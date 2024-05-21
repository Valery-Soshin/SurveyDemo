using Npgsql;
using SurveyDemo.Repositories.Mapper;

namespace SurveyDemo.Repositories
{
    public class RepositoryBase
    {
        protected readonly NpgsqlConnection _connection;

        public RepositoryBase(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(configuration["connectionStrings:PostgreSQL"]);
            ModelMapperConfiguration.ConfigureModels();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}