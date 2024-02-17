using MongoDB.Bson;
using MongoDB.Driver;

Console.WriteLine("Hello, World!");

var client = new MongoClient("mongodb://localhost:27017");
var database = client.GetDatabase("testdb");
var collection = database.GetCollection<BsonDocument>("testcollection");

await collection.DeleteManyAsync(new BsonDocument());
Console.WriteLine("Collection cleared.");

var document = new BsonDocument
            {
                { "name", "Ardalis" },
                { "Company", "NimblePros - Force Multipliers for Dev Teams" },
                { "MvpAwardCount", 20 },
                { "city", "Kent, Ohio" }
            };
await collection.InsertOneAsync(document);
Console.WriteLine("Document inserted.");

var documents = await collection.Find(new BsonDocument()).ToListAsync();
foreach (var doc in documents)
{
    Console.WriteLine(doc.ToString());
}