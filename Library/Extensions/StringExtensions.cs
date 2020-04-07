// <copyright file="StringExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Extensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    public static class StringExtensions
    {
        public static byte[] ToByteArray([AllowNull] this string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            var bytes = new byte[s.Length];
            for (var i = 0; i < s.Length; i++)
            {
                bytes[i] = Convert.ToByte(s[i]);
            }

            return bytes;
        }

        public static string Titalize([DisallowNull] this string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            char[] letters = s.ToCharArray();
            var lettersCapitalized = new string[letters.Length];
            for (var i = 0; i < letters.Length; i++)
            {
                var letter_ = letters[i].ToString(CultureInfo.InvariantCulture);
                string letter = " ";
                if (!letters[i].IsHyphenOrUnderscore())
                {
                    if (i == 0)
                        letter = letter_.ToUpperInvariant();
                    else
                        letter = letter_.ToLowerInvariant();
                }

                lettersCapitalized[i] = letter;
            }

            return lettersCapitalized.Join(string.Empty) !;
        }
    }
}
