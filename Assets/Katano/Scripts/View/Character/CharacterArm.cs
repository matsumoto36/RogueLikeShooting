using System;
using DDD.Matsumoto.Character;
using DDD.Nishiwaki;
using UnityEngine;
using Zenject;

namespace DDD.Katano.View.Character
{
	/// <summary>
	/// キャラクターアーム
	/// </summary>
	public class CharacterArm : MonoBehaviour
	{
		[Inject]
		private CharacterCore _characterCore;

		[Inject]
		private Transform _armAnchor;
		
		public IWeapon EquippedArm { get; private set; }

		private Transform _transformCache;

		private void Awake()
		{
			_transformCache = transform;
		}
		
		public void Attach(IWeapon weapon)
		{
			if (weapon == null)
				throw new ArgumentNullException(nameof(weapon));
			
			Detach();

			EquippedArm = weapon;
			
			EquippedArm.SetOwner(_characterCore);

			var armTransform = EquippedArm.GetBody().transform;
			_transformCache.rotation = armTransform.rotation;

			var position = armTransform.position;
			position.y = _transformCache.position.y;

			_transformCache.position = position;
			armTransform.parent = _armAnchor;
			armTransform.localPosition = Vector3.zero;
		}

		public void Detach()
		{
			if (EquippedArm == null) return;

			EquippedArm.SetOwner(null);

			EquippedArm.GetBody().transform.parent = null;

			EquippedArm = null;
		}
	}
}