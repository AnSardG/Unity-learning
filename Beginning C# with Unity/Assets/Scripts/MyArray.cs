using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyArray : MonoBehaviour
{
    public int totalAmount;
    private int[] scores = new int[3];
    private string[] names = { "Mike", "James", "Pete" };
    public int[] lives;
    public float tipPercentage;
    // Start is called before the first frame update
    void Start()
    {
        // int tip = (int)(totalAmount * tipPercentage);
        // Debug.Log("Your total balance is " + (tip + totalAmount));
        // //Declare the array
        // int[] myArray;
        // //Initialize it
        // myArray = new int[5];
        //Can do on the same sentence btw
        // int[] myArray = {0, 3, 10, 3};
        // myArray[0] = 1;
        // foreach (int i in myArray)
        // {
        //     Debug.Log(i);
        // }
        scores[0] = 403;
        scores[1] = 200;
        scores[2] = 500;
        Debug.Log(names[0]+"'s score is: " + scores[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
