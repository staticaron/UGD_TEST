using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    //Singletons
    public static BGM instance;

    [SerializeField] string mainMenuSceneName = "MainMenu";

    [SerializeField] AudioSource BGMPlayer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += SceneLoaded;

        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        SceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        BGMPlayer = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    private void SceneLoaded(Scene sceneLoaded, LoadSceneMode mode)
    {
        if (sceneLoaded.name == mainMenuSceneName)
        {
            BGMPlayer.Stop();
            BGMPlayer.Play();
            Debug.Log("BGM Reset");
        }
        Debug.Log("BGM Continues");
    }
}
