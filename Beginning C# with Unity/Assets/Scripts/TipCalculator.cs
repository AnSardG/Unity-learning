using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipCalculator : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    public int amount;

    public float percentage = .2F;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateTip()
    {
        float tipAmount = (float)amount * percentage;
        int totalAmount = (int)tipAmount + amount;
        textMeshPro.text = $"{totalAmount}";
    }
}
