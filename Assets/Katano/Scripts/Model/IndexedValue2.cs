namespace RogueLike.Katano.Model
{
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
}