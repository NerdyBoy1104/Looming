using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField] private Camera cam;

	public PlayerStats StatsSctipt;
	public PlayerInput PlayerInputScript;
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;


	// Use this for initialization
	void Start () 
	{
		StatsSctipt = this.GetComponent<PlayerStats>();
		PlayerInputScript = this.GetComponent<PlayerInput>();
	}
	
	public void Move(Vector3 _velocity)
	{
		velocity = _velocity;
	}

	public void Rotate(Vector3 _rotation)
	{
		rotation = _rotation;
	}

	public void RotateCamera(Vector3 _cameraRotation)
	{
		cameraRotation = _cameraRotation;
	}
	
	void Update ()
	{

	}

	void FixedUpdate ()
	{
		AnimationPlayer();

		if (!StatsSctipt.Attacking) {
			PerformMovement ();
		}

		if (Input.GetMouseButton (1) && !StatsSctipt.Attacking) {
			PerformRotation ();
		}
	}

	void PerformMovement ()
	{
		if (velocity != Vector3.zero) {
			StatsSctipt.PlayerRig.MovePosition (transform.position + velocity * Time.deltaTime);
		} 
	}

	void PerformRotation()
	{
		StatsSctipt.PlayerRig.MoveRotation (StatsSctipt.PlayerRig.rotation * Quaternion.Euler(rotation));
		if (cam != null) {
			cam.transform.Rotate(cameraRotation);
		}
	}

	void AnimationPlayer()
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			StatsSctipt.PlayerAnimator.SetFloat ("MoveSpeed", PlayerInputScript.speed);
		}
		else 
		{
			StatsSctipt.PlayerAnimator.SetFloat ("MoveSpeed", 0);
		}

	}
}