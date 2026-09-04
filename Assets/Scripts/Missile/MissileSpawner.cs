using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public Missile missilePrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public int spawnAmount;

    void Start()
    {
        // Continuously spawns new missiles at regular intervals
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }
    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            // Sets missile spawn position and offsets position by a random amount within an area
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            // Sets variance and rotation of a new missile's trajectory
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            // Creates a new instance of a missile
            Missile missile = Instantiate(this.missilePrefab, spawnPoint, rotation);
        }
    }
}