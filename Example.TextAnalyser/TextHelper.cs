namespace Example.TextAnalyser
{
    using System.Collections.Generic;
    using System.Linq;

    public static class TextHelper
    {
        public static IDictionary<string, int> WordCount(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new Dictionary<string, int>();
            }

            var results = string.Concat(text.Where(x => !char.IsPunctuation(x)))
                .ToLower()
                .Split(' ')
                .Where(x => !string.IsNullOrEmpty(x))
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            return results;
        }
    }
}
