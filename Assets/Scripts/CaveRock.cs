using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveRock : MonoBehaviour
{
    public int health = 4;
    public GameObject[] hearts;

    [SerializeField] private GameObject logic;
    [SerializeField] private GameObject caveButton;
    public GameObject newCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Deadzone") || collision.gameObject.CompareTag("Spike"))
        {
            transform.position = new Vector3(-6.46f, -3.7f, 0);
            health--;
            for(int i = 0; i < 4; i++)
            {
                if (i < health)
                {
                    hearts[i].SetActive(true);
                }
                else
                {
                    hearts[i].SetActive(false);
                }
            }
            if(health == 0)
            {
                LogicScript logicReference = logic.GetComponent<LogicScript>();

                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Rock");

                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }

                caveButton.SetActive(false);

                CameraFollowCave scriptToEnable = newCamera.GetComponent<CameraFollowCave>();
                scriptToEnable.enabled = false;
                Camera.main.orthographicSize = 5f;
                Camera.main.transform.position = new Vector3(0, 0, -10);

                logicReference.loadHomeScreen();
            }
        }
    }
}
