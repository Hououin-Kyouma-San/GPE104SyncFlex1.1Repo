using System.Collections;
using UnityEngine;

public class ShooterBullet : Shooter
{
    public GameObject bulletInstance;

    public Transform bulletSpawnpoint;

    public StarShipPawn starShip;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starShip = GetComponent<StarShipPawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot()
    {
        if (bulletInstance != null && bulletSpawnpoint == isActiveAndEnabled)
        {
            GameObject bullet = Instantiate(bulletInstance, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
            bullet.GetComponent<BulletMovement>().speed += starShip.moveSpeed;
        }
    }
}
