using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    public float bulletSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}
