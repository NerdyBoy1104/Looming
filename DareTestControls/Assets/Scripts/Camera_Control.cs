using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Camera_Control : MonoBehaviour {
//  ***********************************************************************************
	// THIS IS HOW YOU SET VARIABULES!!!
	public GameObject go_Target;
	public LayerMask goc_Mask;

	public RaycastHit v_Raycasthit;

	private Transform m_Cam;  // A reference to the main camera in the scenes transform 

	public Vector3 v_Rot; //For Camera locking

	public float v_MouseSpeed;

	public float v_ClampMinY;
	public float v_ClampMaxY;
	public float v_ClampMinX;
	public float v_ClampMaxX;



	void Start () 
	{
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}

		v_Rot = transform.eulerAngles;

		go_Target = GameObject.Find ("ThirdPersonController");

	}
	
	// Update is called once per frame
	void Update () 
	{
		Raycast ();
		transform.position = go_Target.transform.position; // Sets this object to be in the same place as the target

//	[Not In Use]	v_Rot.x = Mathf.Clamp (v_Rot.x + CrossPlatformInputManager.GetAxis ("Mouse Y") * v_MouseSpeed, v_ClampMinY, v_ClampMaxY);
//	[Not In Use]	v_Rot.y = Mathf.Clamp (v_Rot.y + CrossPlatformInputManager.GetAxis ("Mouse X") * v_MouseSpeed, v_ClampMinX, v_ClampMaxX);

		v_Rot.x = Mathf.Clamp (v_Rot.x + Input.GetAxis ("JoyPadVert") * v_MouseSpeed, v_ClampMinY, v_ClampMaxY);
		v_Rot.y = v_Rot.y + Input.GetAxis ("JoyPadHoriz") * v_MouseSpeed;

		transform.eulerAngles = v_Rot;

		if (Input.GetMouseButton(1)) //Onlt runs when 
		{
			v_Rot.x = Mathf.Clamp (v_Rot.x + CrossPlatformInputManager.GetAxis ("Mouse Y") * v_MouseSpeed, v_ClampMinY, v_ClampMaxY);
//	[Not In Use]	v_Rot.y = Mathf.Clamp (v_Rot.y + CrossPlatformInputManager.GetAxis ("Mouse X") * v_MouseSpeed, v_ClampMinX, v_ClampMaxX);
			v_Rot.y = v_Rot.y + CrossPlatformInputManager.GetAxis ("Mouse X") * v_MouseSpeed;
			
			transform.eulerAngles = v_Rot;
		}

	}

	void Raycast (){

//		Vector3 fwd = transform.TransformPoint(Vector3.forward);
		Vector3 fwd = go_Target.transform.position - Camera.main.transform.position;
		

		if (Physics.Raycast (Camera.main.transform.position, fwd,out v_Raycasthit,100,goc_Mask))
		{
//			Debug.Log(v_Raycasthit.collider.name);
			Debug.DrawRay(Camera.main.transform.position,fwd,Color.red);
			if(v_Raycasthit.collider.name != "ThirdPersonController")
			{
//				v_Raycasthit.collider.gameObject.GetComponent(Renderer).
				print ("NotPlayer");
//				v_Raycasthit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", 0.1f);
			}
			else
			{
				print ("Player");

			}
		}
	}


// DONT LEAVE THIS
}