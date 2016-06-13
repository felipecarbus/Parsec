using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIManager : MonoBehaviour {

	public Text distance;
	public Text maxDistance;
	public GameManagerSP GameMng;
	
	// Update is called once per frame
	void Update () 
	{
		distance.text="Distance | " + GameMng.distancePlayer1.ToString("F2") + "m";
		if (GameMng.oldMaxDistancePlayer1<GameMng.maxDistancePlayer1)
		{
			maxDistance.text="NEW! Max Distance | " + GameMng.maxDistancePlayer1.ToString("F2") + "m";
		}
		else if(GameMng.oldMaxDistancePlayer1==GameMng.maxDistancePlayer1)
			maxDistance.text="Max Distance | " + GameMng.maxDistancePlayer1.ToString("F2") + "m";
	}

	public void OnStartButton()
	{
		Application.LoadLevel("MainMenu");
	}
}
