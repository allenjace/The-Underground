using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollingCamera : MonoBehaviour
{
    public Transform player;  // Drag the player object here in the Inspector

    private float initialY;
    private float initialZ;

    void Start()
    {
        if (player == null)
        {
            return;
        }

        // Store the initial Y and Z positions of the camera
        initialY = transform.position.y;
        initialZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Only update the X position of the camera
            transform.position = new Vector3(player.position.x, initialY, initialZ);
        }
    }
}
