using System.Collections;
using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    public float bulletSpeed = 20f;

    //Gets the piercing value from Global
    private float bulletPiercing = Global.bulletPiercing;

    private void Start()
<<<<<<< Updated upstream
    {
        //Start timer that destroys the bullet
        StartCoroutine(DestroyAfterTime(5f));
=======
    {
        //Start timer that destroys the bullet
        StartCoroutine(DestroyAfterTime(5f));
    }
    void Update()
    {
        //Move the bullet
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
>>>>>>> Stashed changes
    }
    void Update()
    {
<<<<<<< Updated upstream
        //Move the bullet
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
<<<<<<< Updated upstream
        StartCoroutine(DestroyAfterTime(5f));

=======
        //Called when an enemy is hit, reduces piercing value and destroys bullet if it's 0
        bulletPiercing--;
>>>>>>> Stashed changes
        if (bulletPiercing <= 0)
        {
            Destroy(this.gameObject);
        }
=======
>>>>>>> Stashed changes
    }

<<<<<<< Updated upstream
    public void Onhit()
    {
        //Called when an enemy is hit, reduces piercing value and destroys bullet if it's 0
        bulletPiercing--;
<<<<<<< Updated upstream
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
=======
        if (bulletPiercing <= 0)
>>>>>>> Stashed changes
        {
            bulletPiercing--;
            if (bulletPiercing <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

=======
>>>>>>> Stashed changes
    IEnumerator DestroyAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
