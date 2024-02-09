using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public Button[] itemButtons;

    void Start()
    {

    }

    private void OnEnable()
    {
        bool[] items = GameManager.instance.GetItems();

        try
        {
            for (int i = 0; i < itemButtons.Length; i++)
            {
                if (items[i])
                {
                    itemButtons[i].interactable = true;
                }
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }
    }
}
