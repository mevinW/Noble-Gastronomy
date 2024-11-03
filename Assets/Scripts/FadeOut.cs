using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
    }

    IEnumerator fadeOut()
    {
        for (float i = 1f; i >= -0.05f; i -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = i;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFading()
    {
        StartCoroutine("fadeOut");
    }
}
