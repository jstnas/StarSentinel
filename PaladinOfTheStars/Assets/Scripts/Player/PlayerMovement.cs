/*
Project: Star Sentinel
Developer:
Version: 0.0.1
Date: 17/04/2018 10:39
*/

using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Vector3 _mousePosition;
	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
    {
        // First update the inputs
        float _horizontalInput = Input.GetAxisRaw("Horizontal");
        float _verticalInput = Input.GetAxisRaw("Vertical");
        _mousePosition = Input.mousePosition;

		// Manage the rotation based on the camera relative to the player.
		var _playerScreenPoint = Camera.main.WorldToScreenPoint(transform.transform.position);
		if (_mousePosition.x < _playerScreenPoint.x) { Turn(-1); }
        else { Turn(1); }

        // scale change due to keyboard.
        if (_horizontalInput > 0) { Turn(1); }
        else if (_horizontalInput < 0) { Turn(-1); }

		_rigidbody.velocity = new Vector2(_horizontalInput, _verticalInput).normalized;
    }

	private void Turn(int x)
	{
		transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
	}
}
