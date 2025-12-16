using System.Collections;
using System.Runtime.CompilerServices;
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
    public float offset;

    private bool reloading = false;
    private float reloadTime = 1f;
    private float ammo = Global.maxAmmo;

    private float currentMaxAmmo = Global.maxAmmo; 

    void Start()
    {
        //Set the UI text appropriately
        ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Global.waveActive)
        {
            //Set the UI text appropriately
            ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();

            //Set the gun position based on the player, and the rotation based on the camera
            Vector3 rotateAngle = cameraObject.transform.localRotation.eulerAngles;
            rotateAngle.x -= offset;

            transform.localEulerAngles = rotateAngle;
            transform.position = player.transform.position + transform.right * 0.7f + transform.up * 0.4f;
        }
        else
        {
            ammo = Global.maxAmmo;
        }

        if (currentMaxAmmo != Global.maxAmmo)
        {
            ammo = Global.maxAmmo;
            currentMaxAmmo = Global.maxAmmo;
        }
    }

    public void OnAttack()
    {
        //Check if able to fire
        if(!reloading && Global.waveActive)
        {
            //Check if there is ammo
            if (ammo > 0)
            {
                //Fires a bullet and decreases ammo count
                SfxManager.Instance.PlaySound(GunshotSound, transform, 1f);
                Instantiate(bulletPrefab, transform.position + transform.up * 0.25f, transform.rotation);
                ammo--;
                ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
            }
            else
            {
                //If player attempts to fire with empty clip, reload.
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
        //Reloads the gun after a delay
        reloading = true;
        SfxManager.Instance.PlaySound(ReloadSound, transform, 1f);
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        ammo = Global.maxAmmo;
        ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
    }
}