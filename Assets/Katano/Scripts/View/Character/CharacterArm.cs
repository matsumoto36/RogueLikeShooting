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
		[NonSerialized]
		public CharacterCore Core;

		public Transform ArmAnchor;
		
		public IWeapon EquippedArm { get; private set; }

		private Transform _transformCache;

		private void Awake()
		{
			_transformCache = transform;
			Core = GetComponent<CharacterCore>();
		}
		
		public void Attach(IWeapon weapon)
		{
			if (weapon == null)
				throw new ArgumentNullException(nameof(weapon));
			
			Detach();

			EquippedArm = weapon;
			
			EquippedArm.SetOwner(Core);

			var armTransform = EquippedArm.GetBody().transform;
			_transformCache.rotation = armTransform.rotation;

			var position = armTransform.position;
			position.y = _transformCache.position.y;

			_transformCache.position = position;
			armTransform.parent = ArmAnchor;
			armTransform.localPosition = Vector3.zero;
		}

		public void Detach()
		{
			if (EquippedArm == null) return;

			EquippedArm.SetOwner(null);

			var o = EquippedArm.GetBody();
			if (o != null) o.transform.parent = null;

			EquippedArm = null;
		}
	}
}