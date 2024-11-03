using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    public GameObject rock;
    private float spawnRate = 0.6f;
    private float timer1 = 0;
    private float timer2 = -0.25f;
    private int offset = 4;
    public float initialOffset = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        spawnRock1();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer1 < spawnRate)
        {
            timer1 += Time.deltaTime;
        }
        else
        {
            timer1 = 0;

            spawnRock1();
        }
        if (timer2 < spawnRate)
        {
            timer2 += Time.deltaTime;
        }
        else
        {
            timer2 = 0;

            spawnRock2();
        }
    }

    void spawnRock1()
    {
        GameObject newRock2 = Instantiate(rock, new Vector3(transform.position.x + initialOffset + 3 * Random.Range(0, offset), transform.position.y, 0), transform.rotation);
    }
    void spawnRock2()
    {
        GameObject newRock2 = Instantiate(rock, new Vector3(transform.position.x + initialOffset + 3 * Random.Range(offset, 2 * offset + 1), transform.position.y, 0), transform.rotation);
    }
}
