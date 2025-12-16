using System.Collections;
using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    public float bulletSpeed = 20f;

    //Gets the piercing value from Global
    private float bulletPiercing = Global.bulletPiercing;

    private void Start()
    {
        //Start timer that destroys the bullet
        StartCoroutine(DestroyAfterTime(5f));
    }
    void Update()
    {
        //Move the bullet
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
    void Update()
    {

        //Called when an enemy is hit, reduces piercing value and destroys bullet if it's 0
        bulletPiercing--;
        if (bulletPiercing <= 0)
        {
            Destroy(this.gameObject);
        }
    }

        if (other.gameObject.CompareTag("Enemy"))
        if (bulletPiercing <= 0)

        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
