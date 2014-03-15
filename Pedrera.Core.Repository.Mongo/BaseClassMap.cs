using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Pedrera.Core.Repository.Mongo
{
    public class BaseClassMap<T, TId> : IClassMap where T : IIdentifiable<TId>
    {
        public void Register()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(T)))
            {
                return;
            }

            BsonClassMap.RegisterClassMap<T>(
                cm =>
                {
                    if (IsAutomapped())
                    {
                        cm.AutoMap();
                    }
                    
                    cm.SetIdMember(cm.GetMemberMap(c => c.Id));

                    var idGenerator = GetIdGenerator();
                    if (idGenerator != null)
                    {
                        cm.IdMemberMap.SetIdGenerator(GetIdGenerator());
                    }
                    
                });
        }

        protected virtual bool IsAutomapped()
        {
            return false;
        }

        protected virtual IIdGenerator GetIdGenerator()
        {
            return null;
        }

    }
}
