namespace day3.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", ExpectedResult = 16)]
        [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", ExpectedResult = 38)]
        [TestCase("PmmdzqPrVvPwwTWBwg", ExpectedResult = 42)]
        [TestCase("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", ExpectedResult = 22)]
        [TestCase("ttgJtRGJQctTZtZT", ExpectedResult = 20)]
        [TestCase("CrZsJsPPZsGzwwsLwLmpwMDw", ExpectedResult = 19)]
        public int Test_RuckSack_Analyze(string ruckSack)
        {
            return RuckSackAnalyzer.Analyze(ruckSack);
        }

        [Test]
        public void Test_RuckSack_GetBadges()
        {
            List<string> input = File.ReadLines("""C:\Git\adventofcode2022\day3.tests\sample1.txt""").ToList();

            int value = 0;

            while (input.Count > 0)
            { 
                var inputs = input.Take(3).ToArray();
                value += RuckSackAnalyzer.GetBadges(inputs);
                input.Remove(inputs[2]);
                input.Remove(inputs[1]);
                input.Remove(inputs[0]);
            }

            Assert.That(value, Is.EqualTo(70));
        }
    }
}