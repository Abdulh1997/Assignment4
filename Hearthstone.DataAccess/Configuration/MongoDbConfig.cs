namespace Hearthstone.DataAccess.Configuration
{
    public class MongoDbConfig
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CardsCollection { get; set; } = null!;
        public string ClassesCollection { get; set; } = null!;
        public string RaritiesCollection { get; set; } = null!;
        public string SetsCollection { get; set; } = null!;
        public string TypesCollection { get; set; } = null!;
    }
}
