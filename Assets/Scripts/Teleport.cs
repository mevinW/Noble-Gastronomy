using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportForest : MonoBehaviour
{
    [SerializeField] private GameObject homeButton1;
    [SerializeField] private GameObject homeButton2;
    [SerializeField] private GameObject homeButton3;

    [SerializeField] private GameObject sign;
    [SerializeField] private GameObject logic;

    private void Start()
    {
        
    }

    public void teleportForest()
    {
        LogicScript logicReference = logic.GetComponent<LogicScript>();
        logicReference.loadForestScreen();
    }
    public void teleportCave()
    {
        LogicScript logicReference = logic.GetComponent<LogicScript>();
        logicReference.loadCaveScreen();
    }
    public void teleportTunnels()
    {
        LogicScript logicReference = logic.GetComponent<LogicScript>();
        logicReference.loadTunnelsScreen();
    }

    private void ResetPlayerPrefsIfNeeded()
    {
        if(PlayerPrefs.GetInt("ButtonState1", 0) == 1
            && PlayerPrefs.GetInt("ButtonState2", 0) == 1
            && PlayerPrefs.GetInt("ButtonState3", 0) == 1)
        {
            homeButton1.SetActive(false);
            homeButton2.SetActive(false);
            homeButton3.SetActive(false);
            PlayerPrefs.DeleteAll();
        }
    }
}
