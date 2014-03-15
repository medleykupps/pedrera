using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedrera.Core.Repository;

namespace Pedrera.Core.Mongo.Tests.Models
{
    public class Bar : IIdentifiable<string>
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
