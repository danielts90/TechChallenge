using System.Text.RegularExpressions;

namespace TechChallenge.Business.Util
{
    public static partial class RegexHelper
    {
        [GeneratedRegex(@"^\d{8,9}$")]
        public static partial Regex DigitsRegex();
    }

}
