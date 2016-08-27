using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject currentGun;

	public void shoot() {
	
		RaycastHit hit;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Vector3 fwd = player.transform.TransformDirection(Vector3.forward);

		if(Physics.Raycast(player.transform.position, fwd, out hit, 10f)) {
			if(hit.transform.tag == "Enemy") {
				Debug.Log("Hit a enemy!");
				hit.transform.GetComponent<AIHandler>().hit();
			}
		}
	}
}
