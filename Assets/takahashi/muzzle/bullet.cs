using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bullet : MonoBehaviour {
    //Vector3 pos;
    //public float speed;
    //public float time;
    //public string tag_name;

    public GameObject prf_muzzle;
    public GameObject prf_damage;
	// Use this for initialization
	void Start () {
        //pos = gameObject.transform.position;

        //muzzle Particle Instantiate
        if (prf_muzzle != null)
        {
            GameObject vfx_muzzle = Instantiate(prf_muzzle, transform.position, Quaternion.identity);
            vfx_muzzle.transform.forward = gameObject.transform.forward;
            ParticleSystem clone_muzzle = vfx_muzzle.GetComponent<ParticleSystem>();
            if (clone_muzzle != null) Destroy(vfx_muzzle, clone_muzzle.main.duration);
            else
            {
                ParticleSystem clone_chiled = vfx_muzzle.transform.GetChild (0).GetComponent<ParticleSystem>();
                Destroy(vfx_muzzle, clone_chiled.main.duration);
            }
        }
    }
	
	// Update is called once per frame
	/*
     * void Update () {
        pos.z += speed;
        gameObject.transform.position = pos;

        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
	}
    */

    
    void OnCollisionEnter(Collision col)
    {
        /*if (col.gameObject.tag == tag_name)
        {
            //speed = 0;*/

        //damage particle Instantiate
        if (prf_muzzle != null)
        {
            GameObject vfx_damage = Instantiate(prf_damage, transform.position, Quaternion.identity);
            vfx_damage.transform.forward = gameObject.transform.forward;
            ParticleSystem clone_damage = vfx_damage.GetComponent<ParticleSystem>();
            if (clone_damage != null)Destroy(vfx_damage, clone_damage.main.duration);
            else
            {
                ParticleSystem clone_chiled = vfx_damage.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(vfx_damage, clone_chiled.main.duration);
                Destroy(gameObject);
            }
        }
        //}
    }
}
