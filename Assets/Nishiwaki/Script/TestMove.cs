﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    float x;
	void Start () {
		
	}
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            x = -2.0f;
        else if (Input.GetKey(KeyCode.RightArrow))
            x = 2.0f;
        else
            x = 0.0f;

        transform.Rotate(0.0f, x, 0.0f);
    }
}