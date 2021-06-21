using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const string lastLevelReachedPlayerPrefsKey = "LevelReached";
    private int lastLevelReached;

    private void Awake()
    {
        lastLevelReached = PlayerPrefs.GetInt(lastLevelReachedPlayerPrefsKey);
        lastLevelReached = lastLevelReached == 0 ? 1 : lastLevelReached;
    }

    public void Play()
    {
        SceneManager.LoadScene(lastLevelReached);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
