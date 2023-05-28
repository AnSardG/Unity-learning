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
        alienOne.HitPoints = 240;
        alienOne.Alive = true;
        alienOne.PointValue = 25;
    }

    void OnDisable()
    {
        Debug.Log("Name: "+playerOne.Name + ", score: "+playerOne.Score);
        if (alienOne.Alive)
        {
            Debug.Log("There's an alien alive!");
            alienOne.Fire();
        }
    }
}
