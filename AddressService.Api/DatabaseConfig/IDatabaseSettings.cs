namespace AddressService.Api.DatabaseConfig
{
    public interface IDatabaseSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string AdressCollectionName { get; set; }
    }
}
