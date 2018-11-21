using System.Linq;
using Moq;
using NUnit.Framework;
using Smartspace.Repository.Interfaces;

namespace Smartspace.Repository.Test
{
    [TestFixture]
    public class InMemoryRepositoryShould
    {
        private IRepository<IStoreable> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new InMemoryRepository<IStoreable>();
        }

        [Test]
        public void AddEntityToMemory_WhenGivenEntityIsIStoreable()
        {
            var item = new Mock<IStoreable>();
            var expectedCount = 1;

            _repository.Save(item.Object);

            Assert.AreEqual(expectedCount, _repository.All().Count());
        }
    }
}
