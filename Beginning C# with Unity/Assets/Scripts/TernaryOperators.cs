using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TernaryOperators : MonoBehaviour
{
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        int[] numbers = new int[] {Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100) ,Random.Range(0, 100)};
        string numberText;
        foreach (int n in numbers)
        {
            numberText = (name != "") ? "Hello " + name: "";
            numberText += ". Your number is ";
            numberText += (n % 2 == 0) ? "even" : "odd";
            Debug.Log(numberText); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
