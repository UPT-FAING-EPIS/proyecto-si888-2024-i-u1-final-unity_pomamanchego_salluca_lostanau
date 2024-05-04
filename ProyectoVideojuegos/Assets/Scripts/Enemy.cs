using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int curHp;
    public int maxHp;
    public int goldToGive;
    public Image healthBarFill;
    public Animation anim;

    public void Damage()
    {
        //Substract 1 from curHP
        curHp--;
        //Update health bar
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;
        anim.Stop();
        anim.Play();
        if(curHp <= 0)
        {
            Defeated();
        }
    }

    public void Defeated()
    {
        GameManager.instance.AddGold(goldToGive);
        EnemyManager.instance.DefeatEnemy(gameObject);
    }


}
