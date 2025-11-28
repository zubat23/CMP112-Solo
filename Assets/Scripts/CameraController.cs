using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform target;
    //public float cameraOffset = 5.0f;

    private float yaw;
    private float pitch;


    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X");// * Time.deltaTime;
        pitch += Input.GetAxis("Mouse Y");// * Time.deltaTime;

        transform.position = target.position;

        transform.rotation = Quaternion.AngleAxis(yaw,Vector3.up);
        transform.rotation *= Quaternion.AngleAxis(pitch,Vector3.right);

        transform.Translate(-Vector3.forward * 5.0f);

        //Vector3 newPosition = transform.position;
        //newPosition.y += 1;
        //newPosition.z -= 5;
        //transform.position = newPosition;
        
    }
}
