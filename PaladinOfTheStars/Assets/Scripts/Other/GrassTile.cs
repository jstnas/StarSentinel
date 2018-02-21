using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : MonoBehaviour {

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
