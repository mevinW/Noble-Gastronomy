using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform player;
    public float yOffset = 3f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);

        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 2f, followSpeed * Time.deltaTime);
    }
}
