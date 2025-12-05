using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GunControls : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletPrefab;
    public TextMeshProUGUI ammoText;

    public float offset;

    private float pitch;

    private float ammo = 6f;
    private float maxAmmo = 6f;

    void Start()
    {
        ammoText.text = "Ammo: " + ammo.ToString() + "/" + maxAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            pitch += Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -10f, 50f);


            transform.rotation = player.transform.rotation;
            transform.position = player.transform.position + transform.right * 0.7f + transform.up * 0.4f;
            transform.rotation *= Quaternion.AngleAxis(pitch - offset, Vector3.right);
        }
    }

    public void OnAttack()
    {
        if (ammo > 0)
        {
            Instantiate(bulletPrefab, transform.position + transform.up * 0.25f, transform.rotation);
            ammo--;
            ammoText.text = "Ammo: " + ammo.ToString() + "/" + maxAmmo.ToString();
        }
    }

    public void OnReload()
    {
        ammo = 6f;
        ammoText.text = "Ammo: " + ammo.ToString() + "/" + maxAmmo.ToString();
    }
}