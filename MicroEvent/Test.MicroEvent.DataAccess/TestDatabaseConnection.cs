using System;
using System.Globalization;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NUnit.Framework;

namespace Test.MicroEvent.DataAccess
{
    [TestFixture]
    public class TestDatabaseConnection
    {
        [Test]
        public void Exercise_database()
        {
            var mongoCollection = GetExerciseCollection();

            var timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            var exerciseEvent = new ExerciseEvent
            {
                TimeStamp = timestamp
            };

            mongoCollection.Insert(exerciseEvent);

            var id = exerciseEvent.Id;

            var mongoQuery = Query<ExerciseEvent>.EQ(x => x.Id, id);

            var eventReadBack = mongoCollection.FindOne(mongoQuery);

            Assert.That(eventReadBack.TimeStamp, Is.EqualTo(timestamp));
        }

        private static MongoCollection<ExerciseEvent> GetExerciseCollection()
        {
            try
            {
                var mongoClient = new MongoClient("mongodb://localhost");
                try
                {
                    var mongoServer = mongoClient.GetServer();
                    try
                    {
                        var mongoDatabase = mongoServer.GetDatabase("test");

                        try
                        {
                            var mongoCollection = mongoDatabase.GetCollection<ExerciseEvent>("exercise");
                            return mongoCollection;
                        }
                        catch (Exception)
                        {
                            Assert.Fail("Couldn't get exercise collection");
                        }
                    }
                    catch (Exception)
                    {
                        Assert.Fail("Couldn't get test database");
                    }
                }
                catch (Exception)
                {
                    Assert.Fail("Couldn't get a server");
                }
            }
            catch (Exception)
            {
                Assert.Fail("Couldn't initialise client");
            }

            throw new Exception("Failed setting up mongo database");
        }
    }

    public class ExerciseEvent
    {
        public ObjectId Id { get; set; }
        public string TimeStamp { get; set; }
    }
}