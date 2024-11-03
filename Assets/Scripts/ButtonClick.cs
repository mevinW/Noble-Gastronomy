using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadNext()
    {
        SceneManager.LoadScene("SceneTwo");
    }
    public void loadPrevious()
    {
        SceneManager.LoadScene("SceneOne");
    }
}
