using System.Collections;
using UnityEngine;

public class ShooterBullet : Shooter
{
    public GameObject bulletInstance;

    public Transform bulletSpawnpoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot()
    {
        if (bulletInstance != null && bulletSpawnpoint != null)
        {
            Instantiate(bulletInstance, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
        }
    }
}
