using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public GameObject[] scenes;
    private int sceneNum = 0;

    public void loadNextScene()
    {
        sceneNum++;

        if (sceneNum == 4)
        {
            LogicScript logicReference = FindObjectOfType<LogicScript>();
            logicReference.loadTutorialScreen();
        }

        for (int i = 0; i < 4; i++)
        {
            if (i == sceneNum)
            {
                scenes[i].SetActive(true);
            }
            else
            {
                scenes[i].SetActive(false);
            }
        }    
    }
}
