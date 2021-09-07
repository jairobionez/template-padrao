using System.Linq;

namespace Ecredrural.Core.Utils
{
    public static class StringExtension
    {
        public static string ApenasNumeros(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
