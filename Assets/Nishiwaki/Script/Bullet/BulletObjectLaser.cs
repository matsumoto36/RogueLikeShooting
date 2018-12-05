using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Item;

namespace RogueLike.Nishiwaki.Bullet
{
    public class BulletObjectLaser : MonoBehaviour
    {
        public BulletParameter BulletPara;
        //float time;
        void Start()
        {
            //time = BulletPara.ChargeTime;
            //StartCoroutine(LaserShot());
        }

        void Update()
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, BulletPara.Range);
        }

        public void BulletDestroy()
        {
            Destroy(gameObject);
        }
        //IEnumerator LaserShot()
        //{
        //    yield return new WaitForSeconds(2);
        //    Destroy(gameObject);
        //}
    }
}
