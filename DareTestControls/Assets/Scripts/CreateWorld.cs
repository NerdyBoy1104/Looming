using UnityEngine;
using System.Collections;

public class CreateWorld : MonoBehaviour {

	public GameObject Balls;
	public int v_NumberToCreate;
	public int v_MaxDistance;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < v_NumberToCreate; i++) {
//			int randomNumber = Random.Range(1,16);
//			v_MaxDistance = Random.Range;
			Instantiate(Balls, new Vector3(Random.Range (-v_MaxDistance, v_MaxDistance), this.transform.position.y, Random.Range(-v_MaxDistance, v_MaxDistance)), Quaternion.identity);;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
