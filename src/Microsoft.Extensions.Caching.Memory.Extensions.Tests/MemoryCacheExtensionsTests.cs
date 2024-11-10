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

        IEnumerable? allKeysEnumerable = null;
        Assert.DoesNotThrow(() => allKeysEnumerable = cache.GetKeys());

        Assert.That(allKeysEnumerable, Is.Not.Null);
        Assert.That(allKeysEnumerable, Is.EquivalentTo(_expectedKeysCollection));

        IEnumerable<string>? stringKeysEnumerable = null;
        Assert.DoesNotThrow(() => stringKeysEnumerable = cache.GetKeys<string>());

        Assert.That(stringKeysEnumerable, Is.Not.Null);
        Assert.That(stringKeysEnumerable, Is.EquivalentTo(_expectedKeysEnumerable));
    }
}