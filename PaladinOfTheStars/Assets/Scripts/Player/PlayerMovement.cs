// Paladin of the stars
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform _playerTransform;
    private Vector3 _mousePosition;
    private bool _isPaused;

    private void Awake()
    {
        _playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        _isPaused = GameObject.Find("EventSystem").GetComponent<PauseMenu>().GetIsPaused();
        _playerTransform.position = new Vector3(Mathf.Round(_playerTransform.position.x * 100) / 100, Mathf.Round(_playerTransform.position.y * 100) / 100, 0);

        // Move the player
        if (!_isPaused)
        {
            // First update the inputs
            float _horizontalInput = Input.GetAxisRaw("Horizontal") * 0.01f;
            float _verticalInput = Input.GetAxisRaw("Vertical") * 0.01f;
            _mousePosition = Input.mousePosition;

            // Update rotations from mouse.
            var _playerScreenPoint = Camera.main.WorldToScreenPoint(_playerTransform.transform.position);
            if (_mousePosition.x < _playerScreenPoint.x)
            {
                _playerTransform.localScale = new Vector3(-1, _playerTransform.localScale.y, _playerTransform.localScale.z);
            }
            else
            {
                _playerTransform.localScale = new Vector3(1, _playerTransform.localScale.y, _playerTransform.localScale.z);
            }

            // rotations from movement override rotations from cursor.
            if (_horizontalInput > 0)
            {
                _playerTransform.localScale = new Vector3(1, _playerTransform.localScale.y, _playerTransform.localScale.z);
            }
            else if (_horizontalInput < 0)
            {
                _playerTransform.localScale = new Vector3(-1, _playerTransform.localScale.y, _playerTransform.localScale.z);
            }

            _playerTransform.position = new Vector3(_playerTransform.position.x + _horizontalInput, _playerTransform.position.y + _verticalInput, -1);
        } 
    }
}
