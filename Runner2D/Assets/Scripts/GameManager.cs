using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeToReset = 20;
    float timePassed;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timeToReset < timePassed)
        {
            timePassed = 0;
            SceneManager.LoadScene(0);            
        }
        if(Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }    
    }
}
