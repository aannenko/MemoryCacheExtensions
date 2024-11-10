using System.Collections;

namespace Microsoft.Extensions.Caching.Memory.Extensions.Tests;

public class Tests
{
    private static readonly object[] _expectedKeysCollection = [1, "two"];
    private static readonly string[] _expectedKeysEnumerable = ["two"];

    [Test]
    public void GetKeys_WhenCalled_ReturnsMemoryCacheKeys()
    {
        var cache = new MemoryCache(new MemoryCacheOptions());
        cache.GetOrCreate(1, ce => "one");
        cache.GetOrCreate("two", ce => "two");

        IEnumerable? keysCollection = null;
        Assert.DoesNotThrow(() => keysCollection = cache.GetKeys());

        Assert.That(keysCollection, Is.Not.Null);
        Assert.That(keysCollection, Is.EquivalentTo(_expectedKeysCollection));

        IEnumerable<string>? keysEnumerable = null;
        Assert.DoesNotThrow(() => keysEnumerable = cache.GetKeys<string>());

        Assert.That(keysEnumerable, Is.Not.Null);
        Assert.That(keysEnumerable, Is.EquivalentTo(_expectedKeysEnumerable));
    }
}