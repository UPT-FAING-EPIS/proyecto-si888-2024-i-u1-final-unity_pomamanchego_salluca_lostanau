using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gold;
    public static GameManager instance;
    public TextMeshProUGUI goldText;

    public Sprite[] backgrounds;
    private int curBackground;
    //How many enemies do we need to defeat until the background changes
    private int enemiesUntilBackgroundChange = 5;
    //Referencing the UI image component
    public Image backgroundImage;
    private void Awake()
    {
        instance = this;
    }

    public void AddGold (int amount)
    {
        gold += amount;
        goldText.text = "Gold: " + gold.ToString();
    }
    public void TakeGold(int amount)
    {
        gold -= amount;
        goldText.text = "Gold: " + gold.ToString();
    }
    public void BackgroundCheck()
    {
        //Substract enemiesUntilBackgroundChange
        enemiesUntilBackgroundChange--;

        //Is enemiesUntilBackgroundChange equal to 0?
        if (enemiesUntilBackgroundChange == 0)
        {
            curBackground++;
            enemiesUntilBackgroundChange = 5;

            if (curBackground == backgrounds.Length)
            {
                curBackground = 0;
            }

            //Update backgroundImage to curBackground
            backgroundImage.sprite = backgrounds[curBackground];
        }
    }
}
