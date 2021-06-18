using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;

    private void Start()
    {
        #region Maintain a single instance
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        #endregion

        Debug.Log($"{instance.name}");
    }
}
