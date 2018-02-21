// Paladin Of The Stars, By Sigma Games
// Tile generator script, By Justinas Grigas
// This script generates tiles that should be in view.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloor : MonoBehaviour {
    public GameObject floorTilePrefab;

    private Camera _camera;
    private float _pixelWidth;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public void Update()
    {
        float _xOffset;
        float _yOffset;

        if (transform.position.x > 0)
        {
            _xOffset = Mathf.Ceil(transform.position.x / 0.32f);
        }
        else
        {
            _xOffset = Mathf.Floor(transform.position.x / 0.32f);
        }

        if (transform.position.y > 0)
        {
            _yOffset = Mathf.Ceil(transform.position.y / 0.32f);
        }
        else
        {
            _yOffset = Mathf.Floor(transform.position.y / 0.32f);
        }

        _pixelWidth = GetComponent<CameraSize>().pixelWidth;
        int _seenHorizontalTiles = (int)Mathf.Ceil(_camera.pixelWidth / (32 * _pixelWidth));
        int _seenVerticalTiles = (int)Mathf.Ceil(_camera.pixelHeight / (32 * _pixelWidth));

        for (int x = 0; x < _seenHorizontalTiles; x ++)
        {
            for (int y = 0; y < _seenVerticalTiles; y++)
            {
                float xPos = _xOffset - x * 0.32f + 0.16f;
                float yPos = _yOffset - y * 0.32f + 0.16f;

                Instantiate(floorTilePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
            }
        }
    }
}
