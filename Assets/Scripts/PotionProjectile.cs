using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public int potionSpeed = 8;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Get the character's facing direction
        float facingDirection = playerObject.transform.right.x;

        // Calculate the adjusted angle based on the facing direction
        float adjustedAngle = (facingDirection > 0) ? 50f : 140;

        // Apply the adjusted angle to the velocity
        rb.velocity = Quaternion.Euler(0, 0, adjustedAngle) * Vector2.right * potionSpeed;
    }
    private void Update()
    {
        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT");
        if (collision.CompareTag("Dragon"))
        {
            Destroy(gameObject);
            HealthManager healthReference = FindObjectOfType<HealthManager>();

            LogicScript potionReference = FindObjectOfType<LogicScript>();
            healthReference.takeDamage(potionReference.potionPotency);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Dragon") && !collision.gameObject.CompareTag("Box"))
        {
            Destroy(gameObject);

        }
    }
}
