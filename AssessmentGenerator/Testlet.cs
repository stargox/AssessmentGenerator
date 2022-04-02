using AssessmentGenerator.Models;
using AssessmentGenerator.Extensions;

namespace AssessmentGenerator
{
    public class Testlet
    {
        private const int OperationalItemsCount = 6;
        private const int PretestItemsCount = 4;
        private const int PreOrderedPretestItemsCount = 2;

        public string TestletId { get; init; }

        private List<Item> _items;

        public Testlet(string testletId, List<Item> items)
        {
            if (!IsValidItemsCount(items))
            {
                throw new ArgumentException($"Invalid items count. Items list should have {OperationalItemsCount} operational and {PretestItemsCount} pretest elements.", nameof(items));
            }

            TestletId = testletId;
            _items = items;
        }

        public List<Item> Randomize(IRandom random)
        {
            var preOrderedItems = _items.Where(item => item.ItemType == ItemTypeEnum.Pretest)
                                       .Shuffle(random)
                                       .Take(PreOrderedPretestItemsCount);
            var otherItems = _items.Except(preOrderedItems)
                                  .Shuffle(random);

            return preOrderedItems.Concat(otherItems)
                                  .ToList();
        }

        private bool IsValidItemsCount(IEnumerable<Item> items)
        {
            return items.Count(item => item.ItemType == ItemTypeEnum.Operational) == OperationalItemsCount
                && items.Count(item => item.ItemType == ItemTypeEnum.Pretest) == PretestItemsCount;
        }
    }
}