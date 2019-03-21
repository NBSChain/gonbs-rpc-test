using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * ┌───────────────────────────────────────────────────────────────────────┐
 * │Project	: grpc2slib.common
 * │ 
 * │Comment	:
 * │
 * │Version	: V1.0.0.0
 * │Author	: lanbery
 * │CreatTime	: 2019/3/18 14:12:01													
 * ├───────────────────────────────────────────────────────────────────────┤
 * │Copyright © NBS-Tech Team 2019.All rights reserved.
 * └───────────────────────────────────────────────────────────────────────┘
 */
namespace grpc2slib.common
{
    public static class AsyncEnumerableExtensions
    {
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="funcTask"></param>
        /// <returns></returns>
        public static async Task ForEachAsync<TSource>(
            this IAsyncEnumerable<TSource> source,
            Func<TSource,Task> funcTask)
        {
            using (var e = source.GetEnumerator())
            {
                while(await e.MoveNext().ConfigureAwait(false))
                {
                    await funcTask(e.Current).ConfigureAwait(false);
                }
            }
        }

        public static IAsyncEnumerable<TResult> SelectAsync<T,TResult>(
            this IEnumerable<T> enumerable,Func<T,Task<TResult>> selector)
        {
            return AsyncEnumerable.CreateEnumerable(() => {
                var enumerator = enumerable.GetEnumerator();
                var current = default(TResult);

                return AsyncEnumerable.CreateEnumerator(async c =>
                {
                    var moveNext = enumerator.MoveNext();
                    current = moveNext ? await selector(enumerator.Current).ConfigureAwait(false) : default(TResult);
                    return moveNext;
                }, () => current, () => enumerator.Dispose());
            });
        }


        public static IAsyncEnumerable<TResult> SelectAsync<T,TResult>(
            this IAsyncEnumerable<T> enumerable,Func<T,Task<TResult>> selector
            )
        {
            return AsyncEnumerable.CreateEnumerable(()=> {
                var enumerator = enumerable.GetEnumerator();
                var current = default(TResult);
                return AsyncEnumerable.CreateEnumerator(async c =>
                {
                    var moveNext = await enumerator.MoveNext().ConfigureAwait(false);
                    current = moveNext ? await selector(enumerator.Current).ConfigureAwait(false) : default(TResult);
                    return moveNext;
                },()=>current,()=>enumerator.Dispose());
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator"></param>
        /// <returns></returns>
        public static IAsyncEnumerable<T> ToAsyncEnumerable<T> (this IAsyncEnumerator<T> enumerator)
        {
            return AsyncEnumerable.CreateEnumerable(() => enumerator);
        }
    }
}
