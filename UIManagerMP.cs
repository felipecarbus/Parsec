using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIManagerMP : MonoBehaviour {

	public Text textP1;
	public Text textP2;
	public GameManagerMP GameMng;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		textP1.text="Player 1| Distance |" + GameMng.distancePlayer1.ToString("F2") + "m";
		textP2.text="Player 2| Distance |" + GameMng.distancePlayer2.ToString("F2") + "m";
	}
}
