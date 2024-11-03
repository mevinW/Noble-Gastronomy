using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ForestCollectible : MonoBehaviour
{
    [SerializeField] private GameObject logic;
    [SerializeField] private GameObject forestButton;
    public GameObject strawBerry;
    public GameObject strawBerryShadow;

    public GameObject newCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            Destroy(collision.gameObject);

            LogicScript logicReference = logic.GetComponent<LogicScript>();

            CameraFollowForest scriptToEnable = newCamera.GetComponent<CameraFollowForest>();
            scriptToEnable.enabled = false;
            Camera.main.orthographicSize = 5f;
            Camera.main.transform.position = new Vector3(0, 0, -10);

            forestButton.SetActive(false);

            strawBerry.SetActive(true);
            strawBerryShadow.SetActive(false);

            logicReference.loadHomeScreen();
        }
    }
}
