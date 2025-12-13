using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    public float health = 50;

    public AudioClip deathSound;
    public AudioClip hitSound;

    private bool isAlive = true;
    private float distance;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            
            distance = Vector3.Distance(rb.transform.position, player.transform.position);

            if (distance > 4f)
            {
                rb.transform.position = Vector3.MoveTowards(rb.transform.position, player.transform.position, speed * Time.deltaTime);
            }

            transform.LookAt(player.transform);             //Make the enemy face the player
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);      //Ensure the enemy doesn't tilt
        }

        if (Global.enemiesRemaining == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet") && isAlive)
        {
            health = health - Global.bulletDamage;
            if (health <= 0)
            {
                isAlive = false;
                SfxManager.Instance.PlaySound(deathSound, transform, 1f);
                Global.enemiesRemaining--;
                Global.enemiesDefeated++;

                Destroy(this.gameObject);
            }
            else
            {
                SfxManager.Instance.PlaySound(hitSound, transform, 1f);
            }
        }
    }
}
