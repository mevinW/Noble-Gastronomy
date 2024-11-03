using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveClearing : MonoBehaviour
{
    public GameObject leaveClearingButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            leaveClearingButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            leaveClearingButton.SetActive(false);
        }
    }
}
