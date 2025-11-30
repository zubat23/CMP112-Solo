using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(rb.transform.position, player.transform.position);

            rb.transform.position = Vector3.MoveTowards(rb.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.LookAt(player.transform);
        }
    }
}