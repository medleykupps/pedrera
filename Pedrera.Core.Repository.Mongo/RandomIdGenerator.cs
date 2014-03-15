using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization;

namespace Pedrera.Core.Repository.Mongo
{
    public class RandomIdGenerator : IIdGenerator
    {
        public object GenerateId(object container, object document)
        {
            var random = new Random(DateTime.Now.Millisecond);
            return random.Next(1000, 1000000);
        }

        public bool IsEmpty(object id)
        {
            int value;
            if (Int32.TryParse(id.ToString(), out value))
            {
                return (value <= 0);
            }
            return true;
        }
    }
}
