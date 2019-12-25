using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteOrientation : MonoBehaviour
{
	private float scale;
    private bool positivOriantation;
    // Start is called before the first frame update
    void Start()
    {
		scale = transform.localScale.x;
        if (scale > 0.001f)
        {
            positivOriantation = true;
        }
        else
        {
            positivOriantation = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        Vector3 tmpScale = transform.localScale;
        Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
        if (velocity.x > 0.0001f && !positivOriantation)
        {
            transform.localScale = new Vector3(scale, tmpScale.y, tmpScale.z);
            positivOriantation = true;
        }
        else if (velocity.x < -0.0001f && positivOriantation)
        {
            transform.localScale = new Vector3(-scale, tmpScale.y, tmpScale.z);
            positivOriantation = false;
        }
    }
}
