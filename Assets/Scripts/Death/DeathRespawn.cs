using UnityEngine;

public class DeathRespawn : Death
{
    public override void Die()
    {
        gameObject.transform.position = Vector3.zero;
    }
}