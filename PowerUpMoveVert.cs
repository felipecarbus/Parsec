using UnityEngine;
using System.Collections;

public class PowerUpMoveVert : MonoBehaviour {
	
	public float speed;
	public float maxHeight;
	public float minHeight;
	
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
		if(rb.transform.position.y>maxHeight)
		{
			Vector2 vel = rb.velocity;
			vel.y = -speed;
			rb.velocity=vel;
		}
		
		if(rb.transform.position.y<minHeight)
		{
			Vector2 vel = rb.velocity;
			vel.y = speed;
			rb.velocity=vel;	
		}
	}
}