using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ZanyBaka.Shared.Utils.Lib.Extensions
{
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitByLength(this string text, int length)
        {
            for (int index = 0; index < text.Length; index += length)
            {
                yield return text.Substring(index, Math.Min(length, text.Length - index));
            }
        }

        public static string FirstNChars(this string text, int count, bool addEllipses)
        {
            if (text == null)
            {
                return null;
            }

            if (!addEllipses)
            {
                return text.Length > count
                    ? text.Substring(0, count)
                    : text;
            }

            return text.Length > count
                ? count > 3 ? $"{text.Substring(0, count - 3)}..." : "..."
                : text;
        }

        public static string FirstWordsButNotMoreThanNChars(this string text, int maxChars)
        {
            if (text == null)
            {
                return null;
            }

            if (text.Length <= maxChars)
            {
                return text;
            }

            int pos = text.LastIndexOf(' ', maxChars);
            if (pos == -1)
            {
                return text.FirstNChars(maxChars, false);
            }

            return $"{text.Substring(0, pos)}";
        }

        public static string SkipFirstWord(this string text, char delimiter = ' ')
        {
            if (text == null)
            {
                return null;
            }

            int pos = text.IndexOf(delimiter);
            if (pos == -1)
            {
                return text;
            }

            return text.Substring(pos + 1);
        }

        /// <summary>
        ///     Returns a new string in which all occurrences of a specified string in the current instance are replaced with
        ///     another
        ///     specified string according the type of search to use for the specified string.
        /// </summary>
        /// <remarks>https://stackoverflow.com/questions/6275980/string-replace-ignoring-case</remarks>
        /// <param name="input">The string performing the replace method.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">
        ///     The string replace all occurrences of <paramref name="oldValue" />.
        ///     If value is equal to <c>null</c>, than all occurrences of <paramref name="oldValue" /> will be removed from the
        ///     <paramref name="input" />.
        /// </param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>
        ///     A string that is equivalent to the current string except that all instances of <paramref name="oldValue" /> are
        ///     replaced with <paramref name="newValue" />.
        ///     If <paramref name="oldValue" /> is not found in the current instance, the method returns the current instance
        ///     unchanged.
        /// </returns>
        // TODO: support NET5_0, NETCOREAPP symbols
        // NETSTANDARD2_0 || NETFRAMEWORK
        [DebuggerStepThrough]
        public static string Replace(this string input,
                                     string oldValue, string newValue,
                                     StringComparison comparisonType)
        {
            // Check inputs.
            if (input == null)
            {
                // Same as original .NET C# string.Replace behavior.
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Length == 0)
            {
                // Same as original .NET C# string.Replace behavior.
                return input;
            }

            if (oldValue == null)
            {
                // Same as original .NET C# string.Replace behavior.
                throw new ArgumentNullException(nameof(oldValue));
            }

            if (oldValue.Length == 0)
            {
                // Same as original .NET C# string.Replace behavior.
                throw new ArgumentException("String cannot be of zero length.");
            }

            // Prepare string builder for storing the processed string.
            StringBuilder resultStringBuilder = new StringBuilder(input.Length);

            // Analyze the replacement: replace or remove.
            bool isReplacementNullOrEmpty = string.IsNullOrEmpty(newValue);

            // Replace all values.
            const int valueNotFound = -1;
            int       foundAt;
            int       startSearchFromIndex = 0;
            while ((foundAt = input.IndexOf(oldValue, startSearchFromIndex, comparisonType)) != valueNotFound)
            {
                // Append all characters until the found replacement.
                int  charsUntilReplacment = foundAt - startSearchFromIndex;
                bool isNothingToAppend    = charsUntilReplacment == 0;
                if (!isNothingToAppend)
                {
                    resultStringBuilder.Append(input, startSearchFromIndex, charsUntilReplacment);
                }

                // Process the replacement.
                if (!isReplacementNullOrEmpty)
                {
                    resultStringBuilder.Append(newValue);
                }

                // Prepare start index for the next search.
                // This needed to prevent infinite loop, otherwise method always start search 
                // from the start of the string. For example: if an oldValue == "EXAMPLE", newValue == "example"
                // and comparisonType == "any ignore case" will conquer to replacing:
                // "EXAMPLE" to "example" to "example" to "example" … infinite loop.
                startSearchFromIndex = foundAt + oldValue.Length;
                if (startSearchFromIndex == input.Length)
                {
                    // It is end of the input string: no more space for the next search.
                    // The input string ends with a value that has already been replaced. 
                    // Therefore, the string builder with the result is complete and no further action is required.
                    return resultStringBuilder.ToString();
                }
            }

            // Append the last part to the result.
            int charsUntilStringEnd = input.Length - startSearchFromIndex;
            resultStringBuilder.Append(input, startSearchFromIndex, charsUntilStringEnd);

            return resultStringBuilder.ToString();
        }
    }
}