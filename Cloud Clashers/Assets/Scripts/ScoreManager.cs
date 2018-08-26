using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public static int scoreP1;

	public static int scoreP2;

	public Text text;


	static public bool P1win1 = false;
	static public bool P1win2 = false;
	static public bool P2win1 = false;
	static public bool P2win2 = false;

	public GameObject P1Round1Win;
	public GameObject P1Round2Win;
	public GameObject P2Round1Win;
	public GameObject P2Round2Win;

	float time = Timer.Timecounter;


	// Use this for initialization
	void Start () 
	{
		text = GetComponent<Text>();


		scoreP1 = 0;

		scoreP2 = 0;


		P1win1 = false;
	 	P1win2 = false;
		P2win1 = false;
		P2win2 = false;


	}

	// Update is called once per frame
	void Update () 
	{

		text.text = "P1: " + scoreP1 + " P2: " + scoreP2 ;

		if (scoreP1 == 5 && P1win1 == false) 
		{
			Debug.Log ("Player 1 Wins");

			P1win1 = true;

			scoreP1 = 0;

			scoreP2 = 0;

			P1Round1Win.SetActive (true);
		}

		if (scoreP1 == 5 && P1win1 == true) 
		{
			Debug.Log ("Player 1 Wins");

			P1Round2Win.SetActive (true);

			SceneManager.LoadScene ("Main Menu");
		}



		if (scoreP2 == 5 && P2win1 == false) 
		{
			Debug.Log ("Player 2 Wins");

			P2win1 = true;

			scoreP1 = 0;

			scoreP2 = 0;

			P2Round1Win.SetActive (true);
		}

		if (scoreP2 == 5 && P2win1 == true) 
		{
			Debug.Log ("Player 2 Wins");

			P2Round2Win.SetActive (true);

			SceneManager.LoadScene ("Main Menu");
		}
			


	}
		
		
	public static void P1AddPoints (int pointsToAdd)
	{
		scoreP1 += pointsToAdd;
	}

	public static void P2AddPoints (int pointsToAdd)
	{
		scoreP2 += pointsToAdd;
	}
}
