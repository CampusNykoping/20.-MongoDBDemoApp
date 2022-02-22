using MongoDB.Driver;
using MongoDBDemo;

string connectionString = "mongodb://127.0.0.1:27017";  //TODO: Flytta till appsettings.json
string databaseName = "simple_db";
string collectionName = "people";

var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<PersonModel>(collectionName);

var person = new PersonModel { FirstName = "Claes", LastName = "Engelin" };
collection.InsertOne(person);

var people = new PersonModel[] 
{ 
    new PersonModel { FirstName = "Anna", LastName = "Engelin"},
    new PersonModel { FirstName = "Tim", LastName = "Corey"},
    new PersonModel { FirstName = "Mosh", LastName = "Hamedani"}
};
collection.InsertMany(people);

var results = await collection.FindAsync(_ => true); // (_ => true) hämtar ALLA poster

foreach (var result in results.ToList())
{
    Console.WriteLine($"{result.Id}: {result.FirstName} {result.LastName}");
}

Console.Write("Press any key");
Console.ReadKey();