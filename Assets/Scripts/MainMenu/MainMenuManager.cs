using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject beginningCanvas;
    public GameObject mainMenuCanvas;
    public GameObject levelSelectionCanvas;
    public GameObject settingsCanvas;
    public GameObject shopCanvas;
    public TMP_Text clickAnywhereText;

    void Start()
    {
        Screen.SetResolution(960, 540, false);

        beginningCanvas.SetActive(true);
        StartCoroutine(FadeText());
    }
    IEnumerator FadeText()
    {
        while(true)
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

    public void OpenPanelMainMenu()
    {
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.SetActive(true);

            beginningCanvas.SetActive(false);
            levelSelectionCanvas.SetActive(false);
            settingsCanvas.SetActive(false);
            shopCanvas.SetActive(false);
        }
    }

    public void GoToLevelSelection()
    {
        levelSelectionCanvas.SetActive(true);
        
        beginningCanvas.SetActive(false);
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        shopCanvas.SetActive(false);
    }

    public void GoToSettings()
    {
        settingsCanvas.SetActive(true);
        
        beginningCanvas.SetActive(false);
        mainMenuCanvas.SetActive(false);
        levelSelectionCanvas.SetActive(false);
        shopCanvas.SetActive(false);
    }

    public void GoToShop()
    {
        shopCanvas.SetActive(true);
        
        beginningCanvas.SetActive(false);
        mainMenuCanvas.SetActive(false);
        levelSelectionCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    public void BackToMenu()
    {
        mainMenuCanvas.SetActive(true);

        beginningCanvas.SetActive(false);
        levelSelectionCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        shopCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // List<int> widths = new List<int>() { 1280, 1366, 1920 };
    // List<int> heights = new List<int>() { 720, 768, 1080 };
    List<int> widths = new List<int>() { 960, 1280, 1920 };
    List<int> heights = new List<int>() { 540, 720, 1080 };

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullScreen(bool _fullscsreen)
    {
        Screen.fullScreen = _fullscsreen;
    }
}
