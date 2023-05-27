using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyVariables : MonoBehaviour {
    // Just a scratchpad for playing with variables - not to be used in production
    public string firstName, lastName;
    private TextMeshProUGUI textMeshPro;
    private int health = 100;
    private int Health = 100;
    private int HeAlTh = 100;
    private int myHealth = 100;
    private string messageForTheTextView = "This space for rent";
    private const int PlayerScore = 100;
    // private const int PLAYER_SCORE = 100;
    // Start is called before the first frame update
    void Start() {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"Hello {firstName} {lastName}!";
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < 10; i++) {
            
        }
    }
}
