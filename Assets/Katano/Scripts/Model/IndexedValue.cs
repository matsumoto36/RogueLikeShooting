using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueLike.Katano.Model
{
	public struct IndexedValue<T>
	{
		public T Element { get; }
		public int Index { get; }

		public IndexedValue(T element, int index)
		{
			Element = element;
			Index = index;
		}
	}
	
	public struct IndexedValue2<T>
	{
		public T Element { get; }
		public int X { get; }
		public int Y { get; }

		internal IndexedValue2(T element, int x, int y)
		{
			Element = element;
			X = x;
			Y = y;
		}
	}


	public static class IndexedValueEx
	{
		public static IEnumerable<IndexedValue<T>> WithIndex<T>(this IEnumerable<T> self)
		{
			if (self == null)
				throw new ArgumentException(nameof(self));

			return self.Select((x, i) => new IndexedValue<T>(x, i));
		}
		
		public static IEnumerable<IndexedValue2<T>> WithIndex<T>(this T[,] self)
		{
			if (self == null)
				throw new ArgumentNullException(nameof(self));

			for (int x = 0; x < self.GetLength(0); x++)
			for (int y = 0; y < self.GetLength(1); y++)
				yield return new IndexedValue2<T>(self[x, y], x, y);
		}
	}
}