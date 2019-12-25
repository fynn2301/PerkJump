using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviour {
    // player input

    public static ConnectionManager instance;

    // Player
    public InformtionFromMenu playerInfo;
    public GameObject player1;
    public GameObject player2;
    private GameObject thisPlayer;
    private GameObject enemyPlayer;

    // Fields for interpolating the movement of an enemy
    Queue<Vector2> posEnemyBuffer = new Queue<Vector2>();

    void Start() {
        if (playerInfo.GetPlayerIndex() == 1)
        {
            thisPlayer = player1;
            enemyPlayer = player2;
        }
        else
        {
            thisPlayer = player2;
            enemyPlayer = player1;
        }
        float deltaTime = 1f / 30f;
        //InvokeRepeating("SetEnemyDirection", 0f, deltaTime);
        InvokeRepeating("SendAndSetDirection", deltaTime, deltaTime);
    }


    ////////////////////////
    // This player send input
    ////////////////////////
    // wrapping a player’s tank position into an array of bytes and transferring this array to an enemy device



    void SendAndSetDirection() {
        // send direction

        Vector2 playerJoystickInput = GetComponentInChildren<VariableJoystick>().Direction;
        if (playerJoystickInput.magnitude < 0.01f)
        {
            return;
        }
        byte[] direction = new byte[9];
        byte[] posX = new byte[4];
        byte[] posY = new byte[4];
        posX = NetworkManager.instance.FloatToBytes(playerJoystickInput.x);
        posY = NetworkManager.instance.FloatToBytes(playerJoystickInput.y);
        direction[0] = 0;
        direction[1] = posX[0];
        direction[2] = posX[1];
        direction[3] = posX[2];
        direction[4] = posX[3];
        direction[5] = posY[0];
        direction[6] = posY[1];
        direction[7] = posY[2];
        direction[8] = posY[3];
        NetworkManager.instance.WriteMessage(direction); // message transfer

        // set player
        thisPlayer.GetComponent<PlayerMovement>().MovePlayer(playerJoystickInput);
    }


    ////////////////////////
    // Enemy Input
    ////////////////////////
    //public void SetEnemyDirection()
    //{
    //    if (posEnemyBuffer.Count > 0) enemyJoystickInput = posEnemyBuffer.Dequeue();
    //}

    // The resulting positions are converted from an array of bytes to coordinates of type Vector2 and added to the buffer.
    public void PutInBufferPosition(byte[] position)
    {
        Vector2 currentDirection;
        byte[] posX = new byte[4];
        byte[] posY = new byte[4];
        posX[0] = position[1];
        posX[1] = position[2];
        posX[2] = position[3];
        posX[3] = position[4];
        posY[0] = position[5];
        posY[1] = position[6];
        posY[2] = position[7];
        posY[3] = position[8];
        currentDirection.x = NetworkManager.instance.BytesToFloat(posX);
        currentDirection.y = NetworkManager.instance.BytesToFloat(posY);
        //posEnemyBuffer.Enqueue(currentDirection);

        enemyPlayer.GetComponent<PlayerMovement>().MovePlayer(currentDirection);
    }

    // Set This Input

    public void ExitScene() {
        NetworkManager.instance.ExitGameScene();
    }



}
