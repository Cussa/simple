﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;

namespace Simple
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T3> Zip<T1, T2, T3>(this IEnumerable<T1> enum1, IEnumerable<T2> enum2, Func<T1, T2, T3> func)
        {
            var i = enum1.GetEnumerator();
            var j = enum2.GetEnumerator();
            while (i.MoveNext() && j.MoveNext())
            {
                yield return func(i.Current, j.Current);
            }
        }

        public static TValue SafeGet<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            try
            {
                return dictionary[key];
            }
            catch (KeyNotFoundException)
            {
                return default(TValue);
            }
        }

        public static T AggregateJoin<T>(this IEnumerable<T> enumerable, Func<T, T, T> joiner)
        {
            var result = enumerable.First();

            foreach (var other in enumerable.Skip(1))
                result = joiner(result, other);

            return result;
        }

        public static IEnumerable<Q> BatchSelect<T, Q>(this IEnumerable<T> source, int batchSize, Func<IEnumerable<T>, IEnumerable<Q>> func)
        {
            var list = new List<T>(batchSize);
            var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
                if (list.Count == batchSize)
                {
                    foreach (var item in func(list))
                        yield return item;

                    list.Clear();
                }
            }

            if (list.Any())
                foreach (var item in func(list))
                    yield return item;
        }

        public static IEnumerable<T> EagerForeach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            return enumerable.EagerForeach(action, null);
        }
        public static IEnumerable<T> EagerForeach<T>(this IEnumerable<T> enumerable, Action<T> action, Action<T> between)
        {
            var enumerator = enumerable.GetEnumerator();
            if (!enumerator.MoveNext())
                return enumerable;

            action(enumerator.Current);

            while (enumerator.MoveNext())
            {
                if (between != null)
                    between(enumerator.Current);
                if (action != null)
                    action(enumerator.Current);
            }

            return enumerable;
        }

        public static string StringJoin<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.StringJoin(string.Empty);
        }

        public static string StringJoin<T>(this IEnumerable<T> enumerable, string separator)
        {
            var builder = new StringBuilder();
            enumerable.EagerForeach(x => builder.AppendFormat("{0}", x), x => builder.Append(separator));
            return builder.ToString();
        }

        public static IEnumerable<T> Union<T>(this IEnumerable<T> enumerable, params T[] items)
        {
            return enumerable.Union((IEnumerable<T>)items);
        }

        public static TSource MaxOrDefault<TSource>(this IEnumerable<TSource> source) { return source.MaxOrDefault<TSource, TSource>(s => s); }
        public static TSource MaxOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue) { return source.MaxOrDefault<TSource, TSource>(s => s, defaultValue); }
        public static TResult MaxOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) { return source.MaxOrDefault(selector, default(TResult)); }
        public static TResult MaxOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult defaultValue) { return source.Any() ? source.Max(selector) : defaultValue; }

        public static TSource MinOrDefault<TSource>(this IEnumerable<TSource> source) { return source.MinOrDefault<TSource, TSource>(s => s); }
        public static TSource MinOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue) { return source.MinOrDefault<TSource, TSource>(s => s, defaultValue); }
        public static TResult MinOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) { return source.MinOrDefault(selector, default(TResult)); }
        public static TResult MinOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult defaultValue) { return source.Any() ? source.Min(selector) : defaultValue; }
   
    }
}
