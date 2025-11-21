using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private float yaw;
    private float pitch;


    private void LateUpdate()
    {
        yaw = Input.GetAxis("Mouse X");
        pitch = Input.GetAxis("Mouse Y");

        transform.position = target.position;

        Debug.Log(Quaternion.AngleAxis(yaw, Vector3.up));
        transform.rotation = Quaternion.AngleAxis(yaw,Vector3.up);
        transform.rotation *= Quaternion.AngleAxis(pitch,Vector3.right);

        Vector3 newPosition = transform.position;
        newPosition.y += 1;
        newPosition.z -= 5;
        transform.position = newPosition;
    }
}
