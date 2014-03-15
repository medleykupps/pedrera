using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using Pedrera.Core.Repository.Mongo;

namespace Pedrera.Core.Mongo.Tests.Models.ClassMaps
{
    public class BarClassMap : BaseClassMap<Bar, string>
    {
        protected override bool IsAutomapped()
        {
            return true;
        }

        protected override IIdGenerator GetIdGenerator()
        {
            return new StringObjectIdGenerator();
        }
    }
}
