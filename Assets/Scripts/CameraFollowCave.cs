using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCave : MonoBehaviour
{
    public float followSpeed;
    public Transform player;
    public float xMin;
    public float xMax;

    public float xOffset;
    public float yOffset;

    public GameObject[] hearts;

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > xMin && player.position.x < xMax)
        {
            Vector3 newPos = new Vector3(player.position.x, transform.position.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

            for(int i = 0; i < 4; i++)
            {
                hearts[i].transform.position = new Vector3(transform.position.x + xOffset + i * 0.7f, transform.position.y + yOffset, 0);
            }

            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5f, followSpeed * Time.deltaTime);
        }
        
        if (player.position.x < xMin)
        {
            Vector3 newPos = new Vector3(0, 0, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

            for (int i = 0; i < 4; i++)
            {
                hearts[i].transform.position = new Vector3(transform.position.x + xOffset + i * 0.7f, transform.position.y + yOffset, 0);
            }

            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5f, followSpeed * Time.deltaTime);
        }
        if (player.position.x > xMax)
        {
            Vector3 newPos = new Vector3(13.9f, 0, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

            for (int i = 0; i < 4; i++)
            {
                hearts[i].transform.position = new Vector3(transform.position.x + xOffset + i * 0.7f, transform.position.y + yOffset, 0);
            }

            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5f, followSpeed * Time.deltaTime);
        }
    }
}
