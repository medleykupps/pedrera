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
    public class RepositoryGetByTests
    {
        private IRepository<Bar, string> _repository;

        [TestFixtureSetUp]
        public void Setup()
        {
            _repository = new MongoRepository<Bar, string>(String.Empty, "PedreraTests", "Bars", new BarClassMap());
        }

        [Test]
        public void GetBy_StartsWith_Test()
        {
            GetBy(bar => bar.Id.StartsWith("BAR-AD-532"));
        }

        [Test]
        public void GetBy_IndexOf_Test()
        {
            GetBy(bar => bar.Id.IndexOf("532", StringComparison.OrdinalIgnoreCase) == 7);
        }

        public void GetBy(Func<Bar, bool> predicate)
        {
            var results = _repository.GetBy(predicate);
            
            Assert.That(results.Count(), Is.GreaterThan(0));
            Console.WriteLine("Count: {0}", results.Count());
        }

    }
}
