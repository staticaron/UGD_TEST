using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Rigidbody2D targetBody;
    private Vector3 targetPrevPos;
    private float speed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxOffset;

    private Camera thisCam;
    [SerializeField] float normalOrthographicSize;
    [SerializeField] float maxOrthographicSize;
    [SerializeField] float easingSpeed;

    private void Start()
    {
        thisCam = GetComponent<Camera>();
        targetPrevPos = target.position;
        targetBody = target.GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        #region Camera Follow
        float camDist = Mathf.Sqrt(Vector2.SqrMagnitude((Vector2)transform.position - (Vector2)target.position));

        if (camDist < maxOffset)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = maxSpeed;
        }

        var movementVector = Vector2.Lerp(transform.position, target.position, Time.deltaTime * speed);
        transform.position = new Vector3(movementVector.x, movementVector.y, -10);

        #endregion

        #region Camera Easing

        //Get the target's velocity
        float targetVel = Mathf.Sqrt(Vector3.SqrMagnitude(targetBody.velocity));

        //Set the orthographic size based on the velocity
        thisCam.orthographicSize = Mathf.Lerp(thisCam.orthographicSize, Mathf.Clamp(targetVel, normalOrthographicSize, maxOrthographicSize), Time.deltaTime * easingSpeed);

        targetPrevPos = target.position;
        #endregion
    }
}
