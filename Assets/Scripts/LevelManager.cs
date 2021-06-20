using UnityEngine;
using UnityEngine.SceneManagement;

public enum LoadReason { LEVEL_COMPLETED, TIME_OUT, SPIKE, SEA };

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private Animator animator;

    public const string TransitionOutAnimationName = "TransitionOut";

    public int currentLevelIndex;
    private int levelToLoad = 0;

    //Time
    [SerializeField] float reloadTimeSpikes;
    [SerializeField] float reloadTimeLevelComplete;
    [SerializeField] float reloadTimeTimeOut;
    [SerializeField] float reloadTimeSea;

    private void Awake()
    {
        #region Maintain a single instance
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        #endregion
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayEndTransitionAndLoadLevel(int levelIndex, LoadReason reason)
    {
        levelToLoad = levelIndex;

        switch (reason)
        {
            case LoadReason.SPIKE:
                Invoke("PlayEndTransition", reloadTimeSpikes);
                break;
            case LoadReason.LEVEL_COMPLETED:
                Invoke("PlayEndTransition", reloadTimeLevelComplete);
                break;
            case LoadReason.SEA:
                Invoke("PlayEndTransition", reloadTimeSea);
                break;
            case LoadReason.TIME_OUT:
                Invoke("PlayEndTransition", reloadTimeTimeOut);
                break;
        }
    }

    private void PlayEndTransition()
    {
        //Play Transition
        animator.Play(TransitionOutAnimationName);
    }


    public void LoadLevel()
    {
        if (levelToLoad != 0) SceneManager.LoadScene(levelToLoad);
        else SceneManager.LoadScene(currentLevelIndex);
    }
}
