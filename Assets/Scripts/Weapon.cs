using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject forkPrefab;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("IsShooting", true); 
            Shoot();
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }
    }

    public void Shoot()
    {
        Instantiate(forkPrefab, firePoint.position, firePoint.rotation);
    }
}
