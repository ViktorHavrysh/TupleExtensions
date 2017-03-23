TupleExtensions
---------------

`TupleExtensions` is a library with a number of convenience extensions that leverages C# 7 tuples.

[![Build status](https://ci.appveyor.com/api/projects/status/l2bwb5ht3sjpaoir?svg=true)](https://ci.appveyor.com/project/VictorGavrish/tupleextensions)

Licensed under the MIT license.

### Requirements

This library requires a framework that supports at least version 1.4 of .NET Standard.

Look [here](https://docs.microsoft.com/en-us/dotnet/articles/standard/library) to find out if your
framework supports it.

### Installation

Run this in your package manager console:

```
 Install-Package TupleExtensions.VictorGavrish
```

### Examples

`WithIndexes` adds indexes to a collection. This allows you to continue to use `foreach`
where previously you'd be tempted to use a `for` loop:

```csharp
var array = new[] { "one", "two", "three" };
foreach ((var index, var element) in array.WithIndexes())
{
    Console.WriteLine($"{index}:{element}");
}
```

This prints:

```
0:one
1:two
2:three
```

An extension on the `KeyValuePair<TKey, TValue>` struct allows ergonomic
dictionary traversal:

```csharp
var dictionary = new Dictionary<int, string>
{
    { 1, "one" },
    { 2, "two" }
};

foreach ((var key, var value) in dictionary)
{
    Console.WriteLine($"{key}:{value}");
}
```

Prints:

```
1:one
2:two
```

You can do something like this with new and improved `Zip` and `Unzip`:

```csharp
var left = new[] { 1, 2, 3 };
var right = new[] { "two", "three", "four" };

var zipped = left.Skip(1).Zip(right);

foreach ((var lval, var rval) in zipped)
{
    Console.WriteLine($"{lval}:{rval}");
}

(var newLeft, var newRight) = zipped.Unzip();

foreach (var element in newLeft)
{
    Console.WriteLine(element);
}

foreach (var element in newRight)
{
    Console.WriteLine(element);
}
```

This prints:

```
2:two
3:three
2
3
two
three
```