using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelControllerMP : LevelController 
{

	public GameObject wall2P;
	public GameObject floatingWall2P;
	public GameObject movingVerticalWall2P;
	
	public GameObject changeHeightPowerUp;
	
	public List<GameObject> objectsP2 = new List<GameObject>();

	int nmb_Walls2;

	// Use this for initialization
	void Start () 
	{

		#region First Player Level Creation
		while (nmb_Walls<100)
		{
			int typeOfWall = Random.Range(0,3);
			int powerUpChance = Random.Range(0,100);
			
			if (typeOfWall==0) 
			{
				float nextSpot = oldSpot+wall_offset;
				GameObject newWall = Instantiate(wall,new Vector3(-5,0.375f,nextSpot),wall.transform.rotation) as GameObject;
				
				objectsP1.Add(newWall);
				oldSpot=nextSpot;
			}
			else if (typeOfWall==1) 
			{
				float nextSpot = oldSpot+floatingWall_offset;
				
				GameObject newFloatingWall=Instantiate(floatingWall,new Vector3(-5,1.5f,nextSpot),floatingWall.transform.rotation) as GameObject;
				oldSpot=nextSpot;
				
				objectsP1.Add(newFloatingWall);
			}
			else if (typeOfWall==2) 
			{
				float nextSpot = oldSpot+movingVerticalWall_offset;
				
				GameObject newMovingVerticalWall=Instantiate(movingVerticalWall,new Vector3(-5,Random.Range (0.2f,3.2f),nextSpot),movingVerticalWall.transform.rotation) as GameObject;
				oldSpot=nextSpot;
				objectsP1.Add(newMovingVerticalWall);
			}
			
			if (powerUpChance>90)
			{
				GameObject powerUp=null;

				int typeOfPowerUp = Random.Range(0,2);

				if (typeOfPowerUp==0)
					powerUp=invenciblePowerUp;
				if(typeOfPowerUp==1)
					powerUp=changeHeightPowerUp;

				float nextSpot = oldSpot+invenciblePowerUp_offset;

				Instantiate(powerUp,new Vector3(-5,0.375f,nextSpot),powerUp.transform.rotation);
				oldSpot=nextSpot;
			}
			nmb_Walls++;
		}
		
		#endregion
		
		#region Second Player Level Creation
		oldSpot=10.0f;
		nmb_Walls=0;

		while (nmb_Walls<100)
		{
				int typeOfWall = Random.Range(0,3);
				int powerUpChance = Random.Range(0,100);
				
				if (typeOfWall==0) 
				{
					float nextSpot = oldSpot+wall_offset;
					GameObject newWall = Instantiate(wall2P,new Vector3(0,0.375f,nextSpot),wall.transform.rotation) as GameObject;
					
					objectsP2.Add(newWall);
					oldSpot=nextSpot;
				}
				else if (typeOfWall==1) 
				{
					float nextSpot = oldSpot+floatingWall_offset;
					
					GameObject newFloatingWall=Instantiate(floatingWall2P,new Vector3(0,1.5f,nextSpot),floatingWall.transform.rotation) as GameObject;
					oldSpot=nextSpot;
					
					objectsP2.Add(newFloatingWall);
				}
				else if (typeOfWall==2) 
				{
					float nextSpot = oldSpot+movingVerticalWall_offset;
					
					GameObject newMovingVerticalWall=Instantiate(movingVerticalWall2P,new Vector3(0,Random.Range (0.2f,3.2f),nextSpot),movingVerticalWall.transform.rotation) as GameObject;
					oldSpot=nextSpot;
					objectsP2.Add(newMovingVerticalWall);
				}
				
				if (powerUpChance>90)
				{
					GameObject powerUp=null;
					
					int typeOfPowerUp = Random.Range(0,2);
					if (typeOfPowerUp==0)
						powerUp=invenciblePowerUp;
					if(typeOfPowerUp==1)
						powerUp=changeHeightPowerUp;
					
					float nextSpot = oldSpot+invenciblePowerUp_offset;
					
					Instantiate(powerUp,new Vector3(0,0.375f,nextSpot),powerUp.transform.rotation);
					oldSpot=nextSpot;
				}
				nmb_Walls++;
		}

		#endregion
	}
}
	

