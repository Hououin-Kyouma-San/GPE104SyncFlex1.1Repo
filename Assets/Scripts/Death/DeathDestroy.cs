using UnityEngine;

public class DeathDestroy : Death
{
    public override void Die()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}