using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelController : MonoBehaviour {

	public GameObject wall;
	public GameObject floatingWall;
	public GameObject movingVerticalWall;

	public GameObject invenciblePowerUp;

	public float wall_offset;
	public float floatingWall_offset;
	public float movingVerticalWall_offset;
	public float invenciblePowerUp_offset;

	public int nmb_Walls_Max;

	public List<GameObject> objectsP1 = new List<GameObject>();
	protected List<GameObject> objectsP2 = new List<GameObject>();

	protected float nextSpot;
	protected float oldSpot=10.0f;
	protected int nmb_Walls;



	// Use this for initialization
	void Start () 
	{
		#region Player Level Creation
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

			if (powerUpChance>95)
			{
				float nextSpot = oldSpot+invenciblePowerUp_offset;
				Instantiate(invenciblePowerUp,new Vector3(-5,0.375f,nextSpot),wall.transform.rotation);
				oldSpot=nextSpot;
			}
			nmb_Walls++;
		}

		#endregion

	}

}
