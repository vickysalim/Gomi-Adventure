using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Background")]
    public SpriteRenderer stageBackground;
    public Sprite[] backgrounds;
    
    [Header("Coins")]
    public int initialCoinCount;
    public int coinCount;

    [Header("Progress")]
    public float gameProgress;
    public int point;
    void Start()
    {
        coinCount = GameObject.FindGameObjectsWithTag("Trash").Length;
        initialCoinCount = coinCount;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBackground();
    }

    void ChangeBackground()
    {
        coinCount = GameObject.FindGameObjectsWithTag("Trash").Length;
        gameProgress = (float)(initialCoinCount - coinCount) / initialCoinCount;

        if (backgrounds.Length == 5)
        {
            if (gameProgress == 1)
            {
                stageBackground.sprite = backgrounds[4];
            }
            else if (gameProgress >= 0.75f)
            {
                stageBackground.sprite = backgrounds[3];
            }
            else if (gameProgress >= 0.50f)
            {
                stageBackground.sprite = backgrounds[2];
            }
            else if (gameProgress >= 0.25f)
            {
                stageBackground.sprite = backgrounds[1];
            }
            else
            {
                stageBackground.sprite = backgrounds[0];
            }
        }
    }
}
