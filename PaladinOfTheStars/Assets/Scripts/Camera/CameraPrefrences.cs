// Project: Star Sentinel - https://sigsec.github.io
// Developer: Justinas Grigas - https://sigsec.github.io
// Version: 0.0.2
// Date: 18/04/2018 12:50

using UnityEngine;

public class CameraPrefrences : MonoBehaviour {

	private Camera _camera;
	private GlobalManager _manager;

	private float _screenWidth;
    private float _screenHeight;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
		_manager = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
    }

    private void Update()
    {
        _screenHeight = Mathf.FloorToInt(Screen.height / 18.0f);
        _screenWidth = Mathf.FloorToInt(Screen.width / 32.0f);

        // Picks the smaller screen size to make sure it fits.
        if (_screenHeight < _screenWidth) { _screenWidth = _screenHeight; }
        else { _screenHeight = _screenWidth; }

        _screenHeight *= 18.0f;
        _screenWidth *= 32.0f;

        _camera.orthographicSize = _screenWidth / 355.029585799f / _manager.GetPixelSize();
        
        // Creates a new camera rectangle and modifies it.
        Rect _rect      = _camera.rect;
        _rect.width     = _screenWidth / Screen.width;
        _rect.height    = _screenHeight / Screen.height;
        _rect.x         = Mathf.Round((( 1 - _rect.width) / 2) * 5000) / 5000;
        _rect.y         = Mathf.Round((( 1 - _rect.height) / 2) * 5000) / 5000;
        _camera.rect    = _rect;
    }
}