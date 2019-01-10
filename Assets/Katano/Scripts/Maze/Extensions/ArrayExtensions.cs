using System;

namespace DDD.Katano
{
	public static class ArrayExtensions
	{
		public static T[,] Initialize<T>(this T[,] dimensionalArray, Func<int, int, T> initializer) where T : class
		{
			for (var i = 0; i < dimensionalArray.GetLength(0); i++)
			{
				for (var j = 0; j < dimensionalArray.GetLength(1); j++)
				{
					dimensionalArray[i, j] = initializer(i, j);
				}
			}

			return dimensionalArray;
		}
	}
}