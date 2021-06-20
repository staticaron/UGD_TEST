using UnityEngine;

public class Background : MonoBehaviour
{
    //Follow the player on the xaxis
    [SerializeField] Transform target;
    [SerializeField] float followSpeed;

    private void LateUpdate()
    {
        var thisPos = transform.position;
        transform.position = Vector3.Lerp(thisPos, new Vector3(target.position.x, thisPos.y, thisPos.z), Time.deltaTime * followSpeed);
    }
}
