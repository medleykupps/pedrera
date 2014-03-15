using MongoDB.Bson.Serialization;
using Pedrera.Core.Repository.Mongo;

namespace Pedrera.Core.Mongo.Tests.Models.ClassMaps
{
    public class FooClassMap : IClassMap
    {
        public void Register()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(Foo)))
            {
                return;
            }

            BsonClassMap.RegisterClassMap<Foo>(
                cm =>
                {
                    cm.AutoMap();
                    cm.SetIdMember(cm.GetMemberMap(c => c.Id));
                    cm.IdMemberMap.SetIdGenerator(new RandomIdGenerator());
                });
        }
    }
}
