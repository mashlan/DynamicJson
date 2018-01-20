using System.Collections.Generic;
using Bogus;

namespace Mashlan.DynamicJson.MockData.Extentions
{
    internal static class FakerExtentions
    {
        public static bool PickRandomBoolean(this Faker faker)
        {
            return faker.PickRandom(new List<bool> {true, false});
        }

        public static string PickRandomCharacter(this Faker faker)
        {
            return faker.PickRandom(new List<char> {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'Z'}).ToString();
        }
    }
}
