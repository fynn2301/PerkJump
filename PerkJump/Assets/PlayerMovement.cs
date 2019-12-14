using System.Collections;
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
            transform.position += new Vector3(0.1f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.1f, 0, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, GetComponent<Rigidbody2D>().velocity.y, 0);
        }
        //__________________________________________//

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 150, 0));
            Debug.Log("Jump");
        }
    }
}
