using System.Globalization;

namespace DigiProj.Helpers
{
	public static class CommonHelper
	{
		public static string ToTitleCase(this string str)
		{
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
	}
}
