using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    public Transform firePoint;
    public GameObject potion;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer > 0.5f)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(potion, firePoint.position, firePoint.rotation);
    }
}
