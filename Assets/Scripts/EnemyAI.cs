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
            //Move towards the player unless too close
            distance = Vector3.Distance(rb.transform.position, player.transform.position);

            if (distance > 4f)
            {
                rb.transform.position = Vector3.MoveTowards(rb.transform.position, player.transform.position, speed * Time.deltaTime);
            }

            //Make the enemy look at the player and ensure they don't tilt
            transform.LookAt(player.transform);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);   
        }

        if (Global.enemiesRemaining == 0)
        {
            //Ensures all enemies are destroyed when the wave ends
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        if (other.gameObject.CompareTag("Bullet") && isAlive)
        {
            health = health - Global.bulletDamage;
=======
=======
>>>>>>> Stashed changes
        //If hit by a bullet and alive, take damage.
        if (other.gameObject.CompareTag("Bullet") && isAlive && vulnerable)
        {
            health = health - Global.bulletDamage;
            other.gameObject.GetComponent<BulletFiring>().Onhit();

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
        if (other.gameObject.CompareTag("Sea"))
        {
            //Ensures enemies dont fall off the map.
            transform.position = new Vector3(transform.position.x, 25, transform.position.z);
        }
    }

    IEnumerator InvulnerabilityFrames()
    {
        vulnerable = false;
        yield return new WaitForSeconds(0.1f);
        vulnerable = true;
>>>>>>> Stashed changes
    }
}
