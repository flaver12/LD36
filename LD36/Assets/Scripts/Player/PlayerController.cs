//by flaver
//Playercontroller
//It controls the player

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject playerObject;
	public float speed = 5f;
	public float turnSpeed = 40f;
	public BasicWeapon currentGun;

	// Use this for initialization
	void Start () {

		if (playerObject == null) {
			Debug.LogError("You forgett the player, dick ass!");
		}

		this.currentGun = GetComponent<Shotgun>();

		if (this.currentGun == null) {
			Debug.Log("FUCK!");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			playerObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            playerObject.SendMessage("StartMove");

        }

		if (Input.GetKey(KeyCode.DownArrow)) {
			playerObject.transform.Translate(Vector3.back * speed *  Time.deltaTime);
            playerObject.SendMessage("StartMove");
        }

		if (Input.GetKey(KeyCode.LeftArrow)) {
			playerObject.transform.Rotate(Vector3.down * turnSpeed *  Time.deltaTime, Space.World);
            playerObject.SendMessage("StartMove");
        }

		if (Input.GetKey(KeyCode.RightArrow)) {
			playerObject.transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime, Space.World);
            playerObject.SendMessage("StartMove");
        }

		if (Input.GetKeyUp(KeyCode.Alpha1)) {
			this.currentGun = GetComponent<Gun>();
		}

		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			this.currentGun = GetComponent<Shotgun>();
		}

		if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerObject.SendMessage("StopMove");
        }

		if (Input.GetKeyDown(KeyCode.Space)) {
			Vector3 fwd = playerObject.transform.TransformDirection(Vector3.forward) * 10;
			Debug.DrawRay(playerObject.transform.position, fwd, Color.red);
			this.currentGun.fire();

        }
	}
}
