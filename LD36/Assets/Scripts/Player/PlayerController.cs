//by flaver
//Playercontroller
//It controls the player

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public GameObject playerObject;
	public float speed = 5f;
	public float turnSpeed = 40f;

	private BasicWeapon currentGun;
	private CharacterController controller;

	// Use this for initialization
	void Start () {

		if (playerObject == null) {
			Debug.LogError("You forgett the player, dick ass!");
		}

		this.currentGun = new Shotgun();
		this.controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			//this.controller.SimpleMove(Vector3.forward * speed);
			playerObject.transform.Translate (Vector3.forward * speed * Time.deltaTime);
			playerObject.BroadcastMessage ("StartMove");
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			//this.controller.SimpleMove(Vector3.back * speed);
			playerObject.transform.Translate (Vector3.back * speed * Time.deltaTime);
			playerObject.BroadcastMessage ("StartMove");
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			playerObject.transform.Rotate (Vector3.down * turnSpeed * Time.deltaTime);
			// playerObject.BroadcastMessage("StartMove");
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			playerObject.transform.Rotate (Vector3.up * turnSpeed * Time.deltaTime);
			// playerObject.BroadcastMessage("StartMove");
		}

		if (Input.GetKeyUp (KeyCode.Alpha1)) {

			if (this.currentGun.getWeaponType () != BasicWeapon.Type.GUN) {
				this.currentGun = new Gun ();
				GameObjectHelper.FindObject(playerObject, "Shotgun").SetActive (false);
				GameObjectHelper.FindObject(playerObject, "Pistol").SetActive(true);
			}
		}

		if (Input.GetKeyUp (KeyCode.Alpha2)) {

			if (this.currentGun.getWeaponType () != BasicWeapon.Type.SHOTGUN) {
				this.currentGun = new Shotgun ();
				GameObjectHelper.FindObject(playerObject, "Pistol").SetActive (false);
				GameObjectHelper.FindObject(playerObject, "Shotgun").SetActive(true);
			}
		}

		if (Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.UpArrow)) {
			playerObject.BroadcastMessage ("StopMove");
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 fwd = playerObject.transform.TransformDirection (Vector3.forward) * 10;
			Debug.DrawRay (playerObject.transform.position, fwd, Color.red);
			playerObject.BroadcastMessage ("shoot");
			playerObject.BroadcastMessage ("StartShooting", this.currentGun);
		}
	}

	public BasicWeapon getSelectedGun() {
		return this.currentGun;
	}
}
