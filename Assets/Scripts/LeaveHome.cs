using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveHome : MonoBehaviour
{
    public GameObject leaveHomeButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            leaveHomeButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            leaveHomeButton.SetActive(false);
        }
    }
}
