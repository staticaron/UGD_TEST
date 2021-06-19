using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    //Update the TimeLeft text based on the TimeManager's values

    [SerializeField] TMP_Text timeLeftText;

    private TimeManager timeManager;

    private void Start()
    {
        timeManager = TimeManager.instance;
    }

    private void Update()
    {
        UpdateTimerGUI(timeManager.GetTimeLeft());
    }

    public void UpdateTimerGUI(string timeToSet)
    {
        timeLeftText.text = timeToSet;
    }

}
