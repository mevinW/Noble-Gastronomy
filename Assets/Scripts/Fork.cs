using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forkSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * forkSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
