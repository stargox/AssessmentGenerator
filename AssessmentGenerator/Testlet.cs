using AssessmentGenerator.Models;
using AssessmentGenerator.Extensions;

namespace AssessmentGenerator
{
    public class Testlet
    {
        public string TestletId;
        private List<Item> Items;

        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }

        public List<Item> Randomize(IRandom random)
        {
            var shuffledItems = Items.Shuffle(random);
            var preOrderedItems = shuffledItems.Where(item => item.ItemType == ItemTypeEnum.Pretest)
                                               .Take(2);
            var otherItems = shuffledItems.Except(preOrderedItems);

            return preOrderedItems.Concat(otherItems)
                                  .ToList();
        }
    }
}