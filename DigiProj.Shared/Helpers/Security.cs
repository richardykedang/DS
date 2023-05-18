using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Helpers
{
	public static class Security
	{

		public const int ByteKey = 16;
		public const int SizeKey = 128;
		public const int SizeBlock = 128;

		public static string RijndaelEncrypt(string plainText, string key)
		{
			return FMFLibSecurity.Security.RijndaelEncrypt(plainText, key, ByteKey, SizeKey, SizeBlock);
		}
		public static string RijndaelDecrypt(string encryptedText, string key)
		{
			return FMFLibSecurity.Security.RijndaelDecrypt(encryptedText, key, ByteKey, SizeKey, SizeBlock);
		}

	}
}
