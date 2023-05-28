using System.Collections;
using System.Collections.Generic;
using Beginning.CSharp;
using UnityEngine;

public class Turret : MonoBehaviour, IShootable
{
    public void Fire()
    {
        Debug.Log("Turret fires.");
    }

    public void Save()
    {
        Debug.Log("Turret game saved.");
    }
}
