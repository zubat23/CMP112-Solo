using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    public float health = 50;
    public float damage = 10;

    public AudioClip deathSound;
    public AudioClip hitSound;

    private bool isAlive = true;
    private bool vulnerable = true;
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

            if (distance > 1f)
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
        if (other.gameObject.CompareTag("Bullet") && isAlive && vulnerable)
        {
            health = health - Global.bulletDamage;
            other.gameObject.GetComponent<BulletFiring>().Onhit();
            other.gameObject.GetComponent<BulletFiring>().checkPiercing();

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
                StartCoroutine(InvulnerabilityFrames());
                SfxManager.Instance.PlaySound(hitSound, transform, 1f);
            }
        }
        if (other.gameObject.CompareTag("Sea"))
        {
            transform.position = new Vector3(transform.position.x, 25, transform.position.z);
        }
    }

    IEnumerator InvulnerabilityFrames()
    {
        vulnerable = false;
        yield return new WaitForSeconds(0.1f);
        vulnerable = true;
    }
}
