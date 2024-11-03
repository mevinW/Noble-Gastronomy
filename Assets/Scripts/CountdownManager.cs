using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour
{

    public Text countdown;
    private float timer = 0f;
    private float secondsLeft = 60;

    [SerializeField] private GameObject logic;

    public GameObject newCamera;

    [SerializeField] private GameObject tunnelsButton;
    public GameObject banana;
    public GameObject bananaShadow;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1f)
        {
            secondsLeft--;
            timer = 0;
            countdown.text = secondsLeft.ToString();

            if(secondsLeft == 0)
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

                logicReference.loadHomeScreen();

                banana.SetActive(false);
                bananaShadow.SetActive(true);
            }
        }
    }
}
