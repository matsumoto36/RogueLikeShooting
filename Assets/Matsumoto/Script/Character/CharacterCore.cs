﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RogueLike.Matsumoto.Attack;

namespace RogueLike.Matsumoto.Character {

	/// <summary>
	/// 各キャラクターのコアクラス
	/// </summary>
	public abstract class CharacterCore : MonoBehaviour {

		[SerializeField]
		protected CharacterParameter _parameter;

		public CharacterParameter Parameter {
			get { return _parameter; }
			protected set { _parameter = value; }
		}

		/// <summary>
		/// ダメージを与える
		/// </summary>
		/// <param name="attacker"></param>
		/// <param name="damage"></param>
		public void ApplyDamage(IAttacker attacker, int damage) {

			var message = "";
			switch(attacker) {
				case CharacterAttacker cAttacker:

                    //debug
                    if (!cAttacker.Attacker)
                    {
                        message = "Unknown";
                        break;
                    }

                    message = cAttacker.Attacker.name;
					break;
				default:
					message = "Unknown";
					break;
			}

			Debug.Log($"{message}は{name}に{damage}ダメージ与えた");

			_parameter.HP -= damage;
			if(_parameter.HP <= 0) {
				_parameter.HP = 0;
				Kill(attacker);
			}
		}

		/// <summary>
		/// 殺す
		/// </summary>
		/// <param name="attacker"></param>
		public void Kill(IAttacker attacker) {

			var message = "";
			switch(attacker) {
				case CharacterAttacker cAttacker:

                    //debug
                    if (!cAttacker.Attacker)
                    {
                        message = "Unknown";
                        break;
                    }

                    message = cAttacker.Attacker.name;
					break;
				default:
					message = "Unknown";
					break;
			}

			Debug.Log($"{name}は{message}に倒された!");

			Destroy(gameObject);
		}

		/// <summary>
		/// アセットから自身を生成する
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="asset"></param>
		/// <param name="spawnTransform"></param>
		/// <returns></returns>
		public static T Create<T>(CharacterAsset asset, Transform spawnTransform) where T : CharacterCore {
			var obj = Instantiate(asset.ModelPrefab, spawnTransform.position, spawnTransform.rotation);
			var chara = obj.AddComponent<T>();
			chara._parameter = asset.CharacterParameter;
			chara.OnSpawn(asset);

			return chara;
		}

		/// <summary>
		/// 生成された瞬間に呼ばれる
		/// </summary>
		/// <param name="asset"></param>
		protected abstract void OnSpawn(CharacterAsset asset);

	}
}