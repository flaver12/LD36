//by flaver
//Playercontroller
//It controls the player

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public GameObject playerObject;
	public float speed = 5f;
	public float turnSpeed = 40f;

	private BasicWeapon currentGun;
	private CharacterController controller;
	private int health = 100;
	private Text txt;

	// Use this for initialization
	void Start () {

		if (playerObject == null) {
			Debug.LogError("You forgett the player, dick ass!");
		}

		this.currentGun = new Shotgun();
		this.controller = GetComponent<CharacterController>();
		this.txt = GetComponent<Text>();

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
			playerObject.BroadcastMessage ("shoot", "Enemy");
			playerObject.BroadcastMessage ("StartShooting", this.currentGun);
		}
	}

	public BasicWeapon getSelectedGun() {
		return this.currentGun;
	}

	public void takeDamge(int amount) {
		if (this.health >= 0) {
			this.health -= amount;
		}
		Debug.Log (this.health.ToString());
		this.txt.text = "Health " + this.health;
	}

	public void heal(int amount) {
		this.health += amount;
		this.txt.text = "Health " + this.health;
	}
}
