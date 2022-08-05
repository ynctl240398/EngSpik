using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace BackEnd.Helpers
{
    public class StringHelper
    {
        public static readonly char[] Base64Letters = new[] {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '_', '-'};
        public static readonly char[] AlphaNumeric = new[] {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        public static readonly char[] PhonenumberChar = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+' };

        public static string RemoveNonPhonenumberChar(string str)
        {
            char[] arr = str.ToCharArray();
            arr = arr.Where(s => PhonenumberChar.Any(a => s.Equals(a))).ToArray();
            str = new string(arr);
            return str;
        }

        public static string RemoveNonAlphaNumeric(string str)
        {
            char[] arr = str.ToCharArray();
            arr = arr.Where(s => AlphaNumeric.Any(a => s.Equals(a))).ToArray();
            str = new string(arr);
            return str;
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = Base64Letters;
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            var ca = data.Select(p => chars[p % (chars.Length)]).ToArray();
            var s = new string(ca);
            return s;
        }

        public static bool IsNull(string str)
        {
            bool result = false;
            if(string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str)) { result = true; }
            return result;
        }

        public static string Utf16ToUtf8(string utf16String)
        {
            string utf8String = String.Empty;
            byte[] utf16Bytes = Encoding.Unicode.GetBytes(utf16String);
            byte[] utf8Bytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, utf16Bytes);
            for (int i = 0; i < utf8Bytes.Length; i++)
            {
                byte[] utf8Container = new byte[2] { utf8Bytes[i], 0 };
                utf8String += BitConverter.ToChar(utf8Container, 0);
            }
            return utf8String;
        }

    }
}
