using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edgeBoundry : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the player's position to the center of the screen
            collision.gameObject.transform.position = new Vector2(0f, 0f);
        }
    }
}
