using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using XInputDotNetPure;

public class PlayerSelectionP2 : MonoBehaviour 
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
	public PlayerIndex playerIndex = PlayerIndex.Two;
	GamePadState state;
	GamePadState prevState;
	public bool P2Ok = false;
	public int TotalOptions = 2;

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
	void Start () 
	{
		playerIndex = PlayerIndex.Two;
	}

	void FixedUpdate()
	{
		playerIndex = PlayerIndex.Two;
	}

	
	// Update is called once per frame
	void Update ()
	{
		// Find a PlayerIndex, for a single player game
		// Will find the first controller that is connected ans use it
		if (!playerIndexSet || !prevState.IsConnected) {
			for (int k = 0; k < 4; k++) {
				PlayerIndex testPlayerIndex = (PlayerIndex)k;
				GamePadState testState = GamePad.GetState (testPlayerIndex);
				if (testState.IsConnected) {
					Debug.Log (string.Format ("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}

		prevState = state;
		state = GamePad.GetState (playerIndex);

		if (playerIndex == PlayerIndex.Two) 
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

			if (Input.GetButtonDown ("P2A") || Input.GetKeyDown (KeyCode.Z) && P2OptionIndex == 0) 
			{

				if (P2CharIndex == 0) 
				{
					CharAudio.PlayOneShot (Duck);
				}

				if (P2CharIndex == 1) 
				{
					CharAudio.PlayOneShot (Duck);
				}

				if (P2CharIndex == 2) 
				{
					CharAudio.PlayOneShot (Unicorn);
				}

				if (P2CharIndex == 3) 
				{
					CharAudio.PlayOneShot (Eagle);
				}

			}


			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed || Input.GetKeyDown (KeyCode.RightArrow) && P2OptionIndex == 0) 
			{
				Audio.PlayOneShot (Navigate);

				if (P2CharIndex < p2CharOptions.Length - 1) 
				{

					P2CharIndex++;

				} 
				else 
				{
					P2CharIndex = 0;
				}

			}



			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed || Input.GetKeyDown (KeyCode.LeftArrow) && P2OptionIndex == 0) 
			{
				Audio.PlayOneShot (Navigate);

				if (P2CharIndex >= 1) 
				{
					P2CharIndex--;


				} 
				else 
				{
					P2CharIndex = p2CharOptions.Length - 1;
				}

			}

			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed || Input.GetKeyDown (KeyCode.RightArrow) && P2OptionIndex == 1) 
			{
				Audio.PlayOneShot (Navigate);

				if (P2AbilityIndex < p2CharOptions.Length - 1) 
				{
					P2AbilityIndex++;
				} 
				else 
				{
					P2AbilityIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed || Input.GetKeyDown (KeyCode.LeftArrow) && P2OptionIndex == 1) 
			{
				Audio.PlayOneShot (Navigate);

				if (P2AbilityIndex >= 1) 
				{
					P2AbilityIndex--;
				} 
				else 
				{
					P2AbilityIndex = p2AbilityOptions.Length - 1;
				}

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed || Input.GetKeyDown (KeyCode.Z) && P2OptionIndex < p2TotalOptions) {

				P2OptionIndex++;


			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed || Input.GetKeyDown (KeyCode.Z) && P2OptionIndex == 2) {


				Audio.PlayOneShot (Confirm);

			}


			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed || Input.GetKeyDown (KeyCode.Z) && P2OptionIndex < TotalOptions && P2CharIndex == 4) {
				P2CharIndex = Random.Range (0, 4);


			}


			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed || Input.GetKeyDown (KeyCode.X)) {

				P2OptionIndex--;

			}

			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed || Input.GetKeyDown (KeyCode.X) && P2OptionIndex <= p2TotalOptions) {

				P2Ok = false;

			}


			if (P2OptionIndex == 0) {

				p2PlayerSelectBox.SetActive (true);
				p2PlayerAbilityBox.SetActive (false);

			}

			if (P2OptionIndex == 1) {

				p2PlayerAbilityBox.SetActive (true);
				p2PlayerSelectBox.SetActive (false);

			}

			if (P2OptionIndex == p2TotalOptions) {

				P2Ok = true;

			}

			if (P2OptionIndex == 2) {

				P2OK.SetActive (true);

			} else {

				P2OK.SetActive (false);

			}


		}





		if (P2Ok == true) 
		{

			SceneManager.LoadScene ("Game");

		}

	}

}

