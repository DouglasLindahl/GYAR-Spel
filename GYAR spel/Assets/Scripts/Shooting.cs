using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Shooting : NetworkBehaviour
{
    public GameObject shotPoint;
    public GameObject projectile;
    public float shotCooldown;
    private float shotCooldown2 = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        Shoot();
    }
    public void Shoot()
    {
        if(shotCooldown2 <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                Instantiate(projectile, shotPoint.transform.position, shotPoint.transform.rotation);
                shotCooldown2 = shotCooldown;
            }
        }
        else
        {
            shotCooldown2 -= Time.deltaTime;
        }
    }
}
