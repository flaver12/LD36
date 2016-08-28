using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public void shoot() {
	
		RaycastHit hit;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		PlayerController pc = player.GetComponent<PlayerController> ();
		Vector3 fwd = player.transform.TransformDirection(Vector3.forward);

		if(Physics.Raycast(player.transform.position, fwd, out hit, pc.getSelectedGun().getDistance())) {
			Debug.Log (hit.transform.tag);
			if(hit.transform.tag == "Enemy") {
				Debug.Log("Hit a enemy! in " + pc.getSelectedGun().getDistance());
				hit.transform.GetComponent<AIHandler>().hit();
			}
		}
	}
}
