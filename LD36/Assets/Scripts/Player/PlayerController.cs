﻿//by flaver
//Playercontroller
//It controls the player

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject playerObject;
	public float speed = 5f;
	public float turnSpeed = 20f;

	// Use this for initialization
	void Start () {

		if (playerObject == null) {
			Debug.LogError("You forgett the player, dick ass!");
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
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            playerObject.SendMessage("StopMove");
        }

		if (Input.GetKeyDown(KeyCode.Space)) {
			Vector3 fwd = playerObject.transform.TransformDirection(Vector3.forward) * 10;
			Debug.DrawRay(playerObject.transform.position, fwd, Color.red);
			//playerObject.GetComponent<Shoot>().shoot();
            playerObject.SendMessage("shoot");

        }
	}
}
