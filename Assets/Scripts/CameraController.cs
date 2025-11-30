using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 100.0f;
    public float cameraOffset = 5.0f;

    private float yaw;
    private float pitch;


    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        pitch += Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;

        pitch = Mathf.Clamp(pitch, 10f, 70f);

        transform.position = target.position;


        transform.rotation = Quaternion.AngleAxis(yaw,Vector3.up);
        transform.rotation *= Quaternion.AngleAxis(pitch,Vector3.right);

        transform.Translate(-Vector3.forward * cameraOffset);
        
    }
}
