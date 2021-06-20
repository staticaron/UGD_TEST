using UnityEngine;

public class Health : MonoBehaviour
{
    //When takes damage reload the scene and spawn some particles

    public void TakeDamage(LoadReason reason)
    {
        //Spawn Some death effects

        //Play dead sfx
        GetComponent<Player>().StopMovement();

        //Reload the scene
        LevelManager levelManager = LevelManager.instance;
        int currentLevelIndex = levelManager.currentLevelIndex;
        levelManager.PlayEndTransitionAndLoadLevel(currentLevelIndex, reason);
    }
}
