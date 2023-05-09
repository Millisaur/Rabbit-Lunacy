using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBound : MonoBehaviour
{
    public float boundaryLeft = -10f;
    public float boundaryRight = 110f;
    public Transform playerTransform;

    void Update() {
        // Get the current position of the player
        Vector3 currentPosition = playerTransform.position;

        // Restrict the x position of the player to the left and right boundaries
        currentPosition.x = Mathf.Clamp(currentPosition.x, boundaryLeft, boundaryRight);

        // Update the position of the player
        playerTransform.position = currentPosition;
    }
}
