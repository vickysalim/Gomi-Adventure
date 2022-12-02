using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsComponent : MonoBehaviour
{
    [SerializeField] string componentName;
    [SerializeField] int level;
    [SerializeField] int price;

    [Header("UI")]
    public TMP_Text levelText;
    public TMP_Text priceText;
    public Button buyButton;

    [Header("Trashes")]
    [SerializeField] int currentTrashes;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(componentName))
            PlayerPrefs.SetInt(componentName, 1);
    }

    // Update is called once per frame
    void Update()
    {
        level = PlayerPrefs.GetInt(componentName);
        price = level;

        priceText.text = price.ToString();
        levelText.text = "Level " + level + " / 5";

        currentTrashes = PlayerPrefs.GetInt("Trashes");

        if (currentTrashes < price || level >= 5)
            buyButton.interactable = false;

        if (level >= 5)
            priceText.text = "-";
    }

    public void OnClick()
    {
        if(currentTrashes >= price || level <= 5)
        {
            int currentLevel = PlayerPrefs.GetInt(componentName);
            PlayerPrefs.SetInt(componentName, currentLevel + 1);

            PlayerPrefs.SetInt("Trashes", currentTrashes - price);
        }
    }

}
