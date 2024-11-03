using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireball : MonoBehaviour
{
    private float timer = 0f;
    public GameObject player;
    private Rigidbody2D rb;
    public float force = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = player.transform.position - transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 5)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerHealthManager healthReference = FindObjectOfType<PlayerHealthManager>();
            HealthManager dragonReference = FindObjectOfType<HealthManager>();

            if (dragonReference.healthAmount >= 65)
            {
                healthReference.takeDamage(8);
            }
            else if(dragonReference.healthAmount >= 35)
            {
                healthReference.takeDamage(12);
            }
            else
            {
                healthReference.takeDamage(16);
            }
        }
    }
}
