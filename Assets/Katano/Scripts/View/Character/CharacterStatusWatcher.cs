using System.Collections.Generic;
using DDD.Matsumoto;
using DDD.Matsumoto.Character;
using UniRx;
using UnityEngine;

namespace DDD.Katano.View.Character
{
	public class CharacterStatusWatcher : MonoBehaviour
	{
		private CharacterCore _core;
		private readonly List<IStatusChange> _characterStatusList = new List<IStatusChange>();

		private void Awake()
		{
			_core = GetComponent<CharacterCore>();
		}

		public void Attach(IStatusChange changer)
		{
			_characterStatusList.Add(changer);
			changer.OnAttachStatus(_core);

			changer.RemainingTime
				.Where(x => x <= 0)
				.Subscribe(_ =>
				{
					changer.OnDetachStatus(_core);
					_characterStatusList.Remove(changer);
				})
				.AddTo(this);
		}
	}
}