// Project: Star Sentinel - https://sigsec.github.io
// Developer: Justinas Grigas - https://sigsec.github.io
// Version: 0.0.2
// Date: 18/04/2018 13:00

using UnityEngine;

public class GlobalManager : MonoBehaviour
{
	private static GlobalManager instance;

	private int _pixelSize = 2;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	// Getter and setter methods for private variables.
	public void SetPixelSize(int pixelSize) { _pixelSize = pixelSize; }
	public int GetPixelSize() { return _pixelSize; }
}
