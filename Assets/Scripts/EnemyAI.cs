using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;

    private float distance;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
    }
}