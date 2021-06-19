using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private SpriteRenderer ren;

    [SerializeField] ParticleSystem collectedParticle;
    [SerializeField] bool isCollected;

    private void Start()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isCollected == false)
            {
                //Disable the collectible
                ren.enabled = false;

                //Play Collected Animation
                collectedParticle.Play();

                //Open the door
                Door.instance.OpenDoor();

                isCollected = true;
            }
        }
    }
}
