using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    public GameObject beginningCanvas;
    public TMP_Text clickAnywhereText;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(960, 540, false);

        beginningCanvas.SetActive(true);
        StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
    {
        while (true)
        {
            // fade out
            yield return Fade(0);
            // wait
            yield return new WaitForSeconds(0.5f);
            // fade in
            yield return Fade(1);
            // wait
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Fade(float targetAlpha)
    {
        while (clickAnywhereText.color.a != targetAlpha)
        {
            var newAlpha = Mathf.MoveTowards(clickAnywhereText.color.a, targetAlpha, 1 * Time.deltaTime);
            clickAnywhereText.color = new Color(clickAnywhereText.color.r, clickAnywhereText.color.g, clickAnywhereText.color.b, newAlpha);
            yield return null;
        }
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
