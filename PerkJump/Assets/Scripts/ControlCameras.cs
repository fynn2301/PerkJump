using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCameras : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;


    // Bekommt über getcomponent
    // Start is called before the first frame update
    void Start()
    {
        InformtionFromMenu playerInfo = GetComponent<InformtionFromMenu>();

        if  (playerInfo.GetPlayerIndex() == 1)
        {
            camera2.GetComponent<Camera>().enabled = false;
            camera1.GetComponent<Camera>().enabled = true;
        }
        else
        {
            camera1.GetComponent<Camera>().enabled = false;
            camera2.GetComponent<Camera>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
