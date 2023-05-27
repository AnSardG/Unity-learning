using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTypes : MonoBehaviour
{
    public string message = "Strings contain text, not cheese";
    public string phoneNumber = "723456321";
    public string whiteSpace = " ";
    public string emptyString = "";
    public char tempType = 'C';
    public bool wetClothesKill = true;
    public bool lovingRelationship = false;
    public int myNumber = 2_147_483_647;
    // uint means unsigned integer, no signs baby
    public uint anotherNumber = 2147483648;
    // public uint errorNumber = -1;
    public long reallyBigNumber = 9_223_372_036_854_775_807;
    public double pi = 3.14159265359;
    public float temp = 95.6F;
    // decimal type is used for financial purposes, to use decimals it's mandatory to put an M after the number.
    public decimal cashOnHand = 1.99M;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
