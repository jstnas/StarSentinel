using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class OnClick : MonoBehaviour {

    public PauseMenu pauseMenu;

    private void OnMouseDown()
    {
        pauseMenu.SetIsPaused(false);   
    }
}
