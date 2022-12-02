using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject begginingCanvas;
    public GameObject settingsCanvas;

    void Start()
    {
        Screen.SetResolution(960, 540, false);
    }

    public void OpenPanelMainMenu()
    {
        if (startCanvas != null)
        {
            startCanvas.SetActive(true);
            begginingCanvas.SetActive(false);
            settingsCanvas.SetActive(false);
        }
    }

    public void GoToSettings()
    {
        settingsCanvas.SetActive(true);
        startCanvas.SetActive(false);
        begginingCanvas.SetActive(false);
    }

    public void BackToMenu()
    {
        begginingCanvas.SetActive(false);
        startCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
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
