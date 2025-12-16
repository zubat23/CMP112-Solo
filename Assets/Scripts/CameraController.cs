using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float sensitivity = 100.0f;
    public float cameraOffset = 5.0f;

    private float yaw;
    private float pitch;


    private void LateUpdate()
    {
        if (target != null && Global.waveActive)
        {
            //Get mouse input and clamp pitch.
            yaw += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
            pitch += Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;


            pitch = Mathf.Clamp(pitch, 10f, 70f);

            //Set camera position and rotation.
            transform.position = target.position;


            transform.rotation = Quaternion.AngleAxis(yaw, Vector3.up);
            transform.rotation *= Quaternion.AngleAxis(pitch, Vector3.right);

            transform.Translate(-Vector3.forward * cameraOffset);
        }
        
    }
}
