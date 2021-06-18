using UnityEngine;
using UnityEngine.SceneManagement;

public class Sea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
