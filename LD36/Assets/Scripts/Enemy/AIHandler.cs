using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AIHandler : MonoBehaviour {

	public int health = 100;
	public float speed = 10f;
	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float maxDistanceToThePlayer;
	public float damping;
	public bool doReturn = true;
	public float returnDistance;

	private Renderer renderer;
	private Transform player;
	private Vector3 initPos;
	private bool gogingBack = false;
    
	// Use this for initialization
    void Start () {
		this.renderer = GetComponent<Renderer>();
		this.player = GameObject.FindGameObjectWithTag("Player").transform;
		this.initPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

		//Check the health
		if(this.health <= 0) {
			Destroy(this.transform.gameObject);
		}
	}

	void FixedUpdate() {
		//Get the distance between a and b
		this.fpsTargetDistance = Vector3.Distance(this.player.position, transform.position);
		//Debug.Log(this.player.position);

		if (this.doReturn) {
			float distance = Vector3.Distance (transform.position, this.initPos);

			if (distance > this.returnDistance) {
				this.gogingBack = true;
				this.moveTo(this.initPos);
			}
		} 

		if(this.gogingBack) {

			if ( Vector3.Distance (transform.position, this.initPos) <= 10)
				this.gogingBack = false;
			this.moveTo(this.initPos);
		}

		//Check if is in distance, that the AI can se him
		if(this.fpsTargetDistance < this.enemyLookDistance) {
			//Debug.Log("Looks now at player!! RUN!!!! FOREST RUN!");
			this.renderer.material.color = Color.yellow;
			this.lookAtPlayer();
		}

		//Check if we can shoot at him
		if (this.fpsTargetDistance < this.attackDistance) {
			//Debug.Log ("SILENCE I KILL YOU!!!");

			if (this.fpsTargetDistance < maxDistanceToThePlayer) {
				this.shotAtPlayer();
			} else {
				this.moveTo(this.player.position);
			}
		} else {
			this.renderer.material.color = Color.red;
		}
	}

	public void hit() {
		this.health -= 10;
		Debug.Log(health.ToString());
	}

	private void lookAtPlayer() {
		Quaternion rotation = Quaternion.LookRotation(this.player.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	private void shotAtPlayer() {
		Debug.Log("Hit the player2");
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, 10)) {
			if(hit.transform.name == "Player") {
				Debug.DrawLine(transform.position, hit.point, Color.blue);
				hit.transform.GetComponent<PlayerController> ().takeDamge(5);
			}
		}
	}

	private void moveTo(Vector3 position) {
		Vector3 dir = position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
	}

}
