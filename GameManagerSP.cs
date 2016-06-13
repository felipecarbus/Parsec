using UnityEngine;
using System.Collections;

public class GameManagerSP : GameManager {

	public GameObject player1;
	public float distancePlayer1;
	public float maxDistancePlayer1;
	public float oldMaxDistancePlayer1;

	public GameObject blueTron;
	public GameObject orangeTron;

	public float bikeSpawnTimer;
	public float triggerBikeSpawnTimer;

	private Vector3 spawnPos;
	// Use this for initialization
	void Start () 
	{
		twoPlayers=false;
		oldMaxDistancePlayer1= PlayerPrefs.GetFloat("Old Distance",0);
		maxDistancePlayer1 = PlayerPrefs.GetFloat("Distance",0);
		print ("MaxDistance " + maxDistancePlayer1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		distancePlayer1=player1.transform.position.z;

		if (player1.activeInHierarchy==false)
		{
			oldMaxDistancePlayer1 = maxDistancePlayer1;
			if (maxDistancePlayer1<distancePlayer1)
			{
				PlayerPrefs.SetFloat("Distance",distancePlayer1);
			}
			PlayerPrefs.SetFloat("Old Distance",oldMaxDistancePlayer1);
			PlayerPrefs.Save();
		}

		bikeSpawnTimer+=Time.deltaTime;

		if (bikeSpawnTimer>triggerBikeSpawnTimer)
		{
			int randomSpawn = Random.Range(0,4);
			int randomSpawnPoint = Random.Range(0,2);

			if (randomSpawnPoint==0)
			{
				spawnPos= new Vector3(-10,0,player1.transform.position.z-10);
			}
			else if (randomSpawnPoint==1)
			{
				spawnPos= new Vector3(0,0,player1.transform.position.z-10);
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
