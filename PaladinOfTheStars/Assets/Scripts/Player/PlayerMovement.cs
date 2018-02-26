// Paladin of the stars
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform _playerTransform;
    private Vector3 _mousePosition;
    private float _horizontalInput;
    private float _verticalInput;

    private void Awake()
    {
        _playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        // First update the inputs
        _horizontalInput = Input.GetAxisRaw("Horizontal") * 0.01f;
        _verticalInput = Input.GetAxisRaw("Vertical") * 0.01f;
        _mousePosition = Input.mousePosition;

        // Update rotations
        var _playerScreenPoint = Camera.main.WorldToScreenPoint(_playerTransform.transform.position);
        if (_mousePosition.x < _playerScreenPoint.x)
        {
            _playerTransform.localScale = new Vector3(-1, _playerTransform.localScale.y, _playerTransform.localScale.z);
        }
        else
        {
            _playerTransform.localScale = new Vector3(1, _playerTransform.localScale.y, _playerTransform.localScale.z);
        }

        // Move the player
        _playerTransform.position = new Vector3(_playerTransform.position.x + _horizontalInput, _playerTransform.position.y + _verticalInput, -1);
    }
}
