using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with the platform or Tilemap
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}