// Duo Chroma By Sigma Games
// Camera Adjustment script By Justinas "SigmaPi" Grigas
// Version 0.2.0
// This script ensures that every pixel is drawn cleanly onto the screen.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour {
    // Width of each pixel on the screen.
    public int pixelWidth = 1;
    // Camera object that will be modified.
    private Camera _camera;
    // The screen width and height snaped to the nearest.
    private float _screenWidth;
    private float _screenHeight;

    private void Awake()
    {
        // Grabs the camera component from the game object.
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        _screenHeight = Mathf.FloorToInt(Screen.height / 18.0f);
        _screenWidth = Mathf.FloorToInt(Screen.width / 32.0f);

        // Picks the smaller screen size to make sure it fits.
        if (_screenHeight < _screenWidth)
        {
            _screenWidth = _screenHeight;
        }
        else
        {
            _screenHeight = _screenWidth;
        }

        _screenHeight *= 18.0f;
        _screenWidth *= 32.0f;

        _camera.orthographicSize = _screenWidth / 355.029585799f / pixelWidth;
        
        // Creates a new camera rectangle and modifies it.
        Rect _rect      = _camera.rect;
        _rect.width     = _screenWidth / Screen.width;
        _rect.height    = _screenHeight / Screen.height;
        _rect.x         = Mathf.Round((( 1 - _rect.width) / 2) * 5000) / 5000;
        _rect.y         = Mathf.Round((( 1 - _rect.height) / 2) * 5000) / 5000;
        _camera.rect    = _rect;
    }
}