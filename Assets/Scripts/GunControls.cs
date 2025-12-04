using UnityEngine;
using UnityEngine.Rendering;

public class GunControls : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletPrefab;

    public float offset;

    private float pitch;

    private float ammo = 6f;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            pitch += Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, 10f, 70f);


            transform.rotation = player.transform.rotation;
            transform.position = player.transform.position + transform.right * 0.7f + transform.up * 0.4f;
            transform.rotation *= Quaternion.AngleAxis(pitch - offset, Vector3.right);
        }
    }

    public void OnAttack()
    {
        if (ammo > 0)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            ammo--;
        }
    }

    public void OnReload()
    {
        ammo = 6f;
    }
}
