using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int sceneNum;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "Player")
        {
            //Pido al gameplaymanager que gestione el cambio de escena
            GameplayManager.instance.ChangeScene(sceneNum);
        }
    }
}
