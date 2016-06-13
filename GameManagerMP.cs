using UnityEngine;
using System.Collections;

public class GameManagerMP : GameManager {
	
	public GameObject player1;
	public float distancePlayer1;
	
	public GameObject player2;
	public float distancePlayer2;

	public GameObject cameraPos;

	public bool p1Lost=false;
	public bool p2Lost=false;

	public GameObject blueTron;
	public GameObject orangeTron;

	public float bikeSpawnTimer;
	public float triggerBikeSpawnTimer;
	private Vector3 spawnPos;

	// Use this for initialization
	void Start () 
	{
		twoPlayers=true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		distancePlayer1=player1.transform.position.z;
		distancePlayer2=player2.transform.position.z;

		//check if there are still players
		if (!player1.gameObject.activeSelf && !player2.gameObject.activeSelf)
		{
			Application.LoadLevel("2Players");
		}

		if (!player1.gameObject.activeSelf && !p1Lost)
		{
			p1Lost=true;
			print("P1 Lost");
		}
		if (!player2.gameObject.activeSelf && !p2Lost)
		{
			p2Lost=true;
			print("P2 Lost");
		}

		bikeSpawnTimer+=Time.deltaTime;
		
		if (bikeSpawnTimer>triggerBikeSpawnTimer)
		{
			int randomSpawn = Random.Range(0,4);
			int randomSpawnPoint = Random.Range(0,2);
			
			if (randomSpawnPoint==0)
			{
				spawnPos= new Vector3(-10,0,cameraPos.transform.position.z-10);
			}
			else if (randomSpawnPoint==1)
			{
				spawnPos= new Vector3(5,0,cameraPos.transform.position.z-10);
			}
			
			if (randomSpawn>1)
			{
				int randomBike = Random.Range(0,2);
				if (randomBike==0)
				{
					Instantiate(blueTron,spawnPos,blueTron.transform.rotation);
				}
				else if (randomBike==1)
				{
					Instantiate(orangeTron,spawnPos,orangeTron.transform.rotation);
				}
			}
			bikeSpawnTimer=0.0f;
			
		}
	}
}
