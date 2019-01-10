using System;
using DDD.Chikazawa;
using GamepadInput;

namespace DDD.Katano
{
	public static class GamePadInputExtensions
	{
		public static ControllerIndex ToControllerIndex(this GamePad.Index index)
		{
			if (index == GamePad.Index.Any)
				throw new ArgumentException(nameof(index));
			
			return (ControllerIndex) index;
		}

		public static GamePad.Index ToGamePadIndex(this ControllerIndex index)
		{
			if (index == ControllerIndex.Invalid)
				throw new ArgumentException("Invalid argument.", nameof(index));
			if (index == ControllerIndex.Keyboard)
				throw new ArgumentException("Keyboard can't convert GamePad.Index.", nameof(index));

			return (GamePad.Index) index;
		}
	}
}