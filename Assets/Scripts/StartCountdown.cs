using System.Collections;
using UnityEngine;
using TMPro;

public class StartCountdown : MonoBehaviour
{
    public TextMeshProUGUI startText;
    public GameObject gameplayObjects;  // Player + spawner

    void Start()
    {
        gameplayObjects.SetActive(false);     // matikan game dulu
        startText.gameObject.SetActive(true);

        StartCoroutine(ShowCountdown());
    }

    IEnumerator ShowCountdown()
    {
        startText.text = "Ready";
        yield return new WaitForSeconds(1f);

        startText.text = "Set";
        yield return new WaitForSeconds(1f);

        startText.text = "Nyam!";
        yield return new WaitForSeconds(1f);

        startText.gameObject.SetActive(false);
        gameplayObjects.SetActive(true);    // game mulai
    }
}
