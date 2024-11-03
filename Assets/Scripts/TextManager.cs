using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textGameObject;
    public GameObject health;
    private HealthManager dragonHealth;

    public GameObject win;
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    { 
        dragonHealth = health.GetComponent<HealthManager>();
        
        if (dragonHealth.healthAmount <= 0)
        {
            textGameObject.text = "You Win!";
            win.SetActive(true);
        }
        else
        {
            textGameObject.text = "You Lose!";
            lose.SetActive(true);
        }
    }
}
