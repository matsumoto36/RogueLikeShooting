using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_height_c : MonoBehaviour {

    public string obj_name;
    public GameObject m_obj;


	// Use this for initialization
	void Start () {
        m_obj = GameObject.Find(obj_name);
        //m_obj = transform.root.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        float f = m_obj.GetComponent<Renderer>().material.GetFloat("_v_jouge");
        gameObject.GetComponent<Renderer>().material.SetFloat("_v_jouge",f);
        gameObject.GetComponent<Renderer>().material.SetFloat("_takasa",m_obj.GetComponent<obj_height>().objy);
        gameObject.GetComponent<Renderer>().material.SetColor("_emi_color", m_obj.GetComponent<obj_height>().c_emistion);
    }
}
