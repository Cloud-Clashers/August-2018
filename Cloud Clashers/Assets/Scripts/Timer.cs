using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour 
{

	public float Overtimex = 500f;
	public float overtimey = -500f;
	public float startingtime = 5;
	public static float Timecounter;

	private TextMeshProUGUI theText;

	public GameObject Timerp1Round1Win;
	public GameObject Timerp1Round2Win;
	public GameObject Timerp2Round1Win;
	public GameObject Timerp2Round2Win;

	int p1score = ScoreManager.scoreP1;
	int p2score = ScoreManager.scoreP2;

	private ScoreManager scoremanager;
	//public GameObject ballcontroll;


	// Use this for initialization
	void Start () 
	{
		theText = GetComponent<TextMeshProUGUI> ();

		scoremanager = GetComponent<ScoreManager> ();

		Timecounter = startingtime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//var ballcontrollscript = ballcontroll.GetComponent<BallControl> ();

		int p1score = ScoreManager.scoreP1;
		int p2score = ScoreManager.scoreP2;

		Timecounter -= Time.deltaTime;

		theText.text = "" + Mathf.Round (Timecounter);

		Debug.Log ("p1score is " + p1score);
		Debug.Log ("p2score is " + p2score);

		if (Timecounter < 1 && ScoreManager.P1win1 == false) 
		{
			
			if (p1score > p2score && ScoreManager.P1win1 == false) 
			{

				Timerp1Round1Win.SetActive (true);

				ScoreManager.scoreP1 = 0;

				ScoreManager.scoreP2 = 0;

				ScoreManager.P1win1 = true;

				resetTime ();

			}

		}

		if (Timecounter < 1 && ScoreManager.P1win1 == true) 
		{
			
			if (p1score > p2score && ScoreManager.P1win1 == true) 
			{
				
				ScoreManager.P1win2 = true;

				SceneManager.LoadScene ("Main Menu");

				resetTime ();

			}
		}

		if (Timecounter < 1 && ScoreManager.P2win1 == false) 
		{
			
			if (p2score > p1score && ScoreManager.P2win1 == false) 
			{

				Timerp2Round1Win.SetActive (true);

				ScoreManager.scoreP1 = 0;

				ScoreManager.scoreP2 = 0;

				ScoreManager.P2win1 = true;

				resetTime ();

			}
		}

		if (Timecounter < 1 && ScoreManager.P2win1 == true) 
		{
			
			if (p2score > p1score && ScoreManager.P2win1 == true) 
			{

				ScoreManager.P2win2 = true;

				SceneManager.LoadScene ("Main Menu");

				resetTime ();

			}
		}

		if (Timecounter < 1) 
		{
			if (p2score == p1score) 
			{
				

				resetTime ();

			}
		}
				


	}



	public void resetTime ()
	{

		Timecounter = startingtime;

	}
}
