using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreOperators : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
         int x = 1;
        int y = 2;
        //bool result = x == y;
        //bool result = x != y;
        string playerName = null;
        //bool result = playerName != null;
        int nextLevelXP = 300;
        int playerOneXP = 185;
        //bool result = playerOneXP > nextLevelXP;

        int level = 5;
        int levelCap = 20;
        //bool result = level < levelCap;
        int points = 100;
        int highScore = 100;
        bool result = !(points >= highScore);
        Debug.Log(!result);
        Debug.Log(result);
        result = !result;
        Debug.Log(result);
        */
        int coins = 100;
        int totalLives = 30;
        int maxLives = 10;
        bool isPremiumMember = true;
        bool shouldIncreaseLifeCount = coins >= 100 && totalLives < maxLives || isPremiumMember;
        Debug.Log(shouldIncreaseLifeCount);
        string firstName = null;
        try
        {
            bool isUpperCase = firstName != null || firstName.ToUpper() == "VEGETARIANZOMBIE";
            Debug.Log(isUpperCase);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }

        bool shouldIncreaseDifficulty = !isPremiumMember && totalLives > 5;
        Debug.Log(shouldIncreaseDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
