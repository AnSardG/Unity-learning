using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BotonPista : MonoBehaviour
{
    public string pista;

    public TMP_Text text;
    
    public void SetPistaDesc()
    {
        text.text = pista;
    }
}
