using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BacktoMain : MonoBehaviour 
{

	private TextMeshProUGUI theText;

	public float Timer;

	// Use this for initialization
	void Start () 
	{
		theText = GetComponent<TextMeshProUGUI> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetButton ("P1B")) 
		{

			Timer += Time.deltaTime;
			theText.text = "" + Mathf.Round (Timer);
			if (Timer >= 3) 
			{

				SceneManager.LoadScene ("Main Menu");

			}




		} 

		if (!Input.GetButton ("P1B")) 
		{

			if (Timer == 1) 
			{
				Timer = 0;
			}

			if (Timer == 2) 
			{
				Timer = 0;
			}

			if (Timer == 3) 
			{
				Timer = 0;
			}


		} 



	}
}
