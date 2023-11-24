using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int value;
    public string[] powerupTypes = {"Immunity", "Double Size"};
    [Tooltip("Selecciona una opción")]
    public string powerupChosen;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            switch (gameObject.tag)
            {
                case "Coin":
                    player.EarnCoins(value);
                    break;
                case "Powerup":
                    if (powerupChosen == powerupTypes[0])
                    {
                        player.Immunity();
                    } else if (powerupChosen == powerupTypes[1])
                    {
                        player.GrowUp();
                    }
                    break;
            }
            Destroy(gameObject);
        }      
    }
}
