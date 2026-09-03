using UnityEngine;

public class MissileTargeting : MonoBehaviour
{
    public float speed;
    private Transform target;

    void Update()
    {
        // Find the closest target every frame (or use an InvokeRepeating for performance)
        GameObject closest = FindClosestEnemy();
        if (closest != null)
        {
            target = closest.transform;
        }

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.up = target.transform.position - transform.position;
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, currentPos);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }
        return closest;
    }
}