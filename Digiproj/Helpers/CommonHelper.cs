using System.Globalization;

namespace DigiProj.Helpers
{
	public static class CommonHelper
	{
		public static string ToTitleCase(this string title)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
		}
	}
}
