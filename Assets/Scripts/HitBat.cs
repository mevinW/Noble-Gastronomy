using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBat : MonoBehaviour
{
    public GameObject banana;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bat"))
        {
            Debug.Log("HIT BAT");
            transform.position = new Vector3(4.949f, 3.793f, 0);

            TunnelsCollectible reference = FindObjectOfType<TunnelsCollectible>();
            reference.collected = false;

            banana.SetActive(true);

            DestroyAllBats();
            Debug.Log("DESTROYED");
        }
    }

    private void DestroyAllBats()
    {
        GameObject[] bats = GameObject.FindGameObjectsWithTag("Bat");

        foreach (GameObject bat in bats)
        {
            if(bat != null)
            {
                Destroy(bat);
            }
        }
    }
}
