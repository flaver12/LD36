using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public void shoot() {
	
		RaycastHit hit;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Vector3 fwd = player.transform.TransformDirection(Vector3.forward);

		if(Physics.Raycast(player.transform.position, fwd, out hit, player.GetComponent<PlayerController>().currentGun.getDistance())) {
			if(hit.transform.tag == "Enemy") {
				Debug.Log("Hit a enemy! in " + player.GetComponent<PlayerController>().currentGun.getDistance());
				hit.transform.GetComponent<AIHandler>().hit();
			}
		}
	}
}
