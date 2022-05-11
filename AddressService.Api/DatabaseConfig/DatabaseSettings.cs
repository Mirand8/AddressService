namespace AddressService.Api.DatabaseConfig
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string AdressCollectionName { get; set; }
    }
}
