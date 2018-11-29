using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Nishiwaki.Item;

namespace RogueLike.Nishiwaki.Bullet
{
    public class BulletObjectLaser : MonoBehaviour
    {
        public BulletParameter BulletPara;

        // Use this for initialization
        void Start()
        {
            StartCoroutine(LaserShot());
        }

        // Update is called once per frame
        void Update()
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, BulletPara.Range);
        }

        IEnumerator LaserShot()
        {
            yield return new WaitForSeconds(2.0f);
            Destroy(gameObject);
        }

    }
}
