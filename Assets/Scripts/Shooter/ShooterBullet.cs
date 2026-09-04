using System.Collections;
using UnityEngine;

public class ShooterBullet : Shooter
{
    public GameObject bulletInstance;
    public Transform bulletSpawnpoint;
    private StarShipPawn starShip;
    private float fireDelay = 0.075f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starShip = GetComponent<StarShipPawn>();
    }
    public override void Shoot()
    {
        if (bulletInstance != null && bulletSpawnpoint == isActiveAndEnabled)
        {
            // Creates coroutine controlling burst fire rate
            StartCoroutine(timer());
            IEnumerator timer()
            {
                // First shot fires instantly
                GameObject bullet1 = Instantiate(bulletInstance, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
                bullet1.GetComponent<BulletMovement>().speed += starShip.moveSpeed;

                // Sets timed delay after first shot and fires
                yield return new WaitForSeconds(fireDelay);
                GameObject bullet2 = Instantiate(bulletInstance, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
                bullet2.GetComponent<BulletMovement>().speed += starShip.moveSpeed;

                // Sets timed delay after second shot and fires
                yield return new WaitForSeconds(fireDelay);
                GameObject bullet3 = Instantiate(bulletInstance, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
                bullet3.GetComponent<BulletMovement>().speed += starShip.moveSpeed;
            }
        }
    }
}