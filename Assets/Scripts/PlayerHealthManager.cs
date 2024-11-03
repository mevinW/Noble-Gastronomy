using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
        if (healthAmount <= 0)
        {
            LogicScript logic = FindObjectOfType<LogicScript>();

            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Fireball");

            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }

            GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag("Potion");

            foreach (GameObject obj in objectsWithTag2)
            {
                Destroy(obj);
            }
            logic.loadRestartScreen();
        }
    }
}
