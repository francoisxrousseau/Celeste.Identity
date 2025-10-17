namespace Celeste.Identity.Data.Installers;

using AspNetCore.Identity.MongoDbCore.Models;
using Celeste.Identity.Core.Options;
using Celeste.Identity.Data.Documents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

/// <summary>
///     The database service installer.
/// </summary>
public static class DatabaseInstaller
{
    /// <summary>
    ///     The install database services depedencies.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection InstallDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        var dbOptions = configuration.GetSection("Database").Get<DatabaseOptions>();

        services.AddSingleton(serviceProvider =>
        {
            var mongoClient = new MongoClient(dbOptions.ConnectionString);
            return mongoClient.GetDatabase(dbOptions.Name);
        });
        
        services
            .AddIdentity<UserDocument, MongoIdentityRole<Guid>>()
            .AddMongoDbStores<UserDocument, MongoIdentityRole<Guid>, Guid>(
                dbOptions.ConnectionString,
                dbOptions.Name
            );

        return services;
    }
}
