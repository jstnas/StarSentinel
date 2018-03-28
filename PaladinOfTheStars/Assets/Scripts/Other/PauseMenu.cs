/// Paladin of the Stars by Sigma Games
/// Pause Menu Script by Justinas Grigas
/// This script manages the pause menu that is triggered while playing the game.
/// Version 0.0.1   28/03/2018
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] arrayOfMenus;
    public GameObject menuBackground;

    public GameObject sfxText;
    public GameObject musicText;

    private List<GameObject> arrayOfOptions = new List<GameObject>();

    private int _menuIndex;
    private float _optionIndex;

    private bool _isPaused;

    private float _pauseTimerMax = 0.2f;
    private float _pauseTimer;

    private float _sfxVolume;
    private float _musicVolume;

    private Color _inactiveTextColour = new Color(1f, 1f, 0.89019607843f, 1f);
    private Color _activeTextColour = new Color(0.96862745098f, 0.87450980392f, 0.39607843137f, 1f);

    public bool GetIsPaused() { return _isPaused; }

    private void Awake()
    {

        _sfxVolume = _musicVolume = 10f;

        menuBackground.SetActive(false);

        foreach (var menu in arrayOfMenus)
        {
            menu.SetActive(false);
        }
    }

    private void Update()
    {


        // Get input.
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!_isPaused)
            {
                _isPaused = true;
                _menuIndex = 0;
                _optionIndex = 1f;
                _pauseTimer = _pauseTimerMax;
                menuBackground.SetActive(true);
            }
            else
            {
                _isPaused = false;
            }
        }

        // Checks if the game is paused.
        if (_isPaused)
        {
            sfxText.GetComponent<UnityEngine.UI.Text>().text = "SFX: " + _sfxVolume;
            musicText.GetComponent<UnityEngine.UI.Text>().text = "Music: " + _musicVolume;

            arrayOfMenus[_menuIndex].SetActive(false);

            foreach (var option in arrayOfMenus[(int)_menuIndex].GetComponentsInChildren<Transform>())
            {
                if (option != arrayOfMenus[(int)_menuIndex].GetComponentsInChildren<Transform>()[0])
                {
                    option.gameObject.GetComponent<UnityEngine.UI.Text>().color = _inactiveTextColour;
                    arrayOfOptions.Add(option.gameObject);
                }
            }

            float _verticalInput = Input.GetAxisRaw("Vertical");
            float _horizontalInput = Input.GetAxisRaw("Horizontal");

            if (_verticalInput > 0 && _pauseTimer > _pauseTimerMax)
            {
                _optionIndex --;
                _pauseTimer = 0;
            }
            else if (_verticalInput < 0 && _pauseTimer > _pauseTimerMax)
            {
                _optionIndex ++;
                _pauseTimer = 0;
            }

            if (_optionIndex > arrayOfOptions.Count -1)
                { _optionIndex = 1f; }
            else if (_optionIndex < 1) 
                { _optionIndex = arrayOfOptions.Count - 1; }

            print(arrayOfMenus[_menuIndex].name);


            if (arrayOfMenus[_menuIndex].name == "SoundCanvas" && arrayOfOptions[(int)_optionIndex].name == "SFX")
            {
                if (_horizontalInput > 0 && _pauseTimer > _pauseTimerMax && _sfxVolume < 10)
                {
                    _sfxVolume ++;
                    _pauseTimer = 0;
                    print("x");
                }
                else if (_horizontalInput < 0 && _pauseTimer > _pauseTimerMax && _sfxVolume > 0)
                {
                    _sfxVolume --;
                    _pauseTimer = 0;
                }
            }
            else if (arrayOfMenus[_menuIndex].name == "SoundCanvas" && arrayOfOptions[(int)_optionIndex].name == "Music")
            {
                if (_horizontalInput > 0 && _pauseTimer > _pauseTimerMax && _musicVolume < 10)
                {
                    _musicVolume ++;
                    _pauseTimer = 0;
                }
                else if (_horizontalInput < 0 && _pauseTimer > _pauseTimerMax && _musicVolume > 0)
                {
                    _musicVolume --;
                    _pauseTimer = 0;
                }
            }


            // Checks if the user selects an option
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (arrayOfOptions[(int)_optionIndex].name == "Continue") { _isPaused = false; }
                else if (arrayOfOptions[(int)_optionIndex].name == "Options")
                {
                    _optionIndex = 1f;
                    _menuIndex = 1;
                    
                }
                else if (arrayOfOptions[(int)_optionIndex].name == "Exit") { Application.Quit(); }
                else if (arrayOfOptions[(int)_optionIndex].name == "Sound")
                {
                    _optionIndex = 1f;
                    _menuIndex = 2;
                }
                else if (arrayOfOptions[(int)_optionIndex].name == "Controls")
                {
                    
                    _optionIndex = 1f;
                    _menuIndex = 3;
                }
                else if (arrayOfOptions[(int)_optionIndex].name == "0Back")
                {
                    _optionIndex = 1f;
                    _menuIndex = 0;
                }
                else if (arrayOfOptions[(int)_optionIndex].name == "1Back")
                {
                    _optionIndex = 1f;
                    _menuIndex = 1;
                }
            }

            arrayOfOptions[(int)_optionIndex].GetComponent<UnityEngine.UI.Text>().color = _activeTextColour;
            _pauseTimer += Time.deltaTime;
            arrayOfOptions.Clear();
            arrayOfMenus[_menuIndex].SetActive(true);
        }
        else
        {
            menuBackground.SetActive(false);
            arrayOfMenus[_menuIndex].SetActive(false);
        }
    }
}