using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedrera.Core.Repository;

namespace Pedrera.Core.Mongo.Tests.Models
{
    public class Foo : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
