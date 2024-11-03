using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour
{
    public GameObject[] scenes;
    private int sceneNum = 0;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;

    public float wordSpeed;

    private float timer = 0f;

    public float cut1;
    private bool cut1Bool = true;
    public float cut2;
    private bool cut2Bool = true;
    public float cut3;
    private bool cut3Bool = true;
    public float cut4;
    private bool cut4Bool = true;

    // Update is called once per frame
    void Start()
    { 
        StartCoroutine(Typing());
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cut1 && cut1Bool) {
            cut1Bool = false;
            loadNextScene();
        }
        if (timer >= cut2 + cut1 && cut2Bool)
        {
            cut2Bool = false;
            loadNextScene();
        }
        else if (timer >= cut3 + cut2 + cut1 && cut3Bool)
        {
            cut3Bool = false;
            loadNextScene();
        }
        else if (timer >= cut4 + cut3 + cut2 + cut1 && cut4Bool)
        {
            cut4Bool = false;
            loadNextScene();
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void nextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void loadNextScene()
    {
        LogicScript logicReference = FindObjectOfType<LogicScript>();

        sceneNum++;

        if (sceneNum == 1)
        {
            logicReference.PlayMusic(1);
        }

        if (sceneNum == 2)
        {
            logicReference.PlayMusic(2);
        }

        if (sceneNum == 4)
        {
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

        nextLine();
    }

    public void skip()
    {
        LogicScript logicReference = FindObjectOfType<LogicScript>();
        logicReference.loadTutorialScreen();
    }
}
