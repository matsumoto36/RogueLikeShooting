using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Reqweldzen.Extensions
{
	public static class LinqExtensions
	{
		public static T RandomAt<T>([NotNull] this IEnumerable<T> ie)
		{
			if (ie == null) throw new ArgumentNullException(nameof(ie));
			
			var enumerable = ie.ToList();
			return !enumerable.Any()
				? default(T)
				: enumerable.ElementAt(UnityEngine.Random.Range(0, enumerable.Count));
		}

		public static T RandomAt<T>(this IEnumerable<T> ie, [NotNull] Func<T, bool> predicate)
		{
			if (ie == null) throw new ArgumentNullException(nameof(ie));
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));

			var enumerable = ie.Where(predicate).ToList();
			return !enumerable.Any()
				? default(T)
				: enumerable.ElementAt(UnityEngine.Random.Range(0, enumerable.Count));
		}

		public static IEnumerable<T> TakeRandom<T>([NotNull] this IEnumerable<T> source, int count)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return TakeRandomIterator(source, count);
		}

		private static IEnumerable<T> TakeRandomIterator<T>(IEnumerable<T> source, int count)
		{
			if (count > 0)
			{
				var array = source.ToArray();
				
				for (var i = array.Length - 1; i > 0; i--)
				{
					var r = Mathf.FloorToInt(UnityEngine.Random.value * (i + 1));
					var tmp = array[i];
					array[i] = array[r];
					array[r] = tmp;
				}
				
				foreach (T source1 in array)
				{
					yield return source1;
					if (--count == 0)
						break;
				}
			}
		}
	}
}