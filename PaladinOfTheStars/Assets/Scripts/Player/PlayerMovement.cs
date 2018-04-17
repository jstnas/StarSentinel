/*
Project: Star Sentinel
Developer:
Version: 0.0.1
Date: 17/04/2018 10:39
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject eventSystem;
    private Vector3 _mousePosition;
    private bool _isPaused;

    private void Update()
    {
        _isPaused = eventSystem.GetComponent<PauseMenu>().GetIsPaused();
        transform.position = new Vector3(Mathf.Round(transform.position.x * 100) / 100, Mathf.Round(transform.position.y * 100) / 100, 0);

        // Move the player
        if (!_isPaused)
        {
            // First update the inputs
            float _horizontalInput = Input.GetAxisRaw("Horizontal") * 0.01f;
            float _verticalInput = Input.GetAxisRaw("Vertical") * 0.01f;
            _mousePosition = Input.mousePosition;

            // scale change due to mouse.
            var _playerScreenPoint = Camera.main.WorldToScreenPoint(transform.transform.position);
            if (_mousePosition.x < _playerScreenPoint.x)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }

            // scale change due to keyboard.
            if (_horizontalInput > 0)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if (_horizontalInput < 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }

            transform.position = new Vector3(transform.position.x + _horizontalInput, transform.position.y + _verticalInput, -1);
        } 
    }
}
