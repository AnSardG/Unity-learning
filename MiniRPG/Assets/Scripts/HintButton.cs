using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    public string hint;

    public TMP_Text text;

    public void SetHintDesc()
    {
        text.text = hint;
    }
}
