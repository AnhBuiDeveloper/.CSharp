// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*

Build a cache data structure which implements the following eviction policy:

1) evict an expired item if it exists
2) otherwise evict the Least Recently Used item of the lowest priority.

// priority = 1 ==> lowest
// only check expiration when it is expired

C = new Cache(5)
//C.Set(key="A", value=5, priority=5, expiration=10001)
//C.Set(key="B", value=4, priority=1, expiration=40006)
C.Set(key="C", value=3, priority=5, expiration=10001)
//C.Set(key="D", value=2, priority=9, expiration= 500)
//C.Set(key="E", value=1, priority=5, expiration=10004)
C.Get("C")

// Current Time = 900 system.get_current_time()

C.Set(key="F", value=10, priority=5, expiration= 5001)
C.Set(key="G", value=9, priority=5, expiration= 5004)
C.Set(key="H", value=-1, priority=5, expiration= 5009)
C.Set(key="I", value=1, priority=5, expiration= 5011)

C.Set(key="C", value=1, priority=5, expiration= 5021)
C.Get("D")

*/

using System;
using System.Collections.Generic;
using System.Linq;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        var myCache = new Cache();
        myCache.Add(new CacheItem("A", 5, 5, 10001));
        myCache.Add(new CacheItem("B", 4, 1, 40006));
        myCache.Add(new CacheItem("C", 3, 5, 10001));
        myCache.Add(new CacheItem("D", 2, 9, 500));
        myCache.Add(new CacheItem("E", 1, 5, 10004));

        var cacheItem = myCache.Get("C");
        Console.Write(cacheItem.Value);
    }
}

class Cache
{
    List<CacheItem> myCaches = new List<CacheItem>();
    long currentTimeStamp = 900;

    public void Add(CacheItem newItem)
    {
        // Implement logic to check if cache is full?
        if (myCaches.Count == 5)
        {
            // if full? then remove one
            CacheItem expiredItem = default;
            // Find the expired item
            expiredItem = FindExpiredItem();

            // Find the lowest priority item
            if (expiredItem == default)
            {
                var lowestPriorityItems = FindLowestPriorityItems();
                if (lowestPriorityItems.Count() == 1)
                {
                    expiredItem = lowestPriorityItems[0];
                }
                else
                {
                    // Find the ealiest accessed item
                    expiredItem = FindTheEarliestAccessItem(lowestPriorityItems);
                }
            }
            myCaches.Remove(expiredItem);
        }

        // Add newItem - modify last access timestamp
        newItem.LastAccess = DateTime.Now;
        myCaches.Add(newItem);
    }

    private CacheItem FindTheEarliestAccessItem(CacheItem[] lowestPriorityItems)
    {
        return myCaches.OrderBy(x => x.LastAccess).First();
    }

    private CacheItem FindExpiredItem()
    {
        return myCaches.Where(x => x.Expiration < currentTimeStamp).FirstOrDefault();
    }

    private CacheItem[] FindLowestPriorityItems()
    {
        var lowestPriority = myCaches.OrderBy(x => x.Priority).First().Priority;
        return myCaches.Where(x => x.Priority == lowestPriority).ToArray();
    }

    public CacheItem Get(string key)
    {
        var foundItem = myCaches.SingleOrDefault(x => x.Key == key);
        if (foundItem != default)
        {
            foundItem.LastAccess = DateTime.Now;
        }
        return foundItem;
    }
}

class CacheItem
{

    public CacheItem(string key, int value, int priority, long expiration)
    {
        Key = key;
        Value = value;
        Priority = priority;
        Expiration = expiration;
    }

    public string Key { get; set; }
    public int Value { get; set; }
    public int Priority { get; set; }
    public long Expiration { get; set; }
    public DateTime LastAccess { get; set; }
}