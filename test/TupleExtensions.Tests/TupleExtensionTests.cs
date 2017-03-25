using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TupleExtensions.Tests
{
    public class TupleExtensionTests
    {
        [Fact]
        public void TestWithIndexes()
        {
            // arrange
            var original = new[] { "one", "two", "three" };
            var expected = new[] { (0, "one"), (1, "two"), (2, "three") };

            // act
            var actual = original.WithIndexes();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestWithIndexesArgumentNullException()
        {
            // arrange
            IEnumerable<string> empty = null;

            // act
            var exception = Record.Exception(() => empty.WithIndexes());

            // assert
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void TestZip()
        {
            // arrange
            var left = new[] { 1, 2, 3 };
            var right = new[] { "two", "three", "four" };
            var expected = new[] { (2, "two"), (3, "three") };

            // act
            var zipped = left.Skip(1).Zip(right);

            // assert
            Assert.Equal(expected, zipped);
        }

        [Fact]
        public void TestZipArgumentNullExceptions()
        {
            // arrange
            var nonEmpty = new List<string> { "one", "two" };
            IEnumerable<string> empty = null;

            // act
            var exception1 = Record.Exception(() => empty.Zip(nonEmpty));
            var exception2 = Record.Exception(() => nonEmpty.Zip(empty));

            // assert
            Assert.IsType<ArgumentNullException>(exception1);
            Assert.IsType<ArgumentNullException>(exception2);
        }

        [Fact]
        public void TestUnzip()
        {
            // arrange
            var zipped = new[] { (2, "two"), (3, "three") };
            IEnumerable<int> leftExpected = new[] { 2, 3 };
            IEnumerable<string> rightExpected = new[] { "two", "three" };

            // act
            (var leftActual, var rightActual) = zipped.Unzip();

            // assert
            Assert.Equal(leftExpected, leftActual);
            Assert.Equal(rightExpected, rightActual);
        }

        [Fact]
        public void TestUnzipArgumentNullException()
        {
            // arrange
            IEnumerable<(int, string)> empty = null;

            // act
            var exception = Record.Exception(() => empty.Unzip());

            // assert
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void TestDeconstruct()
        {
            // arrange
            const int K = 42;
            const string V = "forty two";
            var kvp = new KeyValuePair<int, string>(K, V);

            // act
            (var key, var value) = kvp;

            // assert
            Assert.Equal(K, key);
            Assert.Equal(V, value);
        }

        [Fact]
        public void TestDictionaryForeach()
        {
            // arrange
            var dictionary = new Dictionary<int, string>
            {
                { 1, "one" },
                { 2, "two" }
            };
            var expected = new List<(int, string)> { (1, "one"), (2, "two") };

            // act
            var result = new List<(int, string)>();
            foreach ((var key, var value) in dictionary)
            {
                result.Add((key, value));
            }

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestToDictionary()
        {
            // arrange
            var sequence = new[]
            {
                (1, "one"),
                (2, "two")
            };
            var expected = new Dictionary<int, string>
            {
                { 1, "one" },
                { 2, "two" }
            };

            // act
            var actual = sequence.ToDictionary();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToDictionaryWithEqualityComparer()
        {
            // arrange
            var sequence = new[]
            {
                (1.0f, "one"),
                (2.0f, "two")
            };
            var expected = new Dictionary<float, string>
            {
                { 1.0f, "one" },
                { 2.0f, "two" }
            };

            // act
            var actual = sequence.ToDictionary(new TruncatingEqualityComparer());

            // assert
            Assert.Equal(expected, actual);
            Assert.Equal("one", actual[1.1f]);
            Assert.Throws<KeyNotFoundException>(() => actual[3.0f]);
        }

        [Fact]
        public void TestToDictionaryArgumentException()
        {
            // arrange
            var sequence = new[]
            {
                (1, "one"),
                (1, "duplicate")
            };

            // act
            var exception = Record.Exception(() => sequence.ToDictionary());

            // assert
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void TestToDictionaryArgumentNullException()
        {
            // arrange
            IEnumerable<(int, string)> empty = null;

            // act
            var exception = Record.Exception(() => empty.ToDictionary());

            // assert
            Assert.IsType<ArgumentNullException>(exception);
        }

        private class TruncatingEqualityComparer : IEqualityComparer<float>
        {
            public bool Equals(float x, float y)
            {
                return Math.Truncate(x) == Math.Truncate(y);
            }

            public int GetHashCode(float obj)
            {
                return Math.Truncate(obj).GetHashCode();
            }
        }
    }
}
