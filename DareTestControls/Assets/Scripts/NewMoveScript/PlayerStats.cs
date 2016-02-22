using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour  {
 

	public GameObject Player;
	public Rigidbody PlayerRig;
	public Animator PlayerAnimator;

	public int CurrentLevel;
	public int MaxLevel = 5;
	public int CurrentHealth;
	public int MaxHealth = 100;
	public int CurrentExp;
	public int MaxExp = 100;	
	
	public float MoveSpeed;
	public float WalkSpeed = 2;
	public float RunSpeed = 5;

	public bool Attacking;
	public int AttackPower;

	// Use this for initialization
	void Awake () {
		Player = this.gameObject;
		PlayerRig = this.GetComponent<Rigidbody> ();
		PlayerAnimator = this.GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentExp == MaxExp && CurrentLevel != MaxLevel) {
			LevelUp ();
		}
	}

	void LevelUp (){
		//Up Health
		MaxHealth = MaxHealth + 10; 
		CurrentHealth = MaxHealth; 

		//Up Exp
		CurrentExp = 0; 
		MaxExp = MaxExp + 50;

		//Up Level
		CurrentLevel++; 

		//Up Attack
		AttackPower ++;

	}
}
