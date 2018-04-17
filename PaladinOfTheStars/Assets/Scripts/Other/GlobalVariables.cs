/*
Project: Star Sentinel
Developer:
Version: 0.0.1
Date: 17/04/2018 10:39
*/

using UnityEngine;

public class GlobalVariables : MonoBehaviour {
	// Public Variables to keep track of.
	public static GlobalVariables self;

	[Header("Graphics Settings")]
	public int pixelSize;
	public int uiScale;

	[Space]
	[Header("Audio Settings")]
	public int musicVolume;

	private void Awake()
	{
		// Keep the default cursor hidden.
		Cursor.visible = false;

		// Singleton.
		if (self == null)
		{
			DontDestroyOnLoad(gameObject);
			self = this;
		}
		else if (self != this)
		{
			Destroy(gameObject);
		}
	}
}
