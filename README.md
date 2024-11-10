[![Build and Test](https://github.com/aannenko/MemoryCacheExtensions/actions/workflows/dotnetcore.yml/badge.svg)](https://github.com/aannenko/MemoryCacheExtensions/actions/workflows/dotnetcore.yml)

# MemoryCacheExtensions
Get keys from `MemoryCache` (specifically, `Microsoft.Extensions.Caching.Memory.MemoryCache`): add the class `MemoryCacheExtensions` from this repository to your code and call `memoryCache.GetKeys()`.

```csharp
var cache = new MemoryCache(new MemoryCacheOptions());
cache.GetOrCreate(1, ce => "one");
cache.GetOrCreate("two", ce => "two");

foreach (var key in cache.GetKeys())
    Console.WriteLine($"Key: '{key}', Key type: '{key.GetType()}'");

foreach (var key in cache.GetKeys<string>())
    Console.WriteLine($"Key: '{key}', Key type: '{key.GetType()}'");

// Output:
// Key: '1', Key type: 'System.Int32'
// Key: 'two', Key type: 'System.String'
// Key: 'two', Key type: 'System.String'
```

`MemoryCacheExtensions` uses reflection to build a few delegates which, when built, allow you to tap into `MemoryCache` internals and efficiently retrieve current keys.
