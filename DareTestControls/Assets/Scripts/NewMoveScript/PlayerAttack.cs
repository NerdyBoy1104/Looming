using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public PlayerStats StatsSctipt;
	 
//	public Collider SwordCollider; 



	// Use this for initialization
	void Start () {
		StatsSctipt = this.GetComponent<PlayerStats>();
//		SwordCollider = GameObject.Find ("SwordCollider").GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && StatsSctipt.MoveSpeed == 0 &&StatsSctipt.PlayerAnimator.GetBool("Attacking") == false) {
			Attack();
		}
	}

	void Attack (){
		StatsSctipt.Attacking = true;
		StatsSctipt.PlayerAnimator.SetBool("Attacking", StatsSctipt.Attacking);
	}

	void Idle (){ // Playes at the end of animation (Animation event)
		StatsSctipt.Attacking = false;
		StatsSctipt.PlayerAnimator.SetBool("Attacking", StatsSctipt.Attacking);
	}

//	void OnCollisionEnter(Collision collision){
//		if (collision.collider.name == "SwordCollider") {
//			print ("HIT");
//			//Deal Damge here 
////			Enemy_CurrentHealth -= collision.gameObject.GetComponentInParent<StatsSctipt>().AttackPower; //Cant get to work
//		}
//	}
}
