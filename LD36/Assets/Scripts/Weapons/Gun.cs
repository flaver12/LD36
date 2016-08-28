using UnityEngine;
using System.Collections;

public class Gun : BasicWeapon {

	// Use this for initialization
	public Gun () {
		this.distance = 20;
		this.type = BasicWeapon.Type.GUN;
	}

}
