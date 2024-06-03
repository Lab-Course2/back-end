using MongoDB.Driver;

namespace MindMuse.AspNetCore
{
    public static class MongoConfig
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            var mongoClient = new MongoClient(mongoSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoSettings.DatabaseName);

            services.AddSingleton(mongoClient);
            services.AddSingleton(mongoDatabase);
        }
    }

}