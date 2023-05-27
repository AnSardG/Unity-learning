using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNull : MonoBehaviour
{
    string firstName = "Brian";

    string lastName = null;
    //Here we are modifying the variable to be "nullable", this means that it can contain either the data type (number
    // in this case), or either null.
    int? meaningOfLife = null;
    // Start is called before the first frame update
    void Start()
    {
        /*
        Debug.Log($"{firstName} {lastName}");
        lastName.ToUpper();
        */
        int? anotherNumber = null;
        //The "??" operator is used when the left operand is null, then chooses the right one as the valid option, it's
        //like an OR operator but choosing the non-null value.
        int trueNumber = meaningOfLife ?? anotherNumber ?? 42;
        Debug.Log(trueNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
