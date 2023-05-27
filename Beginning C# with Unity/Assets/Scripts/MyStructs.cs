using UnityEngine;
using Beginning.CSharp;
using LearningObjects;
public class MyStructs : MonoBehaviour
{
    Player playerOne, playerTwo;
    Alien alienOne;
    void Start()
    {
        playerOne = new Player();
        playerTwo = new Player();
        alienOne = new Alien();
        playerOne.Name = "Barney";
        playerOne.Score = 100;
        playerOne.Lives = 3;
        Debug.Log(playerOne.Lives);
        alienOne.HitPoints = 240;
        alienOne.Alive = true;
        alienOne.PointValue = 25;
    }

    void OnDisable()
    {
        Debug.Log("Name: "+playerOne.Name + ", score: "+playerOne.Score+", lives: "+playerOne.Lives);
        if (alienOne.Alive)
        {
            Debug.Log("There's an alien alive!");
        }
    }
}
