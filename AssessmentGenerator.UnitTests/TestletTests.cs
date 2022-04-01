using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using AssessmentGenerator.Models;
using AssessmentGenerator.UnitTests.Utils;

namespace AssessmentGenerator.UnitTests
{
    public class TestletTests
    {
        [Fact]
        public void GivenListWithElementsPassed_WhenRandomizeIsCalled_ThenRandomizedListIsReturned()
        {
            // Arrange
            var testRandom = new TestRandom();
            var items = new List<Item>() {
                new Item { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "4", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "5", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "6", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "7", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "8", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "9", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "10", ItemType = ItemTypeEnum.Pretest },
            };
            var testlet = new Testlet("test", items);

            // Act
            var randomizedItems = testlet.Randomize(testRandom);

            // Assert
            randomizedItems.Should().HaveCount(items.Count);
            randomizedItems[0].ItemType.Should().Be(ItemTypeEnum.Pretest);
            randomizedItems[1].ItemType.Should().Be(ItemTypeEnum.Pretest);
            items.ForEach(item => randomizedItems.Should().Contain(item));
        }

        [Fact]
        public void GivenListWithOnePretestAndOneOperationalElementPassed_WhenRandomizeIsCalled_ThenListWithFirstPretestAndSecondOperationalElementsReturned()
        {
            // Arrange
            var testRandom = new TestRandom();
            var items = new List<Item>() {
                new Item { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
            };
            var testlet = new Testlet("test", items);

            // Act
            var randomizedItems = testlet.Randomize(testRandom);

            // Assert
            randomizedItems.Should().HaveCount(items.Count);
            randomizedItems[0].Should().Be(items[1]);
            randomizedItems[1].Should().Be(items[0]);
            items.ForEach(item => randomizedItems.Should().Contain(item));
        }

        [Fact]
        public void GivenListWithOnlyOperationalElementsPassed_WhenRandomizeIsCalled_ThenRandomizedListWithOperationalElementsReturned()
        {
            // Arrange
            var testRandom = new TestRandom();
            var items = new List<Item>() {
                new Item { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "2", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "3", ItemType = ItemTypeEnum.Operational },
            };
            var testlet = new Testlet("test", items);

            // Act
            var randomizedItems = testlet.Randomize(testRandom);

            // Assert
            randomizedItems.Should().HaveCount(items.Count);
            items.ForEach(item => randomizedItems.Should().Contain(item));
        }

        [Fact]
        public void GivenListWithOnlyPretestElementsPassed_WhenRandomizeIsCalled_ThenRandomizedListWithPretestElementsReturned()
        {
            // Arrange
            var testRandom = new TestRandom();
            var items = new List<Item>() {
                new Item { ItemId = "1", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "3", ItemType = ItemTypeEnum.Pretest },
            };
            var testlet = new Testlet("test", items);

            // Act
            var randomizedItems = testlet.Randomize(testRandom);

            // Assert
            randomizedItems.Should().HaveCount(items.Count);
            items.ForEach(item => randomizedItems.Should().Contain(item));
        }

        [Fact]
        public void GivenEmptyListPassed_WhenRandomizeIsCalled_ThenEmptyListReturned()
        {
            // Arrange
            var testRandom = new TestRandom();
            var items = new List<Item>();
            var testlet = new Testlet("test", items);

            // Act
            var randomizedItems = testlet.Randomize(testRandom);

            // Assert
            randomizedItems.Should().BeEmpty();
        }

        [Fact]
        public void GivenListWithPredefinedRandomPassed_WhenRandomizeIsCalled_ThenListInCorrespondingOrderReturned()
        {
            // Arrange
            var testRandom = new TestStaticRandom(new List<int>() { 4, 1, 2, 0 });
            var items = new List<Item>() {
                new Item { ItemId = "0", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "1", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "2", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "3", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "4", ItemType = ItemTypeEnum.Pretest },
            };
            var testlet = new Testlet("test", items);

            // Act
            var randomizedItems = testlet.Randomize(testRandom);

            // Assert
            randomizedItems.Should().HaveCount(items.Count);
            randomizedItems[0].Should().Be(items[3]);
            randomizedItems[1].Should().Be(items[1]);
            randomizedItems[2].Should().Be(items[0]);
            randomizedItems[3].Should().Be(items[2]);
            randomizedItems[4].Should().Be(items[4]);
        }
    }
}