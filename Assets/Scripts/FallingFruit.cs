using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pot"))
        {
            Destroy(gameObject);
        }
    }
}
