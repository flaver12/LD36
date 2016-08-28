using UnityEngine;
using System.Collections;

public class BasicWeapon {

	public enum Type {SHOTGUN, GUN};

	protected int distance;
	protected Type type;

	public int getDistance (){
		return this.distance;
	}
		
	public Type getWeaponType() {
		return this.type;
	}
}

