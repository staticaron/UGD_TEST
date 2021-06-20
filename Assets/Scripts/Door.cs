using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;

    private const string openDoorAnimationName = "OpenDoor";
    private Animator animator;

    [SerializeField] bool isOpen = false;

    private void Awake()
    {
        #region Maintain a single instance
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        #endregion
    }

    private void Start()
    {
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
                //Disable the controller
                other.GetComponent<Player>().StopMovement();

                //Time
                TimeManager timeManager = TimeManager.instance;
                float timeLeft;
                float.TryParse(timeManager.GetTimeLeft(), out timeLeft);

                LevelManager levelManager = LevelManager.instance;
                int currentBuildIndex = levelManager.currentLevelIndex;

                //Load Level according to time taken
                if (timeLeft <= 0)
                {
                    levelManager.PlayEndTransitionAndLoadLevel(currentBuildIndex, LoadReason.TIME_OUT);
                }
                else
                {
                    levelManager.PlayEndTransitionAndLoadLevel(currentBuildIndex + 1, LoadReason.LEVEL_COMPLETED);
                }
            }
        }
    }
}
