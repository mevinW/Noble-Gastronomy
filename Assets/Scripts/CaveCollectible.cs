using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaveCollectible : MonoBehaviour
{
    [SerializeField] private GameObject logic;
    [SerializeField] private GameObject caveButton;
    public GameObject plum;
    public GameObject plumShadow;

    public GameObject newCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plum"))
        {
            Destroy(collision.gameObject);

            LogicScript logicReference = logic.GetComponent<LogicScript>();

            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Rock");

            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }

            CameraFollowCave scriptToEnable = newCamera.GetComponent<CameraFollowCave>();
            scriptToEnable.enabled = false;
            Camera.main.orthographicSize = 5f;
            Camera.main.transform.position = new Vector3(0, 0, -10);

            caveButton.SetActive(false);

            plum.SetActive(true);
            plumShadow.SetActive(false);

            logicReference.loadHomeScreen();
        }
    }
}
