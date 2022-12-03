using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentLevel;
    public Player player;

    [Header("Background")]
    public SpriteRenderer stageBackground;
    public Sprite[] backgrounds;
    
    [Header("Trashes")]
    public int initialCoinCount;
    public int coinCount;
    public float coinProgress;
    public int coinCollected;

    [Header("Enemies")]
    public int initialEnemyCount;
    public int enemyCount;

    [Header("Progress")]
    public float gameProgress;

    [Header("UI")]
    public Image healthBar;
    public TMP_Text healthText;
    public Image progressBar;
    public TMP_Text progressText;
    public GameObject finishPanel;
    public TMP_Text trashesText;
    public GameObject pausePanel;

    void Start()
    {
        coinCount = GameObject.FindGameObjectsWithTag("Trash").Length;
        initialCoinCount = coinCount;

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        initialEnemyCount = enemyCount;

        finishPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBackground();

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        gameProgress = (float)((initialCoinCount + initialEnemyCount) - (coinCount + enemyCount)) / (initialCoinCount + initialEnemyCount);

        float healthFloat = (float) player.health / player.maxHealth;
        healthBar.fillAmount = healthFloat;

        healthText.text = player.health.ToString() + " (" + player.playerLife + ")";

        progressBar.fillAmount = gameProgress;
        progressText.text = ((int)(gameProgress * 100)) + "%";
    }

    void ChangeBackground()
    {
        coinCount = GameObject.FindGameObjectsWithTag("Trash").Length;
        coinProgress = (float)(initialCoinCount - coinCount) / initialCoinCount;

        if (backgrounds.Length == 5)
        {
            if (coinProgress == 1)
            {
                stageBackground.sprite = backgrounds[4];
            }
            else if (coinProgress >= 0.75f)
            {
                stageBackground.sprite = backgrounds[3];
            }
            else if (coinProgress >= 0.50f)
            {
                stageBackground.sprite = backgrounds[2];
            }
            else if (coinProgress >= 0.25f)
            {
                stageBackground.sprite = backgrounds[1];
            }
            else
            {
                stageBackground.sprite = backgrounds[0];
            }
        }
    }

    public void FinishStage()
    {
        if(gameProgress == 1)
        {
            Destroy(player);

            trashesText.text = "Trashes Collected: " + coinCollected;
            finishPanel.SetActive(true);

            int currentTrashes = PlayerPrefs.GetInt("Trashes");
            PlayerPrefs.SetInt("Trashes", currentTrashes + coinCollected);

            if(((currentLevel - 1) >= PlayerPrefs.GetInt("LevelFinished")))
            {
                PlayerPrefs.SetInt("LevelFinished", currentLevel);
            }
        }
    }
}
