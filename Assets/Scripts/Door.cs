using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;

    private const string openDoorAnimationName = "OpenDoor";
    private Animator animator;

    [SerializeField] bool isOpen = false;

    private void Start()
    {
        #region Maintain a single instance
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        #endregion

        //References
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.Play(openDoorAnimationName);
        isOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Check for the open door
            if (isOpen)
            {
                TimeManager timeManager = TimeManager.instance;
                float timeLeft;
                float.TryParse(timeManager.GetTimeLeft(), out timeLeft);

                LevelManager levelManager = LevelManager.instance;
                int currentBuildIndex = levelManager.currentLevelIndex;

                if (timeLeft <= 0)
                {
                    levelManager.PlayEndTransitionAndLoadLevel(currentBuildIndex);
                }
                else
                {
                    levelManager.PlayEndTransitionAndLoadLevel(currentBuildIndex + 1);
                }
            }
        }
    }
}
