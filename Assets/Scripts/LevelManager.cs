using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private Animator animator;

    public const string TransitionOutAnimationName = "TransitionOut";

    public int currentLevelIndex;
    public int levelToLoad = 0;

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

    public void PlayEndTransitionAndLoadLevel(int levelIndex)
    {
        //Play Transition
        animator.Play(TransitionOutAnimationName);

        levelToLoad = levelIndex;
    }

    public void LoadLevel()
    {
        if (levelToLoad != 0) SceneManager.LoadScene(levelToLoad);
        else SceneManager.LoadScene(currentLevelIndex);
    }
}
