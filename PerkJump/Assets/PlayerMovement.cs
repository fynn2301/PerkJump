﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 500, 0));
            Debug.Log("Jump");
        }
    }
}
