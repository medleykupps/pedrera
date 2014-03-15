using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pedrera.Core.Mongo.Tests.Models;
using Pedrera.Core.Mongo.Tests.Models.ClassMaps;
using Pedrera.Core.Repository;
using Pedrera.Core.Repository.Mongo;
using Pedrera.Core.Tests;

namespace Pedrera.Core.Mongo.Tests.Repository
{
    [TestFixture(Category = Categories.LiveDatabase)]
    public class InsertEntityTests
    {
        private IRepository<Foo, int> _repository;

        [TestFixtureSetUp]
        public void Setup()
        {
            _repository = new MongoRepository<Foo, int>(String.Empty, "PedreraTests", "Foos", new FooClassMap());
        }
    
        [Test]
        public void Insert_IsValid()
        {
            var foo = new Foo() {Name = "Purple Haze", Year = 1969};

            var result = _repository.Insert(foo);

            Assert.That(result, Is.Not.Null);
        }
    }
}
