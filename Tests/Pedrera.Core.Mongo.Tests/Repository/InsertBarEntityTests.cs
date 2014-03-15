using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class InsertBarEntityTests
    {
        private IRepository<Bar, string> _repository;
        private IEnumerable<Bar> _bars;
        
        [TestFixtureSetUp]
        public void Setup()
        {
            _repository = new MongoRepository<Bar, string>(String.Empty, "PedreraTests", "Bars", new BarClassMap());
            _bars = GenerateBars(20000);
        }

    
        [Ignore("Takes too long")]
        [Test]
        public void Insert_IsValid()
        {
            var sw = new Stopwatch();
            sw.Start();

            foreach (var bar in _bars)
            {
                var found = _repository.GetSingle(b => b.Id == bar.Id);
                if (found != null)
                {
                    found.Year++;
                    _repository.Update(found);
                }
                else
                {
                    _repository.Insert(bar);
                }
            }

            sw.Stop();
            Console.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
        }

        private IEnumerable<Bar> GenerateBars(int count)
        {
            var random = new Random(DateTime.Now.Millisecond);

            return Enumerable.Range(1, count).Select(
                idx =>
                {
                    return new Bar()
                           {
                               Id = String.Format("BAR-AD-{0:0000}", random.Next(1, 9999)),
                               Make = "Toyota",
                               Model = "RAV4",
                               Year = 1990
                           };
                });
        }

    }
}
