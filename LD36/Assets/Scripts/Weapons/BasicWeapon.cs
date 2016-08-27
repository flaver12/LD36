using UnityEngine;
using System.Collections;

public class BasicWeapon : MonoBehaviour {

	protected int distance;
	protected bool isShotgun;

	public int getDistance (){
		return this.distance;
	}

	public bool getIsShotgun() {
		return this.isShotgun;
	}

	public void fire() {
		GetComponent<Shoot>().shoot();
	}
		
}

