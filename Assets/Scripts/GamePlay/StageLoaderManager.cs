using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoaderManager : MonoBehaviour
{
    public void RestartStage()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    // Update is called once per frame
    public void FinishStage()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
