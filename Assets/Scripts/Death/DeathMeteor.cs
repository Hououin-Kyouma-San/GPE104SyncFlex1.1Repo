using UnityEngine;

public class DeathMeteor : Death
{
    void Start()
    {
        if (GameManager.instance.meteors != null)
        {
            GameManager.instance.meteors.Add(this);
        }
    }
    public override void Die()
    {
        if (GameManager.instance.meteors != null)
        {
            GameManager.instance.meteors.Remove(this);

            // Checks if half a meteor's size is greater than the minSize, if not, it's too small to split
            if ((this.GetComponent<Meteor>().size * 0.5f) > this.GetComponent<Meteor>().minSize)
            {
                // If large enough, the meteor splits in two smaller parts
                BreakApart();
                BreakApart();
            }
        }
        Destroy(gameObject);
    }
    private void BreakApart()
    {
        // Copies the current meteor position and offsets new position by a random amount within a small area
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        // Creates two smaller copies of the meteor and sets a random trajectory
        Meteor half = Instantiate(this.GetComponent<Meteor>(), position, this.GetComponent<Meteor>().transform.rotation);
        half.GetComponent<Meteor>().size = this.GetComponent<Meteor>().size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized);

        // Gets health of meteor copies and multiplies by 1.25, giving them a slight buff
        half.GetComponent<Meteor>().GetComponent<Health>().currentHealth = GetComponent<Health>().maxHealth * 1.25f;
    }
}