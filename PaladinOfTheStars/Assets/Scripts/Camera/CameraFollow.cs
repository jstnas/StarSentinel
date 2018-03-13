// Paladin of the Stars
// Camera Follow script
// By Justinas Grigas
// Version 0.0.1
// This scripts makes the camera object follow the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float lerpTime = 0.1f;

    private Transform _playerTransform;
    
    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () {
        gameObject.transform.position = new Vector3(Mathf.Lerp(gameObject.transform.position.x,_playerTransform.position.x,lerpTime), Mathf.Lerp(gameObject.transform.position.y,_playerTransform.position.y, lerpTime), -10f);
	}
}
