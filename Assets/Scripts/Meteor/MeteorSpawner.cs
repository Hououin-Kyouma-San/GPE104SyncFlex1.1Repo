using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public Meteor meteorPrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public int spawnAmount;

    void Start()
    {
        // Continuously spawns new meteors at regular intervals
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }
    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            // Sets meteor spawn position and offsets position by a random amount within an area
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            // Sets variance and rotation of a new meteor's trajectory
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            // Creates a new instance of meteor, and sets random size plus trajectory
            Meteor meteor = Instantiate(this.meteorPrefab, spawnPoint, rotation);
            meteor.size = Random.Range(meteor.minSize, meteor.maxSize);
            meteor.SetTrajectory(rotation * -spawnDirection);
        }
    }
}