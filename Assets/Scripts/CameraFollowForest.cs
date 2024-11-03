using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowForest : MonoBehaviour
{
    public float followSpeed;
    public Transform player;
    public float yMin;
    public float yMax;

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > yMin && player.position.y < yMax) {
            Vector3 newPos = new Vector3(transform.position.x, player.position.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5f, followSpeed * Time.deltaTime);
        }
        if(player.position.y < yMin)
        {
            Vector3 newPos = new Vector3(transform.position.x, 0, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5f, followSpeed * Time.deltaTime);
        }
    }
}
