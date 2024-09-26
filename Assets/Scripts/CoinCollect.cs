using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding with the coin is the player
        if (other.gameObject.CompareTag("Coin"))
        {
            // Increase the coin count in the GameManager
            // GameManager.instance.AddCoin();
            
            // Destroy the coin after collection
            Destroy(other.gameObject);
        }
        
    }
}
