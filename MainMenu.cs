using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnStartButton1Player()
	{
		Application.LoadLevel("1Player");
	}

	public void OnStartButton2Players()
	{
		Application.LoadLevel("2Players");
	}

	public void OnStartButtonTutorial()
	{
		Application.LoadLevel("tutorial");
	}
}