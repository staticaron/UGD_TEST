using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private PauseMenuActionMap pauseMenuActionMap;

    private void Awake()
    {
        pauseMenuActionMap = new PauseMenuActionMap();
    }

    private void Start()
    {
        pauseMenuActionMap.PauseMenu.Restart.started += _ => Restart();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        int currentLevelIndex = LevelManager.instance.currentLevelIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }
}
