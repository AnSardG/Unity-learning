using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance;    

    //Public VARS
    public int numItems = 1;
    public float coinTextSpeed = 1f;

    //Private VARS
    private bool[] items;
    private int lastPlayerHealth, lastPlayerCoins;
    private float time;

    //References
    public PlayerController player;
    public Image[] heartImages;
    public TextMeshProUGUI coinText;
    public Animator coinAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //En caso de que la instancia se haya creado ya destruimos la anterior.
            Destroy(instance);
        }

        DontDestroyOnLoad(gameObject);

        items = new bool[numItems];
    }

    private void Start()
    {
        lastPlayerHealth = player.health;
        lastPlayerCoins = player.moneyEarned;
    }

    private void Update()
    {        
        if(player.health != lastPlayerHealth)
        {
            ModifyUIHearts();
        }

        if(player.moneyEarned != lastPlayerCoins)
        {
            ModifyUICoins();
            coinAnim.SetBool("idle", false);
            Invoke("CoinIdleAnim", 1f);
            time += Time.deltaTime;
        }        
    }

    private void ModifyUIHearts()
    {
       if(player.health < lastPlayerHealth)
        {
            while (lastPlayerHealth > player.health)
            {
                lastPlayerHealth--;               
                heartImages[lastPlayerHealth].CrossFadeColor(Color.black, .5f, true, false);
            }
        } else
        {
            while (lastPlayerHealth < player.health)
            {
                lastPlayerHealth++;
                heartImages[lastPlayerHealth - 1].CrossFadeColor(Color.white, 1f, true, false);
            }
        }
        
    }
    
    private void ModifyUICoins()
    {
        if(lastPlayerCoins < player.moneyEarned && time >= 1f / coinTextSpeed)
        {
            lastPlayerCoins++;
            coinText.text = "x " + lastPlayerCoins;
            time = 0;
        }     
    }

    private void CoinIdleAnim()
    {
        coinAnim.SetBool("idle", true);
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void UnlockItem(int itemId)
    {
        items[itemId] = true;
    }

    public bool[] GetItems()
    {
        return items;
    }

    public void PauseScene()
    {
        Time.timeScale = 0;
    }

    public void UnpauseScene()
    {
        Time.timeScale = 1;
    }
}
