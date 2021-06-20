using UnityEngine;

public class Spike : MonoBehaviour
{
    //Add Damage when player hits it.

    private const string PlayerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PlayerTag))
        {
            //Add damage to the player
            Health health = other.GetComponent<Health>();
            health.TakeDamage(LoadReason.SPIKE);
        }
    }
}
