//by flaver
//Playercontroller
//It controls the player

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject playerObject;
	public float speed = 5f;
	public float turnSpeed = 40f;

	private BasicWeapon currentGun;

	// Use this for initialization
	void Start () {

		if (playerObject == null) {
			Debug.LogError("You forgett the player, dick ass!");
		}

		this.currentGun = new Shotgun();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			playerObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            playerObject.BroadcastMessage("StartMove");

        }

		if (Input.GetKey(KeyCode.DownArrow)) {
			playerObject.transform.Translate(Vector3.back * speed *  Time.deltaTime);
            playerObject.BroadcastMessage("StartMove");
        }

		if (Input.GetKey(KeyCode.LeftArrow)) {
			playerObject.transform.Rotate(Vector3.down * turnSpeed *  Time.deltaTime);
            // playerObject.BroadcastMessage("StartMove");
        }

		if (Input.GetKey(KeyCode.RightArrow)) {
			playerObject.transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
            // playerObject.BroadcastMessage("StartMove");
        }

		if (Input.GetKeyUp(KeyCode.Alpha1)) {
			this.currentGun = GetComponent<Gun>();
		}

		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			this.currentGun = GetComponent<Shotgun>();
		}

		if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerObject.BroadcastMessage("StopMove");
        }

		if (Input.GetKeyDown(KeyCode.Space)) {
			Vector3 fwd = playerObject.transform.TransformDirection(Vector3.forward) * 10;
			Debug.DrawRay(playerObject.transform.position, fwd, Color.red);
            playerObject.BroadcastMessage("shoot");
			playerObject.BroadcastMessage("StartShooting", this.currentGun);
        }
	}

	public BasicWeapon getSelectedGun() {
		return this.currentGun;
	}
}
