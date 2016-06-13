using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour {

	public float speed;
	//public Vector3 maxHeight;
	//public Vector3 minHeight;

	protected Rigidbody rb;



	// Use this for initialization
	void Start () 
	{
		rb= GetComponent<Rigidbody>();
		Vector2 vel = rb.velocity;
		int rand = Random.Range(0,2);
		if (rand==0)
		{
			vel.y = -speed;
		}
		else
			vel.y = speed;

		rb.velocity=vel;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(rb.transform.position.y>3.0f)
		{
			Vector2 vel = rb.velocity;
			vel.y = -speed;
			rb.velocity=vel;
		}

		if(rb.transform.position.y<0.1f)
		{
			Vector2 vel = rb.velocity;
			vel.y = speed;
			rb.velocity=vel;	
		}
	}
}
