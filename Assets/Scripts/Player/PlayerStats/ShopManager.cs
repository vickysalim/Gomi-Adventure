using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public TMP_Text trashesText;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("Trashes"))
            PlayerPrefs.SetInt("Trashes", 0);

        trashesText.text = PlayerPrefs.GetInt("Trashes").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        trashesText.text = PlayerPrefs.GetInt("Trashes").ToString();
    }
}
