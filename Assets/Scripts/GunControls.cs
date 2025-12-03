using UnityEngine;

public class GunControls : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletPrefab;

    private GameObject gun;

    void Start()
    {
        gun = this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            gun.transform.rotation = player.transform.rotation;
            gun.transform.position = player.transform.position + transform.right * 0.7f + transform.up * 0.4f;
        }
    }

    public void OnAttack()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
