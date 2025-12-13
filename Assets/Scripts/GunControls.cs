using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GunControls : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraObject;
    public GameObject bulletPrefab;
    public TextMeshProUGUI ammoText;

    public AudioClip GunshotSound;
    public AudioClip ReloadSound;

    private float pitch;

    private float ammo = Global.maxAmmo;

    void Start()
    {
        ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Global.waveActive)
        {
            pitch += Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -10f, 50f);


            transform.rotation = player.transform.rotation;
            transform.position = player.transform.position + transform.right * 0.7f + transform.up * 0.4f;
            transform.rotation *= Quaternion.AngleAxis(pitch, Vector3.right);
        }
        else
        {
            ammo = Global.maxAmmo;
            ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
        }
    }

    public void OnAttack()
    {
        if (ammo > 0 && Global.waveActive)
        {
            SfxManager.Instance.PlaySound(GunshotSound, transform, 1f);
            Instantiate(bulletPrefab, transform.position + transform.up * 0.25f, transform.rotation);
            ammo--;
            ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
        }
        else if (Global.waveActive)
        {
            reloadGun();
        }
    }

    public void OnReload()
    {
        reloadGun();
    }

    public void reloadGun()
    {
        SfxManager.Instance.PlaySound(ReloadSound, transform, 1f);
        ammo = Global.maxAmmo;
        ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
    }
}