using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using SVSBluetooth;

// this script serves as a bridge between the game script and the bluetooth plugin

public class NetworkManager : MonoBehaviour {
    public static NetworkManager instance; // singleton

    // subscription and unsubscribe to events
    private void OnEnable() {
        BluetoothForAndroid.DeviceDisconnected += ExitGameScene;
        BluetoothForAndroid.ReceivedByteMessage += GetMessage;
    }
    private void OnDisable() {
        BluetoothForAndroid.DeviceDisconnected -= ExitGameScene;
        BluetoothForAndroid.ReceivedByteMessage -= GetMessage;
    }

    void Start() {
        if (instance == null) instance = this; // creating singleton
    }

    // data transfer protocol
    // you can come up with any protocol

    // message[0] == 0 - change position
    // message[0] == 1 - shot start
    // message[0] == 2 - shot stop

    void GetMessage(byte[] message) {
        switch ((int)message[0]) {
            case 0:
                ConnectionManager.instance.PutInBufferPosition(message);
                break;
            case 1:
                ConnectionManager.instance.ShotEnemyStart();
                break;
            case 2:
                ConnectionManager.instance.ShotEnemyStop();
                break;
            default:
                break;
        }
    }

    // message transfer
    public void WriteMessage(byte[] message) {
        BluetoothForAndroid.WriteMessage(message);
    }
    // go to menu and disconnect
    public void ExitGameScene() {
        BluetoothForAndroid.Disconnect();
        SceneManager.LoadScene(0);
    }
    // converting float to byte array and back from byte array to float
    public byte[] FloatToBytes(float f) {
        byte[] bytes = BitConverter.GetBytes(f);
        return bytes;
    }
    public float BytesToFloat(byte[] bytes) {
        float f = BitConverter.ToSingle(bytes, 0);
        return f;
    }
}
