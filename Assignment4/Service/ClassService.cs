using Assignment4.Modeles;
using MongoDB.Driver;

namespace Assignment4.Service
{
    public class ClassService
    {
        private readonly ILogger<ClassService> _logger;
        private readonly IMongoCollection<Class> _collection;

        public ClassService(ILogger<ClassService> logger, MongoService service)
        {
            _collection = service.Client.GetDatabase("BED4").GetCollection<Class>("classes");
            _logger = logger;
            
        }


        public async Task<IList<Class>> GetClasses()
        {

            return await _collection.Find<Class>(Builders<Class>.Filter.Empty).ToListAsync();
        }
    }
}
