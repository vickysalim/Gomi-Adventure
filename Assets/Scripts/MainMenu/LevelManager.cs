using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button button;
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        if(!((currentLevel - 1) <= PlayerPrefs.GetInt("LevelFinished")))
        {
            button.interactable = false;
        }
    }
}
