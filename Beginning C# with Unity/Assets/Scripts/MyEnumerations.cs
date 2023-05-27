using UnityEngine;

public enum CompassDirection
{
    North, South, East, West
}
public class MyEnumerations : MonoBehaviour
{
    public CompassDirection playerMovement;
    private void OnDisable()
    {
        string dir = "";
        switch (playerMovement)
        {
            case CompassDirection.North:
                dir = "north";
                break;
            case CompassDirection.East:
                dir = "east";
                break;
            case CompassDirection.West:
                dir = "west";
                break;
            case CompassDirection.South:
                dir = "south";
                break;
        }
        Debug.Log(dir);
    }
}
