namespace Play.DbCatalog.Service;

public class MongoDbSettings
{
    public required string Host { get; init; }

    public int Port { get; init; }

    public string ConnectionString => $"mongodb://{Host}:{Port}";
}