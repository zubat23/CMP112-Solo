<<<<<<< Updated upstream
=======
using System.Collections;
using System.Runtime.CompilerServices;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
    private float pitch;
=======
    public float offset;

>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
            pitch += Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -10f, 50f);
=======
            //Set the UI text appropriately
            ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();

            //Set the gun position based on the player, and the rotation based on the camera
            Vector3 rotateAngle = cameraObject.transform.localRotation.eulerAngles;
            rotateAngle.x -= offset;
>>>>>>> Stashed changes


            transform.rotation = player.transform.rotation;
            transform.position = player.transform.position + transform.right * 0.7f + transform.up * 0.4f;
            transform.rotation *= Quaternion.AngleAxis(pitch, Vector3.right);
        }
        else
        {
            ammo = Global.maxAmmo;
            ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
        }

        if (currentMaxAmmo != Global.maxAmmo)
        {
            ammo = Global.maxAmmo;
            currentMaxAmmo = Global.maxAmmo;
        }
    }

    public void OnAttack()
    {
<<<<<<< Updated upstream
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
=======
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
>>>>>>> Stashed changes
        }
    }

    public void OnReload()
    {
        reloadGun();
    }

    public void reloadGun()
    {
<<<<<<< Updated upstream
=======
        //Reloads the gun after a delay
        reloading = true;
>>>>>>> Stashed changes
        SfxManager.Instance.PlaySound(ReloadSound, transform, 1f);
        ammo = Global.maxAmmo;
        ammoText.text = "Ammo: " + ammo.ToString() + "/" + Global.maxAmmo.ToString();
    }
}