using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MadLibs : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private bool statement;

    private string verb, noun, adjective, pluralNoun;

    private int number;

    private float percent;
    // Start is called before the first frame update
    void Start()
    {
        statement = true;
        verb = "take";
        noun = "money";
        adjective = "handsome";
        pluralNoun = "fellas";
        number = 200;
        percent = 124.53F;
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"The is statement is {statement}. I did not {verb} the {noun}. I am not guilty. I am a " +
                           $"{adjective} person. The act was performed by {number} wandering {pluralNoun}. I am {percent}% " +
                           $"sure of this.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
