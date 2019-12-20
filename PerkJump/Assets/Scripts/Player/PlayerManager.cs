using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    /* CHARACTER TRAITS */
    //player
    
    public float movementSpeed;
    public float maxHealth;
    public float health;
    public float jumpStrength;

    //weapons
    public int ammoPistol;
    public int ammoSubMashine;
    public int granate;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 relativePoint = transform.InverseTransformPoint(collision.contacts[0].point);
        Debug.Log(relativePoint);
    }
}
