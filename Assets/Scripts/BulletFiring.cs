using UnityEngine;

public class BulletFiring : MonoBehaviour
{
    public float bulletSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
    }
}
