using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecs : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawnObject;
    public float bulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shot()
    {
        GameObject shotBullet = Instantiate(bullet, spawnObject.transform.position, bullet.transform.rotation);
        shotBullet.GetComponent<Rigidbody2D>().AddForce(spawnObject.transform.forward.normalized * bulletVelocity);
        Debug.Log(spawnObject.transform.forward);
    }
}
