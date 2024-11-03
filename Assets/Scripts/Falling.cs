using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Rock") && !collision.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }
    }
}
