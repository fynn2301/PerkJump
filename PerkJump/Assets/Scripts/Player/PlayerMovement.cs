using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //objects
    public InformtionFromMenu playerInfo;
    public VariableJoystick joystick;
    public ConnectionManager connectionManager;

    private bool steerPlayer;
    private PlayerManager playerManager;
    private int jumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        
        playerManager = GetComponent<PlayerManager>();
        // setting player or enemy script
        if (playerInfo.GetPlayerIndex() == playerManager.playerIndex)
        {
            steerPlayer = true;
        }
        else
        {
            steerPlayer = false;
        }
        jumpsLeft = playerManager.jumpNum;

    }

    // Update is called once per frame
    void Update()
    {

        // getting direction from joystick or from network
        //if (steerPlayer)
        //{
        //    direction = joystick.Direction;
        //}
        //else
        //{
        //    direction = connectionManager.enemyJoystickInput;
        //}
        //if (direction.magnitude > 0.01f)
        //{
        //    MovePlayer();
        //}
    }

    public void MovePlayer(Vector2 direction)
    {

        // add velocity to player
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        if (direction.magnitude > 0.01f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(playerManager.movementSpeed * direction.x * Time.deltaTime, velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void Jump()
    {
        // send Jumo message
        if (!steerPlayer)
        {
            return;
        }
        // add force to jump
        if (jumpsLeft <= 0)
        {
            return;
        }
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerManager.jumpStrength));
        jumpsLeft--;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {

        Vector3 relativePoint = transform.InverseTransformPoint(collision.contacts[0].point);
        Debug.Log(relativePoint);
        if (relativePoint.y < 0)
        {
            jumpsLeft = playerManager.jumpNum;
        }
    }
}
