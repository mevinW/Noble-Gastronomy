using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CollectedItems : MonoBehaviour
{
    public GameObject strawBerry;
    public GameObject plum;
    public GameObject banana;
    public GameObject message;

    public GameObject strawBerryScreen;
    public GameObject plumScreen;
    public GameObject bananaScreen;

    public GameObject forestButton;
    public GameObject caveButton;
    public GameObject tunnelsButton;

    public Transform drop;
    public float delayBetweenFruits = 1.0f; // Adjust the delay as needed

    public Text messageText;

    public float potionStrength;

    public void checkItems()
    {
        if (!forestButton.activeSelf && !caveButton.activeSelf && !tunnelsButton.activeSelf)
        {
            if (strawBerryScreen.activeSelf && plumScreen.activeSelf && bananaScreen.activeSelf)
            {
                StartCoroutine(InstantiateWithDelay(strawBerry, 0f));
                StartCoroutine(InstantiateWithDelay(plum, delayBetweenFruits));
                StartCoroutine(InstantiateWithDelay(banana, 2 * delayBetweenFruits));

                messageText.text = "You have created the ultimate potion! Leave the cave and fight the monster!";

                potionStrength = 4f;
            }
            else if (strawBerryScreen.activeSelf && plumScreen.activeSelf)
            {
                StartCoroutine(InstantiateWithDelay(strawBerry, 0f));
                StartCoroutine(InstantiateWithDelay(plum, delayBetweenFruits));

                messageText.text = "You have created a strong potion! Leave the cave and fight the monster!";
                potionStrength = 3f;
            }
            else if (strawBerryScreen.activeSelf && bananaScreen.activeSelf)
            {
                StartCoroutine(InstantiateWithDelay(strawBerry, 0f));
                StartCoroutine(InstantiateWithDelay(banana, delayBetweenFruits));

                messageText.text = "You have created a strong potion! Leave the cave and fight the monster!";
                potionStrength = 3f;
            }
            else
            {
                StartCoroutine(InstantiateWithDelay(strawBerry, 0f));
                messageText.text = "You have created an average potion! Leave the cave and fight the monster!";
                potionStrength = 2f;
            }
            LogicScript potionReference = FindObjectOfType<LogicScript>();
            potionReference.potionPotency = potionStrength;
            message.SetActive(true);
        }
    }

    private IEnumerator InstantiateWithDelay(GameObject prefab, float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(prefab, drop.position, Quaternion.identity);
    }
}
