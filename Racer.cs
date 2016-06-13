using UnityEngine;
using System.Collections;

public class Racer : MonoBehaviour {

	public GameObject tronBike;
	Player1 player;
	public float speed;
	float deathTimer;
	public float deathTimerLimit;
	public AudioSource bike;
	public float maxDistance;

	bool updateSound;
	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<Player1>();
		updateSound=true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		tronBike.transform.position+=new Vector3(0,0,speed);

		deathTimer+=Time.deltaTime;
		if (deathTimer>deathTimerLimit)
		{
			Destroy(tronBike);
		}
		/*
		if (updateSound)
		{
		
		float distance=player.transform.position.z- tronBike.transform.position.z;
		distance=Mathf.Abs(distance);
		print("Something " + Mathf.Clamp (distance,0,1));
		bike.volume=Mathf.Abs(distance-10)/10;
		if (distance>maxDistance)
		{
			updateSound=false;	
			bike.volume=0;
		}
		}
		*/
	}
}
