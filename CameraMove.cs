using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	Rigidbody rb;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,speed*Time.deltaTime);
	}
}
