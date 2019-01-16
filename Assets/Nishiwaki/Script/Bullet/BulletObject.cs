using System.Collections;
using System.Collections.Generic;
using DDD.Matsumoto.Character;
using DDD.Nishiwaki.Item;
using UnityEngine;
using DDD.Nishiwaki.Bullet;
using DDD.Katano.Managers;
using UniRx;

namespace DDD.Nishiwaki.Bullet
{
    public class BulletObject : MonoBehaviour
    {

        public BulletParameter BulletPara;
        public WeaponRanged weaponRanged;
        // 消滅用の時間
        float DestroyTime = 0.0f;

        void Start()
        {
            gameObject.GetComponent<vfx_bullet>().muzzle();

			//フロア破壊時に弾を消去する
	        FindObjectOfType<MainGameManager>()
		        .EventReceive<Katano.MazeSignal.FloorDestruct>()
		        .Subscribe((_) => Destroy(gameObject))
		        .AddTo(this);
		}

        void Update()
        {
            Rigidbody rig = GetComponent<Rigidbody>();

            Vector3 now = rig.position;

            now += transform.forward * (BulletPara.Speed * 0.1f);

            rig.position = now;
            // 自動消滅の時間
            DestroyTime += Time.deltaTime;
            // 消滅
            if (DestroyTime >= BulletPara.LifeTime)
            {
                Destroy(gameObject);
            }
        }
        // まだ仮
        void OnTriggerEnter(Collider other)
        {
            // 敵に当たったら
            var character = other.GetComponentInParent<CharacterCore>();
            if (!character) return;
            if (CharacterCore.IsAttackable(weaponRanged.characterCore, character))
            {
                // 敵にダメージを与える
                // nullの部分は攻撃者
                character.ApplyDamage(
                    new Matsumoto.Attack.CharacterAttacker(weaponRanged.characterCore), (int)BulletPara.Power);
                gameObject.GetComponent<vfx_bullet>().damage();
            }
        }
    }
}