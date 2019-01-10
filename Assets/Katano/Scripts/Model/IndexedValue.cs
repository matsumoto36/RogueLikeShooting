namespace DDD.Katano.Model
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
}