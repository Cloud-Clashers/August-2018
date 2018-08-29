using System.Collections;
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
	public PlayerIndex playerIndex = PlayerIndex.One;
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


//	//player2
//	public SpriteRenderer p2part;
//	public SpriteRenderer p2part2;
//	public Sprite[] p2CharOptions;
//	public Sprite[] p2AbilityOptions;
//	static public int P2CharIndex;
//	static public int P2AbilityIndex;
//	public int P2OptionIndex;
//
//	public int p2TotalOptions = 2;
//
//
//
//	public GameObject p2PlayerSelectBox;
//	public GameObject p2PlayerAbilityBox;
//	public GameObject P2OK;
//	private GameObject p2Characterlist;


	// Use this for initialization
	void Start()
	{
		playerIndex = PlayerIndex.One;
	}

	void FixedUpdate()
	{
		playerIndex = PlayerIndex.One;
	}

	// Update is called once per frame
	void Update()
	{
		// Find a PlayerIndex, for a single player game
		// Will find the first controller that is connected ans use it
		if (!playerIndexSet || !prevState.IsConnected) 
		{
			for (int k = 0; k < 4; k++) 
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)k;
				GamePadState testState = GamePad.GetState (testPlayerIndex);
				if (testState.IsConnected) 
				{
					Debug.Log (string.Format ("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}

		prevState = state;
		state = GamePad.GetState (playerIndex);



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
					CharAudio.PlayOneShot (Duck);
				}

				if (P1CharIndex == 1) 
				{
					CharAudio.PlayOneShot (Duck);
				}

				if (P1CharIndex == 2) 
				{
					CharAudio.PlayOneShot (Unicorn);
				}

				if (P1CharIndex == 3) 
				{
					CharAudio.PlayOneShot (Eagle);
				}

			}


			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P1OptionIndex == 0)
			{
				Audio.PlayOneShot (Navigate);

				if (P1CharIndex < CharOptions.Length - 1) 
				{
					P1CharIndex++;
				} else 
				{
					P1CharIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P1OptionIndex == 0) {
				Audio.PlayOneShot (Navigate);

				if (P1CharIndex >= 1)
				{
					P1CharIndex--;
				} else 
				{
					P1CharIndex = CharOptions.Length - 1;
				}

			}

			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P1OptionIndex == 1) 
			{
				Audio.PlayOneShot (Navigate);

				if (P1AbilityIndex < CharOptions.Length - 1) {
					P1AbilityIndex++;
				} else {
					P1AbilityIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P1OptionIndex == 1) 
			{
				Audio.PlayOneShot (Navigate);

				if (P1AbilityIndex >= 1) 
				{
					P1AbilityIndex--;
				} else 
				{
					P1AbilityIndex = AbilityOptions.Length - 1;
				}

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P1OptionIndex < TotalOptions) 
			{

				P1OptionIndex++;

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P1OptionIndex == 2) 
			{


				Audio.PlayOneShot (Confirm);

			}


			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P1OptionIndex < TotalOptions && P1CharIndex == 4) 
			{
				P1CharIndex = Random.Range (0, 4);


			}


			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed) 
			{

				P1OptionIndex--;

			}

			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && P1OptionIndex <= TotalOptions) {

				P1Ok = false;

			}


			if (P1OptionIndex == 0) {

				PlayerSelectBox.SetActive (true);
				PlayerAbilityBox.SetActive (false);

			}

			if (P1OptionIndex == 1) {

				PlayerAbilityBox.SetActive (true);
				PlayerSelectBox.SetActive (false);

			}

			if (P1OptionIndex == TotalOptions) {

				P1Ok = true;




			}

			if (P1OptionIndex == 2) 
			{

				P1OK.SetActive (true);

			} else 
			{

				P1OK.SetActive (false);

			}
		}
	}				
}