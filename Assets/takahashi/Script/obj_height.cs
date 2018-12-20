using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_height : MonoBehaviour {
    public float h_max, h_min;
    public float speed;
    public float objy;
    public Color c_emistion;
    public bool b;

    float f;
    bool key;
    int i;

	// Use this for initialization
	void Start () {
        if (b) {
            gameObject.GetComponent<Renderer>().material.SetFloat("_v_jouge", h_min);
            f = h_min;
        }
        else {
            gameObject.GetComponent<Renderer>().material.SetFloat("_v_jouge", h_max);
            f = h_max;
        }

    }
	
	// Update is called once per frame
	void Update () {
        objy = gameObject.GetComponent<Transform>().position.y;
        gameObject.GetComponent<Renderer>().material.SetFloat("_takasa",objy);
        gameObject.GetComponent<Renderer>().material.SetColor("_emi_color", c_emistion);
        SpawnManager();

    }

    public void Show()
    {
        key = true;
        i = 1;
    }

    public void Hide()
    {
        key = true;
        i = 2;
    }

    void SpawnManager()
    {

//        if (Input.GetKey(KeyCode.UpArrow))
//        {
//            key = true; i = 1; Debug.Log("a");
//        };
//        if (Input.GetKey(KeyCode.DownArrow))
//        {
//            key = true; i = 2; Debug.Log("ab");
//        };
        if (key == true)
        {
            if (i == 1)
            {
                f -= speed;
                gameObject.GetComponent<Renderer>().material.SetFloat("_v_jouge", f);
                Debug.Log("aaa");
                if(h_max >= f)
                {
                    key = false;
                    f = h_max;
                    i = 0;
                }
            }
            if (i == 2)
            {
                f += speed;
                gameObject.GetComponent<Renderer>().material.SetFloat("_v_jouge", f);
                Debug.Log("bbb");
                if (h_min <= f)
                {
                    key = false;
                    f = h_min;
                    i = 0;
                }
            }
        }
                

    }
}
