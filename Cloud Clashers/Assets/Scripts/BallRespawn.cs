using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour 
{

	public GameObject Ball;
	public GameObject Respawn;

	// Use this for initialization
	void Start () 
	{


		
	}
	
	// Update is called once per frame
	void Update () 
	{



	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ball") 
		{

			StartCoroutine (Goal());


		}
	}

	private IEnumerator Goal()
	{

		yield return new WaitForSecondsRealtime(2);

		Instantiate (Ball, Respawn.transform.position, Respawn.transform.rotation);

	}

}
