using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [SerializeField] private GameObject[] screens;
    public int currentScreen = 0;

    public GameObject newCamera;

    public GameObject gameOverScreen;

    public GameObject forestButton;
    public GameObject caveButton;
    public GameObject tunnelsButton;

    public GameObject playerHome;
    public GameObject playerNPC;

    public float potionPotency;

    public AudioClip[] musicClips;
    private AudioSource audioSource;
    private void Start()
    {
        loadStartScreen();
        audioSource = GetComponent<AudioSource>();
    }

    public void loadScreen()
    {
        for(int i = 0; i < screens.Length; i++)
        {
            if(i == currentScreen)
            {
                screens[i].SetActive(true);
            }
            else
            {
                screens[i].SetActive(false);
            }
        }
    }

    public void loadStartScreen()
    {
        currentScreen = 0;
        loadScreen();
    }

    public void loadPlayScreen()
    {
        currentScreen = 1;
        loadScreen();
        PlayMusic(0);
    }

    public void loadTutorialScreen()
    {
        currentScreen = 2;
        loadScreen();
        PlayMusic(4);
    }

    public void loadHomeScreen()
    {
        playerHome.transform.position = new Vector3(2.71f, -3.66f, 0f);

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Fork");

        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }

        currentScreen = 3;
        loadScreen();

        PlayMusic(3);

        CollectedItems scriptReference = FindObjectOfType<CollectedItems>();
        scriptReference.checkItems();
    }

    public void loadForestScreen()
    {
        currentScreen = 4;

        CameraFollowForest scriptToEnable = newCamera.GetComponent<CameraFollowForest>();
        scriptToEnable.enabled = true;

        loadScreen();
        PlayMusic(5);
    }

    public void loadCaveScreen()
    {
        currentScreen = 5;

        CameraFollowCave scriptToEnable = newCamera.GetComponent<CameraFollowCave>();
        scriptToEnable.enabled = true;

        loadScreen();
        PlayMusic(6);
    }

    public void loadTunnelsScreen()
    {
        currentScreen = 6;

        CameraFollow scriptToEnable = newCamera.GetComponent<CameraFollow>();
        scriptToEnable.enabled = true;

        loadScreen();
        PlayMusic(7);
    }

    public void loadRestartScreen()
    {
        currentScreen = 8;
        loadScreen();
    }

    public void loadNPCScreen()
    {
        int musicNum = 4;

        playerNPC.transform.position = new Vector3(-6.21f, -3.19f, 0f);

        currentScreen = 9;

        PlayMusic(4);

        if (!forestButton.activeSelf && !caveButton.activeSelf && !tunnelsButton.activeSelf)
        {
            currentScreen = 7;
            musicNum = 8;
        }

        loadScreen();

        PlayMusic(musicNum);
    }

    public void PlayMusic(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < musicClips.Length)
        {
            audioSource.clip = musicClips[clipIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Invalid music clip index");
        }
    }
}
