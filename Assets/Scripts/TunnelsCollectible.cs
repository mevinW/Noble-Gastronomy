using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TunnelsCollectible : MonoBehaviour
{
    [SerializeField] private GameObject logic;
    [SerializeField] private GameObject tunnelsButton;
    public GameObject banana;
    public GameObject bananaShadow;

    public GameObject bananaCollectible;

    public GameObject newCamera;

    public bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bat"))
        {
            transform.position = new Vector3(4.949f, 3.793f, 0);

            collected = false;

            bananaCollectible.SetActive(true);

            DestroyAllBats();
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            collision.gameObject.SetActive(false);
            collected = true;
        }
        if (collision.gameObject.CompareTag("Exit") && collected)
        {
            LogicScript logicReference = logic.GetComponent<LogicScript>();

            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Bat");

            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }

            CameraFollow scriptToEnable = newCamera.GetComponent<CameraFollow>();
            scriptToEnable.enabled = false;
            Camera.main.orthographicSize = 5f;
            Camera.main.transform.position = new Vector3(0, 0, -10);

            tunnelsButton.SetActive(false);

            banana.SetActive(true);
            bananaShadow.SetActive(false);

            logicReference.loadHomeScreen();
        }
    }
    private void DestroyAllBats()
    {
        GameObject[] bats = GameObject.FindGameObjectsWithTag("Bat");

        foreach (GameObject bat in bats)
        {
            if (bat != null)
            {
                Destroy(bat);
            }
        }
    }
}
