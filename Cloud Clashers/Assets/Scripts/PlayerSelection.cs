﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using XInputDotNetPure;

public class PlayerSelection : MonoBehaviour 
{

	public AudioSource Audio;
	public AudioSource CharAudio;
	public AudioSource ConfirmAudio;
	public AudioClip Navigate;
	public AudioClip Confirm;

	public AudioClip Duck;
	public AudioClip Unicorn;
	public AudioClip Eagle;


	bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;
	public bool P1Ok = false;
	public bool P2Ok = false;
	public int TotalOptions = 2;


	//Player1
	public SpriteRenderer part;
	public SpriteRenderer part2;
	public Sprite[] CharOptions;
	public Sprite[] AbilityOptions;
	static public int P1CharIndex;
	static public int P1AbilityIndex;
	public int P1OptionIndex;



	public GameObject PlayerSelectBox;
	public GameObject PlayerAbilityBox;
	public GameObject P1OK;
	private GameObject Characterlist;


	//player2
	public SpriteRenderer p2part;
	public SpriteRenderer p2part2;
	public Sprite[] p2CharOptions;
	public Sprite[] p2AbilityOptions;
	static public int P2CharIndex;
	static public int P2AbilityIndex;
	public int P2OptionIndex;

	public int p2TotalOptions = 2;



	public GameObject p2PlayerSelectBox;
	public GameObject p2PlayerAbilityBox;
	public GameObject P2OK;
	private GameObject p2Characterlist;


	// Use this for initialization
	void Start()
	{
		
	}

	void FixedUpdate()
	{
		// SetVibration should be sent in a slower rate.
		// Set vibration according to triggers
		GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
	}

	// Update is called once per frame
	void Update()
	{
		// Find a PlayerIndex, for a single player game
		// Will find the first controller that is connected ans use it
		if (!playerIndexSet || !prevState.IsConnected)
		{
			for (int k = 0; k < 4; ++k)
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)k;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if (testState.IsConnected)
				{
					Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}

		prevState = state;
		state = GamePad.GetState(playerIndex);



		if (playerIndex == PlayerIndex.One) 
		{

			for (int i = 0; i < CharOptions.Length; i++) 
			{
				if (i == P1CharIndex) 
				{
					part.sprite = CharOptions [i];
				}

				for (int p = 0; p < AbilityOptions.Length; p++) 
				{
					if (p == P1AbilityIndex) 
					{
						part2.sprite = AbilityOptions [p];
					}
				}

			}
				
			if (Input.GetButtonDown ("P1A") && P1OptionIndex == 0) 
			{

				if (P1CharIndex == 0) 
				{
					CharAudio.PlayOneShot(Duck);
				}

				if (P1CharIndex == 1) 
				{
					CharAudio.PlayOneShot(Duck);
				}

				if (P1CharIndex == 2) 
				{
					CharAudio.PlayOneShot(Unicorn);
				}

				if (P1CharIndex == 3) 
				{
					CharAudio.PlayOneShot(Eagle);
				}

			}


			if (Input.GetButtonDown ("P1RB")  && P1OptionIndex == 0 )
			{
				Audio.PlayOneShot(Navigate);

				if (P1CharIndex < CharOptions.Length - 1) 
				{
					P1CharIndex++;
				} 
				else 
				{
					P1CharIndex = 0;
				}

			}

			if (Input.GetButtonDown ("P1LB") && P1OptionIndex == 0)
			{
				Audio.PlayOneShot(Navigate);

				if (P1CharIndex >= 1) 
				{
					P1CharIndex--;
				} 
				else 
				{
					P1CharIndex = CharOptions.Length - 1;
				}

			}

			if (Input.GetButtonDown ("P1RB")  && P1OptionIndex == 1 )
			{
				Audio.PlayOneShot(Navigate);

				if (P1AbilityIndex < CharOptions.Length - 1) 
				{
					P1AbilityIndex++;
				} 
				else 
				{
					P1AbilityIndex = 0;
				}

			}

			if (Input.GetButtonDown ("P1LB") && P1OptionIndex == 1)
			{
				Audio.PlayOneShot(Navigate);

				if (P1AbilityIndex >= 1) 
				{
					P1AbilityIndex--;
				} 
				else 
				{
					P1AbilityIndex = AbilityOptions.Length - 1;
				}

			}

			if (Input.GetButtonDown ("P1A") && P1OptionIndex < TotalOptions)
			{

				P1OptionIndex++;

			}

			if (Input.GetButtonDown ("P1A") && P1OptionIndex == 2 )
			{


				Audio.PlayOneShot(Confirm);

			}


			if (Input.GetButtonDown ("P1A") && P1OptionIndex < TotalOptions && P1CharIndex == 4)
			{
				P1CharIndex = Random.Range (0, 4);


			}


			if (Input.GetButtonDown ("P1B") )
			{

				P1OptionIndex--;

			}

			if (Input.GetButtonDown ("P1B") && P1OptionIndex <= TotalOptions )
			{

				P1Ok = false;

			}


			if (P1OptionIndex == 0) 
			{

				PlayerSelectBox.SetActive (true);
				PlayerAbilityBox.SetActive (false);

			}

			if (P1OptionIndex == 1) 
			{

				PlayerAbilityBox.SetActive (true);
				PlayerSelectBox.SetActive (false);

			}

			if (P1OptionIndex == TotalOptions) 
			{

				P1Ok = true;




			}

			if (P1OptionIndex == 2) 
			{

				P1OK.SetActive (true);

			}
			else 
			{

				P1OK.SetActive (false);

			}
				

			if (playerIndex == PlayerIndex.Two || Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.Z)|| Input.GetKeyDown (KeyCode.X)) 
			{

				for (int i = 0; i < p2CharOptions.Length; i++) 
				{
					if (i == P2CharIndex) 
					{
						p2part.sprite = p2CharOptions [i];
					}

					for (int p = 0; p < p2AbilityOptions.Length; p++) 
					{
						if (p == P2AbilityIndex) 
						{
							p2part2.sprite = p2AbilityOptions [p];
						}
					}

				}

				if (Input.GetButtonDown ("P2A") || Input.GetKeyDown(KeyCode.Z) && P2OptionIndex == 0) 
				{

					if (P2CharIndex == 0) 
					{
						CharAudio.PlayOneShot(Duck);
					}

					if (P2CharIndex == 1) 
					{
						CharAudio.PlayOneShot(Duck);
					}

					if (P2CharIndex == 2) 
					{
						CharAudio.PlayOneShot(Unicorn);
					}

					if (P2CharIndex == 3) 
					{
						CharAudio.PlayOneShot(Eagle);
					}

				}


				if (Input.GetButtonDown ("P2RB") || Input.GetKeyDown (KeyCode.RightArrow) && P2OptionIndex == 0)
				{
					Audio.PlayOneShot(Navigate);

					if (P2CharIndex < p2CharOptions.Length - 1) 
					{
						
						P2CharIndex++;

						Debug.Log("Char index" + P2CharIndex);
					} 
					else 
					{
						P2CharIndex = 0;
						Debug.Log("Char index" + P2CharIndex);
					}

				}



				if (Input.GetButtonDown ("P2LB") || Input.GetKeyDown (KeyCode.LeftArrow) && P2OptionIndex == 0)
				{
					Audio.PlayOneShot(Navigate);

					if (P2CharIndex >= 1) 
					{
						P2CharIndex--;

						Debug.Log("Char index" + P2CharIndex);
					} 
					else 
					{
						P2CharIndex = p2CharOptions.Length - 1;
					}

				}

				if (Input.GetButtonDown ("P2RB") || Input.GetKeyDown (KeyCode.RightArrow)  && P2OptionIndex == 1)
				{
					Audio.PlayOneShot(Navigate);

					if (P2AbilityIndex < p2CharOptions.Length - 1) 
					{
						P2AbilityIndex++;
					} 
					else 
					{
						P2AbilityIndex = 0;
					}

				}

				if (Input.GetButtonDown ("P2LB") || Input.GetKeyDown (KeyCode.LeftArrow) && P2OptionIndex == 1)
				{
					Audio.PlayOneShot(Navigate);

					if (P2AbilityIndex >= 1) 
					{
						P2AbilityIndex--;
					} 
					else 
					{
						P2AbilityIndex = p2AbilityOptions.Length - 1;
					}

				}

				if (Input.GetButtonDown ("P2A") || Input.GetKeyDown (KeyCode.Z) && P2OptionIndex < p2TotalOptions )
				{

					P2OptionIndex++;


				}

				if (Input.GetButtonDown ("P2A") || Input.GetKeyDown (KeyCode.Z) && P2OptionIndex == 2 )
				{


					Audio.PlayOneShot(Confirm);

				}


				if (Input.GetButtonDown ("P2A") || Input.GetKeyDown (KeyCode.Z) && P2OptionIndex < TotalOptions && P2CharIndex == 4)
				{
					P2CharIndex = Random.Range (0, 4);


				}


				if (Input.GetButtonDown ("P2B") || Input.GetKeyDown (KeyCode.X) )
				{

					P2OptionIndex--;

				}

				if (Input.GetButtonDown ("P2B") || Input.GetKeyDown (KeyCode.X) && P2OptionIndex <=  p2TotalOptions )
				{

					P2Ok = false;

				}


				if (P2OptionIndex == 0) 
				{

					p2PlayerSelectBox.SetActive (true);
					p2PlayerAbilityBox.SetActive (false);

				}

				if (P2OptionIndex == 1) 
				{
					
					p2PlayerAbilityBox.SetActive (true);
					p2PlayerSelectBox.SetActive (false);

				}

				if (P2OptionIndex == p2TotalOptions) 
				{

					P2Ok = true;

				}

				if (P2OptionIndex == 2) 
				{

					P2OK.SetActive (true);

				}
				else 
				{

					P2OK.SetActive (false);

				}


			}



		}


		if (P1Ok == true && P2Ok == true) 
		{

			SceneManager.LoadScene ("Game");

		}

	}
}
