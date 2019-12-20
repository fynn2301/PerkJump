using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviour {
    // player input

    public Vector2 playerJoystickInput;
    public Vector2 enemyJoystickInput;

    public static ConnectionManager instance;
    // Objects
    public GameObject tankPlayer;
    public GameObject tankEnemy;
    public GameObject bullet;
    // Game variables

    // Fields for interpolating the movement of an enemy
    Queue<Vector2> posEnemyBuffer = new Queue<Vector2>();

    void Start() {
        float deltaTime = 1f / 30f;
        InvokeRepeating("MovePlayer", 0f, deltaTime);
        InvokeRepeating("MoveEnemy", deltaTime, deltaTime);
        InvokeRepeating("SendPosition", deltaTime, deltaTime);
    }


    ////////////////////////
    // This player send input
    ////////////////////////

    public void ShotPlayerStart()
    {
        byte[] shotMessage = new byte[1];
        shotMessage[0] = 1;
        NetworkManager.instance.WriteMessage(shotMessage);
    }

    public void ShotPlayerStop()
    {
        byte[] shotMessage = new byte[1];
        shotMessage[0] = 2;
        NetworkManager.instance.WriteMessage(shotMessage);
    }


    // wrapping a player’s tank position into an array of bytes and transferring this array to an enemy device
    void SendDirection() {
        byte[] position = new byte[9];
        byte[] posX = new byte[4];
        byte[] posY = new byte[4];
        posX = NetworkManager.instance.FloatToBytes(playerJoystickInput.x);
        posY = NetworkManager.instance.FloatToBytes(playerJoystickInput.y);
        position[0] = 0;
        position[1] = posX[0];
        position[2] = posX[1];
        position[3] = posX[2];
        position[4] = posX[3];
        position[5] = posY[0];
        position[6] = posY[1];
        position[7] = posY[2];
        position[8] = posY[3];
        NetworkManager.instance.WriteMessage(position); // message transfer
    }


    ////////////////////////
    // Enemy Input
    ////////////////////////

    public void ShotEnemyStart()
    {

    }

    public void ShotEnemyStop()
    {

    }

    // The resulting positions are converted from an array of bytes to coordinates of type Vector2 and added to the buffer.
    public void PutInBufferPosition(byte[] position)
    {
        Vector2 currentPosition;
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
        currentPosition.x = NetworkManager.instance.BytesToFloat(posX);
        currentPosition.y = NetworkManager.instance.BytesToFloat(posY);
        posEnemyBuffer.Enqueue(currentPosition);
    }

    // Set This Input
    public void SetPlayerInput()
    {

    }

    public void ShotButtonPointerDown() {
        StartCoroutine("ShotPlayer");
    }
    public void ShotButtonPointerUp() {
        StopCoroutine("ShotPlayer");
    }
    public void ExitScene() {
        NetworkManager.instance.ExitGameScene();
    }


}
