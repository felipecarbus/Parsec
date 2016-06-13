using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {


	public float jumpHeight;
	public float speed;
	public float boostSpeed;

	protected float timer;
	protected float powerTimer;
	protected bool isGrounded = true;
	protected bool isSliding=false;
	protected bool isJumping=true;
	protected bool isBoosting=false;

	protected CapsuleCollider obj_collider;
	protected Rigidbody rb;
	protected Animator animator;
	protected Material playerMaterial;

	public LevelControllerMP level;

	protected bool isInvencible;
	protected int nmbPress;

	private float hitRaycastLength = 0.05f;
	private float rayCastOffset = 0.5f;
	GameObject newObject;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.G))
		{
			for (int i = 0; i < level.objectsP1.Count; i++) 
			{
				level.objectsP1[i].transform.position=new Vector3(-level.objectsP1[i].transform.position.x,level.objectsP1[i].transform.position.y,level.objectsP1[i].transform.position.z);
			}

			for (int i = 0; i < level.objectsP2.Count; i++) 
			{
				level.objectsP2[i].transform.position=new Vector3(-level.objectsP2[i].transform.position.x,level.objectsP2[i].transform.position.y,level.objectsP2[i].transform.position.z);
			}
		}
	}

	protected void Jump()
	{
		//grab the velocity of the rigid body
		//Vector2 vel = rb.velocity;
		//set the y velocitiy to the jumpHeight
		//vel.y = jumpHeight;
		//finally set the velocity to the new value of vel;
		rb.velocity+=new Vector3(0,jumpHeight,0);
		animator.SetBool("isJumping",true);
	}	

	public void ChangeHeight(List<GameObject> objectPlayer, bool player1)
	{
		for (int i = 0; i < objectPlayer.Count; i++) 
		{
			if(objectPlayer[i].gameObject.tag=="Wall")
			{
				GameObject oldObject = objectPlayer[i].gameObject;
				//changes wall to Floating walls
				oldObject.tag="WallFloating";
				//player 1 transforming player 2 walls
				if (player1)
					newObject = Instantiate(level.floatingWall2P,new Vector3(oldObject.transform.position.x,1.5f,oldObject.transform.position.z),oldObject.transform.rotation) as GameObject;
				//player 2 transforming player 1 walls
				if (!player1)
					newObject = Instantiate(level.floatingWall,new Vector3(oldObject.transform.position.x,1.5f,oldObject.transform.position.z),oldObject.transform.rotation) as GameObject;

				Destroy(oldObject);
				//removes the object from the list
				objectPlayer[i]=newObject;
			}
			else if(objectPlayer[i].gameObject.tag=="WallFloating")
			{
				GameObject oldObject = objectPlayer[i].gameObject;
				//changes wall to Floating walls
				oldObject.tag="Wall";
				//player 1 transforming player 2 walls
				if (player1)
				newObject = Instantiate(level.wall2P,new Vector3(oldObject.transform.position.x,0.375f,oldObject.transform.position.z),oldObject.transform.rotation) as GameObject;
				//player 2 transforming player 1 walls
				if (!player1)
				newObject = Instantiate(level.wall,new Vector3(oldObject.transform.position.x,0.375f,oldObject.transform.position.z),oldObject.transform.rotation) as GameObject;
				Destroy(oldObject);
				//removes the object from the list
				objectPlayer[i]=newObject;
			}
		}
	}
}
