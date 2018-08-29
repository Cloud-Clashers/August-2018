using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class CloudClashersPauseGame : MonoBehaviour 
{
	public GameObject PauseBackground;

	public GameObject Reset;
	public GameObject CharacterSelect;
	public GameObject Charyes;
	public GameObject Charno;
	public GameObject Options;
	public GameObject Quit;

	public int menuindex = 0;
	public int totalLevels = 4;
	public float yOffset = 1f;

	GamePadState state;
	GamePadState prevState;


	private bool paused = false;

	void Start()
	{
		PauseBackground.SetActive (false);
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Pause") ) 
		{
			if (paused) 
			{
				Resume ();
			}
			else 
			{
				Pause ();
			}
		} 

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (paused) 
			{
				Resume ();
			} 
			else 
			{
				Pause ();
			}
		} 
			
		if (Input.GetKeyDown (KeyCode.DownArrow) || prevState.DPad.Down == ButtonState.Released && state.DPad.Down == ButtonState.Pressed )
		{
			if (menuindex < totalLevels - 1) 
			{
				menuindex++;
				Vector2 Position = transform.position;
				Position.y -= yOffset;
				transform.position = Position;
			}
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) || prevState.DPad.Up == ButtonState.Released && state.DPad.Up == ButtonState.Pressed )
		{
			if (menuindex > 0) 
			{
				menuindex--;
				Vector2 Position = transform.position;
				Position.y += yOffset;
				transform.position = Position;
			}
		}

		if (menuindex == 0) 
		{
			
			Reset.SetActive (true);
			CharacterSelect.SetActive (false);
			Options.SetActive (false);
			Quit.SetActive (false);

		}

		if (menuindex == 1) 
		{

			Reset.SetActive (false);
			CharacterSelect.SetActive (true);
			Options.SetActive (false);
			Quit.SetActive (false);

		}

		if (menuindex == 2) 
		{

			Reset.SetActive (false);
			CharacterSelect.SetActive (false);
			Options.SetActive (true);
			Quit.SetActive (false);

		}

		if (menuindex == 3) 
		{

			Reset.SetActive (false);
			CharacterSelect.SetActive (false);
			Options.SetActive (false);
			Quit.SetActive (true);

		}


		if (paused) 
		{
			
			if (Input.GetButtonDown ("P1A") && menuindex == 0) 
			{
				
				Application.LoadLevel (Application.loadedLevel);
				Resume ();

			}
			

			if (Input.GetButtonDown ("P1A") && menuindex == 1) 
			{
			
				SceneManager.LoadScene ("Character Select");
				Resume ();

			}


			if (menuindex == 2) 
			{


			}


			if (Input.GetButtonDown ("P1A") && menuindex == 3) 
			{

				SceneManager.LoadScene ("Main menu");
				Resume ();

			}

		}



	}

	public void Resume()
	{
		PauseBackground.SetActive (false);

		Time.timeScale = 1;
		paused = false;
	}

	void Pause()
	{
		PauseBackground.SetActive (true);
	
		Time.timeScale = 0;
		paused = true;
	}

}
