using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public int health = 100;
	public GameObject enemy;
	public GameObject player;

	// Use this for initialization
	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.health <= 0) {
			Destroy(enemy);
		}
	}

	public void hit() {
		this.health -= 10;
		Debug.Log(health.ToString());
	}
}
