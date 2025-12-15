using System.Collections;
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

    public float offset;

    private float pitch;

    private bool reloading = false;
    private float reloadTime = 1f;
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
            ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
            Vector3 rotateAngle = cameraObject.transform.localRotation.eulerAngles;
            rotateAngle.x -= offset;

            transform.localEulerAngles = rotateAngle;
            transform.position = player.transform.position + transform.right * 0.7f + transform.up * 0.4f;
        }
        else
        {
            ammo = Global.maxAmmo;
        }
    }

    public void OnAttack()
    {
        if(!reloading && Global.waveActive)
        {
            if (ammo > 0)
            {
                SfxManager.Instance.PlaySound(GunshotSound, transform, 1f);
                Instantiate(bulletPrefab, transform.position + transform.up * 0.25f, transform.rotation);
                ammo--;
                ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
            }
            else
            {
                StartCoroutine(reloadGun());
            }
        }
    }

    public void OnReload()
    {
        if (!reloading) { 
            StartCoroutine(reloadGun());
        }
    }

    IEnumerator reloadGun()
    {
        reloading = true;
        SfxManager.Instance.PlaySound(ReloadSound, transform, 1f);
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        ammo = Global.maxAmmo;
        ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
    }
}