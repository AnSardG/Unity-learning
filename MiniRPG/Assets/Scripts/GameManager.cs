using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int numPistas = 1;

    private bool[] pistas;

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

        pistas = new bool[numPistas];
    }

    private void Start()
    {

    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void DesbloquearPista(int idPista)
    {
        pistas[idPista] = true;
    }

    public bool[] GetPistas()
    {
        return pistas;
    }
}
