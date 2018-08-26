using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour 
{

	public AudioSource BGM;

	// Use this for initialization
	void Awake () 
	{
		
//		DontDestroyOnLoad (this.gameObject);

	}

	void Update ()
	{

		DontDestroyOnLoad (this.gameObject);

	}

	public void ChangeBGM(AudioClip music)
	{
		if (BGM.clip.name == music.name)
			return;

		BGM.Stop ();
		BGM.clip = music;
		BGM.Play ();


	}
}
