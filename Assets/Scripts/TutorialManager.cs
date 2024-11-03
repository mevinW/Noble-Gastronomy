using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject player;
    public GameObject nextButton;

    private int popUpIndex = 0;
    
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if(popUpIndex == 0)
        {
            TutorialMovement playerMovement = player.GetComponent<TutorialMovement>();
            playerMovement.jumpSpeed = 0f;
            playerMovement.jumpSpeed2 = 0f;

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 1)
        {
            TutorialMovement playerMovement = player.GetComponent<TutorialMovement>();
            playerMovement.jumpSpeed = 8f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 2)
        {
            TutorialMovement playerMovement = player.GetComponent<TutorialMovement>();
            playerMovement.jumpSpeed2 = 8f;

            if (Input.GetKeyDown(KeyCode.Space) && !playerMovement.IsGrounded())
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.S)) {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 4)
        {
            nextButton.SetActive(true);
        }
    }
}
