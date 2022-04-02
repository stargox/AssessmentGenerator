using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using AssessmentGenerator.Models;
using AssessmentGenerator.UnitTests.Utils;
using System;

namespace AssessmentGenerator.UnitTests
{
    public class TestletTests
    {
        [Fact]
        public void GivenEmptyListPassed_WhenTestletIsCreated_ThenExceptionIsThrown()
        {
            // Arrange
            var testRandom = new TestRandom();
            var items = new List<Item>();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Testlet("test", items));
        }

        [Fact]
        public void GivenListWithOnlyOperationalElementsPassed_WhenRandomizeIsCalled_ThenRandomizedListWithOperationalElementsReturned()
        {
            // Arrange
            var testRandom = new TestRandom();
            var items = new List<Item>() {
                new Item { ItemId = "0", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "2", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "4", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "5", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "6", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "7", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "8", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "9", ItemType = ItemTypeEnum.Operational },
            };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Testlet("test", items));
        }

        [Fact]
        public void GivenListWithOnlyPretestElementsPassed_WhenRandomizeIsCalled_ThenRandomizedListWithPretestElementsReturned()
        {
            // Arrange
            var testRandom = new TestRandom();
            var items = new List<Item>() {
                new Item { ItemId = "0", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "1", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "3", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "4", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "5", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "6", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "7", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "8", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "9", ItemType = ItemTypeEnum.Pretest },
            };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Testlet("test", items));
        }

        [Fact]
        public void GivenListWithElementsPassed_WhenRandomizeIsCalled_ThenRandomizedListReturned()
        {
            // Arrange
            var testRandom = new TestRandom();
            var items = new List<Item>() {
                new Item { ItemId = "0", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "4", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "5", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "6", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "7", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "8", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "9", ItemType = ItemTypeEnum.Pretest },
            };
            var testlet = new Testlet("test", items);

            // Act
            var randomizedItems = testlet.Randomize(testRandom);

            // Assert
            randomizedItems.Should().BeEquivalentTo(items);
            randomizedItems[0].ItemType.Should().Be(ItemTypeEnum.Pretest);
            randomizedItems[1].ItemType.Should().Be(ItemTypeEnum.Pretest);
        }

        [Fact]
        public void GivenListWithStaticRandomPassed_WhenRandomizeIsCalled_ThenListInCorrespondingOrderReturned()
        {
            // Arrange
            var testRandom = new TestStaticRandom(new List<int>() { 3, 0, 1, 7, 4, 5, 2, 3, 1, 1 });
            var items = new List<Item>() {
                new Item { ItemId = "0", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "1", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "2", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "3", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "4", ItemType = ItemTypeEnum.Pretest },
                new Item { ItemId = "5", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "6", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "7", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "8", ItemType = ItemTypeEnum.Operational },
                new Item { ItemId = "9", ItemType = ItemTypeEnum.Pretest },
            };
            var testlet = new Testlet("test", items);

            // Act
            var randomizedItems = testlet.Randomize(testRandom);

            // Assert
            randomizedItems.Should().ContainInOrder(new[] {
                items[4],
                items[2],
                items[0],
                items[8],
                items[1],
                items[5],
                items[3],
                items[7],
                items[6],
                items[9],
            });
        }
    }
}