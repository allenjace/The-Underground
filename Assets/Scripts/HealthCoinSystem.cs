using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealthCoin : MonoBehaviour
{
    public GameObject[] hearts;  // Array to hold the heart GameObjects
    private int lives;  // Number of lives the player has
    public Transform player;  // Player transform to follow
    public Vector3 offset = new Vector3(1f, 1f, 0f);  // Offset from the player for the hearts
    public TextMeshProUGUI coinText;  // UI Text to display the number of coins collected
    private int coinCount = 0;  // Counter for the coins
    public Vector3 coinTextOffset = new Vector3(2f, 2f, 0f);

    void Start()
    {
        lives = hearts.Length;  // Set lives to the number of heart GameObjects
        UpdateCoinText();  // Initialize the coin counter UI
    }
    void Update()
    {
        // Make the hearts follow the player
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
            {
                hearts[i].transform.position = player.position + offset + new Vector3(i * 1.0f, 0f, 0f);  // Adjust the offset as needed
            }
        }

        // Make the coin counter UI follow the player
        if (coinText != null)
        {
            coinText.transform.position = Camera.main.WorldToScreenPoint(player.position + coinTextOffset);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike") || other.CompareTag("Saw")) // Check if the player touches a hazard
        {
            LoseLife();
        }
        else if (other.CompareTag("Coin"))  // Check if the player collects a coin
        {
            CollectCoin();
            Destroy(other.gameObject);  // Destroy the coin GameObject
        }
    }
    void LoseLife()
    {
        if (lives > 0)
        {
            lives--;  // Decrease the lives count
            Destroy(hearts[lives]);  // Destroy the corresponding heart GameObject
            if (lives <= 0)
            {
                // Handle game over, player death, etc.
                SceneManager.LoadSceneAsync("GameOver");
            }
        }
    }

    void CollectCoin()
    {
        coinCount++;  // Increase the coin count
        UpdateCoinText();  // Update the UI to reflect the new coin count
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount.ToString();  // Update the TextMeshProUGUI with the coin count
    }
}