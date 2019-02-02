using DDD.Matsumoto.Character;

namespace DDD.Katano.Extensions
{
	public static class CharacterExtensions
	{
		public static bool IsAbleAttack(this CharacterCore from, CharacterCore to)
		{
			if (!from || !to) return false;
			return from.Alliance != to.Alliance;
		}
	}
}