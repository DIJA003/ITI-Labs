using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Linq_Methods_manually_implementation
{
    public static class LinqExtensionMethods
    {
        public static List<T> WhereBy<T>(this List<T> items, Func<T, bool> filter)
        {
            List<T> newItems = new List<T>();
            foreach (var item in items)
            {
                if (filter(item))
                {
                    newItems.Add(item);
                }
            }
            return newItems;

        }
        public static List<R> SelectBy<T, R>(this List<T> items, Func<T, R> select)
        {
            List<R> res = new List<R>();
            foreach (var item in items)
            {
                res.Add(select(item));
            }
            return res;
        }
        public static List<T> TakeBy<T>(this List<T> items, int count)
        {
            List<T> res = new List<T>();
            for (int i = 0; i < count && i < items.Count; i++)
            {
                res.Add(items[i]);
            }
            return res;
        }
        public static List<T> SkipBy<T>(this List<T> items, int count)
        {
            List<T> res = new List<T>();
            for (int i = count; i < items.Count; i++)
            {
                res.Add(items[i]);
            }
            return res;
        }
        public static List<T> TakeWhileBy<T>(this List<T> items, Func<T, bool> predicate)
        {
            List<T> res = new List<T>();
            foreach (var item in items)
            {
                if (!predicate(item)) break;
                res.Add(item);
            }
            return res;
        }
        public static List<T> SkipWhileBy<T>(this List<T> items, Func<T, bool> predicate)
        {
            List<T> res = new List<T>();
            bool flag = true;
            foreach (var item in items)
            {
                if (flag && !predicate(item)) flag = false;
                if (!flag) res.Add(item);

            }
            return res;
        }
        public static List<T> DistinctBy<T>(this List<T> items)
        {
            HashSet<T> set = new HashSet<T>();
            List<T> res = new List<T>();
            foreach (var item in items)
            {
                if (set.Add(item)) res.Add(item);
            }
            return res;
        }
        public static List<T> MyOrderBy<T, K>(this List<T> items, Func<T, K> selector) where K : IComparable<K>
        {
            List<T> res = new List<T>(items);
            items.Sort((x, y) => selector(x).CompareTo(selector(y)));
            return res;

        }
        public static List<T> MyOrderByDescending<T, K>(this List<T> items, Func<T, K> selector) where K : IComparable<K>
        {
            List<T> res = new List<T>(items);
            items.Sort((x, y) => selector(y).CompareTo(selector(x)));
            return res;

        }
        public static T MyFirst<T>(this List<T> items)
        {
            if (items.Count == 0) throw new InvalidOperationException("Empty List");
            return items[0];
        }
        public static T MyLast<T>(this List<T> items)
        {
            if (items.Count == 0) throw new InvalidOperationException("Empty List");
            return items[^1];
        }
        public static T MyFirstOrDefault<T>(this List<T> items)
        {
            return items.Count > 0 ? items[0] : default;
        }

        public static T MyLastOrDefault<T>(this List<T> items)
        {
            return items.Count > 0 ? items[^1] : default;
        }

        public static T MySingle<T>(this List<T> items)
        {
            if (items.Count == 0) throw new InvalidOperationException("List is empty");
            if (items.Count > 1) throw new InvalidOperationException("List contains more than one element");
            return items[0];
        }

        public static T MySingleOrDefault<T>(this List<T> items)
        {
            if (items.Count == 0) return default;
            if (items.Count > 1) throw new InvalidOperationException("List contains more than one element");
            return items[0];
        }

        public static List<R> SelectWithIndexed<T, R>(this List<T> items, Func<T, int, R> selector)
        {
            List<R> result = new List<R>();
            for (int i = 0; i < items.Count; i++)
            {
                result.Add(selector(items[i], i));
            }
            return result;
        }

        public static List<T> WhereWithIndexed<T>(this List<T> items, Func<T, int, bool> predicate)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < items.Count; i++)
            {
                if (predicate(items[i], i))
                    result.Add(items[i]);
            }
            return result;
        }

        public static List<T> MyPaginate<T>(this List<T> items, int pageNumber, int pageSize)
        {
            return items.SkipBy((pageNumber - 1) * pageSize).TakeBy(pageSize).ToList();
        }

        public static List<T> MyUnion<T>(this List<T> first, List<T> second)
        {
            HashSet<T> set = new(first);
            foreach (var item in second)
            {
                set.Add(item);
            }
            return set.ToList();
        }
        public static List<T> MyIntersect<T>(this List<T> first, List<T> second)
        {
            HashSet<T> set = new(first);
            List<T> res = new List<T>();
            foreach (var item in second)
            {
                if (set.Contains(item))
                {
                    res.Add(item);
                }
            }
            return res;
        }

        public static List<T> MyConcat<T>(this List<T> first, List<T> second)
        {
            List<T> res = new(first);
            res.AddRange(second);
            return res;
        }
        // adjust to null parameter
        public static int MyCount<T>(this List<T> items, Func<T, bool> predicate)
        {
            int count = 0;
            foreach (var item in items) if (predicate(item)) count++;
            return count;
        }

        public static T MyMax<T, K>(this List<T> items, Func<T, K> predicate) where K : IComparable<K>
        {
            T itemmax = items[0];
            K itemkey = predicate(itemmax);
            for (int i = 0; i < items.MyCount(x => true); i++)
            {
                K currkey = predicate(items[i]);
                if (currkey.CompareTo(itemkey) > 0)
                {
                    itemmax = items[i];
                    itemkey = currkey;
                }
            }
            return itemmax;

        }
        public static T MyMin<T, K>(this List<T> items, Func<T, K> predicate) where K : IComparable<K>
        {
            T itemmax = items[0];
            K itemkey = predicate(itemmax);
            for (int i = 0; i < items.MyCount(x => true); i++)
            {
                K currkey = predicate(items[i]);
                if (currkey.CompareTo(itemkey) < 0)
                {
                    itemmax = items[i];
                    itemkey = currkey;
                }
            }
            return itemmax;

        }

        public static bool MyAll<T>(this List<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (!predicate(item)) return false;
            }
            return true;
        }

        public static bool MyAny<T>(this List<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item)) return true;
            }
            return false;
        }

        public static int MySum<T>(this List<T> items, Func<T, int> predicate)
        {
            int sum = 0;
            foreach (var item in items)
            {
                sum += predicate(item);
            }
            return sum;
        }

        public static double MyAverage<T>(this List<T> items, Func<T, int> predicate)
        {
            return items.MySum(predicate) / (double)items.MyCount((x => true));
        }


        public static List<List<T>> MyChunk<T>(this List<T> items, int chunkSize)
        { 

            List<List<T>> result = new List<List<T>>();

            for (int i = 0; i < items.Count; i += chunkSize)
            {
                List<T> chunk = new List<T>();

                for (int j = i; j < i + chunkSize && j < items.Count; j++)
                {
                    chunk.Add(items[j]);
                }

                result.Add(chunk);
            }

            return result;
        }

        public static List<R> MyType<T, R>(this List<T> list)
        {
            List<R> result = new();
            foreach (var item in list)
                if (item is R matched)
                    result.Add(matched);
            return result;
        }

        public static List<(K, V)> ToAnonymousTypeBy<T, K, V>(this List<T> list, Func<T, K> keySelector, Func<T, V> valueSelector)
        {
            List<(K, V)> result = new();
            foreach (var item in list)
                result.Add((keySelector(item), valueSelector(item)));
            return result;
        }


    }
}
