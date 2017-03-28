using System.Collections.Generic;

namespace TupleExtensions
{
    /// <summary>
    /// Extensions that enhance working with KeyValuePairs by leveraging C# 7 tuples
    /// </summary>
    public static class TupleKeyValuePairExtensions
    {
        /// <summary>
        /// Allows to deconstruct a <see cref="KeyValuePair{TKey, TValue}" /> into a (TKey, TValue) tuple. Allows easier traversal
        /// of dictionaries within a foreach.
        /// </summary>
        /// <param name="input">The KeyValuePair to deconstruct.</param>
        /// <param name="key">The Key part of the KeyValuePair.</param>
        /// <param name="value">The Value part of the KeyValuePair.</param>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <example>
        /// foreach ((var key, var value) in dictionary)
        /// {
        ///     Console.WriteLine($"{key}:{value}");
        /// }
        /// </example>
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> input, out TKey key, out TValue value)
        {
            key = input.Key;
            value = input.Value;
        }
    }
}
