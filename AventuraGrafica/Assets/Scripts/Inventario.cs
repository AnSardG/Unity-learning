using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public Button[] botonesPistas;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        bool[] pistas = GameplayManager.instance.GetPistas();

        try
        {
            for (int i = 0; i < botonesPistas.Length; i++)
            {
                if (pistas[i])
                {
                    botonesPistas[i].interactable = true;
                }
            }
        }
        catch(NullReferenceException e)
        {
            Debug.Log(e.Message);
        }        
    }

}
