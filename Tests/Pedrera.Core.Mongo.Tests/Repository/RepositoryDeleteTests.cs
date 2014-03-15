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
    public class RepositoryDeleteTests
    {
        private IRepository<Bar, string> _repository;

        private const string DeleteById = "BAR-AD-90002";

        [TestFixtureSetUp]
        public void Setup()
        {
            _repository = new MongoRepository<Bar, string>(String.Empty, "PedreraTests", "Bars", new BarClassMap());

            var bar = new Bar() {Id = "BAR-AD-90001", Make = "Delete", Model = "Me", Year = 2001};
            DeleteThenInsert(bar);

            bar.Id = DeleteById;
            DeleteThenInsert(bar);
        }

        private void DeleteThenInsert(Bar bar)
        {
            var found = _repository.GetSingle(bar.Id);
            if (found != null)
            {
                _repository.Delete(found.Id);
            }
            _repository.Insert(bar);
        }

        [Test]
        public void DeleteEntityTest()
        {
            var entity = _repository.GetSingle("BAR-AD-90001");
            Assert.That(entity, Is.Not.Null);

            _repository.Delete(entity);
        }

        [Test]
        public void DeleteByIdTest()
        {
            var result = _repository.Delete(DeleteById);
            Assert.That(result, Is.True);

            var bar = _repository.GetSingle(DeleteById);
            Assert.That(bar, Is.Null);
        }

    }
}
