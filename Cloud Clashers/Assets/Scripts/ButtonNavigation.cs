using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNavigation : MonoBehaviour 
{

	int index = 0;
	public int totalLevels = 3;
	public float yOffset = 1f;

	public AudioSource Audio;
	public AudioClip Navigate;

	
	// Update is called once per frame
	void Update () 
	{
		float moveVertical = Input.GetAxisRaw ("Dpad");

		if (Input.GetKeyDown (KeyCode.DownArrow) || moveVertical < 0 )
		{
			Audio.PlayOneShot(Navigate);
			
				if (index < totalLevels - 1) 
				{
					index++;
					Vector2 Position = transform.position;
					Position.y -= yOffset;
					transform.position = Position;
				}

		}

		if (Input.GetKeyDown (KeyCode.UpArrow) || moveVertical > 0 )
		{
			Audio.PlayOneShot(Navigate);

				if (index > 0) 
				{
					index--;
					Vector2 Position = transform.position;
					Position.y += yOffset;
					transform.position = Position;
				}
		}

		if (Input.GetKeyDown (KeyCode.Return) || Input.GetButtonDown("P1A"))
		{
			if (index == 0) 
			{
				SceneManager.LoadScene ("Character Select");
			}

			if (index == 1) 
			{
				SceneManager.LoadScene ("Tutorial");
			}

			if (index == 2) 
			{
				Application.Quit();
			}
				
		}



	}

}
