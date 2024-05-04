using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public List<float> autoClickersLastTime = new List<float>();

    public int autoClickerPrice;
    public TextMeshProUGUI quantityText;

    void Update()
    {
        // loop this until we reach the end of the list
        for (int i = 0; i < autoClickersLastTime.Count; i++)
        {
            // is this value more than one second ago?
            if (Time.time - autoClickersLastTime[i] >= 1.0f)
            {
                // if so, then we can set this to be the current time and damage the                 enemy.

                autoClickersLastTime[i] = Time.time;
                EnemyManager.instance.curEnemy.Damage();
            }
        }
    }
    public void OnBuyAutoClicker()
    {
        // if we have enough gold to buy the autoclicker,
        if (GameManager.instance.gold >= autoClickerPrice)
        {
            GameManager.instance.TakeGold(autoClickerPrice);
            autoClickersLastTime.Add(Time.time);
            //set the text to display the length of the list.
            quantityText.text = "x " + autoClickersLastTime.Count.ToString();
            // subtract the amount from our gold and add a new auto clicker to the li             st.

        }
        GameManager.instance.TakeGold(autoClickerPrice);
        autoClickersLastTime.Add(Time.time);
    }
}

