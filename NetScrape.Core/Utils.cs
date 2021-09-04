using System.Collections.Generic;
using System.Text;

namespace NetScrape.Core
{
    public class Utils
    {
        public static string IntListToStringConverter(List<int> arr) {
            if (arr.Count == 0)
                return "0";

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < arr.Count; i++)
                builder.Append(i == arr.Count - 1 ? $"{arr[i]}" : $"{arr[i]}, ");

            return builder.ToString();
        }
    }
}
