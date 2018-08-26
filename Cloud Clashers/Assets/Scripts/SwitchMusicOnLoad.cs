using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour 
{
	public AudioClip newTrack;

	private AudioManager theAPI;

	// Use this for initialization
	void Start () 
	{
		
		theAPI = FindObjectOfType<AudioManager>	();

		if (newTrack != null) 
		{
			theAPI.ChangeBGM(newTrack);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
