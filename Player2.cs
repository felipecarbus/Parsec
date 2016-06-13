using UnityEngine;
using System.Collections;

public class Player2 : Movement {
	
	public GameObject invencibleShield;
	public GameObject player1Emmiter;
	public float emmiterStandingPosition;
	public float emmiterCrouchPosition;
	ParticleSystem theParticle = new ParticleSystem();
	Color oldColor = new Color();
	
	public AudioSource sfx_jump;
	public AudioSource sfx_powerUp;
	public AudioSource sfx_vanish;

	public GameManager gameMNGMP;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		obj_collider = GetComponent<CapsuleCollider>();
		playerMaterial=GetComponent<Material>();
		
		isInvencible=false;
		theParticle = invencibleShield.GetComponent<ParticleSystem>();
		oldColor=theParticle.startColor;
		invencibleShield.SetActive(false);
	}
	
	void Update () 
	{
		
		rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,speed*Time.deltaTime);
		animator.SetFloat("Forward",1.0f);
		
		//slide
		if(Input.GetKey(KeyCode.L))
		{
			timer+=Time.deltaTime;
			if(timer>0.15f && !isJumping)
			{
				isSliding = true;
				animator.SetBool("Crouch",true);
				obj_collider.height=1.0f;
				obj_collider.center = new Vector3(0,0.55f,0);
				player1Emmiter.transform.position=new Vector3(player1Emmiter.transform.position.x,emmiterCrouchPosition,player1Emmiter.transform.position.z);
			}
		}

		//jump
		if(Input.GetKeyUp(KeyCode.L) && timer<0.15f && !isJumping)
		{
			sfx_jump.Play();
			isJumping=true;
			Jump();
			timer=0;
		}

		if(Input.GetKeyUp(KeyCode.L) && isSliding)
		{
			
			isSliding=false;
			timer=0;
			animator.SetBool("Crouch",false);
			animator.SetFloat("Forward",1.0f);
			obj_collider.height=1.6f;
			obj_collider.center = new Vector3(0,0.8f,0);
			player1Emmiter.transform.position=new Vector3(player1Emmiter.transform.position.x,emmiterStandingPosition,player1Emmiter.transform.position.z);
		}
		
		//code for chaning the prefabs
		if(Input.GetKeyUp(KeyCode.H))
		{
			for (int i = 0; i < level.objectsP1.Count; i++) 
			{
				if(level.objectsP1[i].gameObject.tag=="Wall")
				{
					GameObject oldObject = level.objectsP1[i].gameObject;
					//changes wall to Floating walls
					oldObject.tag="WallFloating";
					GameObject newObject = Instantiate(level.floatingWall,new Vector3(oldObject.transform.position.x,1.5f,oldObject.transform.position.z),oldObject.transform.rotation) as GameObject;
					Destroy(oldObject);
					//removes the object from the list
					level.objectsP1[i]=newObject;
				}
				else if(level.objectsP1[i].gameObject.tag=="WallFloating")
				{
					GameObject oldObject = level.objectsP1[i].gameObject;
					//changes wall to Floating walls
					oldObject.tag="Wall";
					GameObject newObject = Instantiate(level.wall,new Vector3(oldObject.transform.position.x,0.375f,oldObject.transform.position.z),oldObject.transform.rotation) as GameObject;
					Destroy(oldObject);
					//removes the object from the list
					level.objectsP1[i]=newObject;
				}
			}
		}
		
		
		//timer for the isInvencible powerUp
		if (isInvencible)
		{
			sfx_powerUp.Play();
			invencibleShield.SetActive(true);
			powerTimer+=Time.deltaTime;
			if (powerTimer>7.5)
			{
				print ("Quase la");
				theParticle.startColor=Color.white;
				
			}
			if (powerTimer>10)
			{
				print ("Times Up");
				powerTimer=0.0f;
				isInvencible=false;
				invencibleShield.SetActive(false);
				theParticle.startColor=oldColor;
				sfx_powerUp.Stop();
			}
		}
	}
	
	//check the collision with the wall
	void OnCollisionEnter(Collision col)
	{
		
		if (col.gameObject.tag == "Wall" || col.gameObject.tag =="WallMovingVert")
		{
			if (!isInvencible && !gameMNGMP.twoPlayers)
			{
				gameObject.SetActive(false);
				Application.LoadLevel("1Player");
			}
			else if(!isInvencible && gameMNGMP.twoPlayers)
			{
				gameObject.SetActive(false);
			}
			else
			{
				sfx_vanish.Play();
				col.gameObject.SetActive(false);
			}
			
		}
		if (col.gameObject.tag == "WallFloating" && isSliding!=true)
		{
			if (!isInvencible && !gameMNGMP.twoPlayers)
			{
				gameObject.SetActive(false);
				Application.LoadLevel("1Player");
			}
			else if(!isInvencible && gameMNGMP.twoPlayers)
			{
				gameObject.SetActive(false);
			}
			else
			{
				sfx_vanish.Play();
				col.gameObject.SetActive(false);
			}
		}
		
		
		if (col.gameObject.tag == "Floor")
		{
			animator.SetBool("isJumping",false);
			
			isJumping = false;
		}
		if(col.gameObject.tag=="Powerup")
		{
			theParticle.startColor=oldColor;
			isInvencible=true;
			powerTimer=0.0f;
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag=="ChangeHeightPowerUp")
		{
			ChangeHeight(level.objectsP1,false);
			Destroy(col.gameObject);

		}
	}
}
