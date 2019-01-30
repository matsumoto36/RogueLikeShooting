using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public float h_max, h_min;
    public float speed,_speed;
    public Color c_emistion;

    float f,g; //g _01のvalueをいじるやつ0~1
    bool key;
    int i;

    // Use this for initialization
    void Start()
    {
        f = h_min;
        g = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_emi_color", c_emistion);
        SpawnManager();
    }
    void SpawnManager()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            key = true; i = 1;
        };
        if (Input.GetKey(KeyCode.DownArrow))
        {
            key = true; i = 2;
        };

        if (key == true)
        {
            if (i == 1)
            {
                f -= speed;
                if(0 >= f) g -= _speed;
                if (0 >= g)
                {
                    key = false;
                    f = h_max;
                    i = 0;
                }
            }
            if (i == 2)
            {
                if (0.7f >= g) g += _speed;
                else f += speed;
                if (h_min <= f)
                {
                    key = false;
                    f = h_min;
                    i = 0;
                }
            }
            gameObject.GetComponent<Renderer>().material.SetFloat("_01", g);
            gameObject.GetComponent<Renderer>().material.SetFloat("_takasa", f);
        }
    }
}