using UnityEngine;
using System.Collections;

public class ShootingManager : MonoBehaviour
{
    // managers 
    private PlayerManager playerManager;
    private Animator gunAnimator;

    // private variable
    private bool isShooting;
    private bool isAnimating;
     
    // Use this for initialization
    void Start()
    {
        gunAnimator = GetComponentInChildren<Animator>();
        playerManager = GetComponent<PlayerManager>();
    }

    public void FinishedShotAnim()
    {
        isShooting = true;
    }

    public void StartShooting()
    {
        
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private void Shoot()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            Shoot();
        }
    }
}
