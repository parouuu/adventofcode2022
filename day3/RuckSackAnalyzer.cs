namespace day3
{
    public static class RuckSackAnalyzer
    {
        public static int GetBadges(string[] ruckSacks)
        {
            foreach (char c in ruckSacks[0])
            {
                if (ruckSacks[1].Contains(c) && ruckSacks[2].Contains(c))
                    return GetPriorityValue(c);
            }
            return 0;
        }

        public static int Analyze(string ruckSack)
        {
            int halfLength = ruckSack.Length / 2;

            var compartmentOne = ruckSack.Substring(0, halfLength);
            var compartmentTwo = ruckSack.Substring(halfLength, halfLength);


            for (int i = 0; i < compartmentOne.Length; i++)
            {
                var key1 = compartmentOne[i];
                var key2 = compartmentTwo[i];

                if (compartmentOne.Any(x => x == key2))
                    return GetPriorityValue(key2);
                if (compartmentTwo.Any(x => x == key1))
                    return GetPriorityValue(key1);
            }

            return 0;
        }

        private static int GetPriorityValue(char value)
        {
            if (value >= 'a' && value <= 'z')
                return (int) (value - 96);
            
            if (value >= 'A' && value <= 'Z')
                return (int) (value - 38);

            return 0;
        }
    }
}
