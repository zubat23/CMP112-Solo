using System.Collections;
using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    public float bulletSpeed = 20f;
    private float bulletPiercing = Global.bulletPiercing;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        StartCoroutine(DestroyAfterTime(5f));

        if (bulletPiercing <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Onhit()
    {
        bulletPiercing--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            bulletPiercing--;
            if (bulletPiercing <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator DestroyAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
