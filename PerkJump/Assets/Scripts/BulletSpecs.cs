using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecs : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Object shotBullet = Instantiate(bullet, spawnObject.transform.position, spawnObject.transform.rotation);
        }
    }
}
