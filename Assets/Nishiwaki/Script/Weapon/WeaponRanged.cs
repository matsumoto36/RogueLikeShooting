using System.Collections;
using DDD.Matsumoto.Character;
using UnityEngine;
using Zenject;
using UniRx;

namespace DDD.Nishiwaki.Item
{
	public class WeaponRanged : MonoBehaviour, IWeapon
	{
//		private const string CoreMaterialPath = "Material/WeaponCore";
//		private static Material _coreMaterial;
		public GameObject CoreObject;
		public Renderer CoreRenderer;

		private Color _themeColor;
		public CharacterCore characterCore;

		public IBullet iBullet;
		public Transform playerSetPosition;
		public WeaponRangedParameter WeaponRangedPara;

		[Inject]
		protected IMessageReceiver MessageReceiver;

		public void SetOwner(CharacterCore character)
		{
			if (characterCore == character) return;
			
			//装備したときはキャラクターの色で光らせる
			if (character)
			{
				_themeColor = character.ThemeColor;
				CoreObject.layer = character.gameObject.layer;
			}
			else
			{
				CoreObject.layer = LayerMask.NameToLayer("Weapon");
			}

			StartCoroutine(LightFadeAnim(character));

			characterCore = character;
		}

		public CharacterCore GetOwner()
		{
			return characterCore;
		}

		public virtual void Attack()
		{
		}

		public virtual void AttackUp()
		{
		}

		public virtual void AttackDown()
		{
		}

		public GameObject GetBody()
		{
			return gameObject;
		}

		public Transform PlayerSetPosition()
		{
			return playerSetPosition;
		}
		public void SpawnBulletPoint()
		{
			// 弾の発射位置
			iBullet.BulletCreate(transform);

		}

		/// <summary>
		///     コアを光らせる
		/// </summary>
		/// <param name="enable"></param>
		private IEnumerator LightFadeAnim(bool enable)
		{
			var t = 0.0f;
			var animSpeed = 2.0f;
			var intensity = 1.5f;

			while ((t += Time.deltaTime * animSpeed) < 1.0f)
			{
				var ratio = (enable ? t : 1 - t) * intensity;
				var col = _themeColor * new Color(ratio, ratio, ratio, 1.0f);
				CoreRenderer.material.SetColor("_EmissionColor", col);
				yield return null;
			}

			var lightLevel = enable ? new Color(intensity, intensity, intensity) : new Color();
			CoreRenderer.material.SetColor("_EmissionColor", _themeColor * lightLevel);
		}
	}
}