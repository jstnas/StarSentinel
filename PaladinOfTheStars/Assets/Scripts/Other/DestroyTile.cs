// Paladin Of The Stars, By Sigma Games
// Tile destroyer script, By Justinas Grigas
// This script make sures that the tile is destroyed when not in view.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour {

    private BoxCollider2D _boxCollider2D;

    // Checks to see if the camera can see the object, otherwise destroy it.
    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
