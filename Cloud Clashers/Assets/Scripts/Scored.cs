using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scored : MonoBehaviour 
{
	private int pointstoadd = 1;

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Ball" && gameObject.tag == "Goal2") 
		{
			Debug.Log ("Player 1 Scored!!!!");

			ScoreManager.P1AddPoints (pointstoadd);

		}


		if (other.gameObject.tag == "Ball" && gameObject.tag == "Goal1") 
		{
			Debug.Log ("Player 2 Scored!!!!");

			ScoreManager.P2AddPoints (pointstoadd);
		}


	}
}
