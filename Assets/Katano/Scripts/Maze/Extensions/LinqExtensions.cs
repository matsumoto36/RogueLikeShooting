using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Reqweldzen.Extensions
{
	public static class LinqExtensions
	{
		public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> tuple, out T1 key, out T2 value)
		{
			key = tuple.Key;
			value = tuple.Value;
		}
		
		public static T RandomAt<T>([NotNull] this IEnumerable<T> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			
			var enumerable = source.ToList();
			return !enumerable.Any()
				? default(T)
				: enumerable.ElementAt(Random.Range(0, enumerable.Count));
		}

		public static T RandomAt<T>([NotNull] this IEnumerable<T> source, [NotNull] Func<T, bool> predicate)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));

			var enumerable = source.Where(predicate).ToList();
			return !enumerable.Any()
				? default(T)
				: enumerable.ElementAt(Random.Range(0, enumerable.Count));
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
					var r = Mathf.FloorToInt(Random.value * (i + 1));
					var tmp = array[i];
					array[i] = array[r];
					array[r] = tmp;
				}
				
				foreach (var source1 in array)
				{
					yield return source1;
					if (--count == 0)
						break;
				}
			}
		}

		public static IEnumerable<T> Shuffle<T>([NotNull] this IEnumerable<T> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			return ShuffleIterator(source);
		}

		private static IEnumerable<T> ShuffleIterator<T>(IEnumerable<T> source)
		{
			var array = source.ToArray();
				
			for (var i = array.Length - 1; i > 0; i--)
			{
				var r = Mathf.FloorToInt(Random.value * (i + 1));
				var tmp = array[i];
				array[i] = array[r];
				array[r] = tmp;
			}
				
			foreach (var source1 in array)
			{
				yield return source1;
			}
		}
	}
}