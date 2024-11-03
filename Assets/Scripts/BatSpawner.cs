using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject batPrefab;

    private float timer = 0f;
    private bool first1 = true;
    private bool first2 = true;
    private bool first3 = true;

    private float interval = 10f;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2f && first1) {
            GameObject newEnemy = Instantiate(batPrefab, new Vector3(pos1.position.x, pos1.position.y, 0f), Quaternion.identity);
            Transform playerTransform = GameObject.FindWithTag("Player").transform;

            AIDestinationSetter destinationSetter = newEnemy.GetComponent<AIDestinationSetter>();
            if (destinationSetter != null)
            {
                destinationSetter.target = (playerTransform);
            }

            first1 = false;
            StartCoroutine(spawnEnemy(batPrefab, interval));
        }
        if (timer >= 6f && first2)
        {
            GameObject newEnemy = Instantiate(batPrefab, new Vector3(pos2.position.x, pos2.position.y, 0f), Quaternion.identity);
            Transform playerTransform = GameObject.FindWithTag("Player").transform;
           
            AIDestinationSetter destinationSetter = newEnemy.GetComponent<AIDestinationSetter>();
            if (destinationSetter != null)
            {
                destinationSetter.target = (playerTransform);
            }

            first2 = false;
            StartCoroutine(spawnEnemy2(batPrefab, interval));
        }
        if(timer >= 10f && first3)
        {
            GameObject newEnemy = Instantiate(batPrefab, new Vector3(pos3.position.x, pos3.position.y, 0f), Quaternion.identity);
            Transform playerTransform = GameObject.FindWithTag("Player").transform;
           
            AIDestinationSetter destinationSetter = newEnemy.GetComponent<AIDestinationSetter>();
            if (destinationSetter != null)
            {
                destinationSetter.target = (playerTransform);
            }

            first3 = false;
            StartCoroutine(spawnEnemy3(batPrefab, interval));
        }
    }

    private IEnumerator spawnEnemy(GameObject enemy, float interval)
    {
        yield return new WaitForSeconds(interval);

        GameObject newEnemy = Instantiate(batPrefab, new Vector3(pos1.position.x, pos1.position.y, 0f), Quaternion.identity);

        Transform playerTransform = GameObject.FindWithTag("Player").transform;

        // Assuming your batPrefab has a script with a 'target' property
        AIDestinationSetter destinationSetter = newEnemy.GetComponent<AIDestinationSetter>();
        if (destinationSetter != null)
        {
            destinationSetter.target = (playerTransform);
        }
        StartCoroutine(spawnEnemy(batPrefab, interval));
    }

    private IEnumerator spawnEnemy2(GameObject enemy, float interval)
    {
        yield return new WaitForSeconds(interval);

        GameObject newEnemy = Instantiate(batPrefab, new Vector3(pos2.position.x, pos2.position.y, 0f), Quaternion.identity);

        Transform playerTransform = GameObject.FindWithTag("Player").transform;

        // Assuming your batPrefab has a script with a 'target' property
        AIDestinationSetter destinationSetter = newEnemy.GetComponent<AIDestinationSetter>();
        if (destinationSetter != null)
        {
            destinationSetter.target = (playerTransform);
        }
        StartCoroutine(spawnEnemy2(batPrefab, interval));
    }

    private IEnumerator spawnEnemy3(GameObject enemy, float interval)
    {
        yield return new WaitForSeconds(interval);

        GameObject newEnemy = Instantiate(batPrefab, new Vector3(pos3.position.x, pos3.position.y, 0f), Quaternion.identity);

        Transform playerTransform = GameObject.FindWithTag("Player").transform;

        // Assuming your batPrefab has a script with a 'target' property
        AIDestinationSetter destinationSetter = newEnemy.GetComponent<AIDestinationSetter>();
        if (destinationSetter != null)
        {
            destinationSetter.target = (playerTransform);
        }
        StartCoroutine(spawnEnemy3(batPrefab, interval));
    }
}
