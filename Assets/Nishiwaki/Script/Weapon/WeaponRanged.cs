using System.Collections;
using DDD.Matsumoto.Character;
using DDD.Nishiwaki.Bullet;
using UniRx;
using UnityEngine;
using Zenject;

namespace DDD.Nishiwaki.Item
{
	public class WeaponRanged : MonoBehaviour, IWeapon
	{
		private const string CoreMaterialPath = "Material/WeaponCore";
		private static Material _coreMaterial;
		private GameObject _coreObject;
		private Renderer _coreRenderer;

		[Inject]
		private IMessageReceiver _messageReceiver;

		private Color _themeColor;
		public CharacterCore characterCore;

		public IBullet iBullet;
		public Transform playerSetPosition;
		public WeaponRangedParameter WeaponRangedPara;

		public void SetOwner(CharacterCore character)
		{
			if (characterCore == character) return;

			//装備したときはキャラクターの色で光らせる
			if (character)
			{
				_themeColor = character.ThemeColor;
				_coreObject.layer = character.gameObject.layer;
			}
			else
			{
				_coreObject.layer = LayerMask.NameToLayer("Weapon");
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

		public static WeaponRanged Create(WeaponRangedAsset asset, Transform transform)
		{
			var prefab = asset.WeaponRangedPrefab;
			var obj = Instantiate(prefab, transform.position, prefab.transform.rotation);

			WeaponRanged weapon;
			switch (asset)
			{
				case WeaponRangedAutoAsset AutoAsset:
					weapon = obj.AddComponent<WeaponRangedAuto>();
					break;
				case WeaponRangedSemiAsset SemiAsset:
					weapon = obj.AddComponent<WeaponRangedSemi>();
					break;
				case WeaponRangedLaserAsset LaserAsset:
					weapon = obj.AddComponent<WeaponRangedLaser>();
					break;
				default:
					weapon = null;
					break;
			}

			//中心部分の作成
			var core = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			weapon._coreObject = core;
			core.layer = LayerMask.NameToLayer("Weapon");
			core.transform.SetParent(obj.transform);
			core.transform.localPosition = new Vector3();

			weapon._coreRenderer = core.GetComponent<Renderer>();

			if (!_coreMaterial)
				_coreMaterial = Resources.Load<Material>(CoreMaterialPath);

			weapon._coreRenderer.material = Instantiate(_coreMaterial);
			weapon._coreRenderer.material.EnableKeyword("_EMISSION");

			//武器のパラメータ設定
			weapon.WeaponRangedPara = asset.WeaponRangedParameter;
			weapon.iBullet = BulletBase.Create(asset.BulletAsset, weapon);
			weapon.playerSetPosition = obj.transform.Find("PlayerSetPosition");
			Debug.Log("WeaponRanged Create");

			return weapon;
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
				_coreRenderer.material.SetColor("_EmissionColor", col);
				yield return null;
			}

			var lightLevel = enable ? new Color(intensity, intensity, intensity) : new Color();
			_coreRenderer.material.SetColor("_EmissionColor", _themeColor * lightLevel);
		}
	}
}