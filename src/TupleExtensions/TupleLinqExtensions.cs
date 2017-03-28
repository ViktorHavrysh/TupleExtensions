using System;
using System.Collections.Generic;
using System.Linq;

namespace TupleExtensions
{
    /// <summary>
    /// Extensions that enhance .NET LINQ experience by leveranging tuples from C# 7
    /// </summary>
    public static class TupleLinqExtension
    {
        /// <summary>Adds an index to every element of a sequence.</summary>
        /// <param name="input">The input sequence.</param>
        /// <returns>A sequents of tuples that consist of the index of a value in the input iterator plus the value itself.</returns>
        /// <exception cref="ArgumentNullException">input is null</exception>
        /// <example>
        /// foreach ((var index, var item) in list.WithIndexes())
        /// {
        ///     Console.WriteLine($"{index}:{item}");
        /// }
        /// </example>
        public static IEnumerable<(int index, T value)> WithIndexes<T>(this IEnumerable<T> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.Select((value, index) => (index, value));
        }

        /// <summary>
        /// Merges two sequesnces, producing a sequence of tuples. If either of the child sequences stops producing results,
        /// the resulting sequence stops producing results as well.
        /// </summary>
        /// <param name="left">The frist sequence to merge.</param>
        /// <param name="right">The second sequence to merge.</param>
        /// <returns>
        /// The resulting sequence of tuples. The first element of each tuples comes from the first input sequence,
        /// the second element comes from the second input sequence.
        /// </returns>
        /// <exception cref="ArgumentNullException">first or second is null</exception>
        public static IEnumerable<(V1 left, V2 right)> Zip<V1, V2>(this IEnumerable<V1> left, IEnumerable<V2> right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            return left.Zip(right, (v1, v2) => (v1, v2));
        }

        /// <summary>Divides a sequence of tuples into a tuple of two sequences.</summary>
        /// <param name="input">The sequence to divide.</param>
        /// <returns>
        /// The tuple of sequences. The left seqence will consist of the first elements inside the orirignal sequence's tuple values,
        /// the right sequence will consist of the second element inside the orginal sequence's tuple values.
        /// </returns>
        /// <exception cref="ArgumentNullException">input is null</exception>
        public static (IEnumerable<V1> left, IEnumerable<V2> right) Unzip<V1, V2>(this IEnumerable<(V1 left, V2 right)> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return (input.Select(x => x.left), input.Select(x => x.right));
        }

        /// <summary>Creates a <see cref="Dictionary{TKey, TValue}" /> from a sequence of tuples.</summary>
        /// <param name="source">A sequence of tuples to create a <see cref="Dictionary{TKey, TValue}" /> from.</param>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <returns>A <see cref="Dictionary{TKey, TValue}" /> that contains values of type TValue from the input sequence.</returns>
        /// <exception cref="ArgumentNullException">
        /// source is null.
        /// -or-
        /// there is a null key in the sequence.
        /// </exception>
        /// <exception cref="ArgumentException">There are duplicate keys in the sequence.</exception>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey key, TValue value)> source)
        {
            return ToDictionary(source, null);
        }

        /// <summary>
        /// Creates a <see cref="Dictionary{TKey, TValue}" /> from a sequence of tuples
        /// according to a specified comparer.
        /// </summary>
        /// <param name="source">A sequence of tuples to create a <see cref="Dictionary{TKey, TValue}" /> from.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}" /> to compare keys.</param>
        /// <typeparam name="TKey">The type of the keys.</typeparam>
        /// <typeparam name="TValue">The type of the values.</typeparam>
        /// <returns> A <see cref="Dictionary{TKey, TValue}" /> that contains values of type TValue from the input sequence.</returns>
        /// <exception cref="ArgumentNullException">
        /// source is null.
        /// -or-
        /// there is a null key in the sequence.
        /// </exception>
        /// <exception cref="ArgumentException">There are duplicate keys in the sequence.</exception>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey key, TValue value)> source, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ToDictionary(tup => tup.key, tup => tup.value, comparer);
        }
    }
}
