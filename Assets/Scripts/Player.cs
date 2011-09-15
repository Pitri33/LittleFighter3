using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float worldGravity, jumpHight, movementSpeed, minSpeedToStop;
	public Vector3 velocities, gravities, frictions;
	
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		velocities += gravities;
		updateFrictions();
		checkInput();
	
		move(velocities);
		checkCollision();
	}
	
	
	void checkCollision()
	{
		if ( transform.position.y < 1.5f)
		{
			setPosition( transform.position.x, 1.5f, transform.position.z);
			velocities.y = 0.0f;
		}
	}
	
	void updateFrictions()
	{
		velocities.x *= frictions.x;
		velocities.y *= frictions.y;
		velocities.z *= frictions.z;
		
		if ( velocities.x < minSpeedToStop && velocities.x > -minSpeedToStop) velocities.x = 0.0f;
		//if ( velocities.y < minSpeedToStop && velocities.y > -minSpeedToStop) velocities.y = 0.0f;
		if ( velocities.z < minSpeedToStop && velocities.z > -minSpeedToStop) velocities.z = 0.0f;
	}
	
	void setPosition(float x, float y, float z)
	{
		transform.position = new Vector3( x, y, z);
	}
	
	//======================
	//  Movement Funktions
	//======================
	
	void move(float x, float y, float z)
	{
		transform.position = new Vector3( transform.position.x + x,transform.position.y + y,transform.position.z + z);
	}
	void move(Vector3 velocities)
	{
		transform.position = new Vector3( transform.position.x + velocities.x,
		                                 transform.position.y + velocities.y,
		                                 transform.position.z + velocities.z);
	}
	void moveX(float x)
	{
		transform.position = new Vector3( transform.position.x + x,transform.position.y,transform.position.z);
	}
	void moveY(float y)
	{
		transform.position = new Vector3( transform.position.x,transform.position.y + y,transform.position.z);
	}
	void moveZ(float z)
	{
		transform.position = new Vector3( transform.position.x, transform.position.y, transform.position.z + z);
	}
	
	//======================
	//  Input Funktions
	//======================
	
	void checkInput()
	{
		if ( Input.GetKeyDown(KeyCode.Space) ) velocities.y = jumpHight;
		if ( Input.GetKey(KeyCode.LeftArrow) ) velocities.x = -movementSpeed;
		if ( Input.GetKey(KeyCode.RightArrow) ) velocities.x = movementSpeed;
		if ( Input.GetKey(KeyCode.UpArrow) ) velocities.z = movementSpeed;
		if ( Input.GetKey(KeyCode.DownArrow) ) velocities.z = -movementSpeed;
	}
}