using System;
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
        private Mock<IStoreable> _item;

        [SetUp]
        public void Setup()
        {
            _repository = new InMemoryRepository<IStoreable>();
            _item = new Mock<IStoreable>();
        }

        [Test]
        public void AddItemToMemory_WhenSaveIsCalled()
        {
            var expectedCount = 1;

            _repository.Save(_item.Object);

            Assert.AreEqual(expectedCount, _repository.All().Count());
        }

        [Test]
        public void ReturnAllItems_WhenAllIsCalled()
        {
            var item2 = new Mock<IStoreable>();

            _repository.Save(_item.Object);
            _repository.Save(item2.Object);

            var expectedItemCount = 2;

            Assert.AreEqual(expectedItemCount, _repository.All().Count());
        }

        [Test]
        public void ReturnTheSameItem_WhenFindByIdIsCalled()
        {
            var expectedObjectId = 1;
            _item.SetupProperty(i => i.Id, expectedObjectId);

            _repository.Save(_item.Object);
            var result = _repository.FindById(expectedObjectId);

            Assert.AreEqual(expectedObjectId, result.Id);
        }

        [Test]
        public void DeleteTheItem_WhenDeleteIsCalled()
        {
            IComparable objectIdToDelete = 1;
            _item.SetupProperty(i => i.Id, objectIdToDelete);

            _repository.Save(_item.Object);
            _repository.Delete(objectIdToDelete);

            Assert.IsNull(_repository.FindById(objectIdToDelete));
        }
    }
}
