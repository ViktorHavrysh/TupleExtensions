TupleExtensions
---------------

`TupleExtensions` is a NuGet package with a number of convenience extensions that leverage C# 7 tuples.

[![Build status](https://ci.appveyor.com/api/projects/status/l2bwb5ht3sjpaoir?svg=true)](https://ci.appveyor.com/project/VictorGavrish/tupleextensions) [![NuGet](https://img.shields.io/nuget/v/TupleExtensions.VictorGavrish.svg)](https://www.nuget.org/packages/TupleExtensions.VictorGavrish/)  [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/VictorGavrish/TupleExtensions/blob/master/LICENSE)

### Requirements

This library requires a framework that supports at least version 1.0 of .NET Standard.

Look [here](https://docs.microsoft.com/en-us/dotnet/articles/standard/library) to find out if your
framework supports it.

### Installation

Run this in your package manager console:

```
 Install-Package TupleExtensions.VictorGavrish
```

### Examples

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

##

You can await multiple tasks ergonomically:

```csharp
var task1 = Task.FromResult(1);
var task2 = Task.FromResult(true);

var (val1, val2) = await (task1, task2).WhenAll();
```

##

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

##

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

##

You can create a dictionary from a sequence of tuples:

```csharp
var sequence = new[]
{
    (1, "one"),
    (2, "two")
};
var dictionary = sequence.ToDictionary();
```
