using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    public int level = 1;
    public float experience
    {
        get; private set;
    }
    public Text lvlText;
    public Image expBar;

    // Start is called before the first frame update
    public static int ExpNeedTolvUp(int currentLevel)
    {
        
        if (currentLevel == 0)
        {
            return 0;
        }
        Debug.Log((currentLevel * currentLevel + currentLevel) * 5);
        return (currentLevel * currentLevel+currentLevel)*5;
       
    } 
     public void SetExperience(float exp)
    {
        experience += exp;
        float expNeeded = ExpNeedTolvUp(level);
        float previous = ExpNeedTolvUp(level-1);

        if(experience >= expNeeded)
        {
            LevelUpPlayer();
            expNeeded = ExpNeedTolvUp(level);
            previous = ExpNeedTolvUp(level - 1);
        }

        expBar.fillAmount = (experience - previous) / (expNeeded - previous);

        if(expBar.fillAmount == 1)
        {
            expBar.fillAmount = 0;
        }
    }

    private void LevelUpPlayer()
    {
        level++;
        lvlText.text = "Level: "+ level.ToString("");
    }
}
