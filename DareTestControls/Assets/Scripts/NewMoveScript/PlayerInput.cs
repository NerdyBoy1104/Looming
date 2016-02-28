using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerInput : MonoBehaviour {

	public float speed;
	private float walkSpeed = 2f;
	private float runSpeed = 5f;
	[SerializeField] private float sentitive = 3f;
	

	private PlayerMotor motor;

	void Start ()
	{
		motor = GetComponent<PlayerMotor> ();
	}

	void Update ()
	{
		IsRunning ();
		BasicInput ();
	}

	void BasicInput ()
	{
		//Calculate movement velocity as a 3D vector *************************
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMov = Input.GetAxisRaw("Vertical");
		
		Vector3 _moveHorizontal = transform.right * _xMov;
		Vector3 _moveVertical = transform.forward * _zMov;
		
		//Final movement vector
		Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;
		
		//Apply rotation
		motor.Move (_velocity);
		
		//Calc Rotation as 3D vector (turning aroung)*****************
		float _yRot = Input.GetAxisRaw ("Mouse X");
		
		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * sentitive;
		
		//Apply rotaion
		motor.Rotate (_rotation);
		
		//Calc Rotation as 3D vector (Looking up)*************************
		float _xRot = Input.GetAxisRaw ("Mouse Y");
		
		Vector3 _cameraRotation = new Vector3 (_xRot, 0f, 0f) * sentitive;
		
		motor.RotateCamera (_cameraRotation);
	}

	void IsRunning ()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			speed = runSpeed;
		}
		else
		{
			speed = walkSpeed;
		}
	}
}
