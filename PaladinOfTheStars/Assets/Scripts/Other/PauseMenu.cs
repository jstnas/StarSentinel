using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private bool _isPaused = false;
    private GameObject _pausePlane;
    private GameObject _pauseCanvas;

    // Getter function for the paused boolean.
    public bool GetIsPaused() { return _isPaused; }
    public void SetIsPaused(bool isPaused) { isPaused = _isPaused; }

    private void Awake()
    {
        _pausePlane = GameObject.Find("PausePlane");
        _pauseCanvas = GameObject.Find("PauseCanvas");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !_isPaused)
        {
            _isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && _isPaused)
        {
            _isPaused = false;
        }

        if (_isPaused)
        {
            Time.timeScale = 0f;
            _pausePlane.SetActive(true);
            _pauseCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            _pausePlane.SetActive(false);
            _pauseCanvas.SetActive(false);
        }
    }
}
